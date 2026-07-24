namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student)//add a new student
    {
        _students.Add(student);
    }

    public bool UnregisterStudent(int index)//remove a student using indexing
    {
        if (index < 0 || index >= _students.Count)
        {
            return false;
        }

        _students.RemoveAt(index);
        return true;
    }
    public bool RemoveStudent(int id)//removes student using student number
    {
        for(int i = 0; i < _students.Count; i++)
        {
            if(_students.Get(i).Id == id)
            {
                _students.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
    public Student GetStudentAt(int index)//rturns the student via indexing
    {
        return _students.Get(index);
    }

    // Hint: Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        double sum = 0;

        for(int i = 0; i < _students.Count;i++)
        {
            sum += _students.Get(i).Gpa;
        }
        return sum / _students.Count;
    }

    // Hint: Delegate search and sort to CustomArrayList<T>
    public int SearchStudent(Student student)//search for student
    {
        return _students.Search(student);
    }
    public void SortStudentsByGpa()
    {
        _students.Sort();
    }
    public int GetStudentCount()//total number of students
    {
        return _students.Count;
    }
}