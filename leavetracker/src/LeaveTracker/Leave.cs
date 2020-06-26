using System;

namespace LeaveTracker
{
    public class Leave
    {
        public int Index { get; set; }
        public int ID { get; set; }
        public string Creator { get; set; }
        public string Manager { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveStatus Status { get; set; }

        public override string ToString()
        {
            return $"{Index},{ID},{Creator},{Manager},{Title},{Description},{StartDate.ToString()},{EndDate.ToString()},{Status}";
        }
        
    }
}
