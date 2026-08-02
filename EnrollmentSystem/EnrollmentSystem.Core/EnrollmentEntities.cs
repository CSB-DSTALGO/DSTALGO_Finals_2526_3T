namespace EnrollmentSystem.Core;

// Represents a student record in the enrollment system.
public class Student : IComparable<Student>
{
    // Student ID number.
    public int Id { get; set; }

    // Full name of the student.
    public string Name { get; set; }

    // Student's Grade Point Average (GPA).
    public double Gpa { get; set; }

    // Course code assigned to the student.
    public string CourseCode { get; set; } = string.Empty;

    // Creates a new student record.
    public Student(int id, string name, double gpa)
    {
        Id = id;
        Name = name;
        Gpa = gpa;
    }

    // Compares students by GPA for sorting operations.
    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return Gpa.CompareTo(other.Gpa);
    }
}

// Represents a course offered in the curriculum.
public class Course : IComparable<Course>
{
    // Course code (e.g., CS101).
    public string Code { get; set; }

    // Course title.
    public string Title { get; set; }

    // Number of units for the course.
    public int Units { get; set; }

    // Creates a new course.
    public Course(string code, string title, int units)
    {
        Code = code;
        Title = title;
        Units = units;
    }

    // Compares courses by units for sorting operations.
    public int CompareTo(Course? other)
    {
        if (other == null) return 1;
        return Units.CompareTo(other.Units);
    }
}

// Represents a student's admission application.
public class AdmissionApplication : IComparable<AdmissionApplication>
{
    // Unique application ID.
    public int ApplicationId { get; set; }

    // Name of the applicant.
    public string StudentName { get; set; }

    // Priority score used for admissions processing.
    public int PriorityScore { get; set; }

    // Assigned admission ticket ID.
    public string TicketId { get; set; } = string.Empty;

    // Creates a new admission application.
    public AdmissionApplication(int applicationId, string studentName, int priorityScore)
    {
        ApplicationId = applicationId;
        StudentName = studentName;
        PriorityScore = priorityScore;
    }

    // Compares applications by priority score for sorting.
    public int CompareTo(AdmissionApplication? other)
    {
        if (other == null) return 1;
        return PriorityScore.CompareTo(other.PriorityScore);
    }
}

// Represents an admission ticket issued to a student.
public class Ticket : IComparable<Ticket>
{
    // Associated log ID.
    public int LogId { get; set; }

    // Description of the recorded action.
    public string Action { get; set; } = string.Empty;

    // Date and time the ticket was created.
    public DateTime Timestamp { get; set; }

    // Unique ticket identifier.
    public string TicketId { get; set; } = string.Empty;

    // Student ID associated with the ticket.
    public string StudentId { get; set; } = string.Empty;

    // Compares tickets by Log ID for sorting operations.
    public int CompareTo(Ticket? other)
    {
        if (other == null) return 1;
        return LogId.CompareTo(other.LogId);
    }
}

// Represents an administrative system log.
public class Log
{
    // Unique log identifier.
    public string LogId { get; set; } = string.Empty;

    // Summary of the recorded action.
    public string ActionSummary { get; set; } = string.Empty;
}