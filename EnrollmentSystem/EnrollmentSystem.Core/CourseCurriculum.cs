namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    public void InsertCourse(Course course) => _courses.AddLast(course);

    public bool DeleteCourse(string code) => _courses.RemoveWhere(c => c.Code == code);

    // Hint: Sum total credit units across all courses
    public int CalculateTotalUnits() =>
        _courses.Aggregate(0, (total, c) => total + c.Units);

    public void ShowCurriculum() =>
        _courses.PrintAll(c => $"Code: {c.Code}, Title: {c.Title}, Units: {c.Units}");

    // Hint: Delegate search and sort to CustomSinglyLinkedList<T>
    public bool SearchCourse(Course course) =>
        _courses.Contains(c => c.Code == course.Code);

    public void SortCurriculumByUnits() =>
        _courses.Sort((a, b) => a.Units.CompareTo(b.Units));

    public Course? GetCourseAt(int index) => _courses.GetAt(index);
}