using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchApplication
{
    class ResponseEntity<T>
    {
        [JsonProperty("code")]
        string code;
        [JsonProperty("msg")]
        string msg;
        [JsonProperty("response")]
        T response;
        public T GetResponse()
        {
            return response;
        }
    }
}
