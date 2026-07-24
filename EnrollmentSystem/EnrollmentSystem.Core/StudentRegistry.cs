namespace EnrollmentSystem.Core;

using System;
using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student) => _students.Add(student);

    public bool UnregisterStudent(int studentId)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id == studentId)
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
            var student = _students.Get(i);
            if (student.Id.ToString().Equals(id, StringComparison.OrdinalIgnoreCase))
            {
                _students.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public Student GetStudentAt(int index) => _students.Get(index);

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

    public int SearchStudent(Student student) => _students.Search(student);

    public void SortStudentsByGpa() => _students.Sort();

    public int GetStudentCount() => _students.Count;
}