using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReader.Core.Model
{
    class Group
    {
        string name;
        string newName;

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
