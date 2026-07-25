namespace EnrollmentSystem.Core;

using System;
using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student)
    {
        if (student == null) throw new ArgumentNullException(nameof(student));
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
            // Convert the int Id to a string so it can be compared to the string parameter
            if (_students.Get(i)?.Id.ToString() == id)
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

    // Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        if (_students.Count == 0) return 0.0;
        
        double totalGpa = 0;
        for (int i = 0; i < _students.Count; i++)
        {
            totalGpa += _students.Get(i).Gpa;
        }
        
        return totalGpa / _students.Count;
    }

    // Delegate search to CustomArrayList<T>
    public int SearchStudent(Student student)
    {
        return _students.IndexOf(student);
    }

    // Delegate sort to CustomArrayList<T>
    public void SortStudentsByGpa()
    {
        // Sorts descending (highest GPA first). 
        _students.Sort((s1, s2) => s2.Gpa.CompareTo(s1.Gpa));
    }

    public int GetStudentCount()
    {
        return _students.Count;
    }
}