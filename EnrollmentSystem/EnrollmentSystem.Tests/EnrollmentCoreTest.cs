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

            bool removed = registry.RemoveStudent(20260001);

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
       public void IssueAdmissionsTicket_ShouldQueueApplicationsInFIFOOrder()
       {
           var desk = new AdmissionsDesk();
           var a1 = new AdmissionApplication(1, "Alice", 10);
           var a2 = new AdmissionApplication(2, "Bob", 20);

           desk.IssueAdmissionsTicket(a1);
           desk.IssueAdmissionsTicket(a2);

           Assert.Equal(2, desk.GetQueueCount());

           var served = desk.ServeNextStudent();
           Assert.Equal(1, served.ApplicationId);
       }

       [Fact]
       public void ServeNextStudent_ShouldThrowException_WhenQueueIsEmpty()
       {
           var desk = new AdmissionsDesk();

           Assert.Throws<InvalidOperationException>(() => desk.ServeNextStudent());
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