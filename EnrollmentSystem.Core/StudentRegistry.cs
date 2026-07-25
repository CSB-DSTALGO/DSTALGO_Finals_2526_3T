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
        if (index < 0 || index >= _students.Count)
            return false;

        _students.RemoveAt(index);
        return true;
    }

    public bool RemoveStudent(string id)
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

    public Student GetStudentAt(int index)
    {
        return _students.Get(index);
    }

    public Student GetStudentDetails(int index)
    {
        return _students.Get(index);
    }

    public void ShowAllStudents()
    {
        for (int i = 0; i < _students.Count; i++)
        {
            var s = _students.Get(i);
            Console.WriteLine($"[{i}] ID: {s.Id} | Name: {s.Name} | Course: {s.CourseCode}");
        }
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

    // SORTING ALGORITHM: Bubble Sort.
    // Sorts students alphabetically by Id.
    // Time Complexity: O(n^2) worst case, O(n) best case (with early exit).
    public void SortStudentsById()
    {
        int n = _students.Count;

        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                var a = _students.Get(j);
                var b = _students.Get(j + 1);

                if (string.Compare(a.Id, b.Id) > 0)
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