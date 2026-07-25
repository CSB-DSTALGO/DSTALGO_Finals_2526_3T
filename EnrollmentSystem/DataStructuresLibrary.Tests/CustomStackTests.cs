using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void Enqueue_OneItem_CountBecomeOne()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            queue.Enqueue(10);

            Assert.Equal(1, queue.Count);
        }


        [Fact]
        public void Dequeue_ReturnsFirstItemAdded() 
        {
            CustomQueue<string> queue = new CustomQueue<string>();

            queue.Enqueue("student A");
            queue.Enqueue("student B");

            string result = queue.Dequeue();

            Assert.Equal("student A", result);
        }

        [Fact]
        public void Peek_ReturnsFirstItemWithoutRemovingIt() 
        {
            CustomQueue<string> queue = new CustomQueue<string> ();

            queue.Enqueue("student A");
            queue.Enqueue("student B");

            string result = queue.Peek();

            Assert.Equal("student A", result);
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void IsEmpty_NewQueue_ReturnsTrue() 
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            bool result = queue.IsEmpty();

            Assert.True(result);
        }
    }
}