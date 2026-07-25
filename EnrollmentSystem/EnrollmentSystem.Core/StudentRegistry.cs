namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        _students.Add(student);
    }

    public bool UnregisterStudent(int indexOrStudentId)
    {
        // First, check whether the supplied number matches a student ID.
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id == indexOrStudentId)
            {
                _students.RemoveAt(i);
                return true;
            }
        }

        // If no ID matched, treat the number as an array index.
        if (indexOrStudentId < 0 || indexOrStudentId >= _students.Count)
        {
            return false;
        }

        _students.RemoveAt(indexOrStudentId);
        return true;
    }

    public Student GetStudentDetails(int index)
    {
        if (index < 0 || index >= _students.Count)
        {
            throw new IndexOutOfRangeException();
        }

        return _students.Get(index);
    }

    public Student GetStudentAt(int index)
    {
        return GetStudentDetails(index);
    }

    public void ShowAllStudents()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine("No students registered.");
            return;
        }

        Console.WriteLine("===== Student Registry =====");

        for (int i = 0; i < _students.Count; i++)
        {
            Student student = _students.Get(i);

            Console.WriteLine(
                $"[{i}] ID: {student.Id}, Name: {student.Name}, " +
                $"GPA: {student.Gpa:F2}, Course: {student.CourseCode}");
        }
    }

    public int GetStudentCount()
    {
        return _students.Count;
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

    public int SearchStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        // Linear Search
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id == student.Id)
            {
                return i;
            }
        }

        return -1;
    }

    public void SortStudentsByGpa()
    {
        // Bubble Sort in ascending GPA order.
        for (int i = 0; i < _students.Count - 1; i++)
        {
            for (int j = 0; j < _students.Count - i - 1; j++)
            {
                Student first = _students.Get(j);
                Student second = _students.Get(j + 1);

                if (first.CompareTo(second) > 0)
                {
                    _students.Set(j, second);
                    _students.Set(j + 1, first);
                }
            }
        }
    }
}