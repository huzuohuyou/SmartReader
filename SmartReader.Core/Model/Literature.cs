using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReader.Core.Model
{
    public class Literature
    {
        [JsonProperty("title")]
        string title;
        /// <summary>
        /// Last reading time
        /// </summary>
        [JsonProperty("lRTime")]
        string lRTime;
        /// <summary>
        /// 阅读进度即阅读的页码
        /// </summary>
        [JsonProperty("Progress")]
        string progress;
        /// <summary>
        /// 所属哪个组别下的文献
        /// </summary>
        [JsonProperty("parent")]
        string parent;
        /// <summary>
        /// 源路径
        /// </summary>
        [JsonProperty("source")]
        string source;

        public string GetProgress()
        {
            return progress;
        }

        public string GetLRTime()
        {
                return lRTime;
        }

        public Literature(string pTitle, string pLRTime, string pProgress, string pParent, string pSource)
        {
            title = pTitle;
            lRTime = pLRTime;
            progress = pProgress;
            parent = pParent;
            source = pSource;
        }

        public string GetParent()
        {
            
                return parent;
            
        }

        public string GetSource()
        {
            
                return source;
        }

        public string GetTitle()
        {
                return title;
        }

        internal string getProgress()
        {
            return progress;
        }
    }
}
