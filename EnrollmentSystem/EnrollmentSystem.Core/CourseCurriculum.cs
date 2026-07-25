namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    public void InsertCourse(Course course)
    {
        // Appends to the last section of the list
        _courses.AddLast(course);
    }
    public bool DeleteCourse(string code)
    {
        // intended to use Remove method to remove specified course
        _courses.Remove(code);
    }
    // Hint: Sum total credit units across all courses
    public int CalculateTotalUnits()
    {
        // todo later unable to determine value of 'Courses' to display Credit Units
        throw new NotImplementedException();
    }
    public void ShowCurriculum()
    {
        // intended to show each node in the course list
        Console.WriteLine("CURRENT COURSES:");
        foreach (string str in _courses)
        {
            Console.WriteLine(str);
        }
    }

    // Hint: Delegate search and sort to CustomSinglyLinkedList<T>
    public bool SearchCourse(Course course)
    {
        // PROBLEMATIC !! This Code might not work as intended !! PROBLEMATIC
        Node Search = CustomSinglyLinkedList(course);
        Console.WriteLine(Search);
    }
    public void SortCurriculumByUnits()
    {
        // todo after 'Calculate Total Units', need to determine value of 'Courses' & Credit Unit to implement
        throw new NotImplementedException();
    }
}