// CourseCurriculum.cs
using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class CourseCurriculum
    {
        private readonly CustomSinglyLinkedList<Course> _curriculum;

        public CourseCurriculum()
        {
            _curriculum = new CustomSinglyLinkedList<Course>();
        }

        public void InsertCourse(Course course)
        {
            _curriculum.AddLast(course);
        }

        public void DeleteCourse(string courseCode)
        {
            RemoveCourse(courseCode);
        }

        public Course? SearchCourse(string courseCode)
        {
            var current = _curriculum.Head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Code == courseCode)
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }

        public void ShowCurriculum()
        {
            var current = _curriculum.Head;
            while (current != null)
            {
                if (current.Data != null)
                {
                    Console.WriteLine($"{current.Data.Code}: {current.Data.Title}({current.Data.Units} Units)");
                }
                current = current.Next;
            }
        }
        // METHODS REQUIRED BY EnrollmentCoreTest.cs
        public bool RemoveCourse(string courseCode)
        {
            var current = _curriculum.Head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Code == courseCode)
                {
                    return _curriculum.Remove(current.Data);
                }
                current = current.Next;
            }
            return false;
        }
        public int GetTotalUnits()
        {
            int totalUnits = 0;
            var current = _curriculum.Head;
            while (current != null)
            {
                if (current.Data != null)
                {
                    totalUnits += current.Data.Units;
                }
                current = current.Next;
            }
            return totalUnits;
        }
    }
}