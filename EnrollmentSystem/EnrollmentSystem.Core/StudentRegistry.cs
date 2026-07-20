namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student) => throw new NotImplementedException();
    public bool UnregisterStudent(int index) => throw new NotImplementedException();
    public bool RemoveStudent(string id) => throw new NotImplementedException();
    public Student GetStudentAt(int index) => throw new NotImplementedException();

    // Hint: Calculate average GPA of all registered students
    public double CalculateAverageGpa() => throw new NotImplementedException();

    // Hint: Delegate search and sort to CustomArrayList<T>
    public int SearchStudent(Student student) => throw new NotImplementedException();
    public void SortStudentsByGpa() => throw new NotImplementedException();
    public int GetStudentCount() => throw new NotImplementedException();
}