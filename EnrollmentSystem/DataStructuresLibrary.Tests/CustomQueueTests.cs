using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void NewQueue_ShouldBeEmpty()
        {
            var queue = new CustomQueue<int>();

            Assert.True(queue.IsEmpty());
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Enqueue_ShouldAddItemAndIncreaseCount()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(10);

            Assert.False(queue.IsEmpty());
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Enqueue_MultipleItems_ShouldKeepFIFOOrder()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
        }

        [Fact]
        public void Enqueue_PastInitialCapacity_ShouldResizeAndKeepOrder()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.Equal(5, queue.Count);
            Assert.Equal(1, queue.Dequeue()); 
        }

        [Fact]
        public void Dequeue_ShouldRemoveAndReturnFrontItem()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");

            string result = queue.Dequeue();

            Assert.Equal("first", result);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Dequeue_OnEmptyQueue_ShouldThrowException()
        {
            var queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_ShouldReturnFrontItemWithoutRemoving()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(100);
            queue.Enqueue(200);

            int result = queue.Peek();

            Assert.Equal(100, result);
            Assert.Equal(2, queue.Count); 
        }

        [Fact]
        public void Peek_OnEmptyQueue_ShouldThrowException()
        {
            var queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Fact]
        public void IsEmpty_OnNewQueue_ShouldReturnTrue()
        {
            var queue = new CustomQueue<int>();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void IsEmpty_AfterEnqueue_ShouldReturnFalse()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);

            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void IsEmpty_AfterDequeueingAllItems_ShouldReturnTrue()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Dequeue();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenItemExists()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);

            Assert.True(queue.Contains(10));
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);

            Assert.False(queue.Contains(99));
        }

        [Fact]
        public void Sort_ShouldOrderItemsAscending()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(30);
            queue.Enqueue(10);
            queue.Enqueue(20);

            queue.Sort();

            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }

        [Fact]
        public void Sort_OnEmptyQueue_ShouldNotThrow()
        {
            var queue = new CustomQueue<int>();

            var exception = Record.Exception(() => queue.Sort());

            Assert.Null(exception);
        }

        [Fact]
        public void Sort_WithSingleItem_ShouldNotChangeQueue()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(42);

            queue.Sort();

            Assert.Equal(42, queue.Peek());
            Assert.Equal(1, queue.Count);
        }
    }
}