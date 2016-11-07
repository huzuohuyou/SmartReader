using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReader.Core.Utils
{
    public class Serialize<T>
    {
        public Serialize() { }
        public string DoSerialize(T t)
        {
            return JsonConvert.SerializeObject(t);
        }

        public T DeSerialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
