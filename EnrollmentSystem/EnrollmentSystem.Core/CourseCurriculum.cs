namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();
    public int Count => _courses.Count;
    
    public void InsertCourse(Course course)
    {
        // Appends to the last section of the list
        _courses.AddLast(course);
    }

    public bool RemoveCourse(string code)
    {
        // Remove() needs a Course instance (matched via Course.Equals by Code),
        // not a raw string, so find the matching course first.
        Course? match = FindByCode(code);
        if (match == null)
            return false;

        return _courses.Remove(match);
    }

    private Course? FindByCode(string code)
    {
        foreach (Course c in _courses)
        {
            if (c.Code == code)
                return c;
        }
        return null;
    }

    // Sum total credit units across all courses
    public int GetTotalUnits()
    {
        int total = 0;
        foreach (Course c in _courses)
        {
            total += c.Units;
        }
        return total;
    }
    public int CalculateTotalUnits() => GetTotalUnits();
    public bool DeleteCourse(string code) => RemoveCourse(code);

    public void ShowCurriculum()
    {
        // _courses yields Course objects, not strings
        Console.WriteLine("CURRENT COURSES:");
        foreach (Course c in _courses)
        {
            Console.WriteLine(c);
        }
    }

    // Delegate search to the linked list by scanning for a matching Course
    public bool SearchCourse(Course course)
    {
        foreach (Course c in _courses)
        {
            if (c.Equals(course))
                return true;
        }
        return false;
    }

    // Delegate sort to CustomSinglyLinkedList<T>, which sorts using
    // Course.CompareTo (ordering by Units)
    public void SortCurriculumByUnits()
    {
        _courses.Sort();
    }
}