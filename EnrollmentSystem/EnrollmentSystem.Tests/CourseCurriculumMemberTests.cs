using System;
using System.IO;
using Xunit;
using EnrollmentSystem.Core;

namespace EnrollmentSystem.Tests
{
    public class CourseCurriculumMemberTests
    {
        private static string GetPrintedOutput(Action action)
        {
            var writer = new StringWriter();
            var original = Console.Out;

            Console.SetOut(writer);
            action();
            Console.SetOut(original);

            return writer.ToString();
        }

        [Fact]
        public void InsertCourse_ShouldIncreaseTheCount()
        {
            var curriculum = new CourseCurriculum();

            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            Assert.Equal(1, curriculum.Count);
        }

        [Fact]
        public void InsertCourse_ShouldAddManyCourses()
        {
            var curriculum = new CourseCurriculum();

            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));
            curriculum.InsertCourse(new Course("CS103", "Algorithms", 3));

            Assert.Equal(3, curriculum.Count);
        }

        [Fact]
        public void InsertCourse_ShouldKeepTheOrderOfTheCourses()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            string output = GetPrintedOutput(() => curriculum.ShowCurriculum());

            Assert.True(output.IndexOf("CS101") < output.IndexOf("CS102"));
        }

        [Fact]
        public void DeleteCourse_ShouldReturnTrue_WhenTheCourseExists()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            bool removed = curriculum.DeleteCourse("CS102");

            Assert.True(removed);
            Assert.Equal(0, curriculum.Count);
        }

        [Fact]
        public void DeleteCourse_ShouldReturnFalse_WhenTheCourseIsNotThere()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            bool removed = curriculum.DeleteCourse("CS999");

            Assert.False(removed);
            Assert.Equal(1, curriculum.Count);
        }

        [Fact]
        public void DeleteCourse_ShouldOnlyRemoveTheMatchingCourse()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            curriculum.DeleteCourse("CS101");
            string output = GetPrintedOutput(() => curriculum.ShowCurriculum());

            Assert.DoesNotContain("CS101", output);
            Assert.Contains("CS102", output);
        }

        [Fact]
        public void CalculateTotalUnits_ShouldReturnZero_WhenCurriculumIsEmpty()
        {
            var curriculum = new CourseCurriculum();

            Assert.Equal(0, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void CalculateTotalUnits_ShouldAddUpAllTheUnits()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            Assert.Equal(7, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void CalculateTotalUnits_ShouldGoDown_AfterACourseIsDeleted()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            curriculum.DeleteCourse("CS102");

            Assert.Equal(3, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void ShowCurriculum_ShouldSayItIsEmpty_WhenThereAreNoCourses()
        {
            var curriculum = new CourseCurriculum();

            string output = GetPrintedOutput(() => curriculum.ShowCurriculum());

            Assert.Contains("empty", output);
        }

        [Fact]
        public void ShowCurriculum_ShouldPrintTheCourseDetails()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            string output = GetPrintedOutput(() => curriculum.ShowCurriculum());

            Assert.Contains("CS101", output);
            Assert.Contains("Intro to CS", output);
        }

        [Fact]
        public void ShowCurriculum_ShouldPrintTheTotalUnits()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 4));

            string output = GetPrintedOutput(() => curriculum.ShowCurriculum());

            Assert.Contains("Total Units: 7", output);
        }

        [Fact]
        public void SearchCourse_ShouldReturnTrue_WhenTheCourseIsInTheCurriculum()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS102", "Data Structures", 3);
            curriculum.InsertCourse(course);

            Assert.True(curriculum.SearchCourse(course));
        }

        [Fact]
        public void SearchCourse_ShouldReturnFalse_WhenTheCurriculumIsEmpty()
        {
            var curriculum = new CourseCurriculum();
            var course = new Course("CS102", "Data Structures", 3);

            Assert.False(curriculum.SearchCourse(course));
        }

        [Fact]
        public void SearchCourse_ShouldReturnFalse_WhenTheCourseWasNeverAdded()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            var other = new Course("CS999", "Unknown", 3);

            Assert.False(curriculum.SearchCourse(other));
        }

        [Fact]
        public void SearchCourseByCode_ShouldReturnTheCourse_WhenItIsFound()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            Course? result = curriculum.SearchCourse("CS102");

            Assert.NotNull(result);
            Assert.Equal("Data Structures", result!.Title);
        }

        [Fact]
        public void SearchCourseByCode_ShouldReturnNull_WhenTheCodeIsNotThere()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));

            Assert.Null(curriculum.SearchCourse("CS999"));
        }

        [Fact]
        public void SearchCourseByCode_ShouldReturnNull_WhenTheCurriculumIsEmpty()
        {
            var curriculum = new CourseCurriculum();

            Assert.Null(curriculum.SearchCourse("CS101"));
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldDoNothing_WhenCurriculumIsEmpty()
        {
            var curriculum = new CourseCurriculum();

            curriculum.SortCurriculumByUnits();

            Assert.Equal(0, curriculum.Count);
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldArrangeTheCoursesByUnits()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS103", "Algorithms", 5));
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 1));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            curriculum.SortCurriculumByUnits();
            string output = GetPrintedOutput(() => curriculum.ShowCurriculum());

            Assert.True(output.IndexOf("CS101") < output.IndexOf("CS102"));
            Assert.True(output.IndexOf("CS102") < output.IndexOf("CS103"));
        }

        [Fact]
        public void SortCurriculumByUnits_ShouldNotLoseAnyCourses()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS103", "Algorithms", 5));
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 1));

            curriculum.SortCurriculumByUnits();

            Assert.Equal(2, curriculum.Count);
            Assert.Equal(6, curriculum.CalculateTotalUnits());
        }

        [Fact]
        public void Count_ShouldBeZero_WhenTheCurriculumIsNew()
        {
            var curriculum = new CourseCurriculum();

            Assert.Equal(0, curriculum.Count);
        }

        [Fact]
        public void Count_ShouldMatchTheNumberOfCoursesAdded()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            Assert.Equal(2, curriculum.Count);
        }

        [Fact]
        public void Count_ShouldGoBackToZero_WhenAllCoursesAreDeleted()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Intro to CS", 3));
            curriculum.InsertCourse(new Course("CS102", "Data Structures", 3));

            curriculum.DeleteCourse("CS101");
            curriculum.DeleteCourse("CS102");

            Assert.Equal(0, curriculum.Count);
        }
    }
}