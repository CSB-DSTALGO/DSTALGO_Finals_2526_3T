namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        _students.Add(student);
    }

    public bool UnregisterStudent(int index)
    {
        if (index < 0 || index >= _students.Count)
            return false;

        _students.RemoveAt(index);
        return true;
    }

    public bool RemoveStudent(string id)
    {
    if (string.IsNullOrEmpty(id))
        return false;

    if (!int.TryParse(id, out int parsedId))
        return false;

    for (int i = 0; i < _students.Count; i++)
    {
        if (_students.Get(i).Id == parsedId)
        {
            _students.RemoveAt(i);
            return true;
        }
    }

    return false;
}

    public Student GetStudentAt(int index)
    {
        if (index < 0 || index >= _students.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return _students.Get(index);
    }

    // Hint: Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        if (_students.Count == 0)
            return 0.0;

        double total = 0.0;
        for (int i = 0; i < _students.Count; i++)
        {
            total += _students.Get(i).Gpa;
        }

        return total / _students.Count;
    }

    // Hint: Delegate search and sort to CustomArrayList<T>
    public int SearchStudent(Student student)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        return _students.IndexOf(student);
    }

    public void SortStudentsByGpa()
{
    _students.Sort(Comparer<Student>.Default);
}

    public int GetStudentCount()
    {
        return _students.Count;
    }

    public void ShowAllStudents()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine("No students registered.");
            return;
        }

        for (int i = 0; i < _students.Count; i++)
        {
            Console.WriteLine($"[{i}] {_students.Get(i)}");
        }
    }
}