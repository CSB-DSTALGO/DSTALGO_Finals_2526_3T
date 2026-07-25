using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void Enqueue_ShouldIncreaseCount()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(10);

            Assert.Equal(1, queue.Count);
        }

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

        [Fact]
        public void Peek_ShouldReturnFirstItemWithoutRemoving()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(5);

            Assert.Equal(5, queue.Peek());
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenQueueIsEmpty()
        {
            var queue = new CustomQueue<int>();

            Assert.True(queue.IsEmpty());
        }
    }
}