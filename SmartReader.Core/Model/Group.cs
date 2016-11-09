using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReader.Core.Model
{
    public class Group
    {
        string name;
        string newName;

        /// <summary>
        /// 给name 赋值
        /// </summary>
        /// <param name="n"></param>
        public Group(string n)
        {
            name = n;
        }

        /// <summary>
        /// 给name 和newName赋值
        /// </summary>
        /// <param name="n"></param>
        /// <param name="nn"></param>
        public Group(string n, string nn)
        {
            name = n;
            newName = nn;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string NewName
        {
            get
            {
                return newName;
            }

            set
            {
                newName = value;
            }
        }
    }
}
