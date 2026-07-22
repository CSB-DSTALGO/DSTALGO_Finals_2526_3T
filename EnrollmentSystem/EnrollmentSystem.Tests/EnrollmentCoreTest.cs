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
            var student = new Student(1, "Alice", 90.0) { CourseCode = "BSIT" };

            registry.RegisterStudent(student);

            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Alice", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void RemoveStudent_ShouldDecreaseCount_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            var student = new Student(1, "Alice", 90.0) { CourseCode = "BSIT" };
            registry.RegisterStudent(student);

            bool removed = registry.RemoveStudent(1);

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

            Assert.Equal(6, curriculum.GetTotalUnits());
        }

        [Fact]
        public void RemoveCourse_ShouldReturnTrue_WhenCourseIsRemoved()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS102", "Data Structures", 3);
            curriculum.InsertCourse(course);

            bool removed = curriculum.RemoveCourse("CS102");

            Assert.True(removed);
            Assert.Equal(0, curriculum.GetTotalUnits());
        }
    }

    public class AdmissionsDeskTests
    {
        [Fact]
        public void IssueAdmissionsTicket_ShouldQueueTicketsInFIFOOrder()
        {
            var desk = new AdmissionsDesk();
            var t1 = new Ticket { TicketId = "T-101", StudentId = "2026-0001" };
            var t2 = new Ticket { TicketId = "T-102", StudentId = "2026-0002" };

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

            var lastLog = logs.PopSystemLog();
            Assert.Equal("L-002", lastLog.LogId);
        }

        [Fact]
        public void PeekSystemLog_ShouldReturnLatestLog_WithoutRemovingIt()
        {
            var logs = new AdministrativeLogs();
            var log = new Log { LogId = "L-001", ActionSummary = "Action" };
            logs.PushSystemLog(log);

            var peeked = logs.PeekLatestLog();

            Assert.Equal("L-001", peeked.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }

        // (spec method)

        [Fact]
        public void PushSystemLog_NullLog_ThrowsArgumentNullException()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<ArgumentNullException>(() => logs.PushSystemLog(null!));
        }

        [Fact]
        public void PushSystemLog_MultipleLogs_IncreasesCountAccordingly()
        {
            var logs = new AdministrativeLogs();

            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "B" });
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "C" });

            Assert.Equal(3, logs.GetLogCount());
        }

        // (spec method)

        [Fact]
        public void RollbackLastLog_ReturnsMostRecentLogAndRemovesIt()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "B" });

            var rolledBack = logs.RollbackLastLog();

            Assert.Equal("L-002", rolledBack.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }

        [Fact]
        public void RollbackLastLog_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.RollbackLastLog());
        }

        // (spec method) 

        [Fact]
        public void ViewLatestLog_DoesNotRemoveTheLog()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });

            var viewed = logs.ViewLatestLog();

            Assert.Equal("L-001", viewed.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }

        [Fact]
        public void ViewLatestLog_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.ViewLatestLog());
        }

        //  (spec method) 

        [Fact]
        public void CheckLogsEmpty_OnNewInstance_ReturnsTrue()
        {
            var logs = new AdministrativeLogs();

            Assert.True(logs.CheckLogsEmpty());
        }

        [Fact]
        public void CheckLogsEmpty_AfterPush_ReturnsFalse()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });

            Assert.False(logs.CheckLogsEmpty());
        }

        [Fact]
        public void CheckLogsEmpty_AfterPushThenRollback_ReturnsTrue()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });
            logs.RollbackLastLog();

            Assert.True(logs.CheckLogsEmpty());
        }

        // (insertion sort) 

        [Fact]
        public void GetLogsSortedById_ReturnsLogsInAscendingOrder()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "C" });
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "B" });

            var sorted = logs.GetLogsSortedById();

            Assert.Equal(new[] { "L-001", "L-002", "L-003" },
                new[] { sorted[0].LogId, sorted[1].LogId, sorted[2].LogId });
        }

        [Fact]
        public void GetLogsSortedById_DoesNotMutateOriginalStackOrder()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "C" });
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });

            logs.GetLogsSortedById();

            //last pushed (L-001) is still on top.
            Assert.Equal("L-001", logs.ViewLatestLog().LogId);
        }

        [Fact]
        public void GetLogsSortedById_OnEmptyStack_ReturnsEmptyArray()
        {
            var logs = new AdministrativeLogs();

            var sorted = logs.GetLogsSortedById();

            Assert.Empty(sorted);
        }

        // (binary search)

        [Fact]
        public void SearchLogById_ExistingId_ReturnsMatchingLog()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "B" });
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "C" });

            var found = logs.SearchLogById("L-002");

            Assert.NotNull(found);
            Assert.Equal("B", found!.ActionSummary);
        }

        [Fact]
        public void SearchLogById_NonExistentId_ReturnsNull()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "A" });

            var found = logs.SearchLogById("L-999");

            Assert.Null(found);
        }

        [Fact]
        public void SearchLogById_OnEmptyStack_ReturnsNull()
        {
            var logs = new AdministrativeLogs();

            var found = logs.SearchLogById("L-001");

            Assert.Null(found);
        }
    }
}