using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("My Book");
            book.GradeAdded += OneGradeAdded;
            EnterGrades(book);
            var stat = book.GetStatistics();
            Console.WriteLine($"The lowes grade is {stat.Low}");
            Console.WriteLine($"The highest grade is {stat.High}");
            Console.WriteLine($"The average grade is {stat.Average:N1}");
            Console.WriteLine($"The Letter grade is {stat.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter the grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("");
                }
            }
        }

        static void OneGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade is added.");
        }
    }
}
