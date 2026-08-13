using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        // ---------------- Constructor / Count ----------------

        [Fact]
        public void Constructor_ShouldCreateEmptyQueue()
        {
            var queue = new CustomQueue<int>();

            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Count_ShouldIncrease_AsItemsAreEnqueued()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void Count_ShouldDecrease_AsItemsAreDequeued()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.Equal(1, queue.Count);
        }

        // ---------------- Enqueue ----------------

        [Fact]
        public void Enqueue_ShouldIncreaseCountByOne()
        {
            var queue = new CustomQueue<string>();

            queue.Enqueue("A");

            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Enqueue_ShouldPlaceItemAtRear_KeepingFrontUnchanged()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);

            queue.Enqueue(2);

            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void Enqueue_ShouldTriggerResize_WhenCapacityIsExceeded()
        {
            var queue = new CustomQueue<int>();

            for (int i = 0; i < 20; i++)
            {
                queue.Enqueue(i);
            }

            Assert.Equal(20, queue.Count);
            Assert.Equal(0, queue.Peek());
        }

        // ---------------- Dequeue ----------------

        [Fact]
        public void Dequeue_ShouldReturnItemsInFIFOOrder()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }

        [Fact]
        public void Dequeue_ShouldDecreaseCount()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Dequeue_ShouldThrowInvalidOperationException_WhenQueueIsEmpty()
        {
            var queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Dequeue_ShouldMaintainFifoOrder_AcrossWraparoundAndResize()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue(); // front now at index 1, one slot free at index 0
            queue.Enqueue(4);
            queue.Enqueue(5); // forces resize while front index is not 0

            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
            Assert.Equal(5, queue.Dequeue());
        }

        // ---------------- Peek ----------------

        [Fact]
        public void Peek_ShouldReturnFrontItem_WithoutRemovingIt()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(6);

            int peeked = queue.Peek();

            Assert.Equal(5, peeked);
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void Peek_ShouldReturnSameFrontItem_OnRepeatedCalls()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("front");

            Assert.Equal("front", queue.Peek());
            Assert.Equal("front", queue.Peek());
        }

        [Fact]
        public void Peek_ShouldThrowInvalidOperationException_WhenQueueIsEmpty()
        {
            var queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        // ---------------- IsEmpty ----------------

        [Fact]
        public void IsEmpty_ShouldReturnTrue_ForNewQueue()
        {
            var queue = new CustomQueue<int>();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_AfterEnqueue()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);

            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_AfterAllItemsDequeued()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();
            queue.Dequeue();

            Assert.True(queue.IsEmpty());
        }
    }
}
