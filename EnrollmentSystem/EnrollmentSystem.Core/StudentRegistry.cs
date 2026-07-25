namespace EnrollmentSystem.Core;

using DataStructuresLibrary;


public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    
    public void RegisterStudent(Student student)
    {
        if (student is null)
            throw new ArgumentNullException(nameof(student), "Cannot register a null student.");

        _students.Add(student);
    }

    public bool UnregisterStudent(int id)
    {
        int index = _students.Search(s => s.Id == id);
        if (index == -1) return false;

        _students.RemoveAt(index);
        return true;
    }


    public bool RemoveStudent(string id)
    {
        if (!int.TryParse(id, out int parsedId))
            return false;

        return UnregisterStudent(parsedId);
    }


    public Student GetStudentAt(int index) => _students.Get(index);

    public Student GetStudentDetails(int index) => GetStudentAt(index);

    public double CalculateAverageGpa()
    {
        if (_students.Count == 0) return 0.0;

        double total = 0;
        for (int i = 0; i < _students.Count; i++)
            total += _students.Get(i).Gpa;

        return total / _students.Count;
    }

    public int SearchStudent(Student student)
    {
        if (student is null) return -1;
        return _students.Search(s => s.Id == student.Id);
    }

    public void SortStudentsByGpa()
    {
        _students.Sort((a, b) => a.CompareTo(b));
    }

    public int GetStudentCount() => _students.Count;

    public void ShowAllStudents()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine("No students registered yet.");
            return;
        }

        Console.WriteLine("=== Student Registry ===");
        for (int i = 0; i < _students.Count; i++)
        {
            var s = _students.Get(i);
            Console.WriteLine($"[{i}] ID: {s.Id} | Name: {s.Name} | GPA: {s.Gpa:F2} | Course: {s.CourseCode}");
        }
    }
}
namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student) => throw new NotImplementedException();
    public bool UnregisterStudent(int index) => throw new NotImplementedException();
    public bool RemoveStudent(string id) => throw new NotImplementedException();
    public Student GetStudentAt(int index) => throw new NotImplementedException();

    public double CalculateAverageGpa() => throw new NotImplementedException();

  
    public int SearchStudent(Student student) => throw new NotImplementedException();
    public void SortStudentsByGpa() => throw new NotImplementedException();
    public int GetStudentCount() => throw new NotImplementedException();
}
