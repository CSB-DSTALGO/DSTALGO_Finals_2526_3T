namespace EnrollmentSystem.Core;

public class Student : IComparable<Student>
{
    // Fixed: Id is a string (e.g. "2026-0001") to match Program.cs and
    // EnrollmentCoreTest.cs, which both construct Student via object
    // initializer syntax with a string Id.
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Gpa { get; set; }
    public string CourseCode { get; set; } = string.Empty;

    // Parameterless constructor is required so `new Student { Id = ..., Name = ..., CourseCode = ... }`
    // (used throughout Program.cs and the tests) compiles.
    public Student()
    {
    }

    // Optional convenience constructor for callers who want to build a Student in one line.
    public Student(string id, string name, double gpa = 0)
    {
        Id = id;
        Name = name;
        Gpa = gpa;
    }

    // Hint: Compare by GPA for registry sorting
    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return Gpa.CompareTo(other.Gpa);
    }

    // Friendly display used by StudentRegistry.GetStudentDetails / ShowAllStudents.
    public override string ToString()
    {
        return $"ID: {Id} | Name: {Name} | Course: {CourseCode} | GPA: {Gpa}";
    }
}

public class Course : IComparable<Course>
{
    public string Code { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Units { get; set; }

    // Parameterless constructor is required so `new Course { Code = ..., Title = ..., Units = ... }`
    // (used in Program.cs and the tests) compiles.
    public Course()
    {
    }

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

    public override string ToString()
    {
        return $"{Code} - {Title} ({Units} units)";
    }
}

public class AdmissionApplication : IComparable<AdmissionApplication>
{
    public int ApplicationId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public int PriorityScore { get; set; }
    public string TicketId { get; set; } = string.Empty;

    public AdmissionApplication()
    {
    }

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

    public override string ToString()
    {
        return $"Ticket {TicketId} | Student: {StudentId}";
    }
}

public class Log
{
    public string LogId { get; set; } = string.Empty;
    public string ActionSummary { get; set; } = string.Empty;
}