using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    // Unit tests for the CustomQueue class.
    public class CustomQueueTests
    {
        // Verifies that enqueuing an item increases
        // the number of elements in the queue.
        [Fact]
        public void Enqueue_ShouldIncreaseCount()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(10);

            Assert.Equal(1, queue.Count);
        }

        // Verifies that Dequeue removes and returns
        // the first item inserted (FIFO order).
        [Fact]
        public void Dequeue_ShouldReturnFirstItem()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);

            int value = queue.Dequeue();

            Assert.Equal(10, value);
            Assert.Equal(1, queue.Count);
        }

        // Verifies that Peek returns the first item
        // without removing it from the queue.
        [Fact]
        public void Peek_ShouldReturnFirstItemWithoutRemoving()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(5);

            Assert.Equal(5, queue.Peek());
            Assert.Equal(1, queue.Count);
        }

        // Verifies that IsEmpty returns true
        // when the queue contains no elements.
        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenQueueIsEmpty()
        {
            var queue = new CustomQueue<int>();

            Assert.True(queue.IsEmpty());
        }
    }
}