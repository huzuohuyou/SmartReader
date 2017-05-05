using System;

namespace SmartReader.Model
{
    /// <summary>
    /// 用户阅读的PDF文档
    /// wuhailong
    /// 2017-05-05
    /// </summary>
    public class Document
    {
        public string Name { get; set; }
        public int LastReadPage { get; set; }
        public DateTime LastReadTime { get; set; }
        public int TotalPage { get; set; }
        public string Path { get; set; }
    }
}
