using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchApplication
{

    public struct param
    {
        [JsonProperty("server")]
        public string server;
        [JsonProperty("password")]
        public string password;
        [JsonProperty("server_port")]
        public string server_port;
    }

    public class ShadowSocksEntity : IEntity
    {

        public static string URL = string.Format("http://bigdata.api.bimt.com/v1/{0}", "/utils/google_scholar_sslist");
        [JsonProperty("configs")]
        List<param> configs = new List<param>();
        public string GetUrl()
        {
            return URL;
        }

        public List<param> GetParams() {
            return configs;
        }
    }
}
