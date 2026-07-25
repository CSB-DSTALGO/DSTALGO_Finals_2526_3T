namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        _students.Add(student);
    }

    public bool UnregisterStudent(int index)
    {
        if (index < 0 || index >= _students.Count)
        {
            return false;
        }

        _students.RemoveAt(index);
        return true;
    }

    public bool RemoveStudent(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return false;
        }

        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i]?.Id == id)
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
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        return _students[index];
    }

    // Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        if (_students.Count == 0)
        {
            return 0.0;
        }

        double totalGpa = 0;
        for (int i = 0; i < _students.Count; i++)
        {
            totalGpa += _students[i].Gpa;
        }

        return totalGpa / _students.Count;
    }

    // Delegate search and sort to CustomArrayList<T>
    public int SearchStudent(Student student)
    {
        return _students.IndexOf(student);
    }

    public void SortStudentsByGpa()
    {
        // Sorts descending/ascending depending on how your CustomArrayList.Sort or IComparable is set up.
        // If CustomArrayList accepts a Comparison or IComparer:
        _students.Sort((a, b) => b.Gpa.CompareTo(a.Gpa));
    }

    public int GetStudentCount()
    {
        return _students.Count;
    }
}
