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
        Course? remove = null;
        var current = _courses.Head;
        while (current != null)
        {
            if (current.Data!= null && current.Data.Code.Equals(code))
            {
                remove = current.Data;
                break;
            }
            current = current.Next;
        }
        if (remove != null)
        {
            return _courses.Remove(remove);
        }
        return false;
    }

    // Hint: Sum total credit units across all courses
    public int CalculateTotalUnits()
    {
        int totalUnits = 0;
        var current = _courses.Head;
        while (current != null)
        {
            totalUnits += current.Data.Units;
            current = current.Next;
        }
        return totalUnits;
    }
    public void ShowCurriculum()
    {
        var current = _courses.Head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    // Hint: Delegate search and sort to CustomSinglyLinkedList<T>
    public bool SearchCourse(Course course)
    {
        return SearchCourse(course.Code) != null;

    }
    public Course? SearchCourse(string courseCode)
    {
        var current = _courses.Head;

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
        if (_courses.Head == null || _courses.Head.Next == null)
        {
            return;
        }

        Node<Course>? head = null;
        Node<Course>? current = _courses.Head;
        while (current != null)
        {
            Node<Course>? next = current.Next;
            if (head == null || head.Data.Units >= current.Data.Units)
            {
                current.Next = head;
                head = current;
            }
            else
            {
                Node<Course> search = head;
                while (search.Next != null && search.Next.Data.Units < current.Data.Units)
                {
                    search = search.Next;
                }
                current.Next = search.Next;
                search.Next = current;
            }
            current = next;
        }
        _courses.Head = head;
    }
}

