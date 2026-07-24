namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student)
    {
        _students.Add(student);
    }

    public bool UnregisterStudent(int index)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id == index)
            {
                _students.RemoveAt(i);
                return true;
            }
        }
        return false;
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

    public Student GetStudentAt(int index)
    {
        return _students.Get(index);
    }

    public double CalculateAverageGpa()
    {
        if (_students.Count == 0)
            return 0;

        double total = 0;
        for (int i = 0; i < _students.Count; i++)
            total += _students.Get(i).Gpa;

        return total / _students.Count;
    }

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
        int n = _students.Count;

        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                var a = _students.Get(j);
                var b = _students.Get(j + 1);

                if (a.CompareTo(b) < 0) 
                {
                    _students.Set(j, b);
                    _students.Set(j + 1, a);
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    public int GetStudentCount()
    {
        return _students.Count;
    }
}