using System;
using System.Collections.Generic;

namespace LogParser
{
    public class Arguments
    {
        public string logdir;
        public string csv;
        public List<String> loglevel;

        public Arguments()
        {
            logdir = "";
            csv = "";
            loglevel = new List<string>();
        }

        public bool CheckArgs()
        {
            if( csv == "" || logdir == "" || loglevel.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}