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
}