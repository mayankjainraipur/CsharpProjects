using System;

namespace LeaveTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var E = login();
            var L = new LeaveManager();
            var repeat = true;
            while (repeat)
            {
                Console.WriteLine($"Welcome {E.Name} !");
                PrintMenu();
                var menuinput = Console.ReadLine();
                switch (menuinput)
                {
                    case "1":
                        //Add Leave
                        L.AddLeave(E);
                        break;
                    case "2":
                        //List leave
                        L.ListLeave(E);
                        break;
                    case "3":
                        //update leave
                        L.EditLeaveStatus(E);
                        break;
                    case "4":
                        //search leave
                        var searchrepeat = true;
                        while (searchrepeat)
                        {
                            PrintSearchMenu();
                            var searchinput = Console.ReadLine();
                            switch (searchinput)
                            {
                                case "1":
                                    L.SearchLeaveByTitle(E);
                                    break;
                                case "2":
                                    L.SearchLeaveByStatus(E);
                                    break;
                                case "3":
                                    searchrepeat = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid Input");
                                    break;
                            }
                        }
                        break;
                    case "5":
                        //exit
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            L.SaveData();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Create Leave");
            Console.WriteLine("2. List My Leaves");
            Console.WriteLine("3. Update Leaves");
            Console.WriteLine("4. Search Leaves");
            Console.WriteLine("5. Logout");
        }

        private static void PrintSearchMenu()
        {
            Console.WriteLine("1. Search By Title");
            Console.WriteLine("2. Search By Status");
            Console.WriteLine("3. Back To Main Menu");
        }
        public static Employee login()
        {
            //TODO : add try catch
            Employee E;
            while (true)
            {
                Console.WriteLine("Enter the Employee ID or q to quit: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    Environment.Exit(0);
                }
                try
                {
                    var id = Int32.Parse(input);
                    E = EmployeeManager.GetEmployeeFromCsv(id);
                    if (E.valid())
                    {
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("The ID is Invalid");
            }
            return E;
        }
    }
}
