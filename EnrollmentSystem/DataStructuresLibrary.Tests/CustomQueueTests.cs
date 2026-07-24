using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void Enqueue_ShouldIncreaseCount()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Dequeue_ShouldReturnFirstElement()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            var result = queue.Dequeue();

            Assert.Equal(10, result);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Peek_ShouldReturnFrontWithoutRemoving()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            var result = queue.Peek();

            Assert.Equal(10, result);
            Assert.Equal(2, queue.Count);
        }
    }
}