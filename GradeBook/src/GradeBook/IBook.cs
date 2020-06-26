using System;
using System.Collections.Generic;

namespace GradeBook
{
        public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        String Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}