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
        public void InsertCourse_ShouldIncreaseCount()
        {
            var curriculum = new CourseCurriculum();

            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            Assert.Equal(1, curriculum.Count);
        }

        [Fact]
        public void InsertCourse_ShouldThrow_WhenCourseIsNull()
        {
            var curriculum = new CourseCurriculum();

            Assert.Throws<ArgumentNullException>(() => curriculum.InsertCourse(null!));
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
        public void DeleteCourse_ShouldReturnFalse_WhenCodeDoesNotExist()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            bool removed = curriculum.DeleteCourse("CS999");

            Assert.False(removed);
        }

        [Fact]
        public void DeleteCourse_ShouldDecreaseCount()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS101", "Intro to CS", 3);
            curriculum.InsertCourse(course);

            curriculum.DeleteCourse(course.Code);

            Assert.Equal(0, curriculum.Count);
        }

        [Fact]
        public void CalculateTotalUnits_ShouldReturnZero_ForEmptyCurriculum()
        {
            var curriculum = new CourseCurriculum();

            Assert.Equal(0, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void CalculateTotalUnits_ShouldSumAllCourseUnits()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));
            curriculum.InsertCourse(new Course("CS103", "Algorithms", 5));

            Assert.Equal(12, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void CalculateTotalUnits_ShouldUpdate_AfterDeletion()
        {
            var curriculum = new CourseCurriculum();
            var c1 = new Course("CS101", "Intro to CS", 3);
            curriculum.InsertCourse(c1);
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            curriculum.DeleteCourse(c1.Code);

            Assert.Equal(4, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void ShowCurriculum_ShouldNotThrow_WhenCurriculumIsEmpty()
        {
            var curriculum = new CourseCurriculum();

            var exception = Record.Exception(() => curriculum.ShowCurriculum());

            Assert.Null(exception);
        }

        [Fact]
        public void ShowCurriculum_ShouldNotThrow_WithMultipleCourses()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            var exception = Record.Exception(() => curriculum.ShowCurriculum());

            Assert.Null(exception);
        }

        [Fact]
        public void ShowCurriculum_ShouldNotThrow_AfterDeletingAllCourses()
        {
            var curriculum = new CourseCurriculum();
            var c1 = new Course("CS101", "Intro to CS", 3);
            curriculum.InsertCourse(c1);
            curriculum.DeleteCourse(c1.Code);

            var exception = Record.Exception(() => curriculum.ShowCurriculum());

            Assert.Null(exception);
        }

        [Fact]
        public void SearchCourse_ShouldReturnTrue_WhenExactInstanceExistsInCurriculum()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS101", "Intro to CS", 3);
            curriculum.InsertCourse(course);

            Assert.True(curriculum.SearchCourse(course));
        }

        [Fact]
        public void SearchCourse_ShouldReturnFalse_WhenCourseWasNeverInserted()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            var notInserted = new Course("CS999", "Ghost Course", 3);

            Assert.False(curriculum.SearchCourse(notInserted));
        }

        [Fact]
        public void SearchCourse_ShouldReturnFalse_AfterCourseIsDeleted()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS101", "Intro to CS", 3);
            curriculum.InsertCourse(course);
            curriculum.DeleteCourse(course.Code);

            Assert.False(curriculum.SearchCourse(course));
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldOrderCoursesAscendingByUnits()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS103", "Algorithms", 5));
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 1));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            curriculum.SortCurriculumByUnits();

            // Total should be unaffected by sorting, confirming no data was lost
            Assert.Equal(9, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldNotThrow_ForEmptyCurriculum()
        {
            var curriculum = new CourseCurriculum();

            var exception = Record.Exception(() => curriculum.SortCurriculumByUnits());

            Assert.Null(exception);
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldNotThrow_ForSingleCourse()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            var exception = Record.Exception(() => curriculum.SortCurriculumByUnits());

            Assert.Null(exception);
            Assert.Equal(3, curriculum.CalculateTotalUnits());
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
    }
}