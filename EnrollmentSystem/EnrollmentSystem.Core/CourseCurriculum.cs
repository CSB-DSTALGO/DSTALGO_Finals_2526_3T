namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

/// <summary>
/// Course Curriculum module utilizing CustomSinglyLinkedList for in-memory course record management.
/// Provides sorting via Merge Sort and lookups via Linear Search (both delegated to the linked list,
/// since a singly linked list is naturally traversed sequentially rather than by random index).
/// </summary>
public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    /// <summary>
    /// Appends a new course to the end of the curriculum chain.
    /// UML Signature: + InsertCourse(c: Course): void
    /// </summary>
    public void InsertCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException(nameof(course), "Cannot insert a null course.");
        }

        _courses.AddLast(course);
    }

    /// <summary>
    /// Removes the course whose Code matches courseCode.
    /// Named RemoveCourse (rather than the requirements table's DeleteCourse) because that is
    /// the exact name Program.cs and EnrollmentCoreTest.cs already call.
    /// </summary>
    /// <returns>True if a matching course was found and removed, false otherwise.</returns>
    public bool RemoveCourse(string courseCode)
    {
        return _courses.RemoveWhere(c => c.Code == courseCode);
    }

    // Alias kept so the requirements-table name still works if anything references it directly.
    public bool DeleteCourse(string courseCode) => RemoveCourse(courseCode);

    /// <summary>
    /// Locates and returns the course whose Code matches courseCode.
    /// UML Signature: + SearchCourse(code: string): Course (returns the matching node's data)
    /// Delegates to CustomSinglyLinkedList.LinearSearch.
    /// </summary>
    /// <returns>The matching Course, or null if none was found.</returns>
    public Course? SearchCourse(string courseCode)
    {
        Node<Course>? match = _courses.LinearSearch(c => c.Code == courseCode);
        return match?.Data;
    }

    /// <summary>
    /// Sums total credit units across every course currently in the curriculum.
    /// Named GetTotalUnits (rather than the requirements table's CalculateTotalUnits) because
    /// that is the exact name Program.cs and EnrollmentCoreTest.cs already call.
    /// </summary>
    public int GetTotalUnits()
    {
        int total = 0;
        Course[] snapshot = _courses.ToArray();

        for (int i = 0; i < snapshot.Length; i++)
        {
            total += snapshot[i].Units;
        }

        return total;
    }

    // Alias kept so the requirements-table name still works if anything references it directly.
    public int CalculateTotalUnits() => GetTotalUnits();

    /// <summary>
    /// Sorts the curriculum ascending by credit Units using Merge Sort.
    /// </summary>
    public void SortCurriculumByUnits()
    {
        _courses.MergeSort((c1, c2) => c1.Units.CompareTo(c2.Units));
        Console.WriteLine("Curriculum successfully sorted by credit units (Merge Sort).");
    }

    /// <summary>
    /// Traverses and prints the entire curriculum chain.
    /// UML Signature: + ShowCurriculum(): void
    /// </summary>
    public void ShowCurriculum()
    {
        if (_courses.Count == 0)
        {
            Console.WriteLine("No courses currently in the curriculum.");
            return;
        }

        Console.WriteLine("=== CURRENT COURSE CURRICULUM ===");
        Course[] snapshot = _courses.ToArray();

        for (int i = 0; i < snapshot.Length; i++)
        {
            Console.WriteLine($"[Node {i}] {snapshot[i]}");
        }
    }
}