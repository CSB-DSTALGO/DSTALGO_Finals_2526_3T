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
            throw new NotImplementedException();
        }

        public void UnregisterStudent(int index)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentDetails(int index)
        {
            throw new NotImplementedException();
        }

        public void ShowAllStudents()
        {
            throw new NotImplementedException();
        }
    }
}