using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReader.Core.Model
{
    class Literature
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
        string Progress;
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

        public string Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        public string Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
    }
}
