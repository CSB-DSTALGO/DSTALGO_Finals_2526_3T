namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    // Inserts a course at the end of the curriculum.
    public void InsertCourse(Course course)
    {
        _courses.AddLast(course);
    }

    // Deletes a course based on its course code.
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

    // Calculates the total number of units in the curriculum.
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

    // Displays all courses in the curriculum.
    public void ShowCurriculum()
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            Console.WriteLine($"{current.Data.Code} - {current.Data.Title} ({current.Data.Units} units)");
            current = current.Next;
        }
    }

    // Searches the curriculum for a course with the specified course code.
    public bool SearchCourse(Course course)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code == course.Code)
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    // Sorts the curriculum in ascending order by course units using Bubble Sort.
    public void SortCurriculumByUnits()
    {
        if (_courses.Head == null || _courses.Head.Next == null)
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