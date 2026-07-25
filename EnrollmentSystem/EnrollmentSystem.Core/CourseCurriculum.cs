using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    public void InsertCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        _courses.AddLast(course);
    }

    public bool DeleteCourse(string code)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code.Equals(
                code,
                StringComparison.OrdinalIgnoreCase))
            {
                return _courses.Remove(current.Data);
            }

            current = current.Next;
        }

        return false;
    }

    public int CalculateTotalUnits()
    {
        int totalUnits = 0;
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            totalUnits += current.Data.Units;
            current = current.Next;
        }

        return totalUnits;
    }

    public void ShowCurriculum()
    {
        if (_courses.Count == 0)
        {
            Console.WriteLine("No courses in the curriculum.");
            return;
        }

        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            Course course = current.Data;

            Console.WriteLine(
                $"Code: {course.Code}, " +
                $"Title: {course.Title}, " +
                $"Units: {course.Units}");

            current = current.Next;
        }
    }

    public bool SearchCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code.Equals(
                course.Code,
                StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void SortCurriculumByUnits()
    {
        if (_courses.Count < 2)
        {
            return;
        }

        bool swapped;

        do
        {
            swapped = false;
            Node<Course>? current = _courses.Head;

            while (current?.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    Course temporary = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temporary;

                    swapped = true;
                }

                current = current.Next;
            }
        }
        while (swapped);
    }
}