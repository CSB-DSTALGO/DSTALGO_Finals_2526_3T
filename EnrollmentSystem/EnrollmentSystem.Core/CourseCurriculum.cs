namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    public void InsertCourse(Course course) 
    {
        _courses.AddLast(course); //lets the linked work or handle the adding

    }
    public bool DeleteCourse(string code)
    {
        Node<Course>? current = _courses.Head; //it starts looking from the first node

        while (current != null) //it keeps going until there are no more nodes
        {
            if (current.Data.Code == code) // it checks if the course's code matches
            {
                return _courses.Remove(current.Data); // if found then remove
            }
            current = current.Next; //if they dont match then move to the next node
        }

        return false; 
    }

    // Hint: Sum total credit units across all courses
    public int CalculateTotalUnits()
    {
        int total = 0; //will add up as we enroll or enlist
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            total = total + current.Data.Units; //add the course's unit we chose to the total
            current = current.Next; // move to the next node
        }

        return total;
    }
    public void ShowCurriculum() 
    {
        Node<Course>? current = _courses.Head;

        if (current == null) // the list has nothing in it
        {
            Console.WriteLine("The curriculum is empty");
            return; // loop is not needed to run
        }

        while (current != null)
        {
            Console.WriteLine(current.Data.Code + " - " + current.Data.Title + " (" + current.Data.Units + " units)");
            current = current.Next; // move to next course
        }
    }

    // Hint: Delegate search and sort to CustomSinglyLinkedList<T>
    public bool SearchCourse(Course course)
    {
        Node<Course>? current = _courses.Head;

        while (current != null)
        {
            if (current.Data.Code == course.Code) // same code meaning same course
            {
                return true; // if it already has found a match
            }
            current = current.Next;
        }

        return false; // no match found
    }
    public void SortCurriculumByUnits() 
    {
        if (_courses.Head == null) // cant start if list is empty
        {
            return;
        }

        bool swapped = true; // just the loop to run once

        while (swapped == true)
        {
            swapped = false; // assumes that no swap this round unless one happens
             Node<Course> current = _courses.Head; 

             while (current.Next != null) // it compares the current node to the next one
             {
                if (current.Data.Units > current.Next.Data.Units) // it is out of order
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