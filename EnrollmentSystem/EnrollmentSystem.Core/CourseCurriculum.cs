namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

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
        if (string.IsNullOrWhiteSpace(code))
        {
            return false;
        }

        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (string.Equals(
                current.Data.Code,
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
        Node<Course>? current = _courses.Head;

        if (current == null)
        {
            Console.WriteLine("No courses in the curriculum.");
            return;
        }

        while (current != null)
        {
            Console.Write(
                $"{current.Data.Code} ({current.Data.Units} units)"
            );

            if (current.Next != null)
            {
                Console.Write(" -> ");
            }

            current = current.Next;
        }

        Console.WriteLine();
    }

    public bool SearchCourse(Course course)
    {
        if (course == null)
        {
            return false;
        }

        return _courses.Search(course);
    }

    public void SortCurriculumByUnits()
    {
        _courses.Sort(
            (firstCourse, secondCourse) =>
                firstCourse.Units.CompareTo(secondCourse.Units)
        );
    }
}