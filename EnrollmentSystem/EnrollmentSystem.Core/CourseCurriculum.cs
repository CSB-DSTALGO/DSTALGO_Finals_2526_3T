// 12521269 Joaquin Bryan G. Ross
namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
    private readonly CustomSinglyLinkedList<Course> _courses = new();

    public int Count => _courses.Count;

    /// <summary>
    /// Appends a course node to the end of the chain. O(n), because the list
    /// keeps no tail pointer and has to walk to the last node first. Holding a
    /// tail pointer would make this O(1), at the cost of one more field to keep
    /// correct on every removal.
    /// </summary>
    public void InsertCourse(Course course) => _courses.AddLast(course);

    /// <summary>
    /// Removes a targeted node by course code. O(n): locating the node is a
    /// linear walk, and unlinking it is O(1) once the predecessor is known.
    /// </summary>
    public bool DeleteCourse(string courseCode)
    {
        Course? target = SearchCourse(courseCode);
        if (target == null) return false;

        return _courses.Remove(target);
    }

    /// <summary>
    /// Search algorithm: linear search over the chain, comparing course codes.
    /// It follows Next from the head until the code matches or the chain ends.
    /// Best case O(1) at the head, worst and average case O(n). A linked list
    /// cannot beat linear search, because there is no way to jump to the middle
    /// without walking there first, which rules out binary search however well
    /// sorted the curriculum happens to be.
    /// Returns the matching course, or null when the code is not in the chain.
    /// </summary>
    public Course? SearchCourse(string courseCode)
    {
        Node<Course>? current = _courses.Head;
        while (current != null)
        {
            if (string.Equals(current.Data.Code, courseCode, StringComparison.OrdinalIgnoreCase))
                return current.Data;

            current = current.Next;
        }

        return null;
    }

    /// <summary>
    /// Membership check by course object. The instructor's test passes a Course
    /// rather than a code, so this delegates to the linked list's Search, which
    /// matches on the record. O(n).
    /// </summary>
    public bool SearchCourse(Course course) => _courses.Search(course);

    /// <summary>
    /// Sums the credit units across every course in the chain. O(n).
    /// </summary>
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

    /// <summary>
    /// Traverses and prints the continuous chain. O(n) over a single pass.
    /// </summary>
    public void ShowCurriculum()
    {
        if (_courses.Count == 0)
        {
            Console.WriteLine("The curriculum is empty.");
            return;
        }

        int position = 0;
        Node<Course>? current = _courses.Head;
        while (current != null)
        {
            Console.WriteLine($"[{position}] {current.Data.Code} | {current.Data.Title} | {current.Data.Units} unit(s)");
            current = current.Next;
            position++;
        }
    }

    /// <summary>
    /// Sorting algorithm: insertion sort by re-linking, delegated to
    /// CustomSinglyLinkedList.Sort. It builds a second sorted chain and moves
    /// each node into place by pointer surgery, so no course data is copied.
    /// Best case O(n) when already ordered, worst and average case O(n^2), with
    /// O(1) extra space since only the existing nodes are relinked.
    /// Merge sort would give O(n log n) and is the usual pick for long chains,
    /// but insertion sort keeps the pointer work readable and a curriculum is
    /// short by nature.
    /// Course.CompareTo orders by units, so the lightest course leads the chain.
    /// </summary>
    public void SortCurriculumByUnits() => _courses.Sort();
}
