using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using SmartReader.Core.Controller.Service;
using SmartReader.Presenter;

namespace SmartReader.View
{
    public partial class ucPDFReader : UserControl, IContentView
    {
        WebView Browser;
        public ucPDFReader()
        {
            try
            {
                InitializeComponent();
                string path = Application.StartupPath + @"\PDFJSInNet\web\viewer.html";
                Browser = new WebView();
                Browser.Address = path;
                Browser.Parent = this;
                Browser.Dock = DockStyle.Fill;
                RegeistObj();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public void RegeistObj()
        {
            Browser.RegisterJsObject("callbackObj",  CallbackObjectForJs.GetInstance());
        }

        public ucPDFReader(string path)
        {
            try
            {
                InitializeComponent();
                WebView Browser = new WebView();
                Browser.Address = string.Format(Application.StartupPath + @"\PDFJSInNet\web\viewer.html?file={0}", path);
                Browser.Parent = this;
                Browser.Dock = DockStyle.Fill;
                RegeistObj();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool mouseStatus = false;//鼠标状态，false为松开
        private List<Rectangle> rectList = new List<Rectangle>();//存储所有画过的矩形
        private Point startPoint;//鼠标按下的点
        private Point endPoint;//
        private Rectangle currRect;//当前正在绘制的举行
        private int minStartX, minStartY, maxEndX, maxEndY;//最大重绘矩形的上下左右的坐标，这样重绘的效率更高。
       

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseStatus = true;
            startPoint.X = e.X;
            startPoint.Y = e.Y;
            //重新一个矩形，重置最大重绘矩形的上下左右的坐标
            minStartX = e.X;
            minStartY = e.Y;
            maxEndX = e.X;
            maxEndY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseStatus)
            {
                endPoint.X = e.X; endPoint.Y = e.Y;
                //这一段是获取要绘制矩形的上下左右的坐标，如果不这样处理的话，只有从左上开始往右下角才能画出矩形。
                //这样处理的话，可以任意方向，当然中途可以更换方向。
                int realStartX = Math.Min(startPoint.X, endPoint.X);
                int realStartY = Math.Min(startPoint.Y, endPoint.Y);
                int realEndX = Math.Max(startPoint.X, endPoint.X);
                int realEndY = Math.Max(startPoint.Y, endPoint.Y);

                minStartX = Math.Min(minStartX, realStartX);
                minStartY = Math.Min(minStartY, realStartY);
                maxEndX = Math.Max(maxEndX, realEndX);
                maxEndY = Math.Max(maxEndY, realEndY);

                currRect = new Rectangle(realStartX, realStartY, realEndX - realStartX, realEndY - realStartY);
                //一下是为了获取最大重绘矩形。
                Rectangle refeshRect = new Rectangle(minStartX, minStartY, maxEndX - minStartX, maxEndY - minStartY);
                refeshRect.Inflate(1, 1);//重绘矩形的大小扩展1个单位
                this.Invalidate(refeshRect);//失效一个区域，并使其重绘。
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseStatus = false;
            endPoint.X = e.X; endPoint.Y = e.Y;
            int realStartX = Math.Min(startPoint.X, endPoint.X);
            int realStartY = Math.Min(startPoint.Y, endPoint.Y);
            int realEndX = Math.Max(startPoint.X, endPoint.X);
            int realEndY = Math.Max(startPoint.Y, endPoint.Y);
            currRect = new Rectangle(realStartX, realStartY, realEndX - realStartX, realEndY - realStartY);
            rectList.Add(currRect);//当前矩形算是被认可了，所以存起来
            this.Invalidate();//重绘整个界面
        }
        private void Form1_Paint(object sender, PaintEventArgs e)//处理重绘情况
        {
            Graphics g = e.Graphics;
            g.Clear(this.BackColor);
            g.DrawRectangle(new Pen(Color.Red, 1), currRect);
            foreach (Rectangle rect in rectList)
                g.DrawRectangle(new Pen(Color.Red, 1), rect);
        }
    }
}
