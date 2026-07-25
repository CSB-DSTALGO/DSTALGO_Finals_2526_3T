namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    // Returns the total number of courses.
    public int Count => _courses.Count;

    // Adds a new course to the curriculum.
    public void InsertCourse(Course course) => _courses.AddLast(course);

    // Removes a course using its course code.
    public bool DeleteCourse(string courseCode)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code == courseCode)
            {
                return _courses.Remove(current.Data);
            }

            current = current.Next;
        }

        return false;
    }

    // Searches for a course using its course code.
    public bool SearchCourse(string courseCode)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code == courseCode)
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    // Calculates the total credit units of all courses.
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

    // Displays all courses in the curriculum.
    public void ShowCurriculum()
    {
        if (_courses.Head == null)
        {
            Console.WriteLine("No courses in the curriculum.");
            return;
        }

        Console.WriteLine($"Total Courses: {Count}\n");

        Node<Course>? current = _courses.Head;
        int index = 0;

        while (current != null)
        {
            Console.WriteLine(
                $"[{index}] Code: {current.Data.Code} | Title: {current.Data.Title} | Units: {current.Data.Units}");

            current = current.Next;
            index++;
        }

        Console.WriteLine($"\nTotal Curriculum Units: {CalculateTotalUnits()}");
    }

    // Sorts the curriculum by credit units in ascending order.
    public void SortCurriculumByUnits()
    {
        if (_courses.Head == null)
            return;

        bool swapped;

        do
        {
            swapped = false;
            Node<Course>? current = _courses.Head;

            while (current != null && current.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    Course temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }

                current = current.Next;
            }

        } while (swapped);
    }
}