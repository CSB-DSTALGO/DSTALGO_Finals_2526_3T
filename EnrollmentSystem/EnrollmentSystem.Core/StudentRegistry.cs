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

    // Removes a student record by ID (used by ConsoleApp). Returns true if found and removed.
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

    // Removes a student record by matching the Student object itself (required by test scaffold)
    public bool RemoveStudent(Student student)
    {
        int index = _registry.IndexOf(student);
        if (index == -1)
        {
            return false;
        }

        _registry.RemoveAt(index);
        return true;
    }

    // Prints a single student's details by index (required by rubric)
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

    // Calculates the average GPA of all registered students (required by test scaffold)
    public double CalculateAverageGpa()
    {
        if (_registry.Count == 0)
        {
            return 0.0;
        }

        double total = 0.0;
        for (int i = 0; i < _registry.Count; i++)
        {
            total += _registry.Get(i).Gpa;
        }

        return total / _registry.Count;
    }

    // Searches for a student by matching the Student object itself (required by test scaffold)
    public int SearchStudent(Student student)
    {
        return _registry.IndexOf(student);
    }

    // Searches for a student by ID (used internally by UnregisterStudent)
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

    // Sorts all students by GPA using CustomArrayList's insertion sort
    public void SortStudentsByGpa()
    {
        _registry.Sort();
    }
}