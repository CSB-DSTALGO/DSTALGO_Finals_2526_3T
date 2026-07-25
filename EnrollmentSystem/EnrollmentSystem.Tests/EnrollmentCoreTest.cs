using System;
using Xunit;
using EnrollmentSystem.Core;

namespace EnrollmentSystem.Tests
{
    public class StudentRegistryTests
    {
        [Fact]
        public void RegisterStudent_AddsStudentToRegistry()
        {
            var registry = new StudentRegistry();
            var student = new Student(20260001, "Alice", 3.5);

            registry.RegisterStudent(student);
            var found = registry.SearchStudentById(20260001);

            Assert.NotNull(found);
        }

        [Fact]
        public void UnregisterStudent_RemovesStudentAtIndex()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bob", 2.8));

            registry.UnregisterStudent(0);

            var alice = registry.SearchStudentById(20260001);
            var bob = registry.SearchStudentById(20260002);

            Assert.Null(alice);
            Assert.NotNull(bob);
        }

        [Fact]
        public void SortStudentsByGpa_PutsLowestGpaFirst()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bob", 2.5));
            registry.RegisterStudent(new Student(20260003, "Carol", 3.9));

            registry.SortStudentsByGpa();

            var lowest = registry.SearchStudentById(20260002);
            Assert.Equal(2.5, lowest.Gpa);
        }

        [Fact]
        public void SearchStudentById_FindsCorrectStudent()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bob", 2.5));

            var found = registry.SearchStudentById(20260002);

            Assert.Equal("Bob", found.Name);
        }

        [Fact]
        public void SearchStudentById_ReturnsNullWhenNotFound()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));

            var found = registry.SearchStudentById(99999);

            Assert.Null(found);
        }
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

        public void SearchCourse_ShouldFindExistingCourseByCode()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            var found = curriculum.SearchCourse("CS102");

            Assert.NotNull(found);
            Assert.Equal("CS102", found!.Code);
        }

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
