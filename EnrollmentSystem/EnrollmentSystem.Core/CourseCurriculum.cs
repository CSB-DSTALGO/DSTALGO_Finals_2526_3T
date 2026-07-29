using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class CourseCurriculum
    {
        private CustomSinglyLinkedList<Course> _courses = new CustomSinglyLinkedList<Course>();

        public int Count
        {
            get
            {
                return _courses.Count;
            }
        }

        // Appends a course node to the chain
        public void InsertCourse(Course course)
        {
            _courses.AddLast(course);
        }

        // Removes a targeted node by course code
        public bool DeleteCourse(string courseCode)
        {
            return _courses.Remove(c => c.Code.ToUpper() == courseCode.ToUpper());
        }

        // Locates and returns a course by code
        public Course? SearchCourse(string courseCode)
        {
            Node<Course>? node = _courses.Find(c => c.Code.ToUpper() == courseCode.ToUpper());

            if (node != null)
            {
                return node.Data;
            }

            return null;
        }

        // Overload to allow searching directly by Course object (fixes line 146 in EnrollmentCoreTest.cs)
        public bool SearchCourse(Course course)
        {
            if (course == null) return false;
            return SearchCourse(course.Code) != null;
        }

        // Traverses and prints the continuous chain
        public void ShowCurriculum()
        {
            Node<Course>? current = _courses.Head;

            if (current == null)
            {
                Console.WriteLine("Curriculum is empty.");
                return;
            }

            while (current != null)
            {
                Console.WriteLine("[" + current.Data.Code + "] " + current.Data.Title + " - " + current.Data.Units + " units");
                current = current.Next;
            }
        }

        // Calculates total course units
        public int CalculateTotalUnits()
        {
            int total = 0;
            Node<Course>? current = _courses.Head;

            while (current != null)
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