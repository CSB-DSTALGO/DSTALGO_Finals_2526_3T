using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class StudentRegistry
    {
        private readonly CustomArrayList<Student> _registry;

        public StudentRegistry()
        {
            _registry = new CustomArrayList<Student>();
        }

        // Inserts a new student record at the end of the registry.
        public void RegisterStudent(Student student)
        {
            _registry.Add(student);
        }

        // Removes a student record by its index in the registry.
        public bool UnregisterStudent(int index)
        {
            try
            {
                _registry.RemoveAt(index);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public void GetStudentDetails(int index)
        {
            try
            {
                Student student = _registry.GetAt(index);
                Console.WriteLine($"[{index}] {student.Name} (ID: {student.Id}, GPA: {student.Gpa}, Course: {student.CourseCode})");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"No student found at index {index}.");
            }
        }

        public void ShowAllStudents()
        {
            if (_registry.Count == 0)
            {
                Console.WriteLine("No students registered yet.");
                return;
            }

            for (int i = 0; i < _registry.Count; i++)
            {
                Student student = _registry.GetAt(i);
                Console.WriteLine($"[{i}] {student.Name} (ID: {student.Id}, GPA: {student.Gpa}, Course: {student.CourseCode})");
            }
        }

        // Sorts students by GPA using Selection Sort.
        // Builds a plain array by hand from the registry, sorts that array,
        // then prints the sorted result.
        public void SortStudentsByGpa()
        {
            int count = _registry.Count;
            Student[] students = new Student[count];

            for (int i = 0; i < count; i++)
            {
                students[i] = _registry.GetAt(i);
            }

            for (int i = 0; i < count - 1; i++)
            {
                int smallestIndex = i;

                for (int j = i + 1; j < count; j++)
                {
                    if (students[j].Gpa < students[smallestIndex].Gpa)
                    {
                        smallestIndex = j;
                    }
                }

                if (smallestIndex != i)
                {
                    Student temp = students[i];
                    students[i] = students[smallestIndex];
                    students[smallestIndex] = temp;
                }
            }

            Console.WriteLine("Students sorted by GPA:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"[{i}] {students[i].Name} (ID: {students[i].Id}, GPA: {students[i].Gpa})");
            }
        }

        // Searches for a student by Id using Linear Search.
        // Checks each student one at a time from the start of the registry.
        public Student? SearchStudentById(int id)
        {
            for (int i = 0; i < _registry.Count; i++)
            {
                Student student = _registry.GetAt(i);

                if (student.Id == id)
                {
                    return student;
                }
            }

            return null; // not found
        }

        public int GetStudentCount()
        {
            return _registry.Count;
        }

        public Student GetStudentAt(int index)
        {
            return _registry.GetAt(index);
        }
    }
}