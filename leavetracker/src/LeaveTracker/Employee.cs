using System;

namespace LeaveTracker
{
    public class Employee
    {
        public Employee()
        {
            ID = 0;
            Name = "";
            ManID = 0;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManID { get; set; }
        
        public bool valid()
        {
            if ( ID != 0 && Name != "" && ManID != 0)
            {
                return true;
            }
            return false;
        }
    }
}