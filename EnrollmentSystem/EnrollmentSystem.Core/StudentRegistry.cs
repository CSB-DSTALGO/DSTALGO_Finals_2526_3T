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

        public bool UnregisterStudent(int index)
        {
            if (index < 0 || index >= _registry.Count)
            return false;

            _registry.RemoveAt(index);
            return true;
        }

        public Student GetStudentAt(int index)
        {
            if (index < 0 || index >= _registry.Count)
            return null;

            return _registry.Get(index);
        }

        public bool RemoveStudent(string id)
        {
        for (int i = 0; i < _registry.Count; i++)
        {
        if (_registry.Get(i).Id.ToString() == id)
        {
            _registry.RemoveAt(i);
            return true;
        }
        }
        return false;
        }

        public double CalculateAverageGpa()
    {
        if (_registry.Count == 0)
        return 0;

        double total = 0;
        for (int i = 0; i < _registry.Count; i++)
        {
        total += _registry.Get(i).Gpa;
        }

        return total / _registry.Count;
    }

        public Student GetStudentDetails(int index) => _registry.Get(index);

        public int GetStudentCount()
        {
            int count = 0;
            for (int i = 0; i < _registry.Count; i++)
            {
            count++;
            }
            return count;
        }

        public void ShowAllStudents()
        {
            Console.WriteLine("All Students:\n");

            //Use for loop to display all elements in array
            for (int i = 0; i < _registry.Count; i++)
            {
                Console.Write(_registry.Get(i) + "\t");
            }
        }

        public void SortStudents()
        {
            _registry.BubbleSort();
        }

        public int SearchStudent(Student student)
        {
           return _registry.LinearSearch(student);
        }
    }
}