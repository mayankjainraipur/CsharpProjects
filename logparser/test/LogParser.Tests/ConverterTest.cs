using System;
using System.IO;
using Xunit;

namespace LogParser.Tests
{
    public class ConverterTest
    {
        [Fact]
        public void NumberOfInfoLogWrite()
        {
            var arguments = new Arguments();
            arguments.csv = "csvfile";
            arguments.logdir = "logfile";
            arguments.loglevel.Add("INFO");
            var conv = new ConverterFromLogToCSV();
            conv.convert(arguments);
            Assert.Equal(201 , conv.count);
        }
    }
}