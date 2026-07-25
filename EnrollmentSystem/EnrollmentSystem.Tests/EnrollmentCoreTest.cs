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
            var student = new Student(20260001, "Alice", 0.0,"CS102");

            registry.RegisterStudent(student);

            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Alice", registry.GetStudentAt(0).Name);
        }

        [Fact]
        public void RemoveStudent_ShouldDecreaseCount_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            // Use matching constructor and id type for removal
            var student = new Student(20260001, "Alice", 0.0, "CS102");
            registry.RegisterStudent(student);

            bool removed = registry.UnregisterStudent(0);

            Assert.True(removed);
            Assert.Equal(0, registry.GetStudentCount());
        }

        [Fact]
        public void RemoveStudent_ByIdString_ShouldReturnTrue_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            var alice = new Student(20260001, "Alice", 3.5, "CS102");
            var bob = new Student(20260002, "Bob", 2.8, "CS101");
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
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5, "CS102"));
            registry.RegisterStudent(new Student(20260002, "Bob", 2.5, "CS101"));

            double average = registry.CalculateAverageGpa();

            Assert.Equal(3.0, average, 2);
        }

        [Fact]
        public void SearchStudent_ShouldReturnIndex_WhenStudentExists()
        {
            var registry = new StudentRegistry();
            var alice = new Student(20260001, "Alice", 3.5, "CS102");
            var bob = new Student(20260002, "Bob", 2.5, "CS101");
            registry.RegisterStudent(alice);
            registry.RegisterStudent(bob);

            int index = registry.SearchStudent(bob);

            Assert.Equal(1, index);
        }

        [Fact]
        public void UnregisterStudent_MiddleIndex_ShouldRemoveCorrectStudent()
        {
            var registry = new StudentRegistry();

            registry.RegisterStudent(
                new Student(20260001, "Alice", 3.5, "CS102"));

            registry.RegisterStudent(
                new Student(20260002, "Bob", 2.8, "CS101"));

            registry.RegisterStudent(
                new Student(20260003, "Charlie", 3.0, "CS101"));

            bool removed = registry.UnregisterStudent(1);

            Assert.True(removed);
            Assert.Equal(2, registry.GetStudentCount());
            Assert.Equal("Charlie", registry.GetStudentDetails(1).Name);
        }

        [Fact]
        public void GetStudentDetails_FirstIndex_ShouldReturnFirstStudent()
        {
            var registry = new StudentRegistry();

            registry.RegisterStudent(
                new Student(20260001, "Alice", 3.5, "CS102"));

            registry.RegisterStudent(
                new Student(20260002, "Bob", 2.8, "CS101"));

            Student result = registry.GetStudentDetails(0);

            Assert.Equal(20260001, result.Id);
            Assert.Equal("Alice", result.Name);
        }
        [Fact]
        public void ShowAllStudents_OneStudent_ShouldDisplayStudentName()
        {
            var registry = new StudentRegistry();

            registry.RegisterStudent(
                new Student(20260001, "Alice", 3.5, "CS102"));

            var originalOutput = Console.Out;
            using var output = new StringWriter();

            try
            {
                Console.SetOut(output);

                registry.ShowAllStudents();

                Assert.Contains("Alice", output.ToString());
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [Fact]
        public void SortStudentsByGpa_MultipleStudents_ShouldSortAscending()
        {
            var registry = new StudentRegistry();

            registry.RegisterStudent(
                new Student(20260001, "Alice", 3.5, "CS102"));

            registry.RegisterStudent(
                new Student(20260002, "Bob", 2.5, "CS101"));

            registry.RegisterStudent(
                new Student(20260003, "Charlie", 3.0, "CS103"));

            registry.SortStudentsByGpa();

            Assert.Equal("Bob", registry.GetStudentDetails(0).Name);
            Assert.Equal("Charlie", registry.GetStudentDetails(1).Name);
            Assert.Equal("Alice", registry.GetStudentDetails(2).Name);
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

        [Fact]
        public void SearchApplication_ExistingApplication_ReturnsTrue()
        {
            var desk = new AdmissionsDesk();

            var application = new AdmissionApplication(101, "Alice", 80);

            desk.SubmitApplication(application);

            bool result = desk.SearchApplication(application);

            Assert.True(result);
        }

        [Fact]
        public void SearchApplication_MissingApplication_ReturnFalse()
        {
            var desk = new AdmissionsDesk();
            var existingApplication = new AdmissionApplication(101, "Alice", 80);

            var missingApplication = new AdmissionApplication(999, "Unknown", 50);

            desk.SubmitApplication(existingApplication);

            bool result = desk.SearchApplication(missingApplication);

            Assert.False(result);
        }

        [Fact]
        public void SearchApplication_EmptyQueue_ReturnsFalse()
        {
            var desk = new AdmissionsDesk();

            var application = new AdmissionApplication(101, "Alice", 80);

            bool result = desk.SearchApplication(application);

            Assert.False(result);
        }

        [Fact]
        public void SortApplicationsByPriority_HighestPriorityBecomesFirst()
        {
            var desk = new AdmissionsDesk();

            desk.SubmitApplication(
                new AdmissionApplication(101, "Alice", 60));

             desk.SubmitApplication(
                new AdmissionApplication(102, "Bob", 90));

             desk.SubmitApplication(
                new AdmissionApplication(103, "Charlie", 75));

            desk.SortApplicationsByPriority();

            AdmissionApplication firstApplication = desk.ViewNextApplication();

            Assert.Equal(102, firstApplication.ApplicationId);
            Assert.Equal(90, firstApplication.PriorityScore);

        }

        [Fact]
        public void SortApplicationsByPriority_SingleApplicationRemainsFirst()
        {
            var desk = new AdmissionsDesk();
            desk.SubmitApplication(
                new AdmissionApplication(101, "Alice", 89));

            desk.SortApplicationsByPriority();

            AdmissionApplication firstApplication = desk.ViewNextApplication();

            Assert.Equal(101, firstApplication.ApplicationId);

        }

        [Fact]
        public void SortApplicationsByPriority_EmptyQueueDoesNotThrowException()
        {
            var desk = new AdmissionsDesk();

            Exception? error = Record.Exception(() => desk.SortApplicationsByPriority());

            Assert.Null(error);
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
        public void RollbackLastLog_ShouldReturnLatestLog()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            Log result = logs.RollbackLastLog();

            Assert.Equal("L-002", result.LogId);
        }

        [Fact]
        public void RollbackLastLog_ShouldDecreaseCount()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });

            logs.RollbackLastLog();

            Assert.Equal(0, logs.GetLogCount());
        }

        [Fact]
        public void RollbackLastLog_EmptyStack_ShouldThrowException()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.RollbackLastLog());
        }

        [Fact]
        public void SearchLog_ExistingLog_ShouldReturnIndex()
        {
            var logs = new AdministrativeLogs();
            var first = new Log { LogId = "L-001", ActionSummary = "First" };
            var second = new Log { LogId = "L-002", ActionSummary = "Second" };

            logs.PushSystemLog(first);
            logs.PushSystemLog(second);

            int result = logs.SearchLog(second);

            Assert.Equal(1, result);
        }

        [Fact]
        public void SearchLog_MissingLog_ShouldReturnNegativeOne()
        {
            var logs = new AdministrativeLogs();
            var existing = new Log { LogId = "L-001", ActionSummary = "First" };
            var missing = new Log { LogId = "L-999", ActionSummary = "Missing" };

            logs.PushSystemLog(existing);

            int result = logs.SearchLog(missing);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void SearchLog_EmptyStack_ShouldReturnNegativeOne()
        {
            var logs = new AdministrativeLogs();
            var missing = new Log { LogId = "L-999", ActionSummary = "Missing" };

            int result = logs.SearchLog(missing);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void SortLogsById_MultipleLogs_ShouldPlaceLowestIdOnTop()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "Third" });
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            logs.SortLogsById();

            Assert.Equal("L-001", logs.ViewLatestLog().LogId);
        }

        [Fact]
        public void SortLogsById_SingleLog_ShouldRemainOnTop()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });

            logs.SortLogsById();

            Assert.Equal("L-001", logs.ViewLatestLog().LogId);
        }

        [Fact]
        public void SortLogsById_EmptyStack_ShouldNotThrowException()
        {
            var logs = new AdministrativeLogs();

            Exception? error = Record.Exception(() => logs.SortLogsById());

            Assert.Null(error);
        }
    }
}
