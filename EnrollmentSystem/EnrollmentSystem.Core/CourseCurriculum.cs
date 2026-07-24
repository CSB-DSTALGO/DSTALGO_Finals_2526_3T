
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class CourseCurriculum
    {
        // The  linked list that stores Course objects.
        private readonly CustomSinglyLinkedList<Course> _curriculum;

        // Initializes a new empty course curriculum.
        public CourseCurriculum()
        {
            _curriculum = new CustomSinglyLinkedList<Course>();
        }

        // Adds a course to the end of the curriculum.  Throws ArgumentNullException if the course is null.
        public void InsertCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            _curriculum.AddLast(course);
        }

        // Removes a course from the curriculum by its course code. Uses RemoveByPredicate to perform a linear search for the target. Returns true if the course was found and removed; false otherwise.
        public bool DeleteCourse(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode))
                return false;

            return _curriculum.RemoveByPredicate(c => c.Code == courseCode);
        }
        public bool RemoveCourse(string courseCode)
        {
            return DeleteCourse(courseCode);
        }

        // Searches for a course by its course code.Returns the matching Course if found; null otherwise.
        public Course? SearchCourse(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode))
                return null;

            return _curriculum.Find(c => c.Code == courseCode);
        }

        public bool SearchCourse(Course course)
        {
            if (course == null)
                return false;

            return _curriculum.Find(c => c.Code == course.Code) != null;
        }

        // Displays all courses currently in the curriculum.
        public void ShowCurriculum()
        {
            Console.WriteLine("--- Course Curriculum ---");
            if (_curriculum.Count == 0)
            {
                Console.WriteLine("No courses in curriculum.");
                return;
            }

            _curriculum.Traverse(course => Console.WriteLine($"  {course.Code} | {course.Title} | {course.Units} units"));
        }

        // Calculates the total number of units across all courses.
        public int CalculateTotalUnits()
        {
            int total = 0;
            _curriculum.Traverse(course => total += course.Units);
            return total;
        }
        public int GetTotalUnits()
        {
            return CalculateTotalUnits();
        }

        // Returns the total number of courses in the curriculum.
        public int GetCourseCount()
        {
            return _curriculum.Count;
        }

        // Sorts the curriculum alphabetically by course code.Uses the Bubble Sort algorithm integrated into the linked list.
        public void SortCurriculum()
        {
            _curriculum.Sort((a, b) => string.Compare(a.Code, b.Code, StringComparison.OrdinalIgnoreCase));
        }
    }
}