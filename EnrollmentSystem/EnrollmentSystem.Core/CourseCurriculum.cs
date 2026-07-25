namespace EnrollmentSystem.Core;

using System;
using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    public void InsertCourse(Course course)
    {
        if (course == null) throw new ArgumentNullException(nameof(course));
        _courses.AddLast(course);
    }

    public bool DeleteCourse(string code)
    {
        Node<Course> current = _courses.Head;
        while (current != null)
        {
            if (current.Data != null && current.Data.Code == code)
            {
                return _courses.Remove(current.Data);
            }
            current = current.Next;
        }
        return false;
    }

    // Sum total credit units across all courses
    public int CalculateTotalUnits()
    {
        int totalUnits = 0;
        Node<Course> current = _courses.Head;
        
        while (current != null)
        {
            if (current.Data != null)
            {
                totalUnits += current.Data.Units;
            }
            current = current.Next;
        }
        
        return totalUnits;
    }

    public void ShowCurriculum()
    {
        _courses.ShowAll(); 
    }

    // Delegate search to CustomSinglyLinkedList<T>
    public bool SearchCourse(Course course)
    {
        return _courses.Contains(course);
    }

    public Course SearchCourse(string courseCode)
    {
        Node<Course> current = _courses.Head;
        while (current != null)
        {
            if (current.Data != null && current.Data.Code == courseCode)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Delegate sort to CustomSinglyLinkedList<T>
    public void SortCurriculumByUnits()
    {
        // Sorts descending (highest units first). Swap c1 and c2 to sort ascending.
        _courses.Sort((c1, c2) => c2.Units.CompareTo(c1.Units));
    }
}