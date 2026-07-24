
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
 
        /// Inserts a new student record at the end of the registry.
        public void RegisterStudent(Student student)
        {
            _registry.Add(student);
        }
 
        /// Removes a student record by its index in the registry.
        public void UnregisterStudent(int index)
        {
            try
            {
                _registry.RemoveAt(index);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"No student found at index {index}.");
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
            Student[] all = _registry.ToArray();
 
            if (all.Length == 0)
            {
                Console.WriteLine("No students registered yet.");
                return;
            }
 
            for (int i = 0; i < all.Length; i++)
            {
                Console.WriteLine($"[{i}] {all[i].Name} (ID: {all[i].Id}, GPA: {all[i].Gpa}, Course: {all[i].CourseCode})");
            }
        }
 
        public void SortStudentsByGpa()
        {
            Student[] students = _registry.ToArray();
            int n = students.Length;
 
            for (int i = 0; i < n - 1; i++)
            {
                int smallestIndex = i;
 
                for (int j = i + 1; j < n; j++)
                {
                    if (students[j].CompareTo(students[smallestIndex]) < 0)
                    {
                        smallestIndex = j;
                    }
                }
 
                if (smallestIndex != i)
                {
                    (students[i], students[smallestIndex]) = (students[smallestIndex], students[i]);
                }
            }
 
            for (int i = 0; i < students.Length; i++)
            {
                _registry.SetAt(i, students[i]);
            }
        }
 
        public Student? SearchStudentById(int id)
        {
            Student[] snapshot = _registry.ToArray();
            Array.Sort(snapshot, (a, b) => a.Id.CompareTo(b.Id));
 
            int low = 0;
            int high = snapshot.Length - 1;
 
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int comparison = snapshot[mid].Id.CompareTo(id);
 
                if (comparison == 0)
                    return snapshot[mid];
                else if (comparison < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
 
            return null; // not found
        }
    }
}