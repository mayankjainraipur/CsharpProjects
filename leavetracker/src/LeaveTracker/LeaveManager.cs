using System;
using System.Collections.Generic;
using System.IO;

namespace LeaveTracker
{
    public class LeaveManager
    {
        private List<Leave> L = new List<Leave>();
        private int leavecount = 0;

        public LeaveManager()
        {
            if (CheckLeaveCsvFile())
            {
                using (var reader = File.OpenText($"Leave.csv"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        L.Add(getLeaveObjectFromString(line));
                        leavecount++;
                        line = reader.ReadLine();
                    }
                }
            }
        }

        // ~LeaveManager()
        // {
        //     File.Delete("Leave.csv"); //delete old file and write new content
        //     using (var writter = File.AppendText("Leave.csv"))
        //     {
        //         foreach (var l in L)
        //         {
        //             writter.WriteLine(l.ToString());
        //         }
        //     }
        // }
        
        public void SaveData()
        {
            File.Delete("Leave.csv"); //delete old file and write new content
            using (var writter = File.AppendText("Leave.csv"))
            {
                foreach (var l in L)
                {
                    writter.WriteLine(l.ToString());
                }
            }
        }

        public void AddLeave(Employee e)
        {
            L.Add(GetLeaveObjectFromUser(e));
            leavecount++;
        }

        public void ListLeave(Employee e)
        {
            int count = 0;
            Console.WriteLine("Index,ID, Creator, Manager, Title, Description, Start-Date, End-Date, Status");
            foreach (var l in L)
            {
                if (e.ID == l.ID)
                {
                    Console.WriteLine(l.ToString());
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"No entry Found for the user : {e.Name}");
            }
        }

        public bool EditLeaveStatus(Employee e)
        {
            var rstatus = false;
            int count = 0;
            Console.WriteLine("Index,ID, Creator, Manager, Title, Description, Start-Date, End-Date, Status");
            foreach (var l in L)
            {
                if (l.Status == LeaveStatus.Pending && l.Manager == e.Name)
                {
                    Console.WriteLine(l.ToString());
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No Editable Leave found");
            }
            else
            {
                Console.WriteLine("Enter the index of the leave you want to edit: ");
                var i = Console.ReadLine();
                foreach (var l in L)
                {
                    if (l.Index == int.Parse(i))
                    {
                        Console.WriteLine("Enter the new Status (Approved , Rejected)");
                        l.Status = (LeaveStatus)Enum.Parse(typeof(LeaveStatus), Console.ReadLine(), true);
                        rstatus = true;
                    }
                    else
                    {
                        Console.WriteLine("Index out of bound");
                    }
                }

            }
            return rstatus;
        }

        public void SearchLeaveByTitle(Employee e)
        {
            Console.WriteLine("Enter the Complete or part of the title: ");
            var s = Console.ReadLine();
            int count = 0;
            Console.WriteLine("Index,ID, Creator, Manager, Title, Description, Start-Date, End-Date, Status");
            foreach (var l in L)
            {
                if (l.Title.Contains(s))
                {
                    Console.WriteLine(l.ToString());
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"No entry Found for the Title : {s}");
            }
        }

        internal void SearchLeaveByStatus(Employee e)
        {
            LeaveStatus v;
            while (true)
            {
                Console.WriteLine("Enter the Status(Pending / Approved / Rejected): ");
                var s = Console.ReadLine();
                if (s == "Pending" || s == "Approved" || s == "Rejected")
                {
                    v = (LeaveStatus)Enum.Parse(typeof(LeaveStatus), s, true);
                    break;
                }
                Console.WriteLine("Invalid Status");
            }
            int count = 0;
            Console.WriteLine("Index,ID, Creator, Manager, Title, Description, Start-Date, End-Date, Status");
            foreach (var l in L)
            {
                if (l.Status == v)
                {
                    Console.WriteLine(l.ToString());
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"No entry Found for the status : {v}");
            }
        }

        private bool CheckLeaveCsvFile()
        {
            return File.Exists("Leave.csv");
        }

        public Leave GetLeaveObjectFromUser(Employee e)
        {
            var l = new Leave();
            l.Index = leavecount + 1;
            l.ID = e.ID;
            l.Creator = e.Name;
            l.Manager = EmployeeManager.GetEmployeeFromCsv(e.ManID).Name;
            Console.WriteLine("Enter the title for the Leave: ");
            l.Title = Console.ReadLine();
            Console.WriteLine("Enter Description For the Leave: ");
            l.Description = Console.ReadLine();
            Console.WriteLine("Enter Start Date (DD-MM-YYYY): ");
            l.StartDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter End Date (DD-MM-YYYY): ");
            l.EndDate = DateTime.Parse(Console.ReadLine());
            l.Status = LeaveStatus.Pending;
            return l;
        }

        public Leave getLeaveObjectFromString(string line)
        {
            var l = new Leave();
            var fields = line.Split(",");
            l.Index = int.Parse(fields[0]);
            l.ID = int.Parse(fields[1]);
            l.Creator = fields[2];
            l.Manager = fields[3];
            l.Title = fields[4];
            l.Description = fields[5];
            l.StartDate = DateTime.Parse(fields[6]);
            l.EndDate = DateTime.Parse(fields[7]);
            l.Status = (LeaveStatus)Enum.Parse(typeof(LeaveStatus), fields[8], true);
            return l;
        }
    }
}