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
        public void PushSystemLog_MultipleLogs_IncreasesCountCorrectly()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "Third" });

            Assert.Equal(3, logs.GetLogCount());
        }

        [Fact]
        public void RollbackLastLog_RemovesAndReturnsMostRecentLog()
        {
            var logs = new AdministrativeLogs();
            var log1 = new Log { LogId = "L-001", ActionSummary = "First" };
            var log2 = new Log { LogId = "L-002", ActionSummary = "Second" };
            logs.PushSystemLog(log1);
            logs.PushSystemLog(log2);

            var rolledBack = logs.RollbackLastLog();

            Assert.Equal("L-002", rolledBack.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }

        [Fact]
        public void RollbackLastLog_CalledTwice_ReturnsLogsInLIFOOrder()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            var first = logs.RollbackLastLog();
            var second = logs.RollbackLastLog();

            Assert.Equal("L-002", first.LogId);
            Assert.Equal("L-001", second.LogId);
        }

        [Fact]
        public void RollbackLastLog_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.RollbackLastLog());
        }

        [Fact]
        public void CheckLogsEmpty_ReturnsTrue_WhenNoLogsPushed()
        {
            var logs = new AdministrativeLogs();

            Assert.True(logs.CheckLogsEmpty());
        }

        [Fact]
        public void CheckLogsEmpty_ReturnsFalse_AfterPushingLog()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "Action" });

            Assert.False(logs.CheckLogsEmpty());
        }

        [Fact]
        public void CheckLogsEmpty_ReturnsTrue_AfterPoppingOnlyLog()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "Action" });
            logs.RollbackLastLog();

            Assert.True(logs.CheckLogsEmpty());
        }

        [Fact]
        public void ViewLatestLog_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.ViewLatestLog());
        }

        [Fact]
        public void SearchLog_FindsLogById()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            int index = logs.SearchLog(new Log { LogId = "L-002" });

            Assert.Equal(1, index);
        }

        [Fact]
        public void SortLogsById_OrdersLogsByLogId()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "Third" });
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            logs.SortLogsById();

            Assert.Equal("L-003", logs.ViewLatestLog().LogId);
        }
    }
}