using System;
using System.IO;

namespace LeaveTracker
{
    public class EmployeeManager
    {
        public static Employee GetEmployeeFromCsv(int id)
        {
            var E = new Employee();
            using( var reader = File.OpenText("employees.csv"))
            {
                var entry = reader.ReadLine(); //skip first line as it is header
                entry = reader.ReadLine();
                while(entry != null)
                {
                    var employ = entry.Split(",");
                    if (Int32.Parse(employ[0]) == id )
                    {
                        E.ID = Int32.Parse(employ[0]);
                        E.Name = employ[1];
                        if(employ[2] != "")
                        {
                            E.ManID = Int32.Parse(employ[2]);
                        }
                        break;
                    }
                    entry = reader.ReadLine();
                }
            }
            return E;
        }
    }
}