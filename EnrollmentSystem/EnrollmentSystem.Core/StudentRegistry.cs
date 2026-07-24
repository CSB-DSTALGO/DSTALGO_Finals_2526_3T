// 12521269 Joaquin Bryan G. Ross
namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    /// <summary>
    /// Inserts a student record at the end of the registry. O(1) amortised.
    /// </summary>
    public void RegisterStudent(Student student) => _students.Add(student);

    /// <summary>
    /// Removes a record by its student id. The instructor's test calls
    /// UnregisterStudent with the student number, not an array position, so the
    /// id is located first and then the slot is removed. O(n) for the search
    /// plus O(n) for the shift. Returns false when no student has that id.
    /// </summary>
    public bool UnregisterStudent(int id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id == id)
            {
                _students.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Removes a record by its student id given as a string. Same behaviour as
    /// UnregisterStudent, matching on the text form of the id. O(n).
    /// </summary>
    public bool RemoveStudent(string id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id.ToString() == id)
            {
                _students.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Returns a record by index. O(1), since an array list computes the slot
    /// address directly. That is the reason the registry is backed by one.
    /// </summary>
    public Student GetStudentDetails(int index) => _students.Get(index);

    /// <summary>
    /// The name the project scaffold shipped for the same indexed lookup, kept
    /// alongside GetStudentDetails so code written against either name compiles.
    /// O(1).
    /// </summary>
    public Student GetStudentAt(int index) => _students.Get(index);

    /// <summary>
    /// Outputs the entire array state. O(n) over a single pass.
    /// </summary>
    public void ShowAllStudents()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine("No students are registered.");
            return;
        }

        for (int i = 0; i < _students.Count; i++)
        {
            Student student = _students.Get(i);
            Console.WriteLine($"[{i}] ID: {student.Id} | Name: {student.Name} | GPA: {student.Gpa:F2} | Course: {student.CourseCode}");
        }
    }

    /// <summary>
    /// Averages the GPA across every registered student. O(n), and returns 0
    /// for an empty registry rather than dividing by zero.
    /// </summary>
    public double CalculateAverageGpa()
    {
        if (_students.Count == 0) return 0.0;

        double total = 0.0;
        for (int i = 0; i < _students.Count; i++)
        {
            total += _students.Get(i).Gpa;
        }

        return total / _students.Count;
    }

    /// <summary>
    /// Search algorithm: linear search, delegated to CustomArrayList.Search.
    /// It compares each slot from index 0 upward until it finds a match.
    /// Best case O(1) when the student is first, worst and average case O(n).
    /// Linear search fits because the registry is only sorted on demand, and
    /// binary search would require the data to stay sorted at all times.
    /// Returns the student's index, or -1 when the student is not registered.
    /// </summary>
    public int SearchStudent(Student student) => _students.Search(student);

    /// <summary>
    /// Sorting algorithm: insertion sort, delegated to CustomArrayList.Sort.
    /// It grows a sorted region at the front of the array, taking each next
    /// record and shifting larger records right until it drops into place.
    /// Best case O(n) when already ordered, worst and average case O(n^2),
    /// with O(1) extra space since it sorts in place. A registry is appended
    /// to far more often than it is reordered, so the near-sorted best case is
    /// the one that actually shows up in practice.
    /// Student.CompareTo orders by GPA, so the lowest GPA ends up first.
    /// </summary>
    public void SortStudentsByGpa() => _students.Sort();

    /// <summary>Returns how many students are registered. O(1).</summary>
    public int GetStudentCount() => Count;
}
