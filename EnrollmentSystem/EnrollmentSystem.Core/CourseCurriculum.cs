using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class CourseCurriculum
    {
        private readonly CustomSinglyLinkedList<Course> _courses = new();

        public int Count => _courses.Count;

        // Appends a course node to the chain
        public void InsertCourse(Course course)
        {
            _courses.AddLast(course);
        }

        // Removes a targeted node by course code[cite: 1]
        public bool DeleteCourse(string courseCode)
        {
            return _courses.Remove(c => c.Code.Equals(courseCode, StringComparison.OrdinalIgnoreCase));
        }

        // Locates and returns a course[cite: 1]
        public Course? SearchCourse(string courseCode)
        {
            var node = _courses.Find(c => c.Code.Equals(courseCode, StringComparison.OrdinalIgnoreCase));
            return node?.Data;
        }

        // Traverses and prints the continuous chain[cite: 1]
        public void ShowCurriculum()
        {
            var current = _courses.Head;
            if (current is null)
            {
                Console.WriteLine("Curriculum is empty.");
                return;
            }

            while (current is not null)
            {
                Console.WriteLine($"[{current.Data.Code}] {current.Data.Title} - {current.Data.Units} units");
                current = current.Next;
            }
        }

        // Calculates total course units
        public int CalculateTotalUnits()
        {
            var total = 0;
            var current = _courses.Head;

            while (current is not null)
            {
                total += current.Data.Units;
                current = current.Next;
            }

            return total;
        }

        // Sorts curriculum by course units
        public void SortCurriculumByUnits()
        {
            _courses.Sort((left, right) => left.Units.CompareTo(right.Units));
        }
    }
}