using Xunit;
using System;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void Enqueue_And_Dequeue_ShouldProcessInFIFOOrder()
        {
            var queue = new CustomQueue<string>();

            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            Assert.Equal("First", queue.Dequeue());
            Assert.Equal("Second", queue.Dequeue());
            Assert.Equal("Third", queue.Dequeue());
        }

        [Fact]
        public void Dequeue_OnEmptyQueue_ThrowsInvalidOperationException()
        {
            var queue = new CustomQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            var result = queue.Peek();

            Assert.Equal(10, result);
            Assert.False(queue.IsEmpty());
            Assert.Equal(10, queue.Dequeue());
        }

        [Fact]
        public void Peek_OnEmptyQueue_ThrowsInvalidOperationException()
        {
            var queue = new CustomQueue<double>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Fact]
        public void IsEmpty_ReturnsTrue_WhenNoElements()
        {
            var queue = new CustomQueue<char>();
            Assert.True(queue.IsEmpty());
            queue.Enqueue('A');
            Assert.False(queue.IsEmpty());
            queue.Dequeue();
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Clear_ShouldRemoveAllElements()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("Test");
            queue.Enqueue("Data");

            queue.Clear();

            Assert.True(queue.IsEmpty());
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Enqueue_ShouldDoubleCapacity_WhenFull()
        {
            var queue = new CustomQueue<int>();
            for (int i = 0; i < 5; i++) queue.Enqueue(i);

            for (int i = 0; i < 5; i++) Assert.Equal(i, queue.Dequeue());
        }

        [Fact]
        public void Sort_ShouldOrderElementsAscending()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(4);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Sort();

            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
            Assert.Equal(5, queue.Dequeue());
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenItemExists()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("Apple");
            queue.Enqueue("Banana");

            Assert.True(queue.Contains("Banana"));
            Assert.False(queue.Contains("Grape"));
        }
    }
}