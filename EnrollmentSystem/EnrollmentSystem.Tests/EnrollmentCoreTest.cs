// 12521269 Joaquin Bryan G. Ross
using System;
using System.IO;
using Xunit;
using EnrollmentSystem.Core;

// xUnit runs separate test classes in parallel by default. The Show methods are
// asserted by redirecting Console.Out, which is process-wide global state, so two
// classes capturing at once would steal each other's output and fail at random.
// Running this assembly serially removes the race.
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace EnrollmentSystem.Tests
{
    public class StudentRegistryTests
    {
        // --- RegisterStudent ---

        [Fact]
        public void RegisterStudent_ShouldAddStudentAndIncreaseCount()
        {
            var registry = new StudentRegistry();
            // Student constructor requires (int id, string name, double gpa)
            var student = new Student(20260001, "Alice", 0.0);

            registry.RegisterStudent(student);

            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Alice", registry.GetStudentDetails(0).Name);
        }

        [Fact]
        public void RegisterStudent_ShouldAppendInRegistrationOrder()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bruno", 2.8));

            Assert.Equal("Alice", registry.GetStudentDetails(0).Name);
            Assert.Equal("Bruno", registry.GetStudentDetails(1).Name);
        }

        [Fact]
        public void RegisterStudent_ShouldKeepRecords_WhenRegistryGrowsPastInitialCapacity()
        {
            // The array list starts with four slots, so ten students force a resize.
            var registry = new StudentRegistry();

            for (int i = 0; i < 10; i++)
            {
                registry.RegisterStudent(new Student(20260000 + i, $"Student {i}", 1.0));
            }

            Assert.Equal(10, registry.GetStudentCount());
            Assert.Equal("Student 9", registry.GetStudentDetails(9).Name);
        }

        // --- UnregisterStudent (removes by student id) ---

        [Fact]
        public void UnregisterStudent_ShouldDecreaseCount_WhenStudentIdExists()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 0.0));

            // The instructor's test passes the student id, not an array index.
            bool removed = registry.UnregisterStudent(20260001);

            Assert.True(removed);
            Assert.Equal(0, registry.GetStudentCount());
        }

        [Fact]
        public void UnregisterStudent_ShouldReturnFalse_WhenStudentIdIsNotRegistered()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 0.0));

            Assert.False(registry.UnregisterStudent(29999999));
            Assert.Equal(1, registry.GetStudentCount());
        }

        [Fact]
        public void UnregisterStudent_ShouldShiftLaterRecordsDown()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bruno", 2.8));
            registry.RegisterStudent(new Student(20260003, "Cara", 3.9));

            registry.UnregisterStudent(20260002);

            Assert.Equal("Alice", registry.GetStudentDetails(0).Name);
            Assert.Equal("Cara", registry.GetStudentDetails(1).Name); // slid down from index 2
        }

        // --- RemoveStudent (removes by student id given as a string) ---

        [Fact]
        public void RemoveStudent_ShouldReturnTrue_WhenStudentIdExists()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bruno", 2.8));

            bool removed = registry.RemoveStudent("20260001");

            Assert.True(removed);
            Assert.Equal(1, registry.GetStudentCount());
            Assert.Equal("Bruno", registry.GetStudentDetails(0).Name);
        }

        [Fact]
        public void RemoveStudent_ShouldReturnFalse_WhenIdIsNotRegistered()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));

            Assert.False(registry.RemoveStudent("29999999"));
            Assert.Equal(1, registry.GetStudentCount());
        }

        [Fact]
        public void RemoveStudent_ShouldReturnFalse_ForAnEmptyRegistry()
        {
            var registry = new StudentRegistry();

            Assert.False(registry.RemoveStudent("20260001"));
        }

        // --- CalculateAverageGpa ---

        [Fact]
        public void CalculateAverageGpa_ShouldAverageEveryRegisteredStudent()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bruno", 2.5));

            Assert.Equal(3.0, registry.CalculateAverageGpa(), 2);
        }

        [Fact]
        public void CalculateAverageGpa_ShouldReturnZero_ForAnEmptyRegistry()
        {
            var registry = new StudentRegistry();

            Assert.Equal(0.0, registry.CalculateAverageGpa());
        }

        [Fact]
        public void CalculateAverageGpa_ShouldFollowRemovals()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 4.0));
            registry.RegisterStudent(new Student(20260002, "Bruno", 2.0));

            registry.UnregisterStudent(20260002);

            Assert.Equal(4.0, registry.CalculateAverageGpa(), 2);
        }

        // --- GetStudentDetails ---

        [Fact]
        public void GetStudentDetails_ShouldReturnTheRecordAtThatIndex()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bruno", 2.8));

            Assert.Equal(20260002, registry.GetStudentDetails(1).Id);
        }

        [Fact]
        public void GetStudentDetails_ShouldThrow_WhenIndexIsNegative()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));

            Assert.Throws<ArgumentOutOfRangeException>(() => registry.GetStudentDetails(-1));
        }

        [Fact]
        public void GetStudentDetails_ShouldThrow_WhenIndexIsBeyondTheRegistry()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));

            Assert.Throws<ArgumentOutOfRangeException>(() => registry.GetStudentDetails(1));
        }

        // --- ShowAllStudents ---

        [Fact]
        public void ShowAllStudents_ShouldWriteOneLinePerStudent()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bruno", 2.8));

            string output = TestConsole.Capture(registry.ShowAllStudents);

            Assert.Contains("Alice", output);
            Assert.Contains("Bruno", output);
            Assert.Equal(2, TestConsole.CountLines(output));
        }

        [Fact]
        public void ShowAllStudents_ShouldReportAnEmptyRegistry()
        {
            var registry = new StudentRegistry();

            string output = TestConsole.Capture(registry.ShowAllStudents);

            Assert.Contains("No students", output, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void ShowAllStudents_ShouldListRecordsInRegistryOrder()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "HighGpa", 4.0));
            registry.RegisterStudent(new Student(20260002, "LowGpa", 1.0));

            registry.SortStudentsByGpa();
            string output = TestConsole.Capture(registry.ShowAllStudents);

            Assert.True(output.IndexOf("LowGpa", StringComparison.Ordinal)
                      < output.IndexOf("HighGpa", StringComparison.Ordinal));
        }
        // --- SearchStudent ---

        [Fact]
        public void SearchStudent_ShouldReturnTheIndex_WhenStudentIsRegistered()
        {
            var registry = new StudentRegistry();
            var target = new Student(20260002, "Bruno", 2.8);
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(target);

            Assert.Equal(1, registry.SearchStudent(target));
        }

        [Fact]
        public void SearchStudent_ShouldReturnMinusOne_WhenStudentIsNotRegistered()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));

            Assert.Equal(-1, registry.SearchStudent(new Student(29999999, "Nobody", 0.0)));
        }

        [Fact]
        public void SearchStudent_ShouldReturnMinusOne_ForAnEmptyRegistry()
        {
            var registry = new StudentRegistry();

            Assert.Equal(-1, registry.SearchStudent(new Student(20260001, "Alice", 3.5)));
        }

        // --- SortStudentsByGpa ---

        [Fact]
        public void SortStudentsByGpa_ShouldOrderAscendingByGpa()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "High", 4.0));
            registry.RegisterStudent(new Student(20260002, "Low", 1.5));
            registry.RegisterStudent(new Student(20260003, "Mid", 3.0));

            registry.SortStudentsByGpa();

            Assert.Equal("Low", registry.GetStudentDetails(0).Name);
            Assert.Equal("Mid", registry.GetStudentDetails(1).Name);
            Assert.Equal("High", registry.GetStudentDetails(2).Name);
        }

        [Fact]
        public void SortStudentsByGpa_ShouldKeepEveryRecord()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "High", 4.0));
            registry.RegisterStudent(new Student(20260002, "Low", 1.5));

            registry.SortStudentsByGpa();

            Assert.Equal(2, registry.GetStudentCount());
        }

        [Fact]
        public void SortStudentsByGpa_ShouldHandleEmptyAndSingleRecordRegistries()
        {
            var empty = new StudentRegistry();
            var single = new StudentRegistry();
            single.RegisterStudent(new Student(20260001, "Alice", 3.5));

            empty.SortStudentsByGpa();
            single.SortStudentsByGpa();

            Assert.Equal(0, empty.GetStudentCount());
            Assert.Equal("Alice", single.GetStudentDetails(0).Name);
        }
    }

    public class CourseCurriculumTests
    {
        // --- InsertCourse ---

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
        public void InsertCourse_ShouldAppendToTheTailOfTheChain()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            Assert.Equal("CS101", curriculum.SearchCourse("CS101")!.Code);
            Assert.Equal(2, curriculum.Count);
        }

        [Fact]
        public void InsertCourse_ShouldIncrementCount()
        {
            var curriculum = new CourseCurriculum();

            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            Assert.Equal(2, curriculum.Count);
        }

        // --- DeleteCourse ---

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
        public void DeleteCourse_ShouldReturnFalse_WhenCodeIsNotInTheCurriculum()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            Assert.False(curriculum.DeleteCourse("MATH999"));
            Assert.Equal(1, curriculum.Count);
        }

        [Fact]
        public void DeleteCourse_ShouldRemoveTheTailNode()
        {
            // The tail is reached last by the traversal, so it exercises a
            // different re-linking path than removing the head.
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            bool removed = curriculum.DeleteCourse("CS102");

            Assert.True(removed);
            Assert.Equal(3, curriculum.CalculateTotalUnits());
            Assert.Null(curriculum.SearchCourse("CS102"));
        }

        // --- SearchCourse ---

        [Fact]
        public void SearchCourse_ShouldReturnTheCourse_WhenCodeExists()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            Course? found = curriculum.SearchCourse("CS102");

            Assert.NotNull(found);
            Assert.Equal("Data Structures", found!.Title);
        }

        [Fact]
        public void SearchCourse_ShouldReturnNull_WhenCodeIsAbsent()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            Assert.Null(curriculum.SearchCourse("MATH999"));
        }

        [Fact]
        public void SearchCourse_ShouldIgnoreCaseOnTheCourseCode()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            Assert.NotNull(curriculum.SearchCourse("cs101"));
        }

        // --- SearchCourse by object (the overload the instructor's test uses) ---

        [Fact]
        public void SearchCourseByObject_ShouldReturnTrue_WhenTheCourseIsInTheChain()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS102", "Data Structures", 4);
            curriculum.InsertCourse(course);

            Assert.True(curriculum.SearchCourse(course));
        }

        [Fact]
        public void SearchCourseByObject_ShouldReturnFalse_WhenTheCourseIsAbsent()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            Assert.False(curriculum.SearchCourse(new Course("MATH999", "Missing", 3)));
        }

        [Fact]
        public void SearchCourseByObject_ShouldReturnFalse_ForAnEmptyCurriculum()
        {
            var curriculum = new CourseCurriculum();

            Assert.False(curriculum.SearchCourse(new Course("CS101", "Intro to CS", 3)));
        }

        // --- CalculateTotalUnits ---

        [Fact]
        public void CalculateTotalUnits_ShouldSumEveryCourse()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            Assert.Equal(7, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void CalculateTotalUnits_ShouldReturnZero_ForAnEmptyCurriculum()
        {
            var curriculum = new CourseCurriculum();

            Assert.Equal(0, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void CalculateTotalUnits_ShouldBeUnaffectedBySorting()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            int before = curriculum.CalculateTotalUnits();
            curriculum.SortCurriculumByUnits();

            Assert.Equal(before, curriculum.CalculateTotalUnits());
        }

        // --- ShowCurriculum ---

        [Fact]
        public void ShowCurriculum_ShouldWriteOneLinePerCourse()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            string output = TestConsole.Capture(curriculum.ShowCurriculum);

            Assert.Contains("CS101", output);
            Assert.Contains("CS102", output);
            Assert.Equal(2, TestConsole.CountLines(output));
        }

        [Fact]
        public void ShowCurriculum_ShouldReportAnEmptyCurriculum()
        {
            var curriculum = new CourseCurriculum();

            string output = TestConsole.Capture(curriculum.ShowCurriculum);

            Assert.Contains("empty", output, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void ShowCurriculum_ShouldTraverseInChainOrder()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("HEAVY", "Thesis", 6));
            curriculum.InsertCourse(new Course("LIGHT", "Elective", 1));

            curriculum.SortCurriculumByUnits();
            string output = TestConsole.Capture(curriculum.ShowCurriculum);

            Assert.True(output.IndexOf("LIGHT", StringComparison.Ordinal)
                      < output.IndexOf("HEAVY", StringComparison.Ordinal));
        }

        // --- SortCurriculumByUnits ---

        [Fact]
        public void SortCurriculumByUnits_ShouldPutTheLightestCourseAtTheHead()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS301", "Thesis", 6));
            curriculum.InsertCourse(new Course("CS101", "Elective", 1));
            curriculum.InsertCourse(new Course("CS201", "Data Structures", 3));

            curriculum.SortCurriculumByUnits();

            // ShowCurriculum traverses from the head, so the lightest course
            // must be the first line printed.
            string output = TestConsole.Capture(curriculum.ShowCurriculum);
            Assert.StartsWith("[0] CS101", output);
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldKeepEveryCourse()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS301", "Thesis", 6));
            curriculum.InsertCourse(new Course("CS101", "Elective", 1));

            curriculum.SortCurriculumByUnits();

            Assert.Equal(2, curriculum.Count);
            Assert.NotNull(curriculum.SearchCourse("CS301"));
            Assert.NotNull(curriculum.SearchCourse("CS101"));
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldHandleEmptyAndSingleCourseCurriculums()
        {
            var empty = new CourseCurriculum();
            var single = new CourseCurriculum();
            single.InsertCourse(new Course("CS101", "Intro to CS", 3));

            empty.SortCurriculumByUnits();
            single.SortCurriculumByUnits();

            Assert.Equal(0, empty.Count);
            Assert.NotNull(single.SearchCourse("CS101"));
        }
    }

    public class AdmissionsDeskTests
    {
        // --- IssueAdmissionsTicket ---

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
        public void IssueAdmissionsTicket_ShouldIncrementTheQueueCount()
        {
            var desk = new AdmissionsDesk();

            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });
            desk.IssueAdmissionsTicket(new Ticket { LogId = 2, TicketId = "T-102" });

            Assert.Equal(2, desk.GetQueueCount());
        }

        [Fact]
        public void IssueAdmissionsTicket_ShouldKeepOrder_WhenTheBufferWrapsAndGrows()
        {
            // Interleaving keeps the front index advancing, so the circular
            // buffer wraps before it grows. That is where an off-by-one hides.
            var desk = new AdmissionsDesk();

            for (int i = 0; i < 6; i++)
            {
                desk.IssueAdmissionsTicket(new Ticket { LogId = i, TicketId = $"WARM-{i}" });
                desk.ServeNextStudent();
            }

            for (int i = 0; i < 10; i++)
            {
                desk.IssueAdmissionsTicket(new Ticket { LogId = 100 + i, TicketId = $"T-{100 + i}" });
            }

            Assert.Equal(10, desk.GetQueueCount());
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal($"T-{100 + i}", desk.ServeNextStudent().TicketId);
            }
        }

        // --- ServeNextStudent ---

        [Fact]
        public void ServeNextStudent_ShouldThrowException_WhenQueueIsEmpty()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<InvalidOperationException>(() => desk.ServeNextStudent());
        }

        [Fact]
        public void ServeNextStudent_ShouldRemoveTheTicketFromTheLine()
        {
            var desk = new AdmissionsDesk();
            var ticket = new Ticket { LogId = 1, TicketId = "T-101" };
            desk.IssueAdmissionsTicket(ticket);

            desk.ServeNextStudent();

            Assert.Equal(0, desk.GetQueueCount());
            Assert.False(desk.SearchTicket(ticket));
        }

        [Fact]
        public void ServeNextStudent_ShouldThrow_WhenTheLineHasBeenCleared()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });
            desk.ServeNextStudent();

            Assert.Throws<InvalidOperationException>(() => desk.ServeNextStudent());
        }

        // --- ViewNextTicket ---

        [Fact]
        public void ViewNextTicket_ShouldReturnTheFrontTicketWithoutServingIt()
        {
            var desk = new AdmissionsDesk();
            var first = new Ticket { LogId = 1, TicketId = "T-101" };
            desk.IssueAdmissionsTicket(first);
            desk.IssueAdmissionsTicket(new Ticket { LogId = 2, TicketId = "T-102" });

            Assert.Equal("T-101", desk.ViewNextTicket().TicketId);
            Assert.Equal(2, desk.GetQueueCount());
        }

        [Fact]
        public void ViewNextTicket_ShouldFollowTheFront_AfterServing()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });
            desk.IssueAdmissionsTicket(new Ticket { LogId = 2, TicketId = "T-102" });

            desk.ServeNextStudent();

            Assert.Equal("T-102", desk.ViewNextTicket().TicketId);
        }

        [Fact]
        public void ViewNextTicket_ShouldThrow_WhenQueueIsEmpty()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<InvalidOperationException>(() => desk.ViewNextTicket());
        }

        // --- CheckQueueEmpty ---

        [Fact]
        public void CheckQueueEmpty_ShouldBeTrue_ForANewDesk()
        {
            var desk = new AdmissionsDesk();

            Assert.True(desk.CheckQueueEmpty());
        }

        [Fact]
        public void CheckQueueEmpty_ShouldBeFalse_WhenStudentsAreWaiting()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });

            Assert.False(desk.CheckQueueEmpty());
        }

        [Fact]
        public void CheckQueueEmpty_ShouldBeTrue_AfterEveryoneIsServed()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });
            desk.ServeNextStudent();

            Assert.True(desk.CheckQueueEmpty());
        }

        // --- SearchTicket ---

        [Fact]
        public void SearchTicket_ShouldFindTheTicketWithoutDisturbingTheLine()
        {
            var desk = new AdmissionsDesk();
            var first = new Ticket { LogId = 1, TicketId = "T-101" };
            var second = new Ticket { LogId = 2, TicketId = "T-102" };
            desk.IssueAdmissionsTicket(first);
            desk.IssueAdmissionsTicket(second);

            Assert.True(desk.SearchTicket(second));
            Assert.Equal(2, desk.GetQueueCount());
            Assert.Equal("T-101", desk.ViewNextTicket().TicketId);
        }

        [Fact]
        public void SearchTicket_ShouldReturnFalse_WhenTheTicketWasNeverIssued()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });

            Assert.False(desk.SearchTicket(new Ticket { LogId = 99, TicketId = "T-999" }));
        }

        [Fact]
        public void SearchTicket_ShouldReturnFalse_ForAnAlreadyServedTicket()
        {
            var desk = new AdmissionsDesk();
            var served = new Ticket { LogId = 1, TicketId = "T-101" };
            var waiting = new Ticket { LogId = 2, TicketId = "T-102" };
            desk.IssueAdmissionsTicket(served);
            desk.IssueAdmissionsTicket(waiting);

            desk.ServeNextStudent();

            Assert.False(desk.SearchTicket(served));
            Assert.True(desk.SearchTicket(waiting));
        }

        // --- SortTicketsById ---

        [Fact]
        public void SortTicketsById_ShouldServeTheLowestIdFirst()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { LogId = 3, TicketId = "T-103" });
            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });
            desk.IssueAdmissionsTicket(new Ticket { LogId = 2, TicketId = "T-102" });

            desk.SortTicketsById();

            Assert.Equal("T-101", desk.ServeNextStudent().TicketId);
            Assert.Equal("T-102", desk.ServeNextStudent().TicketId);
            Assert.Equal("T-103", desk.ServeNextStudent().TicketId);
        }

        [Fact]
        public void SortTicketsById_ShouldKeepEveryTicketQueued()
        {
            var desk = new AdmissionsDesk();
            var t1 = new Ticket { LogId = 3, TicketId = "T-103" };
            var t2 = new Ticket { LogId = 1, TicketId = "T-101" };
            desk.IssueAdmissionsTicket(t1);
            desk.IssueAdmissionsTicket(t2);

            desk.SortTicketsById();

            Assert.Equal(2, desk.GetQueueCount());
            Assert.True(desk.SearchTicket(t1));
            Assert.True(desk.SearchTicket(t2));
        }

        [Fact]
        public void SortTicketsById_ShouldSortCorrectly_AfterAStudentWasServed()
        {
            // Serving advances the front pointer, so this sorts a queue whose
            // storage has already shifted underneath it.
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { LogId = 9, TicketId = "T-109" });
            desk.ServeNextStudent();

            desk.IssueAdmissionsTicket(new Ticket { LogId = 3, TicketId = "T-103" });
            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });

            desk.SortTicketsById();

            Assert.Equal("T-101", desk.ServeNextStudent().TicketId);
            Assert.Equal("T-103", desk.ServeNextStudent().TicketId);
        }
    }

    public class AdministrativeLogsTests
    {
        // --- PushSystemLog ---

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
        public void PushSystemLog_ShouldIncrementTheLogCount()
        {
            var logs = new AdministrativeLogs();

            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            Assert.Equal(2, logs.GetLogCount());
        }

        [Fact]
        public void PushSystemLog_ShouldKeepHistory_WhenItGrowsPastInitialCapacity()
        {
            // The stack starts with four slots, so ten logs force a resize.
            var logs = new AdministrativeLogs();

            for (int i = 0; i < 10; i++)
            {
                logs.PushSystemLog(new Log { LogId = $"L-{i:D3}", ActionSummary = $"Action {i}" });
            }

            Assert.Equal(10, logs.GetLogCount());
            Assert.Equal("L-009", logs.ViewLatestLog().LogId);
        }

        // --- RollbackLastLog ---

        [Fact]
        public void RollbackLastLog_ShouldRemoveTheNewestLog()
        {
            var logs = new AdministrativeLogs();
            var older = new Log { LogId = "L-001", ActionSummary = "First" };
            var newest = new Log { LogId = "L-002", ActionSummary = "Second" };
            logs.PushSystemLog(older);
            logs.PushSystemLog(newest);

            Assert.Equal("L-002", logs.RollbackLastLog().LogId);
            Assert.Equal("L-001", logs.ViewLatestLog().LogId);
        }

        [Fact]
        public void RollbackLastLog_ShouldThrow_WhenNoLogsExist()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.RollbackLastLog());
        }

        [Fact]
        public void RollbackLastLog_ShouldThrow_WhenEveryLogHasBeenRolledBack()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.RollbackLastLog();

            Assert.Throws<InvalidOperationException>(() => logs.RollbackLastLog());
        }

        // --- ViewLatestLog ---

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
        public void ViewLatestLog_ShouldFollowTheMostRecentPush()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            logs.RollbackLastLog();

            Assert.Equal("L-001", logs.ViewLatestLog().LogId);
        }

        [Fact]
        public void ViewLatestLog_ShouldThrow_WhenNoLogsExist()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.ViewLatestLog());
        }

        // --- CheckLogsEmpty ---

        [Fact]
        public void CheckLogsEmpty_ShouldBeTrue_ForANewLogStack()
        {
            var logs = new AdministrativeLogs();

            Assert.True(logs.CheckLogsEmpty());
        }

        [Fact]
        public void CheckLogsEmpty_ShouldBeFalse_WhenLogsAreRecorded()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "Action" });

            Assert.False(logs.CheckLogsEmpty());
        }

        [Fact]
        public void CheckLogsEmpty_ShouldBeTrue_AfterEveryLogIsRolledBack()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "Action" });
            logs.RollbackLastLog();

            Assert.True(logs.CheckLogsEmpty());
        }

        // --- SearchLog ---

        [Fact]
        public void SearchLog_ShouldReturnDepthFromTop()
        {
            var logs = new AdministrativeLogs();
            var first = new Log { LogId = "L-001", ActionSummary = "First" };
            var second = new Log { LogId = "L-002", ActionSummary = "Second" };
            var third = new Log { LogId = "L-003", ActionSummary = "Third" };
            logs.PushSystemLog(first);
            logs.PushSystemLog(second);
            logs.PushSystemLog(third);

            Assert.Equal(1, logs.SearchLog(third));  // top
            Assert.Equal(3, logs.SearchLog(first));  // bottom
        }

        [Fact]
        public void SearchLog_ShouldReturnMinusOne_WhenTheLogWasNeverPushed()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "Action" });

            Assert.Equal(-1, logs.SearchLog(new Log { LogId = "L-999", ActionSummary = "Missing" }));
        }

        [Fact]
        public void SearchLog_ShouldLeaveTheStackIntact()
        {
            var logs = new AdministrativeLogs();
            var first = new Log { LogId = "L-001", ActionSummary = "First" };
            var newest = new Log { LogId = "L-002", ActionSummary = "Second" };
            logs.PushSystemLog(first);
            logs.PushSystemLog(newest);

            logs.SearchLog(first);

            Assert.Equal(2, logs.GetLogCount());
            Assert.Equal("L-002", logs.ViewLatestLog().LogId);
        }

        // --- SortLogsById ---

        [Fact]
        public void SortLogsById_ShouldPutTheLowestIdOnTop()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "Third" });
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            logs.SortLogsById();

            Assert.Equal("L-001", logs.ViewLatestLog().LogId);
        }

        [Fact]
        public void SortLogsById_ShouldMakeRollbackWalkIdsAscending()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-003", ActionSummary = "Third" });
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            logs.SortLogsById();

            Assert.Equal("L-001", logs.RollbackLastLog().LogId);
            Assert.Equal("L-002", logs.RollbackLastLog().LogId);
            Assert.Equal("L-003", logs.RollbackLastLog().LogId);
        }

        [Fact]
        public void SortLogsById_ShouldKeepEveryLog()
        {
            var logs = new AdministrativeLogs();
            var a = new Log { LogId = "L-003", ActionSummary = "Third" };
            var b = new Log { LogId = "L-001", ActionSummary = "First" };
            logs.PushSystemLog(a);
            logs.PushSystemLog(b);

            logs.SortLogsById();

            Assert.Equal(2, logs.GetLogCount());
            Assert.NotEqual(-1, logs.SearchLog(a));
            Assert.NotEqual(-1, logs.SearchLog(b));
        }
    }

    // Members the project scaffold shipped, kept alongside the requirement
    // table names so nothing from the original project is missing.
    public class ScaffoldCompatibilityTests
    {
        // --- StudentRegistry.GetStudentAt ---

        [Fact]
        public void GetStudentAt_ShouldMatchGetStudentDetails()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));
            registry.RegisterStudent(new Student(20260002, "Bruno", 2.8));

            Assert.Equal(registry.GetStudentDetails(1), registry.GetStudentAt(1));
        }

        [Fact]
        public void GetStudentAt_ShouldThrow_WhenIndexIsNegative()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));

            Assert.Throws<ArgumentOutOfRangeException>(() => registry.GetStudentAt(-1));
        }

        [Fact]
        public void GetStudentAt_ShouldThrow_WhenIndexIsBeyondTheRegistry()
        {
            var registry = new StudentRegistry();
            registry.RegisterStudent(new Student(20260001, "Alice", 3.5));

            Assert.Throws<ArgumentOutOfRangeException>(() => registry.GetStudentAt(1));
        }
        // --- AdmissionsDesk.ServeNextTicket ---

        [Fact]
        public void ServeNextTicket_ShouldDequeueTheFrontTicket()
        {
            var desk = new AdmissionsDesk();
            desk.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });
            desk.IssueAdmissionsTicket(new Ticket { LogId = 2, TicketId = "T-102" });

            Assert.Equal("T-101", desk.ServeNextTicket().TicketId);
            Assert.Equal(1, desk.GetQueueCount());
        }

        [Fact]
        public void ServeNextTicket_ShouldBehaveTheSameAsServeNextStudent()
        {
            var deskA = new AdmissionsDesk();
            var deskB = new AdmissionsDesk();
            deskA.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });
            deskB.IssueAdmissionsTicket(new Ticket { LogId = 1, TicketId = "T-101" });

            Assert.Equal(deskA.ServeNextStudent().TicketId, deskB.ServeNextTicket().TicketId);
        }

        [Fact]
        public void ServeNextTicket_ShouldThrow_WhenQueueIsEmpty()
        {
            var desk = new AdmissionsDesk();

            Assert.Throws<InvalidOperationException>(() => desk.ServeNextTicket());
        }

        // --- AdministrativeLogs.PopSystemLog and PeekLatestLog ---

        [Fact]
        public void PopSystemLog_ShouldRemoveTheNewestLog()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            Assert.Equal("L-002", logs.PopSystemLog().LogId);
            Assert.Equal(1, logs.GetLogCount());
        }

        [Fact]
        public void PopSystemLog_ShouldThrow_WhenNoLogsExist()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.PopSystemLog());
        }

        [Fact]
        public void PeekLatestLog_ShouldMatchViewLatestLog()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "First" });
            logs.PushSystemLog(new Log { LogId = "L-002", ActionSummary = "Second" });

            Assert.Equal(logs.ViewLatestLog().LogId, logs.PeekLatestLog().LogId);
            Assert.Equal(2, logs.GetLogCount());
        }

        [Fact]
        public void PeekLatestLog_ShouldThrow_WhenNoLogsExist()
        {
            var logs = new AdministrativeLogs();

            Assert.Throws<InvalidOperationException>(() => logs.PeekLatestLog());
        }

        [Fact]
        public void PeekLatestLog_ShouldNotConsumeTheLog()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "Action" });

            logs.PeekLatestLog();
            logs.PeekLatestLog();

            Assert.Equal(1, logs.GetLogCount());
        }

        [Fact]
        public void PopSystemLog_ShouldThrow_WhenEveryLogHasBeenPopped()
        {
            var logs = new AdministrativeLogs();
            logs.PushSystemLog(new Log { LogId = "L-001", ActionSummary = "Action" });
            logs.PopSystemLog();

            Assert.Throws<InvalidOperationException>(() => logs.PopSystemLog());
        }
    }

    // The Show methods write straight to the console, so the only way to assert
    // on them is to redirect the output stream for the duration of the call.
    internal static class TestConsole
    {
        public static string Capture(Action action)
        {
            TextWriter original = Console.Out;
            using var buffer = new StringWriter();

            try
            {
                Console.SetOut(buffer);
                action();
            }
            finally
            {
                Console.SetOut(original);
            }

            return buffer.ToString();
        }

        public static int CountLines(string output)
        {
            return output.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
