using System;
using System.IO;
using Xunit;

namespace LogParser.Tests
{
    public class ArgParseTest
    {
        [Fact]
        public void PassingNoArguments()
         {
            string[] args = {""};
            var parser = new ArgParser();
            Assert.Throws<ArgumentException>(() => parser.ParseArgs(args));
        }
    
        [Fact]
        public void PassinglimitedArguments()
        {
            string[] args = {"--log-dir",".","--csv","."};
            var parser = new ArgParser();
            Assert.Throws<ArgumentException>(() => parser.ParseArgs(args));
        }
        [Fact]
        public void PassingWrongArguments()
        {
            string[] args = {"--log","."};
            var parser = new ArgParser();
            Assert.Throws<ArgumentException>(() => parser.ParseArgs(args));
        }

        [Fact]
        public void PassingCorrectArguments()
        {
            string[] args = {"--log-dir","logfile","--csv","csvfile","--log-level","INFO"};
            var parser = new ArgParser();
            var  arguments = parser.ParseArgs(args);
            Assert.True(arguments.CheckArgs());
        }
    }
}
