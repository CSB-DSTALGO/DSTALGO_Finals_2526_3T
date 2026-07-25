using System;
using EnrollmentSystem.Core;

namespace EnrollmentSystem.ConsoleApp
{
    class Program
    {
        private static StudentRegistry _registry = new StudentRegistry();
        private static CourseCurriculum _curriculum = new CourseCurriculum();
        private static AdmissionsDesk _desk = new AdmissionsDesk();
        private static AdministrativeLogs _logs = new AdministrativeLogs();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("    ENROLLMENT MANAGEMENT SYSTEM CORE NAVIGATOR  ");
                Console.WriteLine("=================================================");
                Console.WriteLine("1. Student Registry (ArrayList Interface)");
                Console.WriteLine("2. Course Curriculum (Singly Linked List Interface)");
                Console.WriteLine("3. Admissions Desk Queue (FIFO Interface)");
                Console.WriteLine("4. Administrative Logs Stack (LIFO Interface)");
                Console.WriteLine("5. Exit Application");
                Console.WriteLine("=================================================");
                Console.Write("Select a module to navigate (1-5): ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1": NavigateStudentRegistry(); break;
                    case "2": NavigateCourseCurriculum(); break;
                    case "3": NavigateAdmissionsDesk(); break;
                    case "4": NavigateAdministrativeLogs(); break;
                    case "5":
                        Console.WriteLine("\nExiting system navigation. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid selection. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        #region Module Navigators

        static void NavigateStudentRegistry()
        {
            Console.Clear();
            Console.WriteLine("--- STUDENT REGISTRY MANAGEMENT ---");
            Console.WriteLine("1. Register New Student");
            Console.WriteLine("2. Remove Student by ID");
            Console.WriteLine("3. View Registered Students");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID: ");
                        string id = Console.ReadLine() ?? "";
                        Console.Write("Enter Full Name: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("Enter Course Code: ");
                        string course = Console.ReadLine() ?? "";
                        
                        _registry.RegisterStudent(new Student(int.Parse(id), name, 0.0,course));
                        Console.WriteLine("\nStudent registered successfully.");
                        _logs.PushSystemLog(new Log { LogId = $"L-{Guid.NewGuid().ToString().Substring(0,4)}", ActionSummary = $"Registered student {id}" });
                        break;

                    case "2":
                        Console.Write("Enter Student ID to remove: ");
                        string targetId = Console.ReadLine() ?? "";
                        bool removed = _registry.UnregisterStudent(int.Parse(targetId));
                        Console.WriteLine(removed ? "\nStudent removed successfully." : "\nStudent not found.");
                        if (removed)
                        {
                            _logs.PushSystemLog(new Log { LogId = $"L-{Guid.NewGuid().ToString().Substring(0,4)}", ActionSummary = $"Removed student {targetId}" });
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- Current Student List ---");
                        // If students haven't implemented a printing function, this handles it via the tracking metrics
                        int count = _registry.GetStudentCount();
                        Console.WriteLine($"Total Students: {count}");
                        for (int i = 0; i < count; i++)
                        {
                            var s = _registry.GetStudentAt(i);
                            Console.WriteLine($"[{i}] ID: {s.Id} | Name: {s.Name} | Course: {s.CourseCode}");
                        }
                        break;
                }
            }
            catch (NotImplementedException)
            {
                DisplayNotImplementedMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void NavigateCourseCurriculum()
        {
            Console.Clear();
            Console.WriteLine("--- COURSE CURRICULUM MANAGEMENT ---");
            Console.WriteLine("1. Insert Course");
            Console.WriteLine("2. Remove Course by Code");
            Console.WriteLine("3. View Curriculum Summary");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Course Code (e.g., CS102): ");
                        string code = Console.ReadLine() ?? "";
                        Console.Write("Enter Course Title: ");
                        string title = Console.ReadLine() ?? "";
                        Console.Write("Enter Credit Units: ");
                        int.TryParse(Console.ReadLine(), out int units);

                        _curriculum.InsertCourse(new Course(code, title, units));
                        Console.WriteLine("\nCourse inserted into curriculum.");
                        break;

                    case "2":
                        Console.Write("Enter Course Code to remove: ");
                        string targetCode = Console.ReadLine() ?? "";
                        bool removed = _curriculum.DeleteCourse(targetCode);
                        Console.WriteLine(removed ? "\nCourse removed successfully." : "\nCourse not found.");
                        break;

                    case "3":
                        Console.WriteLine("\n--- Curriculum Matrix ---");
                        _curriculum.ShowCurriculum();
                        Console.WriteLine($"\nTotal Curriculum Units: {_curriculum.CalculateTotalUnits()}");
                        break;
                }
            }
            catch (NotImplementedException)
            {
                DisplayNotImplementedMessage();
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void NavigateAdmissionsDesk()
        {
            Console.Clear();
            Console.WriteLine("--- ADMISSIONS DESK QUEUE ---");
            Console.WriteLine("1. Issue New Ticket (Enqueue)");
            Console.WriteLine("2. Serve Next Student (Dequeue)");
            Console.WriteLine("3. View Queue Status");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID for Ticket: ");
                        string studentId = Console.ReadLine() ?? "";
                        string ticketId = $"T-{100 + _desk.GetQueueCount() + 1}";

                        _desk.IssueAdmissionsTicket(new Ticket { TicketId = ticketId, StudentId = studentId });
                        Console.WriteLine($"\nTicket {ticketId} successfully issued to Student {studentId}.");
                        break;

                    case "2":
                        var served = _desk.ServeNextTicket();
                        Console.WriteLine($"\n[SERVED] Processing Ticket: {served.TicketId} for Student: {served.StudentId}");
                        break;

                    case "3":
                        Console.WriteLine($"\nTickets remaining in queue line: {_desk.GetQueueCount()}");
                        _desk.ShowQueue();
                        break;
                }
            }
            catch (NotImplementedException)
            {
                DisplayNotImplementedMessage();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nNo tickets left in queue. The queue line is empty.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void NavigateAdministrativeLogs()
        {
            Console.Clear();
            Console.WriteLine("--- SYSTEM ADMINISTRATIVE LOGS ---");
            Console.WriteLine("1. View Current Top Log (Peek)");
            Console.WriteLine("2. Clear/Purge Latest Log (Pop)");
            Console.WriteLine("3. Check Total Log Capacity");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        var latest = _logs.PeekLatestLog();
                        Console.WriteLine($"\n[TOP LOG] ID: {latest.LogId} | Action: {latest.ActionSummary}");
                        break;

                    case "2":
                        var popped = _logs.PopSystemLog();
                        Console.WriteLine($"\n[REMOVED] Purged Log ID: {popped.LogId} ({popped.ActionSummary}) from system tracking stack.");
                        break;

                    case "3":
                        Console.WriteLine($"\nTotal active operations recorded in Stack: {_logs.GetLogCount()}");
                        break;
                }
            }
            catch (NotImplementedException)
            {
                DisplayNotImplementedMessage();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nLog transaction stack history is empty.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayNotImplementedMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[!] OPERATION FAILED: The underlying data structure methods for this module have not been implemented yet.");
            Console.ResetColor();
        }

        #endregion
    }
}