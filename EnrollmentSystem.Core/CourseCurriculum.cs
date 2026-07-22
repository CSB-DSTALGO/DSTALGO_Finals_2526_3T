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
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            if (SearchCourse(course.Code) != null)
                throw new InvalidOperationException($"Course {course.Code} already exists!");

            _curriculum.Add(course);
        }

        public bool RemoveCourse(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Course code cannot be empty");

            var courseToDelete = SearchCourse(code);
            if (courseToDelete == null)
                return false;

            return _curriculum.Remove(courseToDelete);
        }

        public Course? SearchCourse(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Course code cannot be empty");

            foreach (var course in _curriculum)
            {
                if (course.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
                {
                    return course;
                }
            }
            return null;
        }

        public void ShowCurriculum()
        {
            if (_curriculum.IsEmpty)
            {
                Console.WriteLine("The curriculum is empty.");
                return;
            }

            Console.WriteLine("=== COURSE CURRICULUM ===");
            int index = 1;
            foreach (var course in _curriculum)
            {
                Console.WriteLine($"{index}. {course.Code} - {course.Title} ({course.Units} units)");
                index++;
            }
            Console.WriteLine($"Total: {_curriculum.Count} courses");
        }

        public int GetTotalUnits()
        {
            int total = 0;
            foreach (var course in _curriculum)
            {
                total += course.Units;
            }
            return total;
        }

        public int GetCourseCount()
        {
            return _curriculum.Count;
        }

        public void SortByCourseCode()
        {
            if (_curriculum.Count <= 1) return;

            Course[] courseArray = new Course[_curriculum.Count];
            int i = 0;
            foreach (var course in _curriculum)
            {
                courseArray[i] = course;
                i++;
            }

            for (int outer = 0; outer < courseArray.Length - 1; outer++)
            {
                for (int inner = 0; inner < courseArray.Length - outer - 1; inner++)
                {
                    if (string.Compare(courseArray[inner].Code, courseArray[inner + 1].Code, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var temp = courseArray[inner];
                        courseArray[inner] = courseArray[inner + 1];
                        courseArray[inner + 1] = temp;
                    }
                }
            }

            _curriculum.Clear();
            foreach (var course in courseArray)
            {
                _curriculum.Add(course);
            }
        }

        public Course[] GetAllCourses()
        {
            Course[] result = new Course[_curriculum.Count];
            int i = 0;
            foreach (var course in _curriculum)
            {
                result[i] = course;
                i++;
            }
            return result;
        }
    }
}