using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(String name)
        {
            Name = name;
        }

        public String Name
        {
            get;
            set;
        }
    }
}