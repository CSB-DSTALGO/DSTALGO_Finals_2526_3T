namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    public void InsertCourse(Course course) => throw new NotImplementedException();
    public bool DeleteCourse(string code) => throw new NotImplementedException();

    // Hint: Sum total credit units across all courses
    public int CalculateTotalUnits() => throw new NotImplementedException();
    public void ShowCurriculum() => throw new NotImplementedException(); 

    // Hint: Delegate search and sort to CustomSinglyLinkedList<T>
    public bool SearchCourse(Course course) => throw new NotImplementedException();
    public void SortCurriculumByUnits() => throw new NotImplementedException();
}