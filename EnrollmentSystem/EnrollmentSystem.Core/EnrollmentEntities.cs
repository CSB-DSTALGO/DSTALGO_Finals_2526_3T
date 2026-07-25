namespace EnrollmentSystem.Core;

public class Student : IComparable<Student>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Gpa { get; set; }
    public string CourseCode { get; set; } = string.Empty;

    public Student(int id, string name, double gpa, string courseCode ="")
    {
        Id = id;
        Name = name;
        Gpa = gpa;
        CourseCode = courseCode;
    }

    // Hint: Compare by GPA for registry sorting
    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return Gpa.CompareTo(other.Gpa);
    }
}

public class Course : IComparable<Course>
{
    public string Code { get; set; }
    public string Title { get; set; }
    public int Units { get; set; }

    public Course(string code, string title, int units)
    {
        Code = code;
        Title = title;
        Units = units;
    }

    // Hint: Compare by Units for curriculum sorting
    public int CompareTo(Course? other)
    {
        if (other == null) return 1;
        return Units.CompareTo(other.Units);
    }
}

public class AdmissionApplication : IComparable<AdmissionApplication>
{
    public int ApplicationId { get; set; }
    public string StudentName { get; set; }
    public int PriorityScore { get; set; }
    public string TicketId { get; set; } = string.Empty;

    public AdmissionApplication(int applicationId, string studentName, int priorityScore)
    {
        ApplicationId = applicationId;
        StudentName = studentName;
        PriorityScore = priorityScore;
    }

    // Hint: Compare by PriorityScore for admissions queue sorting
    public int CompareTo(AdmissionApplication? other)
    {
        if (other == null) return 1;
        return PriorityScore.CompareTo(other.PriorityScore);
    }
}

public class Ticket : IComparable<Ticket>
{
    public int LogId { get; set; }
    public string Action { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public string TicketId { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;

    // Hint: Compare by LogId for log stack sorting
    public int CompareTo(Ticket? other)
    {
        if (other == null) return 1;
        return LogId.CompareTo(other.LogId);
    }
}

public class Log
{
    public string LogId { get; set; } = string.Empty;
    public string ActionSummary { get; set; } = string.Empty;
}
