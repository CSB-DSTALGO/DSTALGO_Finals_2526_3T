namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    public void InsertCourse(Course course) => _courses.AddLast(course); // utilized AddLast method from CustomSinglyLinkedList
    public bool DeleteCourse(string code)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code == code) // if the node data matches the given code, perform Remove function
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

        // simply traverses through list and adds the total units
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
        // prints all courses
        while (current != null)
        {
            Console.WriteLine($"{current.Data.Code} - {current.Data.Title} ({current.Data.Units} units)");
            current = current.Next;
        }
    }

    public bool SearchCourse(Course course)
    {
        Node<Course>? current = _courses.Head;

        // linear search for searching course
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

    public void SortCurriculumByUnits()
    {
        // bubble sort
        if (_courses.Head == null) return;

        bool swapped = true;

        while (swapped)
        {
            swapped = false;
            Node<Course>? current = _courses.Head;

            while (current != null && current.Next != null)
            {
                if (current.Data.Units > current.Next.Data.Units)
                {
                    Course temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        }
    }
}