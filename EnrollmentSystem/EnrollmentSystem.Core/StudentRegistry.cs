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

        for(int i = 0; i < _students.Count; i++)
        {
            Student students = _students.Get(i);
            if (students.Id == index)
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
            Student students = _students.Get(i);
            if (Convert.ToString(students.Id) == id)
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

    // Hint: Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        if(_students.Count == 0)
        {
            return 0;
        }
        double total = 0;
        for (int i = 0; i < _students.Count; i++)
        {
            Student student = _students.Get(i);
            total += student.Gpa;
        }
        return total / _students.Count;
    }

    // Hint: Delegate search and sort to CustomArrayList<T>
    public int SearchStudent(Student student)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            Student current = _students.Get(i);
            if (current.Id == student.Id)
            {
                return i;
            }
        }
        return -1;
    }
    public void SortStudentsByGpa()
    {
        for (int i = 1; i < _students.Count; i++)
        {
            Student current = _students.Get(i);
            int j = i - 1;
            while (j >= 0 && _students.Get(j).Gpa > current.Gpa)
            {
                _students.Set(j + 1, _students.Get(j));
                j--;
            }
            _students.Set(j + 1, current);
        }
    }
    public int GetStudentCount()
    {
        return _students.Count;
    }
}