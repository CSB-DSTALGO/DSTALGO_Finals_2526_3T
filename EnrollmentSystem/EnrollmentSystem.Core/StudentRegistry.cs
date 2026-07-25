namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student) => _students.Add(student);

    public bool UnregisterStudent(int index)
    {
        if (index < 0 || index >= _students.Count) return false;
        _students.RemoveAt(index);
        return true;
    }

    public bool RemoveStudent(string id)
    {
        if (int.TryParse(id, out int numericId))
        {
            var student = _students.Search(s => s.Id == numericId);
            if (student != null)
            {
                for (int i = 0; i < _students.Count; i++)
                {
                    if (_students.Get(i).Id == numericId)
                    {
                        _students.RemoveAt(i);
                        return true;
                    }
                }
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

    public Student GetStudentDetails(int index) => GetStudentAt(index);

    public void ShowAllStudents()
    {
        for (int i = 0; i < _students.Count; i++)
        {
            var s = _students.Get(i);
            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, GPA: {s.Gpa}");
        }
    }

    // Hint: Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        if (_students.Count == 0) return 0.0;
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
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id == student.Id)
                return i;
        }
        return -1;
    }

    public void SortStudentsByGpa()
    {
        // CustomArrayList.Sort takes Comparison<T>
        _students.Sort((s1, s2) => s1.Gpa.CompareTo(s2.Gpa));
    }

    public int GetStudentCount() => _students.Count;
}