namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    // Adds a student.
    public void RegisterStudent(Student student)
    {
        _students.Add(student);
    }
    // Removes a student by index. Returns false if index is invalid.
    public bool UnregisterStudent(int index)
    {
        if (index < 0 || index >= _students.Count)
        {
            return false;
        }
        
        _students.RemoveAt(index);
        return true;
    }

    // Removes a student by ID. Returns false if not found.
    public bool RemoveStudent(int id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id == id)
            {
                _students.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    // Returns the student at the given index.
    public Student GetStudentAt(int index)
    {
        return _students.Get(index);
    }

    // Hint: Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        if (_students.Count == 0)
        {
            return 0;
        }

        double total = 0;
        for (int i = 0; i < _students.Count; i++)
        {
            total += _students.Get(i).Gpa;
        }
        
        return total / _students.Count;
    }

    // Hint: Delegate search and sort to CustomArrayList<T>
    public int SearchStudent(Student student)
    {
        return _students.Search(student);
    }
    public void SortStudentsByGpa()
    {
        _students.Sort((a, b) => a.Gpa.CompareTo(b.Gpa));
    }
    public int GetStudentCount()
    {
        return _students.Count;
    }
}