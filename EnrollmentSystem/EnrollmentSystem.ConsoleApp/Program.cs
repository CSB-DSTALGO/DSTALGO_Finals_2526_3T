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
                Console.WriteLine("|===================================================|");
                Console.WriteLine("|     ENROLLMENT MANAGEMENT SYSTEM CORE NAVIGATOR   |");
                Console.WriteLine("|===================================================|");
                Console.WriteLine();
                Console.WriteLine("[1] Student Registry (ArrayList Interface)");
                Console.WriteLine();
                Console.WriteLine("[2] Course Curriculum (Singly Linked List Interface)");
                Console.WriteLine();
                Console.WriteLine("[3] Admissions Desk Queue (FIFO Interface)");
                Console.WriteLine();
                Console.WriteLine("[4] Administrative Logs Stack (LIFO Interface)");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("[5] Exit Application");
                Console.WriteLine("=====================================================");
                Console.WriteLine();
                Console.Write("Select a module to navigate (1-5): ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1": NavigateStudentRegistry(); break;
                    case "2": NavigateCourseCurriculum(); break;
                    case "3": NavigateAdmissionsDesk(); break;
                    case "4": NavigateAdministrativeLogs(); break;
                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("\nExiting system navigation... Goodbye!");
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\nInvalid selection! Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        #region Module Navigators

        static void NavigateStudentRegistry()
        {
            Console.Clear();
            Console.WriteLine("|===================================================|");
            Console.WriteLine("|              STUDENT REGISTRY MANAGEMENT          |");
            Console.WriteLine("|===================================================|");
            Console.WriteLine();
            Console.WriteLine("[1] Register New Student");
            Console.WriteLine();
            Console.WriteLine("[2] Remove Student by ID");
            Console.WriteLine();
            Console.WriteLine("[3] View Registered Students");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[4] Back to Main Menu");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.Write("|Input choice|: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                STUDENT REGISTRATION               |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.Write("|STUDENT ID|: ");
                        string id = Console.ReadLine() ?? "";
                        Console.Write("|FULL NAME|: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("|COURSE CODE|: ");
                        string course = Console.ReadLine() ?? "";

                        _registry.RegisterStudent(new Student(int.Parse(id), name, 0.0) {CourseCode = course}); 
                        Console.WriteLine();
                        Console.WriteLine("Student registered successfully!");
                        Console.WriteLine("=====================================================");


                        _registry.RegisterStudent(new Student(int.Parse(id), name, 0.0));
                        Console.WriteLine("\nStudent registered successfully.");

                        _logs.PushSystemLog(new Log { LogId = $"L-{Guid.NewGuid().ToString().Substring(0, 4)}", ActionSummary = $"Registered student {id}" });
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                  REMOVE STUDENT                   |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.Write("|ENTER STUDENT ID TO REMOVE|: ");
                        string targetId = Console.ReadLine() ?? "";
                        bool removed = _registry.RemoveStudent(targetId); 

                        Console.WriteLine();
                        Console.WriteLine(removed ? "Student removed successfully." : "Student not found.");
                        Console.WriteLine("=====================================================");

                        if (removed)
                        {
                            _logs.PushSystemLog(new Log { LogId = $"L-{Guid.NewGuid().ToString().Substring(0, 4)}", ActionSummary = $"Removed student {targetId}" });
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                  CURRENT STUDENT LIST             |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        int count = _registry.GetStudentCount();
                        Console.WriteLine($"|TOTAL STUDENTS|: {count}");
                        Console.WriteLine();

                        for (int i = 0; i < count; i++)
                        {
                            var s = _registry.GetStudentAt(i);
                            Console.WriteLine($"[{i}] ID: {s.Id} | NAME: {s.Name} | COURSE: {s.CourseCode}");
                            Console.WriteLine();
                            Console.WriteLine("=====================================================");
                            Console.WriteLine();
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
                Console.WriteLine();
                Console.WriteLine("=====================================================");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void NavigateCourseCurriculum()
        {
            Console.Clear();
            Console.WriteLine("|===================================================|");
            Console.WriteLine("|              COURSE CURRICULUM MANAGEMENT         |");
            Console.WriteLine("|===================================================|");
            Console.WriteLine();
            Console.WriteLine("[1] Insert Course");
            Console.WriteLine();
            Console.WriteLine("[2] Remove Course by Code");
            Console.WriteLine();
            Console.WriteLine("[3] View Curriculum Summary");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[4] Back to Main Menu");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.Write("|Input choice|: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                   INSERT COURSE                   |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.Write("|COURSE CODE (e.g., CS102) |: ");
                        string code = Console.ReadLine() ?? "";
                        Console.Write("|COURSE TITLE|: ");
                        string title = Console.ReadLine() ?? "";
                        Console.Write("|CREDIT UNITS|: ");
                        int.TryParse(Console.ReadLine(), out int units);

                        _curriculum.InsertCourse(new Course(code, title, units));
                        Console.WriteLine("\nCourse successfully inserted into curriculum.");
                        Console.WriteLine("=====================================================");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                   REMOVE COURSE                   |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.Write("|ENTER COURSE CODE TO REMOVE|: ");
                        string targetCode = Console.ReadLine() ?? "";
                        bool removed = _curriculum.DeleteCourse(targetCode);
                        Console.WriteLine(removed ? "\nCourse removed successfully." : "\nCourse not found.");
                        Console.WriteLine("=====================================================");
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                 CURRICULUM MATRIX                 |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.WriteLine($"|TOTAL CURRICULUM UNITS|: {_curriculum.CalculateTotalUnits()}");
                        Console.WriteLine();
                        _curriculum.ShowCurriculum();
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");
                        break;
                }
            }
            catch (NotImplementedException)
            {
                DisplayNotImplementedMessage();
                Console.WriteLine();
                Console.WriteLine("=====================================================");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void NavigateAdmissionsDesk()
        {
            Console.Clear();
            Console.WriteLine("|===================================================|");
            Console.WriteLine("|               ADMISSIONS DESK QUEUE               |");
            Console.WriteLine("|===================================================|");
            Console.WriteLine();
            Console.WriteLine("[1] Issue New Ticket (Enqueue)");
            Console.WriteLine();
            Console.WriteLine("[2] Serve Next Student (Dequeue)");
            Console.WriteLine();
            Console.WriteLine("[3] View Queue Status");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[4] Back to Main Menu");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.Write("|Input choice|: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                 ISSUE NEW TICKET                  |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.Write("|STUDENT ID|: ");
                        string studentId = Console.ReadLine() ?? "";
                        string ticketId = $"T-{100 + _desk.GetQueueCount() + 1}";
                        Console.WriteLine();

                        _desk.IssueAdmissionsTicket(new Ticket { TicketId = ticketId, StudentId = studentId });
                        Console.WriteLine($"Ticket {ticketId} successfully issued to Student {studentId}.");
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                SERVE NEXT STUDENT                 |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        var served = _desk.ServeNextTicket();
                        Console.WriteLine($"[SERVED] Processing Ticket: {served.TicketId} for Student: {served.StudentId}");
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                   QUEUE STATUS                    |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.WriteLine($"Tickets remaining in queue line: {_desk.GetQueueCount()}");
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");
                        break;
                }
            }
            catch (NotImplementedException)
            {
                DisplayNotImplementedMessage();
                Console.WriteLine();
                Console.WriteLine("=====================================================");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nNo tickets left in queue. The queue line is empty.");
                Console.WriteLine();
                Console.WriteLine("=====================================================");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void NavigateAdministrativeLogs()
        {
            Console.Clear();
            Console.WriteLine("|===================================================|");
            Console.WriteLine("|              SYSTEM ADMINISTRATIVE LOGS           |");
            Console.WriteLine("|===================================================|");
            Console.WriteLine();
            Console.WriteLine("[1] View Current Top Log (Peek)");
            Console.WriteLine();
            Console.WriteLine("[2] Clear/Purge Latest Log (Pop)");
            Console.WriteLine();
            Console.WriteLine("[3] Check Total Log Capacity");
            Console.WriteLine();
            Console.WriteLine("[4] Search Log by ID");
            Console.WriteLine();
            Console.WriteLine("[5] Sort Logs by ID");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[6] Back to Main Menu");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.Write("|Input choice|: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|              VIEWING CURRENT TOP LOG              |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        var latest = _logs.PeekLatestLog();
                        Console.WriteLine($"[TOP LOG] ID: {latest.LogId} | Action: {latest.ActionSummary}");
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                    LATEST LOG                     |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        var popped = _logs.PopSystemLog();
                        Console.WriteLine($"[REMOVED] Purged Log ID: {popped.LogId} ({popped.ActionSummary}) from system tracking stack.");
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                   LOG CAPACITY                    |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.WriteLine($"[LOG CAPACITY] Total active operations recorded in Stack: {_logs.GetLogCount()}");
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                     SEARCH LOG                    |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        Console.Write("|ENTER LOG ID TO SEARCH|: ");
                        string searchId = Console.ReadLine() ?? "";
                        int index = _logs.SearchLog(new Log { LogId = searchId });
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");

                        if (index != -1)
                        {
                            Console.WriteLine($"\nLog found in stack at position {index} (distance from top).");
                        }
                        else
                        {
                            Console.WriteLine("\nLog ID not found in stack.");
                        }
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine("|                     SORT LOGS                     |");
                        Console.WriteLine("|===================================================|");
                        Console.WriteLine();
                        _logs.SortLogsById();
                        Console.WriteLine("Administrative logs sorted successfully by Log ID.");
                        Console.WriteLine();
                        Console.WriteLine("=====================================================");
                        break;
                }
            }
            catch (NotImplementedException)
            {
                DisplayNotImplementedMessage();
                Console.WriteLine();
                Console.WriteLine("=====================================================");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nLog transaction stack history is empty.");
                Console.WriteLine();
                Console.WriteLine("=====================================================");
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