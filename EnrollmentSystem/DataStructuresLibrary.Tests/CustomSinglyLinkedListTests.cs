using System;
using Xunit;
using DataStructuresLibrary;
using EnrollmentSystem.Core;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        // ------------------------------------------
        // Tests for CustomSinglyLinkedList<T>
        // ------------------------------------------

        [Fact]
        public void AddLast_ShouldAppendItemAndIncreaseCount()
        {
            var list = new CustomSinglyLinkedList<string>();

            list.AddLast("CS101");
            list.AddLast("CS102");

            Assert.Equal(2, list.Count);
            Assert.Equal("CS101", list.Head!.Data);
            Assert.Equal("CS102", list.Head.Next!.Data);
        }

        [Fact]
        public void Remove_ShouldRemoveMatchingItem()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            bool result = list.Remove(x => x == 10);

            Assert.True(result);
            Assert.Equal(1, list.Count);
            Assert.Equal(20, list.Head!.Data);
        }

        [Fact]
        public void Find_ShouldReturnMatchingNode()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("MATH1");

            var node = list.Find(x => x == "MATH1");

            Assert.NotNull(node);
            Assert.Equal("MATH1", node!.Data);
        }

        // ------------------------------------------
        // Tests for CourseCurriculum
        // ------------------------------------------

        [Fact]
        public void InsertCourse_ShouldAddCourseToLinkedList()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Programming 1", 3));

            Assert.Equal(1, curriculum.Count);
            Assert.NotNull(curriculum.SearchCourse("CS101"));
        }

        [Fact]
        public void DeleteCourse_ShouldRemoveTargetCourse()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("CS101", "Programming 1", 3));

            bool removed = curriculum.DeleteCourse("CS101");

            Assert.True(removed);
            Assert.Equal(0, curriculum.Count);
            Assert.Null(curriculum.SearchCourse("CS101"));
        }

        [Fact]
        public void SearchCourse_ShouldReturnCorrectCourse()
        {
            var curriculum = new CourseCurriculum();
            curriculum.InsertCourse(new Course("DSTALGO", "Data Structures", 3));

            var course = curriculum.SearchCourse("DSTALGO");

            Assert.NotNull(course);
            Assert.Equal("Data Structures", course!.Title);
        }
    }
}