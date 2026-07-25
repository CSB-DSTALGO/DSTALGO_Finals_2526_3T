namespace EnrollmentSystem.Core;
using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();
    public int Count => _students.Count;

    // Adds a new student to the registry.
    public void RegisterStudent(Student student)
    {
        _students.Add(student);
    }

    // Removes a student using their index in the list.
    public bool UnregisterStudent(int index)
    {
        // Add a safety check to prevent IndexOutOfRangeException
        if (index < 0 || index >= _students.Count)
        {
            throw new IndexOutOfRangeException();
        }

        // Remove the student from the list.
        _students.RemoveAt(index);
        return true;
    }

    // Removes a student by searching for their ID.
    public bool RemoveStudent(string id)
    {
        // Search through the student list.
        for (int i = 0; i < _students.Count; i++)
        {
            Student students = _students.Get(i);

            // Compare the student's ID with the given ID.
            if (students.Id == int.Parse(id))
            {
                // Remove the matching student.
                _students.RemoveAt(i);
                return true;
            }
        }

        // Return false if no matching student was found.
        return false;
    }

    // Returns the student at the specified index.
    public Student GetStudentDetails(int index)
    {
        return _students.Get(index);
    }

    // Returns the student stored at the specified index.
    public Student GetStudentAt(int index)
    {
        return _students.Get(index);
    }

    // Hint: Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        // Return 0 if there are no registered students.
        if (_students.Count == 0)
        {
            return 0;
        }

        double total = 0;

        // Add the GPA of each student.
        for (int i = 0; i < _students.Count; i++)
        {
            Student student = _students.Get(i);
            total += student.Gpa;
        }

        // Return the average GPA.
        return total / _students.Count;
    }

    // Hint: Delegate search and sort to CustomArrayList<T>
    public int SearchStudent(Student student)
    {
        // Search for the student by ID.
        for (int i = 0; i < _students.Count; i++)
        {
            Student current = _students.Get(i);

            // Return the index if a match is found.
            if (current.Id == student.Id)
            {
                return i;
            }
        }

        // Return -1 if the student is not found.
        return -1;
    }

    // Sorts students by GPA in ascending order using Insertion Sort.
    public void SortStudentsByGpa()
    {
        // Start from the second student.
        for (int i = 1; i < _students.Count; i++)
        {
            Student current = _students.Get(i);
            int j = i - 1;

            // Shift students with higher GPA one position to the right.
            while (j >= 0 && _students.Get(j).Gpa > current.Gpa)
            {
                _students.Set(j + 1, _students.Get(j));
                j--;
            }

            // Insert the current student into the correct position.
            _students.Set(j + 1, current);
        }
    }

    // Returns the total number of registered students.
    public int GetStudentCount()
    {
        return _students.Count;
    }

    // Displays all registered students.
    public void ShowAllStudents()
    {
        // Check if there are any students to display.
        if (_students.Count == 0)
        {
            Console.WriteLine("No students registered.");
            return;
        }

        // Print each student's index, ID, and name.
        for (int i = 0; i < _students.Count; i++)
        {
            Student student = _students.Get(i);
            Console.WriteLine($"Index {i}: {student.Id} - {student.Name}");
        }
    }
}