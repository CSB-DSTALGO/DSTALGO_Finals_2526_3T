using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        // ---------- Enqueue / Dequeue ----------

        [Fact]
        public void EnqueueDequeue_ShouldFollowFIFOOrder_AndTrackCount()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");
            queue.Enqueue("third");

            Assert.Equal(3, queue.Count);
            Assert.Equal("first", queue.Dequeue());
            Assert.Equal("second", queue.Dequeue());
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Enqueue_ShouldGrowAndPreserveOrder_PastInitialCapacity()
        {
            var queue = new CustomQueue<int>();
            for (int i = 1; i <= 10; i++) queue.Enqueue(i);

            Assert.Equal(10, queue.Count);
            for (int i = 1; i <= 10; i++) Assert.Equal(i, queue.Dequeue());
        }

        [Fact]
        public void Dequeue_ShouldThrowInvalidOperationException_WhenQueueIsEmpty()
        {
            var queue = new CustomQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        // ---------- Peek ----------

        [Fact]
        public void Peek_ShouldReturnFrontItem_WithoutRemovingIt()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(100);
            queue.Enqueue(200);

            Assert.Equal(100, queue.Peek());
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void Peek_ShouldThrowInvalidOperationException_WhenQueueIsEmpty()
        {
            var queue = new CustomQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        // ---------- IsEmpty ----------

        [Fact]
        public void IsEmpty_ShouldReflectQueueState_AcrossEnqueueAndDequeue()
        {
            var queue = new CustomQueue<int>();
            Assert.True(queue.IsEmpty());

            queue.Enqueue(1);
            Assert.False(queue.IsEmpty());

            queue.Dequeue();
            Assert.True(queue.IsEmpty());
        }

        // ---------- Search ----------

        [Fact]
        public void Search_ShouldReturnLogicalIndex_WhenItemExists()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            queue.Enqueue(15);

            Assert.Equal(0, queue.Search(5));
            Assert.Equal(1, queue.Search(10));
        }

        [Fact]
        public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(5);

            Assert.Equal(-1, queue.Search(999));
        }

        // ---------- Contains (predicate search) ----------

        [Fact]
        public void Contains_ShouldMatchOnPredicate()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("T-101");
            queue.Enqueue("T-102");

            Assert.True(queue.Contains(t => t == "T-102"));
            Assert.False(queue.Contains(t => t == "T-999"));
        }

        // ---------- Sort ----------

        [Fact]
        public void Sort_ShouldOrderElementsAscending_WithoutChangingCount()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(30);
            queue.Enqueue(10);
            queue.Enqueue(20);

            queue.Sort();

            Assert.Equal(3, queue.Count);
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }

        [Fact]
        public void Sort_ShouldBeSafe_OnEmptyOrSingleItemQueue()
        {
            var emptyQueue = new CustomQueue<int>();
            var singleQueue = new CustomQueue<int>();
            singleQueue.Enqueue(42);

            emptyQueue.Sort();
            singleQueue.Sort();

            Assert.True(emptyQueue.IsEmpty());
            Assert.Equal(42, singleQueue.Peek());
        }
    }
}