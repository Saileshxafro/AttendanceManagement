using System;
using System.Collections.Generic;

namespace AttendanceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Company Attendance Management System!");

            Dictionary<int, (string, string)> employeeAttendance = new Dictionary<int, (string, string)>();

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
                            AddEmployeeRecord(employeeAttendance);
                            break;
                        case 2:
                            MarkAttendance(employeeAttendance);
                            break;
                        case 3:
                            ViewAttendance(employeeAttendance);
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

        static void AddEmployeeRecord(Dictionary<int, (string, string)> attendance)
        {
            Console.Write("Enter employee ID: ");
            int employeeID;
            if (int.TryParse(Console.ReadLine(), out employeeID))
            {
                if (!attendance.ContainsKey(employeeID))
                {
                    Console.Write("Enter employee name: ");
                    string employeeName = Console.ReadLine();
                    attendance.Add(employeeID, (employeeName, "A"));
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

        static void MarkAttendance(Dictionary<int, (string, string)> attendance)
        {
            Console.Write("Enter employee ID: ");
            int employeeID;
            if (int.TryParse(Console.ReadLine(), out employeeID))
            {
                if (attendance.ContainsKey(employeeID))
                {
                    Console.Write("Enter attendance status (P for present, A for absent): ");
                    string status = Console.ReadLine().ToUpper();
                    if (status == "P" || status == "A")
                    {
                        attendance[employeeID] = (attendance[employeeID].Item1, status);
                        Console.WriteLine($"Attendance marked for employee {attendance[employeeID].Item1}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter P or A.");
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

        static void ViewAttendance(Dictionary<int, (string, string)> attendance)
        {
            Console.WriteLine("\nAttendance Report:");
            foreach (var employee in attendance)
            {
                Console.WriteLine($"Employee ID: {employee.Key}, Name: {employee.Value.Item1}, Status: {employee.Value.Item2}");
            }
        }
    }
}
