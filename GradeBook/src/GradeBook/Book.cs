
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public abstract class Book : NamedObject , IBook
    {
        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        protected Book(string name) : base(name)
        {
        }
    }
}