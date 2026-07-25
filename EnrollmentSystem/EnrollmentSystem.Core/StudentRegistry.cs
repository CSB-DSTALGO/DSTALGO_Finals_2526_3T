namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _registry = new();

    // Inserts a new student record into the registry
    public void RegisterStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        _registry.Add(student);
    }

    // Removes a student record by ID. Returns true if found and removed.
    public bool UnregisterStudent(int id)
    {
        int index = SearchStudentById(id);
        if (index == -1)
        {
            return false;
        }

        _registry.RemoveAt(index);
        return true;
    }

    // Retrieves and prints a single student's details by index (required by rubric)
    public void GetStudentDetails(int index)
    {
        Student student = _registry.Get(index);
        Console.WriteLine($"ID: {student.Id} | Name: {student.Name} | Course: {student.CourseCode} | GPA: {student.Gpa:F2}");
    }

    // Prints the entire current state of the registry (required by rubric)
    public void ShowAllStudents()
    {
        if (_registry.Count == 0)
        {
            Console.WriteLine("No students registered.");
            return;
        }

        for (int i = 0; i < _registry.Count; i++)
        {
            GetStudentDetails(i);
        }
    }

    // Returns the student at a given index (needed by ConsoleApp)
    public Student GetStudentAt(int index)
    {
        return _registry.Get(index);
    }

    // Returns the current number of registered students (needed by ConsoleApp)
    public int GetStudentCount()
    {
        return _registry.Count;
    }

    // Sorts all students by GPA using CustomArrayList's insertion sort
    public void SortStudentsByGpa() 
    {
        _registry.Sort();
    }

    // Searches for a student by ID using linear search
    // Time complexity: O(n)
    public int SearchStudentById(int id)
    {
        for (int i = 0; i < _registry.Count; i++)
        {
            if (_registry.Get(i).Id == id)
            {
                return i;
            }
        }
        return -1;
    }
}