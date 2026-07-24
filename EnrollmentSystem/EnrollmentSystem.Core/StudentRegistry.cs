// StudentRegistry.cs
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

        public void RegisterStudent(Student student)
        {
            _registry.Add(student);
        }

        public void UnregisterStudent(int index)
        {
            _registry.RemoveAt(index);
        }

        public Student GetStudentDetails(int index) => _registry.Get(index);

        public void ShowAllStudents()
        {
            Console.WriteLine("All Students:\n");
            for (int i = 0; i < _registry.Count; i++)
            {
                Console.Write($"_registry.Get(i)\t");
            }
        }
    }
}