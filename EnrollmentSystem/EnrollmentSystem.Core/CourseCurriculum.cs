namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    
    public void InsertCourse(Course course) => _courses.AddLast(course);
    
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

    // Hint: Sum total credit units across all courses
    
    public int CalculateTotalUnits()
    {
        int totalUnits = 0;
        Node<Course>? current = _courses.Head;

        while(current != null)
        {
            totalUnits += current.Data.Units;
            current = current.Next;
        }

        return totalUnits;
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

    // Hint: Delegate search and sort to CustomSinglyLinkedList<T>
   
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
    //public void SortCurriculumByUnits() => throw new NotImplementedException();
    public void SortCurriculumByUnits()
    {
        if (_courses.Head == null)
        {
            return;
        }

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