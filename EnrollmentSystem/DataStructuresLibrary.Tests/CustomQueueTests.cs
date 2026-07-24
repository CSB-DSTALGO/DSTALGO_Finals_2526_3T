using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void Dequeue_ShouldRemoveAndReturnFrontItem()
        {
            CustomQueue<string> queue = new CustomQueue<string>();

            queue.Enqueue("Student A");
            queue.Enqueue("Student B");

            string removedStudent = queue.Dequeue();

            Assert.Equal("Student A", removedStudent);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenQueueHasNoItems()
        {
            CustomQueue<string> queue = new CustomQueue<string>();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_WhenQueueHasAnItem()
        {
            CustomQueue<string> queue = new CustomQueue<string>();

            queue.Enqueue("Student A");

            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void Peek_ShouldReturnFrontItemWithoutRemovingIt()
        {
            CustomQueue<string> queue = new CustomQueue<string>();

            queue.Enqueue("Student A");
            queue.Enqueue("Student B");

            string frontStudent = queue.Peek();

            Assert.Equal("Student A", frontStudent);
            Assert.Equal(2, queue.Count);
        }   
    }
}