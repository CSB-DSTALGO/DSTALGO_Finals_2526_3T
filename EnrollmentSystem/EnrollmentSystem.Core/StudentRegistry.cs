namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    public int Count => _students.Count;

    public void RegisterStudent(Student student)
    {
        _students.Add(student); // add
    }

    public bool UnregisterStudent(int index)
    {
        
        if (index < 0 || index >= _students.Count)
        {
            return false;
        }

        _students.RemoveAt(index); // remove student at given index
        return true; 
    }
    public bool RemoveStudent(string id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id.ToString() == id) // check if student id matches
            {
                _students.RemoveAt(i); // remove matching student
                return true; 
            }
        }
            return false;
    }
    public Student GetStudentAt(int index)
    {
        return _students.Get(index); // return student at given index
    }


    // Hint: Calculate average GPA of all registered students
    public double CalculateAverageGpa()
    {
        
        if (_students.Count == 0)
        {
            return 0;
        }

        double total = 0;

        
        for (int i = 0; i < _students.Count; i++)
        {
            total += _students.Get(i).Gpa; // add all GPAs
        }

        return total / _students.Count; // return average GPA
    }

    // Hint: Delegate search and sort to CustomArrayList<T>
    public int SearchStudent(Student student)
    {
        return _students.Search(student, (a, b) => a.Id == b.Id); // search by student id
    }
    public void SortStudentsByGpa()
    {
        _students.Sort((a, b) => a.Gpa > b.Gpa); // sort students by GPA
    }
    public int GetStudentCount()
    {
        return _students.Count; // return count
    }
}