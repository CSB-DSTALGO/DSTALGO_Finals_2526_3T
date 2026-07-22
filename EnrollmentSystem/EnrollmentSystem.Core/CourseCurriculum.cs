namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    public void InsertCourse(Course course)
    {
        _courses.AddLast(course);
    }

    // Finds the course with the matching code and then removes it.
    public bool DeleteCourse(string code)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code == code)
            {
                return _courses.Remove(current.Data);
            }

            current = current.Next;
        }

        return false;
    }

    // Hint: Sum total credit units across all courses
    public int CalculateTotalUnits()
    {
        int total = 0;
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            total += current.Data.Units;
            current = current.Next;
        }

        return total;
    }

    public void ShowCurriculum()
    {
        if (_courses.Count == 0)
        {
            Console.WriteLine("Curriculum is empty.");
            return;
        }

        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            Course c = current.Data;
            Console.WriteLine($"{c.Code} | {c.Title} | {c.Units} unit(s)");
            current = current.Next;
        }

        Console.WriteLine($"Total Units: {CalculateTotalUnits()}");
    }

    // Hint: Delegate search and sort to CustomSinglyLinkedList<T>

    public bool SearchCourse(Course course)
    {
        return _courses.LinearSearch(course) >= 0;
    }

    // Searches by course code and then returns the course or null if not found.
    public Course? SearchCourse(string courseCode)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code == courseCode)
            {
                return current.Data;
            }

            current = current.Next;
        }

        return null;
    }

    public void SortCurriculumByUnits()
    {
        _courses.Sort();
    }
}