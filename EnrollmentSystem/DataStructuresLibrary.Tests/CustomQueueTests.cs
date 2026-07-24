using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void Enqueue_SingleItem_IncreasesCountAndStoresValue()
        {
            var queue = new CustomQueue<string>();

            queue.Enqueue("First");

            Assert.Equal(1, queue.Count);
            Assert.False(queue.IsEmpty());
            Assert.Equal("First", queue.Peek());

        }
        [Fact]
        public void Dequeue_RemovesAndReturnsFrontItemInFIFO()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            int firstOut = queue.Dequeue();

            Assert.Equal(10, firstOut);
            Assert.Equal(2, queue.Count);
            Assert.Equal(20, queue.Peek());
        }
        [Fact]
        public void Enqueue_BeyondCapacity_TriggersResizeAndPreservesOrder()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3); //Forces array resize

            Assert.Equal(3, queue.Count);
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
        }
        [Fact]
        public void CircularWrapAround_WorksCorrectlyAfterEnqueueAndDequeue()
        {
            var queue = new CustomQueue<int>(); //initial capacity = 2
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue(); //Front moves to index 1

            queue.Enqueue(3); //Rear wraps around to index 0

            Assert.Equal(2, queue.Count);
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
            Assert.True(queue.IsEmpty());
        }
        [Fact]
        public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
        {
            var queue = new CustomQueue<double>();

            Assert.Throws<InvalidOperationException>(() => { queue.Dequeue(); });
        }
        [Fact]
        public void Peek_EmptyQueue_ThrowsInvalidOperationException()
        {
            var queue = new CustomQueue<char>();

            Assert.Throws<InvalidOperationException>(() => { queue.Peek(); });
        }
    }
}