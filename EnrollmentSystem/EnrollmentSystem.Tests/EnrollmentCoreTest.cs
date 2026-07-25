using System;
using Xunit;
using EnrollmentSystem.Core;

namespace EnrollmentSystem.Tests
{
    public class StudentRegistryTests
    {
        // RegisterStudent tests
        [Fact]
        public void RegisterStudent_ShouldAddStudentAndIncreaseCount()
        {
            var registry = new StudentRegistry();
            var student = new Student(20260001, "Alice", 0.0);
            registry.RegisterStudent(student);
            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Alice", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void RegisterStudent_MultipleStudents_MaintainsOrder()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 3.0));
            registry.RegisterStudent(new Student(2, "B", 3.5));
            registry.RegisterStudent(new Student(3, "C", 4.0));
            
            Assert.Equal(3, registry.GetStudentCount());
            Assert.Equal("C", registry.GetStudentAt(2).Name);
        }

        [Fact]
        public void RegisterStudent_SameStudentTwice_AllowsDuplicates()
        {
            var registry = new StudentRegistry();
            var s = new Student(1, "A", 3.0);
            registry.RegisterStudent(s);
            registry.RegisterStudent(s);
            Assert.Equal(2, registry.GetStudentCount());
        }

        // UnregisterStudent tests
        [Fact]
        public void UnregisterStudent_ShouldDecreaseCount_WhenValidIndex()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "Alice", 0.0));
            registry.RegisterStudent(new Student(2, "Bob", 0.0));
            
            bool removed = registry.UnregisterStudent(0);
            
            Assert.True(removed);
            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Bob", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void UnregisterStudent_InvalidIndex_ShouldReturnFalse()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 3.0));
            bool removed = registry.UnregisterStudent(5);
            Assert.False(removed);
            Assert.Equal(1, registry.GetStudentCount());
        }

        [Fact]
        public void UnregisterStudent_NegativeIndex_ShouldReturnFalse()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 3.0));
            bool removed = registry.UnregisterStudent(-1);
            Assert.False(removed);
            Assert.Equal(1, registry.GetStudentCount());
        }

        // RemoveStudent tests
        [Fact]
        public void RemoveStudent_ByIdString_ShouldReturnTrue_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bob", 2.8));

            bool removed = registry.RemoveStudent("20260001");

            Assert.True(removed);
            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Bob", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void RemoveStudent_ByInvalidIdString_ShouldReturnFalse()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 3.5));
            bool removed = registry.RemoveStudent("InvalidID");
            Assert.False(removed);
            Assert.Equal(1, registry.GetStudentCount());
        }

        [Fact]
        public void RemoveStudent_ByNonExistentId_ShouldReturnFalse()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 3.5));
            bool removed = registry.RemoveStudent("999");
            Assert.False(removed);
            Assert.Equal(1, registry.GetStudentCount());
        }

        // GetStudentAt & GetStudentDetails tests
        [Fact]
        public void GetStudentAt_ValidIndex_ReturnsStudent()
        {
            var registry = new StudentRegistry();
            var s = new Student(1, "A", 3.0);
            registry.RegisterStudent(s);
            Assert.Equal(s, registry.GetStudentAt(0));
            Assert.Equal(s, registry.GetStudentDetails(0));
        }

        [Fact]
        public void GetStudentAt_InvalidIndex_ThrowsException()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 3.0));
            Assert.Throws<ArgumentOutOfRangeException>(() => registry.GetStudentAt(1));
            Assert.Throws<ArgumentOutOfRangeException>(() => registry.GetStudentDetails(1));
        }

        [Fact]
        public void GetStudentAt_NegativeIndex_ThrowsException()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 3.0));
            Assert.Throws<ArgumentOutOfRangeException>(() => registry.GetStudentAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => registry.GetStudentDetails(-1));
        }

        // ShowAllStudents tests
        [Fact]
        public void ShowAllStudents_PrintsToConsole()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "Test", 3.5));
            
            using var sw = new System.IO.StringWriter();
            Console.SetOut(sw);
            
            registry.ShowAllStudents();
            
            var output = sw.ToString().Trim();
            Assert.Contains("Test", output);
            Assert.Contains("3.5", output);
            
            var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        [Fact]
        public void ShowAllStudents_EmptyRegistry_PrintsNothing()
        {
            var registry = new StudentRegistry();
            
            using var sw = new System.IO.StringWriter();
            Console.SetOut(sw);
            
            registry.ShowAllStudents();
            
            var output = sw.ToString();
            Assert.Empty(output);
            
            var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        [Fact]
        public void ShowAllStudents_MultipleStudents_PrintsInOrder()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 1.0));
            registry.RegisterStudent(new Student(2, "B", 2.0));
            
            using var sw = new System.IO.StringWriter();
            sw.NewLine = "\n";
            Console.SetOut(sw);
            
            registry.ShowAllStudents();
            
            var output = sw.ToString().Trim();
            Assert.Contains("Name: A", output);
            Assert.Contains("Name: B", output);
            
            var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        // CalculateAverageGpa tests
        [Fact]
        public void CalculateAverageGpa_ShouldReturnAverageOfRegisteredStudents()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bob", 2.5));

            double average = registry.CalculateAverageGpa();

            Assert.Equal(3.0, average, 2);
        }

        [Fact]
        public void CalculateAverageGpa_EmptyRegistry_ShouldReturnZero()
        {
            var registry = new StudentRegistry();
            double average = registry.CalculateAverageGpa();
            Assert.Equal(0.0, average, 2);
        }

        [Fact]
        public void CalculateAverageGpa_SingleStudent_ShouldReturnStudentGpa()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 4.0));
            double average = registry.CalculateAverageGpa();
            Assert.Equal(4.0, average, 2);
        }

        // SearchStudent tests
        [Fact]
        public void SearchStudent_ShouldReturnIndex_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            var alice = new Student(20260001, "Alice", 3.5);
            var bob = new Student(20260002, "Bob", 2.5);
            registry.RegisterStudent(alice);
            registry.RegisterStudent(bob);

            int index = registry.SearchStudent(bob);

            Assert.Equal(1, index);
        }

        [Fact]
        public void SearchStudent_ShouldReturnMinusOne_WhenStudentDoesNotExist()
        {
            var registry = new StudentRegistry();
            var alice = new Student(1, "Alice", 3.5);
            var bob = new Student(2, "Bob", 2.5);
            registry.RegisterStudent(alice);

            int index = registry.SearchStudent(bob);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void SearchStudent_EmptyRegistry_ShouldReturnMinusOne()
        {
            var registry = new StudentRegistry();
            var bob = new Student(2, "Bob", 2.5);
            int index = registry.SearchStudent(bob);
            Assert.Equal(-1, index);
        }

        // SortStudentsByGpa tests
        [Fact]
        public void SortStudentsByGpa_SortsAscending()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 3.5));
            registry.RegisterStudent(new Student(2, "B", 2.0));
            registry.RegisterStudent(new Student(3, "C", 4.0));

            registry.SortStudentsByGpa();

            Assert.Equal(2.0, registry.GetStudentAt(0).Gpa);
            Assert.Equal(3.5, registry.GetStudentAt(1).Gpa);
            Assert.Equal(4.0, registry.GetStudentAt(2).Gpa);
        }

        [Fact]
        public void SortStudentsByGpa_AlreadySorted_MaintainsOrder()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(1, "A", 1.0));
            registry.RegisterStudent(new Student(2, "B", 2.0));

            registry.SortStudentsByGpa();

            Assert.Equal(1.0, registry.GetStudentAt(0).Gpa);
            Assert.Equal(2.0, registry.GetStudentAt(1).Gpa);
        }

        [Fact]
        public void SortStudentsByGpa_EmptyRegistry_DoesNotThrow()
        {
            var registry = new StudentRegistry();
            registry.SortStudentsByGpa();
            Assert.Equal(0, registry.GetStudentCount());
        }

        // GetStudentCount tests
        [Fact]
        public void GetStudentCount_ReturnsCorrectCount()
        {
            var registry = new StudentRegistry();
            Assert.Equal(0, registry.GetStudentCount());
            
            registry.RegisterStudent(new Student(1, "A", 3.0));
            Assert.Equal(1, registry.GetStudentCount());
        }
    }

    public class CourseCurriculumTests
    {
        [Fact]
        public void InsertCourse_ShouldAddInOrder()
        {
            var curriculum = new CourseCurriculum();
            var c1 = new Course("CS101", "Intro to CS", 3);
            var c2 = new Course("CS102", "Data Structures", 3);

            curriculum.InsertCourse(c1);
            curriculum.InsertCourse(c2);

            Assert.Equal(6, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void RemoveCourse_ShouldReturnTrue_WhenCourseIsRemoved()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS102", "Data Structures", 3);
            curriculum.InsertCourse(course);

            bool removed = curriculum.DeleteCourse(course.Code);

            Assert.True(removed);
            Assert.Equal(0, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void DeleteCourse_ShouldReturnFalse_WhenCourseCodeDoesNotExist()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            bool removed = curriculum.DeleteCourse("CS999");

            Assert.False(removed);
            Assert.Equal(3, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void CalculateTotalUnits_ShouldReturnSumOfAllInsertedCourses()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            Assert.Equal(7, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void SearchCourse_ShouldReturnTrue_WhenCourseExists()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS102", "Data Structures", 4);
            curriculum.InsertCourse(course);

            Assert.True(curriculum.SearchCourse(course));
        }
    }

    public class AdmissionsDeskTests
    {
        [Fact]
        public void IssueAdmissionsTicket_ShouldQueueTicketsInFIFOOrder()
        {
            var desk = new AdmissionsDesk();
            var t1 = new Ticket { LogId = 1, Action = "First Action", Timestamp = DateTime.Now };
            var t2 = new Ticket { LogId = 2, Action = "Second Action", Timestamp = DateTime.Now };

            desk.IssueAdmissionsTicket(t1);
            desk.IssueAdmissionsTicket(t2);

            Assert.Equal(2, desk.GetQueueCount());

            var served = desk.ServeNextTicket();
            Assert.Equal("T-101", served.TicketId);
        }

        [Fact]
        public void ServeNextTicket_ShouldThrowException_WhenQueueIsEmpty()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<InvalidOperationException>(() => desk.ServeNextTicket());
        }

        [Fact]
        public void ViewNextTicket_ShouldReturnFirstTicketInQueue()
        {
            var desk = new AdmissionsDesk();
            var t1 = new Ticket { LogId = 1, Action = "First Action", Timestamp = DateTime.Now, TicketId = "T-101" };
            var t2 = new Ticket { LogId = 2, Action = "Second Action", Timestamp = DateTime.Now, TicketId = "T-102" };

            desk.IssueAdmissionsTicket(t1);
            desk.IssueAdmissionsTicket(t2);

            var served = desk.ViewNextTicket();
            Assert.Equal("T-101", served.TicketId);

        }

        [Fact]
        public void ViewNextTicket_ShouldThrowException_WhenQueueIsEmpty()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<InvalidOperationException>(() => desk.ViewNextTicket());
        }
    }

    public class AdministrativeLogsTests
    {

        [Fact]
        public void PushSystemLog_ShouldRetrieveLogsInLIFOOrder()
        {
            var logs = new AdministrativeLogs();
            var log1 = new Log { LogId = "L-001", ActionSummary = "First Action" };
            var log2 = new Log { LogId = "L-002", ActionSummary = "Second Action" };

            logs.PushSystemLog(log1);
            logs.PushSystemLog(log2);

            Assert.Equal(2, logs.GetLogCount());

            var lastLog = logs.ViewLatestLog();
            Assert.Equal("L-002", lastLog.LogId);
        }

        [Fact]
        public void PeekSystemLog_ShouldReturnLatestLog_WithoutRemovingIt()
        {
            var logs = new AdministrativeLogs();
            var log = new Log { LogId = "L-001", ActionSummary = "Action" };
            logs.PushSystemLog(log);

            var peeked = logs.ViewLatestLog();

            Assert.Equal("L-001", peeked.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }

        [Fact]
        public void CheckLogsEmpty_ShouldReturnTrue_WhenNoLogsExist()
        {
            var logs = new AdministrativeLogs();

            Assert.True(logs.CheckLogsEmpty());
        }

        [Fact]
        public void PopSystemLog_ShouldRemoveAndReturnLatestLog()
        {
            var logs = new AdministrativeLogs();
            var first = new Log { LogId = "L-001", ActionSummary = "First" };
            var second = new Log { LogId = "L-002", ActionSummary = "Second" };
            logs.PushSystemLog(first);
            logs.PushSystemLog(second);

            var popped = logs.PopSystemLog();

            Assert.Equal("L-002", popped.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }
    }
}
