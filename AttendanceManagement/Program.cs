using System;
using System.Collections.Generic;

namespace AttendanceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Company Attendance Management System!");

            Dictionary<int, (string, string, string, List<(DateTime, string)>)> employeeData = new Dictionary<int, (string, string, string, List<(DateTime, string)>)>();

            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Add Employee Record");
                Console.WriteLine("2. Mark Attendance");
                Console.WriteLine("3. View Attendance");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddEmployeeRecord(employeeData);
                            break;
                        case 2:
                            MarkAttendance(employeeData);
                            break;
                        case 3:
                            ViewAttendance(employeeData);
                            break;
                        case 4:
                            Console.WriteLine("Exiting...");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
        }

        static void AddEmployeeRecord(Dictionary<int, (string, string, string, List<(DateTime, string)>)> employeeData)
        {
            Console.Write("Enter employee ID: ");
            int employeeID;
            if (int.TryParse(Console.ReadLine(), out employeeID))
            {
                if (!employeeData.ContainsKey(employeeID))
                {
                    Console.Write("Enter employee name: ");
                    string employeeName = Console.ReadLine();
                    Console.Write("Enter employee password: ");
                    string password = Console.ReadLine();
                    Console.Write("Enter employee position: ");
                    string position = Console.ReadLine();
                    employeeData.Add(employeeID, (employeeName, password, position, new List<(DateTime, string)>()));
                    Console.WriteLine($"Employee with ID {employeeID} added successfully.");
                }
                else
                {
                    Console.WriteLine($"Employee with ID {employeeID} already exists.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid employee ID.");
            }
        }

        static void MarkAttendance(Dictionary<int, (string, string, string, List<(DateTime, string)>)> employeeData)
        {
            Console.WriteLine("Mark Attendance:");
            Console.WriteLine("1. Clock In");
            Console.WriteLine("2. Clock Out");
            Console.Write("Enter your choice (1-2): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                string action = (choice == 1) ? "Clock In" : "Clock Out";
                Console.Write("Enter employee ID: ");
                int employeeID;
                if (int.TryParse(Console.ReadLine(), out employeeID))
                {
                    if (employeeData.ContainsKey(employeeID))
                    {
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();

                        
                        if (password == employeeData[employeeID].Item2)
                        {
                            
                            if (action == "Clock Out")
                            {
                                
                                bool clockedIn = false;
                                foreach (var record in employeeData[employeeID].Item4)
                                {
                                    if (record.Item2 == "Clock In")
                                    {
                                        clockedIn = true;
                                        break;
                                    }
                                }
                                if (!clockedIn)
                                {
                                    Console.WriteLine("Cannot clock out before clocking in.");
                                    return;
                                }
                            }

                            DateTime currentTime = DateTime.Now;
                            employeeData[employeeID].Item4.Add((currentTime, action));
                            Console.WriteLine($"Attendance marked for employee {employeeID} - {action} at {currentTime}.");
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password. Attendance marking failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Employee with ID {employeeID} does not exist.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid employee ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
            }
        }

        static void ViewAttendance(Dictionary<int, (string, string, string, List<(DateTime, string)>)> employeeData)
        {
            Console.Write("Enter employee ID: ");
            int employeeID;
            if (int.TryParse(Console.ReadLine(), out employeeID))
            {
                if (employeeData.ContainsKey(employeeID))
                {
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    
                    if (password == employeeData[employeeID].Item2)
                    {
                        
                        Console.WriteLine("\nAttendance Report:");
                        foreach (var record in employeeData[employeeID].Item4)
                        {
                            Console.WriteLine($"Date/Time: {record.Item1}, Action: {record.Item2}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Attendance viewing failed.");
                    }
                }
                else
                {
                    Console.WriteLine($"Employee with ID {employeeID} does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid employee ID.");
            }
        }
    }
}
