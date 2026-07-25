namespace EnrollmentSystem
{

    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Units { get; set; }

        public Course(string code, string name, int units)
        {
            CourseCode = code;
            CourseName = name;
            Units = units;
        }

        public override string ToString()
        {
            return $"[{CourseCode}] {CourseName} ({Units} units)";
        }
    }

    public class CourseCurriculum
    {
        private CustomSinglyLinkedList<Course> courses;

        public CourseCurriculum()
        {
            courses = new CustomSinglyLinkedList<Course>();
        }

        public void InsertCourse(Course course)
        {
            courses.Add(course);
            Console.WriteLine($"Course {course.CourseCode} inserted successfully.");
        }

        public void DeleteCourse(string courseCode)
        {

            int index = -1;
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses.Get(i).CourseCode == courseCode)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                courses.RemoveAt(index);
                Console.WriteLine($"Course {courseCode} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Course {courseCode} not found.");
            }
        }

        public Course SearchCourse(string courseCode)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                Course course = courses.Get(i);
                if (course.CourseCode == courseCode)
                {
                    Console.WriteLine($"Course found: {course}");
                    return course;
                }
            }
            Console.WriteLine($"Course {courseCode} not found.");
            return null;
        }

        public void ShowCurriculum()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("Curriculum is empty.");
                return;
            }

            Console.WriteLine("\n===== COURSE CURRICULUM =====");
            courses.ShowAll();
            Console.WriteLine("=============================\n");
        }
        public void SortCoursesByCode()
        {
            if (courses.Count <= 1) return;

            for (int i = 0; i < courses.Count - 1; i++)
            {
                for (int j = 0; j < courses.Count - i - 1; j++)
                {
                    Course current = courses.Get(j);
                    Course next = courses.Get(j + 1);


                    if (string.Compare(current.CourseCode, next.CourseCode) > 0)
                    {

                        SwapCourses(j, j + 1);
                    }
                }
            }
            Console.WriteLine("Courses sorted by Course Code!");
        }

        private void SwapCourses(int index1, int index2)
        {
            Course course1 = courses.Get(index1);
            Course course2 = courses.Get(index2);


            Course temp1 = new Course(course2.CourseCode, course2.CourseName, course2.Units);
            Course temp2 = new Course(course1.CourseCode, course1.CourseName, course1.Units);

        }


        public Course SearchByCourseName(string courseName)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                Course course = courses.Get(i);
                if (course.CourseName.Contains(courseName))
                {
                    return course;
                }
            }
            return null;
        }
    }
}