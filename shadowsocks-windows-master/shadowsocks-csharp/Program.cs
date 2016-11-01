using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

using Shadowsocks.Controller;
using Shadowsocks.Util;
using Shadowsocks.View;
using Shadowsocks.Model;
using System.Collections.Generic;
using GoogleSearchApplication;
using Shadowsocks.Controller.Service;

namespace Shadowsocks
{
    static class Program
    {
        private static ShadowsocksController _controller;
        // XXX: Don't change this name
        private static MenuViewController _viewController;

        public static void LoadBimtProxySetting() {
            BimtProxyService<ShadowSocksEntity> bps = new BimtProxyService<ShadowSocksEntity>(ShadowSocksEntity.URL);
            Configuration cfg = Configuration.Load();
            Random ro = new Random();
            cfg.localPort = ro.Next(5000, 65534);
            //"strategy" : "com.shadowsocks.strategy.ha"
            cfg.strategy = "com.shadowsocks.strategy.ha";
            List<param> list = bps.Entity.GetParams();
            cfg.configs.Clear();
            foreach (var item in list)
            {
                Server server = new Server();
                server.auth = false;
                server.method = "aes-256-cfb";
                server.server = item.server;
                server.password = item.password;
                server.server_port = int.Parse(item.server_port);
                server.timeout = 6;
                cfg.configs.Add(server);
            }
            Configuration.Save(cfg);
        }

        public static bool StartProcess(string filename, string[] args)
        {
            try
            {
                string s = "";
                foreach (string arg in args)
                {
                    s = s + arg + " ";
                }
                s = s.Trim();
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(filename, s);
                myprocess.StartInfo = startInfo;

                //通过以下参数可以控制exe的启动方式，具体参照 myprocess.StartInfo.下面的参数，如以无界面方式启动exe等
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动应用程序时出错！原因：" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            BimtRemoting.RegeistChanel();
            bool ok = true;
            //Utils.IsVip(ref ok, args);
            //if (!ok)
            //{
            //    return;
            //}
            LoadBimtProxySetting();
            // Check OS since we are using dual-mode socket
            //为了xp拼了
            if (!Utils.IsWinVistaOrHigher())
            {
                MessageBox.Show(I18N.GetString("Unsupported operating system, use Windows Vista at least."),
                "Shadowsocks Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //BimtProxyService<ProxyEntity> proxy = new BimtProxyService<ProxyEntity>(ProxyEntity.URL);
                //proxy.Entity.StartUp();
                //BIMTClassLibrary.frmGoogleSearch frm = new BIMTClassLibrary.frmGoogleSearch();
                //frm.Show();
                //Application.Run();
            }
            else
            {
                Utils.ReleaseMemory(true);
                using (Mutex mutex = new Mutex(false, $"Global\\Shadowsocks_{Application.StartupPath.GetHashCode()}"))
                {
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    // handle UI exceptions
                    Application.ThreadException += Application_ThreadException;
                    // handle non-UI exceptions
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    Application.ApplicationExit += Application_ApplicationExit;
                    SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if (!mutex.WaitOne(0, false))
                    {
                        Process[] oldProcesses = Process.GetProcessesByName("Shadowsocks");
                        if (oldProcesses.Length > 0)
                        {
                            Process oldProcess = oldProcesses[0];
                        }
                        MessageBox.Show(I18N.GetString("Find Shadowsocks icon in your notify tray.")
                            + Environment.NewLine
                            + I18N.GetString("If you want to start multiple Shadowsocks, make a copy in another directory."),
                            I18N.GetString("Shadowsocks is already running."));
                        return;
                    }
                    Directory.SetCurrentDirectory(Application.StartupPath);
#if DEBUG
                    Logging.OpenLogFile();

                    // truncate privoxy log file while debugging
                    string privoxyLogFilename = Utils.GetTempPath("privoxy.log");
                    if (File.Exists(privoxyLogFilename))
                        using (new FileStream(privoxyLogFilename, FileMode.Truncate)) { }
#else
                Logging.OpenLogFile();
#endif
                    _controller = new ShadowsocksController();
                    _viewController = new MenuViewController(_controller);
                    HotKeys.Init();
                    _controller.Start();
                    string path = string.Format("{0}\\SmartReader.View.exe", Application.StartupPath);
                    string[] arg = new string[2];
                    //arg[0] = User.GetInstance().IsVip().ToString();
                    //arg[1] = User.GetInstance().Id;
                    StartProcess(path,args);
                    Application.Run();
                }
            }
        }

        private static int exited = 0;
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (Interlocked.Increment(ref exited) == 1)
            {
                Logging.Error(e.ExceptionObject?.ToString());
                MessageBox.Show(
                    $"{I18N.GetString("Unexpected error, shadowsocks will exit. Please report to")} https://github.com/shadowsocks/shadowsocks-windows/issues {Environment.NewLine}{e.ExceptionObject?.ToString()}",
                    "Shadowsocks non-UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string errorMsg = $"Exception Type: {e.Exception.GetType().Name}{Environment.NewLine}Stack Trace:{Environment.NewLine}{e.Exception.StackTrace}";
            Logging.Error(errorMsg);
            MessageBox.Show(
                $"{I18N.GetString("Unexpected error, shadowsocks will exit. Please report to")} https://github.com/shadowsocks/shadowsocks-windows/issues {Environment.NewLine}{errorMsg}",
                "Shadowsocks UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private static void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    Logging.Info("os wake up");
                    if (_controller != null)
                    {
                        System.Timers.Timer timer = new System.Timers.Timer(10 * 1000);
                        timer.Elapsed += Timer_Elapsed;
                        timer.AutoReset = false;
                        timer.Enabled = true;
                        timer.Start();
                    }
                    break;
                case PowerModes.Suspend:
                    if (_controller != null)
                    {
                        _controller.Stop();
                        Logging.Info("controller stopped");
                    }
                    Logging.Info("os suspend");
                    break;
            }
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (_controller != null)
                {
                    _controller.Start();
                    Logging.Info("controller started");
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
            finally
            {
                try
                {
                    System.Timers.Timer timer = (System.Timers.Timer)sender;
                    timer.Enabled = false;
                    timer.Stop();
                    timer.Dispose();
                }
                catch (Exception ex)
                {
                    Logging.LogUsefulException(ex);
                }
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
            HotKeys.Destroy();
            if (_controller != null)
            {
                _controller.Stop();
                _controller = null;
            }
        }

        //public void ShutDown()
        //{
        //    _controller.Stop();
        //    Application.Exit();
        //}
    }
}
