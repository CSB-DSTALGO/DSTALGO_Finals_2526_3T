namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class StudentRegistry
{
    private readonly CustomArrayList<Student> _students = new();

    // Returns the total number of registered students.
    public int Count => _students.Count;

    // Adds a new student to the registry.
    public void RegisterStudent(Student student) => _students.Add(student);

    // Removes a student by Student ID.
    public bool UnregisterStudent(int studentId)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students.Get(i).Id == studentId)
            {
                _students.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    // Removes a student by Student ID. 
    public bool UnregisterStudent(string id) 
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

    // Returns the student at the specified index.
    public Student GetStudentAt(int index) => _students.Get(index);

    // Calculates the average GPA of all registered students.
    public double CalculateAverageGpa()
    {
        if (_students.Count == 0)
            return 0;

        double total = 0;

        for (int i = 0; i < _students.Count; i++)
        {
            total += _students.Get(i).Gpa;
        }

        return total / _students.Count;
    }

    // Searches for a student and returns its index.
    public int SearchStudent(Student student) => _students.Search(student);

    // Sorts students by GPA in ascending order.
    public void SortStudentsByGpa() => _students.Sort();

    // Returns the number of registered students.
    public int GetStudentCount() => _students.Count;

    // Displays all registered students, 10 at a time.
    public void ShowAllStudents()
    {
        const int pageSize = 10;

        if (_students.Count == 0)
        {
            Console.WriteLine("No students registered.");
            return;
        }

        int page = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Current Student List ---");
            Console.WriteLine($"Total Students: {_students.Count}\n");
            int start = page * pageSize;
            int end = start + pageSize;
            if (end > _students.Count)
                end = _students.Count;

            for (int i = start; i < end; i++)
            {
                Student s = _students.Get(i);

                Console.WriteLine(
                    $"[{i}] ID: {s.Id} | Name: {s.Name} | GPA: {s.Gpa:F2} | Course: {s.CourseCode}");
            }

            Console.WriteLine($"\nPage {page + 1} of {(_students.Count + pageSize - 1) / pageSize}");

            Console.Write("\n[N] Next  [P] Previous  [Q] Quit\n: ");

            string input = (Console.ReadLine() ?? "").ToUpper();
            

            if (input == "N")
            {
                if (end < _students.Count)
                    page++;
            }
            else if (input == "P")
            {
                if (page > 0)
                    page--;
            }
            else if (input == "Q")
            {
                break;
            }
        }
        
    }
}