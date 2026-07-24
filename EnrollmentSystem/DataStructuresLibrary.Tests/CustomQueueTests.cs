using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void Enqueue_ShouldIncreaseCount()
        {
            var queue = new CustomQueue<string>();

            queue.Enqueue("A");
            queue.Enqueue("B");

            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void Dequeue_ShouldReturnItemsInFIFOOrder()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");
            queue.Enqueue("third");

            Assert.Equal("first", queue.Dequeue());
            Assert.Equal("second", queue.Dequeue());
            Assert.Equal("third", queue.Dequeue());
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
        public void Dequeue_OnEmptyQueue_ShouldThrowInvalidOperationException()
        {
            var queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_ShouldReturnFrontItem_WithoutRemovingIt()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("front");
            queue.Enqueue("back");

            var peeked = queue.Peek();

            Assert.Equal("front", peeked);
            Assert.Equal(2, queue.Count); // nothing removed
        }

        [Fact]
        public void Peek_OnEmptyQueue_ShouldThrowInvalidOperationException()
        {
            var queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenNoItemsQueued()
        {
            var queue = new CustomQueue<int>();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_AfterEnqueue()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(42);

            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void Queue_ShouldGrowBeyondInitialCapacity()
        {
            // Default starting capacity is 4 — push past it to force Resize()
            var queue = new CustomQueue<int>();
            for (int i = 1; i <= 10; i++)
            {
                queue.Enqueue(i);
            }

            Assert.Equal(10, queue.Count);
            for (int i = 1; i <= 10; i++)
            {
                Assert.Equal(i, queue.Dequeue());
            }
        }

        [Fact]
        public void Queue_ShouldHandleWrapAroundCorrectly()
        {
            // Fill, drain partially, then refill to force the circular
            // buffer's front/rear indices to wrap past the end of the array.
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4); // now full at capacity 4

            queue.Dequeue(); // remove 1 -> front moves forward
            queue.Dequeue(); // remove 2 -> front moves forward again

            queue.Enqueue(5); // rear wraps around to reuse freed slots
            queue.Enqueue(6);

            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
            Assert.Equal(5, queue.Dequeue());
            Assert.Equal(6, queue.Dequeue());
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void ToArray_ShouldReturnItemsInFrontToBackOrder_WithoutRemovingThem()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            var snapshot = queue.ToArray();

            Assert.Equal(new[] { "A", "B", "C" }, snapshot);
            Assert.Equal(3, queue.Count); // ToArray must not drain the queue
        }

        [Fact]
        public void ToArray_ShouldReflectFrontToBackOrder_EvenAfterWrapAround()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue(); // front moves off 1
            queue.Enqueue(5); // wraps around into the freed slot

            var snapshot = queue.ToArray();

            Assert.Equal(new[] { 2, 3, 4, 5 }, snapshot);
        }
    }
}