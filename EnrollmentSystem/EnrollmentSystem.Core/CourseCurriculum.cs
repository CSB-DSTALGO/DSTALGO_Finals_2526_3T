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
        var current = _courses.Head;
        while (current != null)
        {
            if (current.Data != null && current.Data.CourseCode == code)
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
        var current = _courses.Head;
        while (current != null)
        {
            if (current.Data != null)
            {
                total += current.Data.Units;
            }
            current = current.Next;
        }
        return total;
    }

    public void ShowCurriculum()
    {
        Console.WriteLine("--- Course Curriculum ---");
        var current = _courses.Head;
        if (current == null)
        {
            Console.WriteLine("No courses enrolled.");
            return;
        }

        while (current != null)
        {
            if (current.Data != null)
            {
                Console.WriteLine($"[{current.Data.CourseCode}] {current.Data.CourseName} ({current.Data.Units} Units)");
            }
            current = current.Next;
        }
        Console.WriteLine("-------------------------");
    }

    public bool SearchCourse(Course course)
    {
        var current = _courses.Head;
        while (current != null)
        {
            if (current.Data != null && current.Data.CourseCode == course.CourseCode)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void SortCurriculumByUnits()
    {
        if (_courses.Head == null || _courses.Count <= 1) return;

        int n = _courses.Count;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            var current = _courses.Head;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (current != null && current.Next != null &&
                    current.Data != null && current.Next.Data != null)
                {
                    if (current.Data.Units > current.Next.Data.Units)
                    {
                        string tempCode = current.Data.CourseCode;
                        string tempName = current.Data.CourseName;
                        int tempUnits = current.Data.Units;

                        current.Data.CourseCode = current.Next.Data.CourseCode;
                        current.Data.CourseName = current.Next.Data.CourseName;
                        current.Data.Units = current.Next.Data.Units;

                        current.Next.Data.CourseCode = tempCode;
                        current.Next.Data.CourseName = tempName;
                        current.Next.Data.Units = tempUnits;

                        swapped = true;
                    }
                }
                current = current.Next;
            }
            if (!swapped) break;
        }
        Console.WriteLine("Curriculum sorted by Units!");
    }
}