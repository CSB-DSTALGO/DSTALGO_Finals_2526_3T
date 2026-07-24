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
            var student = new Student { Id = "2026-0001", Name = "Alice", CourseCode = "BSIT" };

            registry.RegisterStudent(student);

            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Alice", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void RemoveStudent_ShouldDecreaseCount_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            var student = new Student { Id = "2026-0001", Name = "Alice", CourseCode = "BSIT" };
            registry.RegisterStudent(student);

            bool removed = registry.RemoveStudent("2026-0001");

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
            var c1 = new Course { Code = "CS101", Title = "Intro to CS", Units = 3 };
            var c2 = new Course { Code = "CS102", Title = "Data Structures", Units = 3 };

            curriculum.InsertCourse(c1);
            curriculum.InsertCourse(c2);

            Assert.Equal(6, curriculum.GetTotalUnits());
        }

        [Fact]
        public void RemoveCourse_ShouldReturnTrue_WhenCourseIsRemoved()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course { Code = "CS102", Title = "Data Structures", Units = 3 };
            curriculum.InsertCourse(course);

            bool removed = curriculum.RemoveCourse("CS102");

            Assert.True(removed);
            Assert.Equal(0, curriculum.GetTotalUnits());
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
    }

    // ==============================================
    // MEMBER 2: Additional CourseCurriculum Tests
    // ==============================================

    public class AdditionalCourseCurriculumTests
    {
        [Fact]
        public void InsertCourse_DuplicateCode_ShouldThrowException()
        {
            var curriculum = new CourseCurriculum();
            var course1 = new Course { Code = "CS101", Title = "Intro to CS", Units = 3 };
            var course2 = new Course { Code = "CS101", Title = "Data Structures", Units = 3 };

            curriculum.InsertCourse(course1);

            Assert.Throws<InvalidOperationException>(() => curriculum.InsertCourse(course2));
        }

        [Fact]
        public void RemoveCourse_CourseNotFound_ShouldReturnFalse()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course { Code = "PHY101", Title = "Physics", Units = 3 };
            curriculum.InsertCourse(course);

            bool deleted = curriculum.RemoveCourse("CHEM101");

            Assert.False(deleted);
            Assert.Equal(1, curriculum.GetCourseCount());
        }

        [Fact]
        public void SearchCourse_ShouldFindExistingCourse()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course { Code = "ENG101", Title = "English Composition", Units = 3 };
            curriculum.InsertCourse(course);

            var found = curriculum.SearchCourse("ENG101");

            Assert.NotNull(found);
            Assert.Equal("ENG101", found!.Code);
            Assert.Equal("English Composition", found.Title);
        }

        [Fact]
        public void SearchCourse_NotFound_ShouldReturnNull()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course { Code = "HIST101", Title = "World History", Units = 3 };
            curriculum.InsertCourse(course);

            var found = curriculum.SearchCourse("ART101");

            Assert.Null(found);
        }

        [Fact]
        public void SortByCourseCode_ShouldSortAlphabetically()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course { Code = "ZOO101", Title = "Zoology", Units = 3 });
            curriculum.InsertCourse(new Course { Code = "BIO101", Title = "Biology", Units = 3 });
            curriculum.InsertCourse(new Course { Code = "CHEM101", Title = "Chemistry", Units = 3 });

            curriculum.SortByCourseCode();
            var sorted = curriculum.GetAllCourses();

            Assert.Equal("BIO101", sorted[0].Code);
            Assert.Equal("CHEM101", sorted[1].Code);
            Assert.Equal("ZOO101", sorted[2].Code);
        }

        [Fact]
        public void GetTotalUnits_ShouldReturnSumOfAllCourseUnits()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course { Code = "CS101", Title = "Intro", Units = 3 });
            curriculum.InsertCourse(new Course { Code = "CS102", Title = "Data Structures", Units = 4 });
            curriculum.InsertCourse(new Course { Code = "CS103", Title = "Algorithms", Units = 2 });

            int total = curriculum.GetTotalUnits();

            Assert.Equal(9, total);
        }

        [Fact]
        public void ShowCurriculum_ShouldNotThrowException_WhenEmpty()
        {
            var curriculum = new CourseCurriculum();

            var exception = Record.Exception(() => curriculum.ShowCurriculum());
            Assert.Null(exception);
        }

        [Fact]
        public void ShowCurriculum_ShouldNotThrowException_WhenNotEmpty()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course { Code = "CS101", Title = "Intro", Units = 3 });

            var exception = Record.Exception(() => curriculum.ShowCurriculum());
            Assert.Null(exception);
        }
    }

    /// <summary>
    /// Unit tests for the AdmissionsDesk class.
    /// Tests all queue operations, sorting, and search functionality.
    /// </summary>
    public class AdmissionsDeskTests
    {
        #region IssueAdmissionsTicket Tests (3+ tests)

        [Fact]
        public void IssueAdmissionsTicket_ValidTicket_ShouldAddTicketToQueue()
        {
            var desk = new AdmissionsDesk();
            var ticket = new Ticket { TicketId = "T001", StudentId = "S001" };

            desk.IssueAdmissionsTicket(ticket);

            Assert.Equal(1, desk.GetQueueCount());
            Assert.False(desk.CheckQueueEmpty());
        }

        [Fact]
        public void IssueAdmissionsTicket_NullTicket_ShouldThrowArgumentNullException()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<ArgumentNullException>(() => desk.IssueAdmissionsTicket(null!));
        }

        [Fact]
        public void IssueAdmissionsTicket_MultipleTickets_ShouldIncreaseQueueCount()
        {
            var desk = new AdmissionsDesk();

            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T003" });

            Assert.Equal(3, desk.GetQueueCount());
        }

        #endregion

        #region ServeNextStudent Tests (3+ tests)

        [Fact]
        public void ServeNextStudent_QueueWithTickets_ShouldReturnAndRemoveFrontTicket()
        {
            var desk = new AdmissionsDesk();
            var ticket1 = new Ticket { TicketId = "T001", StudentId = "S001" };
            var ticket2 = new Ticket { TicketId = "T002", StudentId = "S002" };
            desk.IssueAdmissionsTicket(ticket1);
            desk.IssueAdmissionsTicket(ticket2);

            var served = desk.ServeNextStudent();

            Assert.Equal("T001", served.TicketId);
            Assert.Equal(1, desk.GetQueueCount());
            Assert.Equal("T002", desk.ViewNextTicket().TicketId);
        }

        [Fact]
        public void ServeNextStudent_EmptyQueue_ShouldThrowInvalidOperationException()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<InvalidOperationException>(() => desk.ServeNextStudent());
        }

        [Fact]
        public void ServeNextStudent_SingleTicket_ShouldReturnTicketAndEmptyQueue()
        {
            var desk = new AdmissionsDesk();
            var ticket = new Ticket { TicketId = "T001", StudentId = "S001" };
            desk.IssueAdmissionsTicket(ticket);

            var served = desk.ServeNextStudent();

            Assert.Equal("T001", served.TicketId);
            Assert.Equal(0, desk.GetQueueCount());
            Assert.True(desk.CheckQueueEmpty());
        }

        #endregion

        #region ServeNextTicket Tests (3+ tests)

        [Fact]
        public void ServeNextTicket_QueueWithTickets_ShouldReturnFrontTicket()
        {
            var desk = new AdmissionsDesk();
            var ticket = new Ticket { TicketId = "T001", StudentId = "S001" };
            desk.IssueAdmissionsTicket(ticket);

            var served = desk.ServeNextTicket();

            Assert.Equal("T001", served.TicketId);
            Assert.True(desk.CheckQueueEmpty());
        }

        [Fact]
        public void ServeNextTicket_EmptyQueue_ShouldThrowInvalidOperationException()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<InvalidOperationException>(() => desk.ServeNextTicket());
        }

        [Fact]
        public void ServeNextTicket_MultipleTickets_ShouldReturnInCorrectOrder()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T003" });

            var first = desk.ServeNextTicket();
            var second = desk.ServeNextTicket();
            var third = desk.ServeNextTicket();

            Assert.Equal("T001", first.TicketId);
            Assert.Equal("T002", second.TicketId);
            Assert.Equal("T003", third.TicketId);
            Assert.Equal(0, desk.GetQueueCount());
        }

        #endregion

        #region ViewNextTicket Tests (3+ tests)

        [Fact]
        public void ViewNextTicket_QueueWithTickets_ShouldReturnFrontWithoutRemoving()
        {
            var desk = new AdmissionsDesk();
            var ticket1 = new Ticket { TicketId = "T001", StudentId = "S001" };
            var ticket2 = new Ticket { TicketId = "T002", StudentId = "S002" };
            desk.IssueAdmissionsTicket(ticket1);
            desk.IssueAdmissionsTicket(ticket2);

            var viewed = desk.ViewNextTicket();

            Assert.Equal("T001", viewed.TicketId);
            Assert.Equal(2, desk.GetQueueCount());
        }

        [Fact]
        public void ViewNextTicket_EmptyQueue_ShouldThrowInvalidOperationException()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<InvalidOperationException>(() => desk.ViewNextTicket());
        }

        [Fact]
        public void ViewNextTicket_MultipleCalls_ShouldReturnSameTicket()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });

            var firstView = desk.ViewNextTicket();
            var secondView = desk.ViewNextTicket();

            Assert.Equal(firstView.TicketId, secondView.TicketId);
            Assert.Equal(1, desk.GetQueueCount());
        }

        #endregion

        #region CheckQueueEmpty Tests (3+ tests)

        [Fact]
        public void CheckQueueEmpty_EmptyQueue_ShouldReturnTrue()
        {
            var desk = new AdmissionsDesk();

            var isEmpty = desk.CheckQueueEmpty();

            Assert.True(isEmpty);
        }

        [Fact]
        public void CheckQueueEmpty_NonEmptyQueue_ShouldReturnFalse()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });

            var isEmpty = desk.CheckQueueEmpty();

            Assert.False(isEmpty);
        }

        [Fact]
        public void CheckQueueEmpty_AfterServingAllTickets_ShouldReturnTrue()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002" });

            desk.ServeNextStudent();
            desk.ServeNextStudent();

            Assert.True(desk.CheckQueueEmpty());
        }

        #endregion

        #region GetQueueCount Tests (3+ tests)

        [Fact]
        public void GetQueueCount_EmptyQueue_ShouldReturnZero()
        {
            var desk = new AdmissionsDesk();

            var count = desk.GetQueueCount();

            Assert.Equal(0, count);
        }

        [Fact]
        public void GetQueueCount_AfterAddingTickets_ShouldReturnCorrectCount()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002" });

            var count = desk.GetQueueCount();

            Assert.Equal(2, count);
        }

        [Fact]
        public void GetQueueCount_AfterServingTickets_ShouldReturnCorrectCount()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T003" });

            desk.ServeNextStudent();
            var count = desk.GetQueueCount();

            Assert.Equal(2, count);
        }

        #endregion

        #region GetTicketsSortedById Tests (3+ tests)

        [Fact]
        public void GetTicketsSortedById_UnsortedTickets_ShouldReturnSortedTickets()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T003", StudentId = "S003" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001", StudentId = "S001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002", StudentId = "S002" });

            var sorted = desk.GetTicketsSortedById();

            Assert.Equal(3, sorted.Length);
            Assert.Equal("T001", sorted[0].TicketId);
            Assert.Equal("T002", sorted[1].TicketId);
            Assert.Equal("T003", sorted[2].TicketId);
        }

        [Fact]
        public void GetTicketsSortedById_EmptyQueue_ShouldReturnEmptyArray()
        {
            var desk = new AdmissionsDesk();

            var sorted = desk.GetTicketsSortedById();

            Assert.Empty(sorted);
        }

        [Fact]
        public void GetTicketsSortedById_SingleTicket_ShouldReturnArrayWithOneTicket()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });

            var sorted = desk.GetTicketsSortedById();

            Assert.Single(sorted);
            Assert.Equal("T001", sorted[0].TicketId);
        }

        #endregion

        #region FindTicketById Tests (3+ tests)

        [Fact]
        public void FindTicketById_ExistingTicket_ShouldReturnTicket()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001", StudentId = "S001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002", StudentId = "S002" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T003", StudentId = "S003" });

            var found = desk.FindTicketById("T002");

            Assert.NotNull(found);
            Assert.Equal("T002", found.TicketId);
            Assert.Equal("S002", found.StudentId);
        }

        [Fact]
        public void FindTicketById_NonExistingTicket_ShouldReturnNull()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002" });

            var found = desk.FindTicketById("T999");

            Assert.Null(found);
        }

        [Fact]
        public void FindTicketById_FirstTicket_ShouldReturnFirstTicket()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T001" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T002" });
            desk.IssueAdmissionsTicket(new Ticket { TicketId = "T003" });

            var found = desk.FindTicketById("T001");

            Assert.NotNull(found);
            Assert.Equal("T001", found.TicketId);
        }

        #endregion
    }
}