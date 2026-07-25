using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void Enqueue_ShouldIncreaseCount()
        {
            CustomQueue<int> queue = new();

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.Equal(3, queue.Count);
        }

        [Fact]
        public void Dequeue_ShouldReturnItemsInFIFOOrder()
        {
            CustomQueue<int> queue = new();

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Peek_ShouldReturnFrontItemWithoutRemovingIt()
        {
            CustomQueue<int> queue = new();

            queue.Enqueue(10);
            queue.Enqueue(20);

            Assert.Equal(10, queue.Peek());
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenQueueHasNoItems()
        {
            CustomQueue<int> queue = new();

            Assert.True(queue.IsEmpty());

            queue.Enqueue(10);

            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
        {
            CustomQueue<int> queue = new();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_ShouldThrowException_WhenQueueIsEmpty()
        {
            CustomQueue<int> queue = new();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Fact]
        public void Search_ShouldReturnTrue_WhenItemExists()
        {
            CustomQueue<int> queue = new();

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.True(queue.Search(20));
        }

        [Fact]
        public void Search_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            CustomQueue<int> queue = new();

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.False(queue.Search(40));
        }

        [Fact]
        public void Sort_ShouldArrangeItemsInAscendingOrder()
        {
            CustomQueue<int> queue = new();

            queue.Enqueue(30);
            queue.Enqueue(10);
            queue.Enqueue(20);

            queue.Sort();

            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }
    }
}