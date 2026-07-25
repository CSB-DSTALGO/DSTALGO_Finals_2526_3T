namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

// Manages the list of courses in the curriculum, backed by a CustomSinglyLinkedList<Course>.
public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    // Number of courses currently stored.
    public int Count => _courses.Count;

    // Adds a new course to the end of the curriculum list.
    public void InsertCourse(Course course)
    {
        if (course == null) throw new ArgumentNullException(nameof(course));
        _courses.AddLast(course);
    }

    // Removes a course by its code (e.g. "CS101").
    // Looks up the matching Course object first, then asks the linked list to remove that exact object.
    public bool DeleteCourse(string code)
    {
        Course? target = FindCourseByCode(code);
        if (target == null) return false; // no course with that code exists

        return _courses.Remove(target);
    }

    // Adds up the Units of every course in the curriculum.
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

    // Prints every course in the curriculum to the console, in insertion (or sorted) order.
    public void ShowCurriculum()
    {
        Console.WriteLine("--- Course Curriculum ---");

        Node<Course>? current = _courses.Head;
        if (current == null)
        {
            Console.WriteLine("No courses in curriculum.");
            return;
        }

        while (current != null)
        {
            Console.WriteLine($"{current.Data.Code} - {current.Data.Title} ({current.Data.Units} units)");
            current = current.Next;
        }
    }

    // Checks if a specific course exists in the curriculum.
    // Delegated straight to the linked list's Contains — doesn't reimplement traversal here.
    // Hint: Delegate search and sort to CustomSinglyLinkedList<T>
    public bool SearchCourse(Course course)
    {
        return _courses.Contains(course);
    }

    // Reorders the curriculum in place from lowest to highest Units.
    // Delegated to the linked list's own Sort(), which uses Course.CompareTo (by Units).
    public void SortCurriculumByUnits()
    {
        _courses.Sort();
    }

    // Internal helper: walks the list looking for a course whose Code matches.
    // Used by DeleteCourse to find the exact object to remove.
    private Course? FindCourseByCode(string code)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code == code) return current.Data;
            current = current.Next;
        }

        return null; // not found
    }
}