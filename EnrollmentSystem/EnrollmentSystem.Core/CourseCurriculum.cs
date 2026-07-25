namespace EnrollmentSystem.Core;

using DataStructuresLibrary;


public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;


    public void InsertCourse(Course course)
    {
        if (course is null)
            throw new ArgumentNullException(nameof(course), "Cannot insert a null course.");

        _courses.AddLast(course);
    }


    public bool DeleteCourse(string code)
    {
        return _courses.RemoveMatch(c => c.Code == code);
    }


    public int CalculateTotalUnits()
    {
        int total = 0;
        Node<Course>? current = _courses.Head;

        while (current is not null)
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
            Console.WriteLine("The curriculum is currently empty.");
            return;
        }

        Console.WriteLine("=== Course Curriculum ===");
        Node<Course>? current = _courses.Head;

        while (current is not null)
        {
            var c = current.Data;
            Console.WriteLine($"{c.Code,-10} | {c.Title,-25} | {c.Units} units");
            current = current.Next;
        }
    }


    public bool SearchCourse(Course course)
    {
        if (course is null) return false;
        return _courses.Find(c => c.Code == course.Code) is not null;
    }


    public void SortCurriculumByUnits()
    {
        _courses.Sort((a, b) => a.CompareTo(b));
    }
}
