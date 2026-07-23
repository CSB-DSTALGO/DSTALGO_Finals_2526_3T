using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    //This class manages all student records using our CustomArrayList
    //It wraps the array list and provides student-specific methods
    public class StudentRegistry
    {
        //The underlying data structure - our custom array list of students
        private readonly CustomArrayList<Student> _students = new();

        //Property to check how many students are registered
        public int Count => _students.Count;

        //Add a new student to the registry
        //Checks for null, empty ID, and duplicate IDs
        public void RegisterStudent(Student student)
        {
            //Don't allow null students
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }

            //Don't allow empty ID
            if (string.IsNullOrWhiteSpace(student.Id))
            {
                throw new ArgumentException("Student ID cannot be empty.", nameof(student));
            }

            //Check if ID already exists - loop through all students
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students.Get(i).Id == student.Id)
                {
                    throw new InvalidOperationException($"Student with ID '{student.Id}' already exists.");
                }
            }

            //All good, add the student
            _students.Add(student);
        }

        //Remove student by index
        //Returns true if removed, false if index is bad
        public bool UnregisterStudent(int index)
        {
            //Check if index is valid
            if (index < 0 || index >= _students.Count)
            {
                return false;
            }

            _students.RemoveAt(index);
            return true;
        }

        //Remove student by their ID string
        //Returns true if found and removed, false if not found
        public bool RemoveStudent(string id)
        {
            //Loop through to find the student with matching ID
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students.Get(i).Id == id)
                {
                    _students.RemoveAt(i);
                    return true;
                }
            }

            // Not found
            return false;
        }

        //Get student at specific index
        //Throws error if index is out of range
        public Student GetStudentAt(int index)
        {
            if (index < 0 || index >= _students.Count)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count: {_students.Count}");
            }

            return _students.Get(index);
        }

        //Calculate average GPA of all students
        //Returns 0.0 if no students
        public double CalculateAverageGpa()
        {
            //No students? Average is 0
            if (_students.Count == 0)
            {
                return 0.0;
            }

            //Add up all GPAs
            double total = 0.0;
            for (int i = 0; i < _students.Count; i++)
            {
                total += _students.Get(i).Gpa;
            }

            //Divide by count to get average
            return total / _students.Count;
        }

        //Search for a student using Binary Search
        //IMPORTANT: Must sort by ID first before calling this!
        //Returns index if found, -1 if not found
        public int SearchStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            //Delegate to our CustomArrayList's BinarySearch
            //Compare by student ID
            return _students.BinarySearch(
                student,
                (a, b) => string.Compare(a.Id, b.Id, StringComparison.OrdinalIgnoreCase)
            );
        }

        //Sort students by GPA from highest to lowest
        //Uses our CustomArrayList's QuickSort
        public void SortStudentsByGpa()
        {
            _students.QuickSort((a, b) => b.Gpa.CompareTo(a.Gpa));
        }

        //Returns total number of students
        //Same as Count property, just a method version
        public int GetStudentCount()
        {
            return _students.Count;
        }

        //Sort by name (A to Z) - extra helper
        public void SortStudentsByName()
        {
            _students.QuickSort((a, b) =>
                string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
        }

        //Sort by ID (A to Z) - extra helper, useful before Binary Search
        public void SortStudentsById()
        {
            _students.QuickSort((a, b) =>
                string.Compare(a.Id, b.Id, StringComparison.OrdinalIgnoreCase));
        }

        //Print all students to console - for testing/display
        public void ShowAllStudents()
        {
            Console.WriteLine("\n----------- REGISTERED STUDENTS --------------");

            if (_students.Count == 0)
            {
                Console.WriteLine("No students registered.");
                return;
            }

            for (int i = 0; i < _students.Count; i++)
            {
                Student s = _students.Get(i);
                Console.WriteLine($"[{i}] ID: {s.Id} | Name: {s.Name} | Course: {s.CourseCode} | GPA: {s.Gpa}");
            }

            Console.WriteLine($"<><><><><><><><><><><><><><><><><><>");
            Console.WriteLine($"Total: {_students.Count} student(s)\n");
        }
    }
}