namespace EnrollmentSystem.Core;

using System;
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
        if (index >= _students.Count)
        {
            string idStr = index.ToString();
            for (int i = 0; i < _students.Count; i++)
            {
                var student = _students.Get(i);
                if (student != null && student.Id.ToString() == idStr)
                {
                    _students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        if (index < 0 || index >= _students.Count)
            return false;

        _students.RemoveAt(index);
        return true;
    }

    public bool RemoveStudent(string id)
    {
        if (string.IsNullOrEmpty(id))
            return false;

        for (int i = 0; i < _students.Count; i++)
        {
            var student = _students.Get(i);
            if (student != null && student.Id.ToString() == id)
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

    public double CalculateAverageGpa()
    {
        if (_students.Count == 0)
            return 0.0;

        double totalGpa = 0.0;
        for (int i = 0; i < _students.Count; i++)
        {
            totalGpa += _students.Get(i).Gpa;
        }

        return totalGpa / _students.Count;
    }

    public int SearchStudent(Student student)
    {
        if (student == null)
            return -1;

        for (int i = 0; i < _students.Count; i++)
        {
            var current = _students.Get(i);
            if (current != null && current.Id.ToString() == student.Id.ToString())
            {
                return i;
            }
        }
        return -1;
    }

    public void SortStudentsByGpa()
    {
        if (_students.Count <= 1)
            return;

        // Extract items into a temporary array using only Get()
        Student[] items = new Student[_students.Count];
        for (int i = 0; i < _students.Count; i++)
        {
            items[i] = _students.Get(i);
        }

        // Sort the temporary array using Bubble Sort
        for (int i = 0; i < items.Length - 1; i++)
        {
            for (int j = 0; j < items.Length - i - 1; j++)
            {
                if (items[j].Gpa > items[j + 1].Gpa)
                {
                    var temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }

        // Clear the custom list using only RemoveAt()
        while (_students.Count > 0)
        {
            _students.RemoveAt(0);
        }

        // Re-add sorted items back using only Add()
        foreach (var student in items)
        {
            _students.Add(student);
        }
    }
    public int GetStudentCount()
    {
        return _students.Count;
    }
}