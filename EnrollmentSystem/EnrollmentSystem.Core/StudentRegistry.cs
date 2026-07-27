using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new(); // Internal list for storing registered students

    public int Count => _students.Count; // Exposes the total number of registered students (as read-only)

    // Registers a new student
    public void RegisterStudent(Student student) 
    {
        if (student == null)                                  // Is the student null? 
            throw new ArgumentNullException(nameof(student)); // YES, throw an exception

        if (string.IsNullOrEmpty(student.CourseCode))         // Is the student's course code null?
        {
            student.CourseCode = "N/A";                       // YES, default to N/A
        }

        _students.Add(student);                               // Add the student to the registry list
    }

    // Removes a student by index or falls back to searching by ID string value
    public bool UnregisterStudent(int index)
    { 
        if (index >= _students.Count)                 // Is index out of bounds?
        {
            string idStr = index.ToString();          // Convert the search index number to a string ID
            for (int i = 0; i < _students.Count; i++) // Loop through all students to find matching ID
            {
                var student = _students.Get(i);
                if (student != null && student.Id.ToString() == idStr)
                {
                    _students.RemoveAt(i);            // Remove the student
                    return true;                      // Successfully removed
                }
            }
            return false;                             // ID not found
        }

        if (index < 0)                                // Is the index invalid?
            return false;                             // YES, return false

        _students.RemoveAt(index); // Remove student at the specified index
        return true;
    }

    // Removes a student matching a specific ID string
    public bool RemoveStudent(string id)
    {
        if (string.IsNullOrEmpty(id))             // Is ID string null or empty?
            return false;                         // YES, return false

        for (int i = 0; i < _students.Count; i++) // Loop through all students to find matching ID
        {
            var student = _students.Get(i);
            if (student != null && student.Id.ToString() == id)
            {
                _students.RemoveAt(i);            // Remove the student
                return true;                      // Successfully removed
            }
        }
        return false;                             // ID not found
    }

    // Retrieves a student at a specific index 
    public Student GetStudentAt(int index)
    {
        if (index < 0 || index >= _students.Count)                // Is the index invalid?
            throw new ArgumentOutOfRangeException(nameof(index)); // YES, throw an exception

        return _students.Get(index); // Return the student object at index
    }

    // Calculates the average GPA across all registered students
    public double CalculateAverageGpa()
    {
        if (_students.Count == 0)                 // Is the registry empty?
            return 0.0;                           // YES, return 0.0 to avoid division by zero

        double totalGpa = 0.0;
        for (int i = 0; i < _students.Count; i++) // Loop through all students to calculate total GPA sum
        {
            totalGpa += _students.Get(i).Gpa;
        }

        return totalGpa / _students.Count;       // Return calculated average
    }

    // Searches for a student object and returns their index 
    public int SearchStudent(Student student)
    {
        if (student == null)                      // Is the student null?
            return -1;                            // YES, return -1 to indicate not found

        for (int i = 0; i < _students.Count; i++) // Loop through the list to find a matching student ID
        {
            var current = _students.Get(i);
            if (current != null && current.Id.ToString() == student.Id.ToString())
            {
                return i;                         // Return index
            }
        }
        return -1;                                // Student not found
    }

    // Sorts all registered students in ascending order based on GPA
    public void SortStudentsByGpa()
    {
        if (_students.Count <= 1)                       // Is the list empty or has only one student? Implies no need to sort
            return;

        Student[] items = new Student[_students.Count]; // Extract items into a temporary array using only Get()
        for (int i = 0; i < _students.Count; i++)
        {
            items[i] = _students.Get(i);
        }

        for (int i = 0; i < items.Length - 1; i++)      // Sort the temporary array using Bubble Sort
        {
            for (int j = 0; j < items.Length - i - 1; j++)
            {
                if (items[j].Gpa > items[j + 1].Gpa)    // Compare adjacent GPAs and swap if out of order
                {
                    var temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }

        while (_students.Count > 0)                     // Clears all existing elements from internal list
        {
            _students.RemoveAt(0);
        }

        foreach (var student in items)                  // Re-add the newly sorted items back into the internal list
        {
            _students.Add(student);
        }
    }

    // Returns the total number of registered students
    public int GetStudentCount()
    {
        return _students.Count;
    }
}