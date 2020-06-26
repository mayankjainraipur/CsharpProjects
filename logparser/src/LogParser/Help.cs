using System;

namespace LogParser
{
    public class Help
    {
        public static void PrintHelp()
        {
            Console.WriteLine("    Usage:  logParser --log-dir <dir> --log-level <level> --csv <out>");
            Console.WriteLine("            --log-dir   Directory to parse recursively for .log files");
            Console.WriteLine("            --csv       Out file-path (absolute/relative)");
            Environment.Exit(0);
        }
    }
}