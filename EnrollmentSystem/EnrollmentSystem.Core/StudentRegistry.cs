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

        public Student GetStudentDetails(int index)
        {
            return _registry.Get(index);
        }

        public void ShowAllStudents()
        {
            for (int i = 0; i < _registry.Count; i++)
            {
                var student = _registry.Get(i);
                if (student != null)
                {
                    Console.WriteLine($"[{student.Id}] [{student.Name}] -- {student.CourseCode}");
                }
            }
        }
        // METHODS REQUIRED BY EnrollmentCoreTest.cs
        public int GetStudentCount()
        {
            return _registry.Count;
        }
        public Student GetStudentAt(int index)
        {
            return GetStudentDetails(index);
        }
        public bool RemoveStudent(string id)
        {
            for (int i = 0; i < _registry.Count; i++)
            {
                var student = _registry.Get(i);
                if (student != null && student.Id == id)
                {
                    _registry.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}