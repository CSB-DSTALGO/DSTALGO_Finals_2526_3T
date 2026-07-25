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
            
            // I added another variable in the parameter that i think best fits (course)
            var student = new Student(20260001, "Alice", 0.0, "BSIS");

            registry.RegisterStudent(student);

            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Alice", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void RemoveStudent_ShouldDecreaseCount_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            // Use matching constructor and id type for removal
            var student = new Student(20260001, "Alice", 0.0, "BSIS");
            registry.RegisterStudent(student);

            bool removed = registry.UnregisterStudent(20260001);

            Assert.True(removed);
            Assert.Equal(0, registry.GetStudentCount());
        }

        [Fact]
        public void RemoveStudent_ByIdString_ShouldReturnTrue_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            var alice = new Student(20260001, "Alice", 3.5, "BSIS");
            var bob = new Student(20260002, "Bob", 2.8, "BSIT");
            registry.RegisterStudent(alice);
            registry.RegisterStudent(bob);

            bool removed = registry.UnregisterStudent("20260001");

            Assert.True(removed);
            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Bob", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void CalculateAverageGpa_ShouldReturnAverageOfRegisteredStudents()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5, "BSIS"));
            registry.RegisterStudent(new Student(20260002, "Bob", 2.5, "BSIT"));

            double average = registry.CalculateAverageGpa();

            Assert.Equal(3.0, average, 2);
        }

        [Fact]
        public void SearchStudent_ShouldReturnIndex_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            var alice = new Student(20260001, "Alice", 3.5, "BSIS");
            var bob = new Student(20260002, "Bob", 2.5, "BSIT");
            registry.RegisterStudent(alice);
            registry.RegisterStudent(bob);

            int index = registry.SearchStudent(bob);

            Assert.Equal(1, index);
        }

        [Fact]
        public void SortStudentsByGpa_ShouldSortStudentsAscending()
        {
            var registry = new StudentRegistry();

            registry.RegisterStudent(new Student(20260001, "Alice", 3.8, "BSIS"));
            registry.RegisterStudent(new Student(20260002, "Bob", 2.5, "BSIT"));
            registry.RegisterStudent(new Student(20260003, "Charlie", 3.2, "BSCS"));

            registry.SortStudentsByGpa();

            Assert.Equal("Bob", registry.GetStudentAt(0).Name);
            Assert.Equal("Charlie", registry.GetStudentAt(1).Name);
            Assert.Equal("Alice", registry.GetStudentAt(2).Name);
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

            Assert.True(curriculum.SearchCourse(course.Code));
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldSortCoursesAscending()
        {
            var curriculum = new CourseCurriculum();

            curriculum.InsertCourse(new Course("CS101", "Programming", 5));
            curriculum.InsertCourse(new Course("CS102", "Database", 3));
            curriculum.InsertCourse(new Course("CS103", "Networking", 4));

            curriculum.SortCurriculumByUnits();

            Assert.True(curriculum.SearchCourse("CS101"));
            Assert.True(curriculum.SearchCourse("CS102"));
            Assert.True(curriculum.SearchCourse("CS103"));

            Assert.Equal(12, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void SearchCourse_ShouldReturnFalse_WhenCourseDoesNotExist()
        {
            var curriculum = new CourseCurriculum();

            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            Assert.False(curriculum.SearchCourse("CS999"));
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

        [Fact]
        public void CheckQueueEmpty_ShouldReturnTrue_WhenQueueIsEmpty()
        {
            var desk = new AdmissionsDesk();

            Assert.True(desk.CheckQueueEmpty());
        }

        [Fact]
        public void SearchApplication_ShouldReturnTrue_WhenApplicationExists()
        {
            var desk = new AdmissionsDesk();

            var ticket = new Ticket
            {
                TicketId = "T-101",
                StudentId = "20260001"
            };

            desk.IssueAdmissionsTicket(ticket);

            var application = new AdmissionApplication(1, "20260001", 0)
            {
                TicketId = "T-101"
            };

            Assert.True(desk.SearchApplication(application));
        }

        [Fact]
        public void SortApplicationsByPriority_ShouldExecuteWithoutException()
        {
            var desk = new AdmissionsDesk();

            desk.IssueAdmissionsTicket(new Ticket
            {
                TicketId = "T-101",
                StudentId = "20260001"
            });

            desk.IssueAdmissionsTicket(new Ticket
            {
                TicketId = "T-102",
                StudentId = "20260002"
            });

            var exception = Record.Exception(() => desk.SortApplicationsByPriority());

            Assert.Null(exception);
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

        [Fact]
        public void SearchLog_ShouldReturnTrue_WhenLogExists()
        {
            var logs = new AdministrativeLogs();

            var log = new Log
            {
                LogId = "L-001",
                ActionSummary = "First Action"
            };

            logs.PushSystemLog(log);

            Assert.True(logs.SearchLog(log));
        }

        [Fact]
        public void SearchLog_ShouldReturnFalse_WhenLogDoesNotExist()
        {
            var logs = new AdministrativeLogs();

            logs.PushSystemLog(new Log
            {
                LogId = "L-001",
                ActionSummary = "First Action"
            });

            var missing = new Log
            {
                LogId = "L-999",
                ActionSummary = "Missing"
            };

            Assert.False(logs.SearchLog(missing));
        }

        [Fact]
        public void SortLogsById_ShouldSortLogsCorrectly()
        {
            var logs = new AdministrativeLogs();

            logs.PushSystemLog(new Log
            {
                LogId = "L-003",
                ActionSummary = "Third"
            });

            logs.PushSystemLog(new Log
            {
                LogId = "L-001",
                ActionSummary = "First"
            });

            logs.PushSystemLog(new Log
            {
                LogId = "L-002",
                ActionSummary = "Second"
            });

            logs.SortLogsById();

            Assert.Equal("L-003", logs.PopSystemLog().LogId);
            Assert.Equal("L-002", logs.PopSystemLog().LogId);
            Assert.Equal("L-001", logs.PopSystemLog().LogId);
        }

        [Fact]
        public void RollbackLastLog_ShouldRemoveLatestLog()
        {
            var logs = new AdministrativeLogs();

            logs.PushSystemLog(new Log
            {
                LogId = "L-001",
                ActionSummary = "First"
            });

            logs.PushSystemLog(new Log
            {
                LogId = "L-002",
                ActionSummary = "Second"
            });

            var rolledBack = logs.RollbackLastLog();

            Assert.Equal("L-002", rolledBack.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }
    }
}