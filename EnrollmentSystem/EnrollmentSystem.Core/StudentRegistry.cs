using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    // Manages student records using CustomArrayList
    public class StudentRegistry
    {
        private readonly CustomArrayList<Student> _students = new();

        public int Count => _students.Count;

        // Add student. Check for null, duplicate ID
        public void RegisterStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }

            // Check duplicate ID
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students.Get(i).Id == student.Id)
                {
                    throw new InvalidOperationException($"Student with ID '{student.Id}' already exists.");
                }
            }

            _students.Add(student);
        }

        // Remove by index. Return true if success
        public bool UnregisterStudent(int index)
        {
            if (index < 0 || index >= _students.Count)
            {
                return false;
            }

            _students.RemoveAt(index);
            return true;
        }

        // Remove by ID (int). Return true if found
        public bool RemoveStudent(int id)
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
        // Remove by ID (string). Supports IDs like "2026-0001"
        public bool RemoveStudent(string id)
        {
            if (int.TryParse(id.Replace("-", ""), out int numericId))
            {
                return RemoveStudent(numericId);
            }

            return false;
        }
        // Get student at index
        public Student GetStudentAt(int index)
        {
            if (index < 0 || index >= _students.Count)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count: {_students.Count}");
            }

            return _students.Get(index);
        }

        // Calculate average GPA
        public double CalculateAverageGpa()
        {
            if (_students.Count == 0)
            {
                return 0.0;
            }

            double total = 0.0;
            for (int i = 0; i < _students.Count; i++)
            {
                total += _students.Get(i).Gpa;
            }

            return total / _students.Count;
        }

        // Binary Search for student. MUST sort by ID first!
        public int SearchStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            return _students.BinarySearch(
                student,
                (a, b) => a.Id.CompareTo(b.Id)
            );
        }

        // Sort by GPA highest to lowest using QuickSort
        public void SortStudentsByGpa()
        {
            _students.QuickSort((a, b) => b.Gpa.CompareTo(a.Gpa));
        }

        // Return total student count
        public int GetStudentCount()
        {
            return _students.Count;
        }

        // Bonus: Sort by name A to Z
        public void SortStudentsByName()
        {
            _students.QuickSort((a, b) =>
                string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
        }

        // Bonus: Sort by ID (use before Binary Search)
        public void SortStudentsById()
        {
            _students.QuickSort((a, b) => a.Id.CompareTo(b.Id));
        }

        // Bonus: Print all students
        public void ShowAllStudents()
        {
            Console.WriteLine("\n------------ REGISTERED STUDENTS ------------");

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

            Console.WriteLine($"==========================================");
            Console.WriteLine($"Total: {_students.Count} student(s)\n");
        }
    }
}