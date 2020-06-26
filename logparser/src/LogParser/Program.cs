// This is a program to parse the number of log files and convert
// them to a single csv file with desired log level.

using System;
using System.IO;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new ArgParser();
            var arguments = Parsing(parser, args);
            if (arguments.CheckArgs())
            {
                var conv = new ConverterFromLogToCSV();
                try
                {
                    conv.convert(arguments);
                    Console.WriteLine("Data conveted Successfully");
                }
                catch (Exception es)
                {
                    Console.WriteLine(es);
                }
            }
        }

        private static Arguments Parsing(ArgParser parser, string[] args)
        {
            var arguments = new Arguments();
            try
            {
                arguments = parser.ParseArgs(args);
            }
            catch (ArgumentException es)
            {
                // If there is error related to arguments
                Console.WriteLine(es);
                Help.PrintHelp();
            }
            catch (DirectoryNotFoundException es)
            {
                // if error related to directory passed.
                Console.WriteLine(es);
                Help.PrintHelp();
            }
            finally
            {
                Console.WriteLine("");
            }
            return arguments;
        }
    }
}
