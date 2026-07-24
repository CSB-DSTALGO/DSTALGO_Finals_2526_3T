using System;
using Xunit;
using EnrollmentSystem.Core;

namespace EnrollmentSystem.Tests
{
    public class StudentRegistryTests
    {
        [Fact]
        public void RegisterStudent_ShouldAddStudentAndIncreaseCount()
        {
            var registry = new StudentRegistry();
            // Student constructor requires (int id, string name, double gpa)
            var student = new Student(20260001, "Alice", 0.0);

            registry.RegisterStudent(student);

            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Alice", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void RemoveStudent_ShouldDecreaseCount_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            // Use matching constructor and id type for removal
            var student = new Student(20260001, "Alice", 0.0);
            registry.RegisterStudent(student);

            bool removed = registry.UnregisterStudent(20260001);

            Assert.True(removed);
            Assert.Equal(0, registry.GetStudentCount());
        }

        [Fact]
        public void RemoveStudent_ByIdString_ShouldReturnTrue_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            var alice = new Student(20260001, "Alice", 3.5);
            var bob = new Student(20260002, "Bob", 2.8);
            registry.RegisterStudent(alice);
            registry.RegisterStudent(bob);

            bool removed = registry.RemoveStudent("20260001");

            Assert.True(removed);
            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Bob", registry.GetStudentAt(0).Name);
        }

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
            var t1 = new Ticket 
            { 
                LogId = 1,
                Action = "First Action",
                Timestamp = DateTime.Now,
                TicketId = "T-101"
            
            };

            var t2 = new Ticket 
            { 
                LogId = 2, 
                Action = "Second Action", 
                Timestamp = DateTime.Now,
                TicketId = "T-102"
            };

            desk.IssueAdmissionsTicket(t1);
            desk.IssueAdmissionsTicket(t2);

            Assert.Equal(2, desk.GetQueueCount());

            var firstServed = desk.ServeNextTicket();
            var secondServed = desk.ServeNextTicket();

            Assert.Equal("T-101", firstServed.TicketId);
            Assert.Equal("T-102", secondServed.TicketId);
            Assert.Equal(0, desk.GetQueueCount());
            
            
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

        [Fact]
        public void CheckQueueEmpty_NewDesk_ReturnsTrue() 
        {
            var desk = new AdmissionsDesk();

            bool result = desk.CheckQueueEmpty();

            Assert.True(result);
        }

        [Fact]
        public void CheckQueueEmpty_AfterIssuingTicket_ReturnsFalse() 
        {
            var desk = new AdmissionsDesk();

            var ticket = new Ticket 
            {
                TicketId = "T-101"
            };

            desk.IssueAdmissionsTicket(ticket);

            bool result = desk.CheckQueueEmpty();

            Assert.False(result);
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
