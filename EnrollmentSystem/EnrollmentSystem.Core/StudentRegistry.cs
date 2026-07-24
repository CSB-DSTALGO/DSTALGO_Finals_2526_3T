using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    // This class manages all student records
    // It uses our CustomArrayList to store the students
    public class StudentRegistry
    {
        // The list that holds all our students
        private readonly CustomArrayList<Student> _students = new();

        // Quick way to check how many students we have
        public int Count => _students.Count;

        // Add a new student to the registry
        // Checks if student is null and if ID already exists
        public void RegisterStudent(Student student)
        {
            // Don't allow null students
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }

            // Loop through all students to check for duplicate ID
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students.Get(i).Id == student.Id)
                {
                    throw new InvalidOperationException($"Student with ID '{student.Id}' already exists.");
                }
            }

            // No duplicate found, add the student
            _students.Add(student);
        }

        // Remove student by index (position in the list)
        // Returns true if removed, false if index is bad
        public bool UnregisterStudent(int index)
        {
            // Check if index is valid
            if (index < 0 || index >= _students.Count)
            {
                return false;
            }

            _students.RemoveAt(index);
            return true;
        }

        // Remove student by ID
        // ConsoleApp sends string, so we parse it to int
        // Returns true if found and removed, false if not
        public bool RemoveStudent(string id)
        {
            // Try to convert string ID to number
            if (!int.TryParse(id, out int studentId))
            {
                return false;  // Invalid ID format
            }

            // Find the student with matching ID
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students.Get(i).Id == studentId)
                {
                    _students.RemoveAt(i);
                    return true;
                }
            }

            // Student not found
            return false;
        }

        // Get student at specific position
        // Throws error if index is out of range
        public Student GetStudentAt(int index)
        {
            if (index < 0 || index >= _students.Count)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count: {_students.Count}");
            }

            return _students.Get(index);
        }

        // Calculate average GPA of all students
        // Returns 0 if no students yet
        public double CalculateAverageGpa()
        {
            if (_students.Count == 0)
            {
                return 0.0;
            }

            // Add all GPAs together
            double total = 0.0;
            for (int i = 0; i < _students.Count; i++)
            {
                total += _students.Get(i).Gpa;
            }

            // Divide by number of students
            return total / _students.Count;
        }

        // Search for student using Binary Search
        // IMPORTANT: Must call SortStudentsById() first!
        // Returns index if found, -1 if not found
        public int SearchStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            // Use our CustomArrayList's BinarySearch
            // Compare by student ID
            return _students.BinarySearch(
                student,
                (a, b) => a.Id.CompareTo(b.Id)
            );
        }

        // Sort students by GPA - highest first
        // Uses QuickSort from our CustomArrayList
        public void SortStudentsByGpa()
        {
            _students.QuickSort((a, b) => b.Gpa.CompareTo(a.Gpa));
        }

        // Return total number of students
        public int GetStudentCount()
        {
            return _students.Count;
        }

        // Sort students by name A to Z
        public void SortStudentsByName()
        {
            _students.QuickSort((a, b) =>
                string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
        }

        // Sort students by ID smallest to largest
        // Call this before using SearchStudent (Binary Search)
        public void SortStudentsById()
        {
            _students.QuickSort((a, b) => a.Id.CompareTo(b.Id));
        }

        // Print all students to console
        public void ShowAllStudents()
        {
            Console.WriteLine("\n__________ REGISTERED STUDENTS __________");

            if (_students.Count == 0)
            {
                Console.WriteLine("No students registered.");
                return;
            }

            // Loop and print each student
            for (int i = 0; i < _students.Count; i++)
            {
                Student s = _students.Get(i);
                Console.WriteLine($"[{i}] ID: {s.Id} | Name: {s.Name} | Course: {s.CourseCode} | GPA: {s.Gpa}");
            }

            Console.WriteLine($"==========================================");
            Console.WriteLine($"Total: {_students.Count} student(s)\n");
        }
    }
}