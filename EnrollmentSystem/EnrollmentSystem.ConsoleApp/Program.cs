// 12521269 Joaquin Bryan G. Ross
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
            Console.WriteLine("4. Search Student by GPA");
            Console.WriteLine("5. Sort Students by GPA");
            Console.WriteLine("6. Back to Main Menu");
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
                        Console.Write("Enter GPA: ");
                        double.TryParse(Console.ReadLine(), out double gpa);

                        // CourseCode is set separately because the Student constructor
                        // takes id, name and gpa only.
                        _registry.RegisterStudent(new Student(int.Parse(id), name, gpa) { CourseCode = course });
                        Console.WriteLine("\nStudent registered successfully.");
                        _logs.PushSystemLog(new Log { LogId = NextLogId(), ActionSummary = $"Registered student {id}" });
                        break;

                    case "2":
                        // UnregisterStudent removes by student id, which is what the
                        // instructor's test expects, so the prompt asks for the id.
                        Console.Write("Enter Student ID to remove: ");
                        int.TryParse(Console.ReadLine(), out int removeId);
                        bool removed = _registry.UnregisterStudent(removeId);
                        Console.WriteLine(removed ? "\nStudent removed successfully." : "\nStudent not found.");
                        if (removed)
                        {
                            _logs.PushSystemLog(new Log { LogId = NextLogId(), ActionSummary = $"Removed student {removeId}" });
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- Current Student List ---");
                        Console.WriteLine($"Total Students: {_registry.GetStudentCount()}");
                        _registry.ShowAllStudents();
                        Console.WriteLine($"Average GPA: {_registry.CalculateAverageGpa():F2}");
                        break;

                    case "4":
                        Console.Write("Enter Student ID to locate: ");
                        string lookupId = Console.ReadLine() ?? "";

                        // SearchStudent matches on the record itself, not on a field,
                        // so the record has to be identified before it can be searched
                        // for. Building a throwaway Student here would never match.
                        Student? match = null;
                        for (int i = 0; i < _registry.GetStudentCount(); i++)
                        {
                            if (_registry.GetStudentDetails(i).Id.ToString() == lookupId)
                            {
                                match = _registry.GetStudentDetails(i);
                                break;
                            }
                        }

                        if (match == null)
                        {
                            Console.WriteLine("\nThat student is not registered.");
                        }
                        else
                        {
                            int position = _registry.SearchStudent(match);
                            Console.WriteLine($"\n{match.Name} is at registry index {position} (GPA {match.Gpa:F2}).");
                        }
                        break;

                    case "5":
                        _registry.SortStudentsByGpa();
                        Console.WriteLine("\nRegistry sorted by GPA in ascending order.");
                        _registry.ShowAllStudents();
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
            Console.WriteLine("4. Search Course by Code");
            Console.WriteLine("5. Sort Curriculum by Units");
            Console.WriteLine("6. Back to Main Menu");
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
                        Console.WriteLine($"Total Curriculum Units: {_curriculum.CalculateTotalUnits()}");
                        break;

                    case "4":
                        Console.Write("Enter Course Code to find: ");
                        string lookupCode = Console.ReadLine() ?? "";
                        Course? found = _curriculum.SearchCourse(lookupCode);
                        Console.WriteLine(found != null
                            ? $"\nFound: {found.Code} | {found.Title} | {found.Units} unit(s)"
                            : "\nThat course code is not in the curriculum.");
                        break;

                    case "5":
                        _curriculum.SortCurriculumByUnits();
                        Console.WriteLine("\nCurriculum sorted by credit units in ascending order.");
                        _curriculum.ShowCurriculum();
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
            Console.WriteLine("4. Peek Next Ticket");
            Console.WriteLine("5. Search Ticket by ID");
            Console.WriteLine("6. Sort Tickets by Ticket Number");
            Console.WriteLine("7. Back to Main Menu");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID for Ticket: ");
                        string studentId = Console.ReadLine() ?? "";
                        int ticketNumber = 100 + _desk.GetQueueCount() + 1;
                        string ticketId = $"T-{ticketNumber}";

                        // LogId carries the ticket number because Ticket.CompareTo
                        // orders by LogId, so SortTicketsById has a key to work with.
                        _desk.IssueAdmissionsTicket(new Ticket { LogId = ticketNumber, TicketId = ticketId, StudentId = studentId });
                        Console.WriteLine($"\nTicket {ticketId} successfully issued to Student {studentId}.");
                        break;

                    case "2":
                        var served = _desk.ServeNextTicket();
                        Console.WriteLine($"\n[SERVED] Processing Ticket: {served.TicketId} for Student: {served.StudentId}");
                        break;

                    case "3":
                        Console.WriteLine($"\nTickets remaining in queue line: {_desk.GetQueueCount()}");
                        Console.WriteLine($"Queue empty: {_desk.CheckQueueEmpty()}");
                        break;

                    case "4":
                        var next = _desk.ViewNextTicket();
                        Console.WriteLine($"\n[NEXT] Ticket {next.TicketId} for Student {next.StudentId}");
                        break;

                    case "5":
                        Console.Write("Enter Ticket ID to find (e.g. T-101): ");
                        string wantedTicket = Console.ReadLine() ?? "";

                        // SearchTicket matches on the ticket record, so the queue is
                        // cycled once to locate it, then searched for.
                        Ticket? foundTicket = null;
                        for (int i = _desk.GetQueueCount(); i > 0; i--)
                        {
                            Ticket cycled = _desk.ServeNextTicket();
                            if (cycled.TicketId == wantedTicket && foundTicket == null) foundTicket = cycled;
                            _desk.IssueAdmissionsTicket(cycled);
                        }
                        Console.WriteLine(foundTicket != null && _desk.SearchTicket(foundTicket)
                            ? $"\nTicket {wantedTicket} is in the queue."
                            : "\nThat ticket is not in the queue.");
                        break;

                    case "6":
                        _desk.SortTicketsById();
                        Console.WriteLine("\nQueue reordered by ticket number in ascending order.");
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
            Console.WriteLine("4. Search Log Depth by Log ID");
            Console.WriteLine("5. Sort Logs by Log ID");
            Console.WriteLine("6. Back to Main Menu");
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
                        Console.WriteLine($"Log stack empty: {_logs.CheckLogsEmpty()}");
                        break;

                    case "4":
                        Console.Write("Enter Log ID to locate: ");
                        string wantedLogId = Console.ReadLine() ?? "";

                        // SearchLog matches on the record itself, so the log has to be
                        // found before it can be searched for. The stack is walked by
                        // popping into a holding stack and pushing everything back.
                        var holding = new AdministrativeLogs();
                        Log? target = null;
                        while (!_logs.CheckLogsEmpty())
                        {
                            Log candidate = _logs.RollbackLastLog();
                            if (candidate.LogId == wantedLogId) target = candidate;
                            holding.PushSystemLog(candidate);
                        }
                        while (!holding.CheckLogsEmpty())
                        {
                            _logs.PushSystemLog(holding.RollbackLastLog());
                        }

                        if (target == null)
                        {
                            Console.WriteLine("\nThat log ID is not on the stack.");
                        }
                        else
                        {
                            int depth = _logs.SearchLog(target);
                            Console.WriteLine($"\nLog {target.LogId} sits {depth} entr{(depth == 1 ? "y" : "ies")} from the top.");
                        }
                        break;

                    case "5":
                        _logs.SortLogsById();
                        Console.WriteLine("\nLog stack sorted by Log ID, lowest on top.");
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

        // Log ids are issued in sequence and zero padded so that an ordinal
        // comparison orders them the way they read. The original random suffix
        // sorted arbitrarily, which made SortLogsById impossible to demonstrate.
        private static int _logSequence = 0;

        private static string NextLogId()
        {
            _logSequence++;
            return $"L-{_logSequence:D3}";
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