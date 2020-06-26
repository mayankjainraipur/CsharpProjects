// Assuming the data in log file are in format 
//  <date>(month/day) <Time>(hour:minute:second) <loglevel> :. <text>
//
using System;

namespace LogParser
{
    public class CsvData
    {
        public string Level { set; get; }
        public string Date { set; get; }
        public string Time { set; get; }
        public string Text { set; get; }

        public string GetString()
        {
            return $"{Level},{Date},{Time},{Text}";
        }
    }
}
