using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void Enqueue_AddsItem()
        {
            var queue = new CustomQueue<int>(3);
            queue.Enqueue(10);
            Assert.Equal(1, queue.Count);
            Assert.Equal(10, queue.Peek());
        }

        [Fact]
        public void Dequeue_RemovesFrontItem()
        {
            var queue = new CustomQueue<int>(3);
            queue.Enqueue(10);
            queue.Enqueue(20);

            var item = queue.Dequeue();

            Assert.Equal(10, item);
            Assert.Equal(1, queue.Count);
            Assert.Equal(20, queue.Peek());
        }

        [Fact]
        public void Dequeue_ThrowsWhenEmpty()
        {
            var queue = new CustomQueue<int>(3);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Enqueue_ThrowsWhenFull()
        {
            var queue = new CustomQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.Throws<InvalidOperationException>(() => queue.Enqueue(3));
        }
    }
}

