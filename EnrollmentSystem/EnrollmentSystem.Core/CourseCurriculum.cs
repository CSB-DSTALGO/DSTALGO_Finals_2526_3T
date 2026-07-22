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
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            Console.WriteLine($"{current.Data.Code} - {current.Data.Title} ({current.Data.Units} units)");
            current = current.Next;
        }
    }

    public bool SearchCourse(Course course) => throw new NotImplementedException();
    public void SortCurriculumByUnits() => throw new NotImplementedException();
}