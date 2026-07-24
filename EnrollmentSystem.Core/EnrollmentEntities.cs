// File name: EnrollmentEntities.cs
namespace EnrollmentSystem.Core
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
    }

    public class Course
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Units { get; set; }
    }

    public class Ticket
    {
        public string TicketId { get; set; }
        public string StudentId { get; set; }
    }

    public class Log
    {
        public string LogId { get; set; }
        public string ActionSummary { get; set; }
    }
}