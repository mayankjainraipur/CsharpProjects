// Assuming the data in log file are in format 
//  <date>(month/day) <Time>(hour:minute:second) <loglevel> :. <text>
//
using System;
using System.IO;

namespace LogParser
{
    class CsvFormatter
    {
        public CsvData ParseLine(string line)
        {
            var csvdata = new CsvData();
            String[] logdata = line.Split(":.");
            if (logdata.Length >= 2)
            {
                csvdata.Text = logdata[1];
                String[] loginfo = logdata[0].Trim().Split(' ');
                csvdata.Date = GetDateString(loginfo[0]);
                csvdata.Time = GetTimeString(loginfo[1]);
                csvdata.Level = loginfo[2];
            }
            else
            {
                throw new InvalidDataException("log data is not in format");
            }
            return csvdata;
        }

        private string GetTimeString(string v)
        {
            var time = DateTime.ParseExact(v, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return time.ToLongTimeString();
        }

        private string GetDateString(string v)
        {
            string[] strdate = v.Split('/');
            var date = new DateTime(2020, int.Parse(strdate[0]), int.Parse(strdate[1]));
            return String.Format("{0:dd MMMM yyyy}", date);
        }
    }
}
