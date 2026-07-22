namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student) => _students.Add(student);
    public bool UnregisterStudent(int index)
    {
        try
        {
            _students.RemoveAt(index);
            return true;
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    public bool RemoveStudent(string id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id.ToString() == id)
            {
                _students.RemoveAt(i);
                return true;
            }
        }

        return false;

    }
    
    public Student GetStudentAt(int index) => _students.Get(index);

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
    public int SearchStudent(Student student) => _students.Search(student);
    public void SortStudentsByGpa() => _students.Sort();
    public int GetStudentCount() => _students.Count;
}