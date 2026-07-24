namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class CourseCurriculum
{
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

            _curriculum.AddLast(course);
        }

        public bool DeleteCourse(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode))
                return false;

            return _curriculum.RemoveByPredicate(c => c.Code == courseCode);
        }

        public Course? SearchCourse(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode))
                return null;

            return _curriculum.Find(c => c.Code == courseCode);
        }

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

        public int CalculateTotalUnits()
        {
            int total = 0;
            _curriculum.Traverse(course => total += course.Units);
            return total;
        }

        public int GetCourseCount()
        {
            return _curriculum.Count;
        }
    }


    //DIKO PA GAWA SORT GUYS 
    //public void SortCurriculumByUnits() => throw new NotImplementedException();
}