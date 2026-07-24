using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void NewQueue_IsEmpty_ReturnsTrue() // Test for an empty queue
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue

            Assert.True(queue.IsEmpty()); // This verifies that the queue is empty
            Assert.Equal(0, queue.Count); // Verifies that the queue count is 0
        }

        [Fact]
        public void Enqueue_AddItem() // Test for adding an item 
        {
           var queue = new CustomQueue<int>(); // Create a new CustomQueue

            queue.Enqueue(10); // Add an item

            Assert.Equal(1, queue.Count); // Verifies that the count increased to 1
            Assert.False(queue.IsEmpty()); //Checks if the queue is not empty
        }

        [Fact]
        public void Enqueue_MultipleItems_IncreasesCount() // Test for adding multiple items
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue

            // Add multiple items
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.Equal(3, queue.Count); // Verifies that the count increased to 3
        }

        [Fact]
        public void Enqueue_WrapsAround() // Test the queue's wrap-around behavior
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Fill the queue to its capacity
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);

            // Dequeue a few items to create space at the front
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            // Enqueue more items
            queue.Enqueue(50);
            queue.Enqueue(60);

            // Check if the items are dequeued in the correct order
            Assert.Equal(40, queue.Dequeue());
            Assert.Equal(50, queue.Dequeue());
            Assert.Equal(60, queue.Dequeue());

        }

        [Fact]
        public void Dequeue_FollowFIFO() // Test for FIFO behavior
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            // Dequeue items and check if they follow the FIFO order
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }

        [Fact]
        public void Dequeue_DecreasesCount() // Test for decreasing count
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items
            queue.Enqueue(10);
            queue.Enqueue(20);

            queue.Dequeue(); // Dequeue an item

            Assert.Equal(1, queue.Count); // Verifies that the count decreased to 1
        }

        [Fact]
        public void Peek_ReturnsFrontItem() // Test for peeking at the front
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            int result = queue.Peek(); // Peek at the front item

            Assert.Equal(10, result); // Verifies that the front item is 10
            Assert.Equal(3, queue.Count); // Remains unchanged after peeking
        }

        [Fact]
        public void Dequeue_OnEmptyQueue_ThrowsException() // Test for exception when dequeuing an empty queue
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue()); // Throws exception when dequeuing from an empty queue
        }

        [Fact]
        public void Peek_OnEmptyQueue_ThrowsException() // Test for exception when peeking an empty queue
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue

            Assert.Throws<InvalidOperationException>(() => queue.Peek()); // Throws exception when peeking from an empty queue
        }

        [Fact]
        public void Enqueue_QueueIsFull_ThrowsException() // Test for exception when enqueuing to a full queue
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Fill the queue to its capacity
            for (int i = 0; i < 4; i++)
            {
                queue.Enqueue(i);
            }

            Assert.Throws<InvalidOperationException>(() => queue.Enqueue(4)); // Throws exception when trying to enqueue to a full queue
        }

        [Fact]
        public void Sort_SortsQueue() // Test for sorting the queue
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items in unsorted order
            queue.Enqueue(30);
            queue.Enqueue(10);
            queue.Enqueue(20);
            // Sort the queue
            queue.Sort((a, b) => a.CompareTo(b));
            // Dequeue items and check if they are in sorted order
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }

        [Fact]
        public void Sort_AlreadySortedQueue_RemainsSorted() // Test for sorting an already sorted queue
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items in sorted order
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            // Sort the queue
            queue.Sort((a, b) => a.CompareTo(b));
            // Dequeue items and check if they are still in sorted order
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }

        [Fact]
        public void Sort_DuplicateItems_SortsCorrectly() // Test for sorting with duplicate items
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items with duplicates
            queue.Enqueue(30);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(10);
            // Sort the queue
            queue.Sort((a, b) => a.CompareTo(b));
            // Dequeue items and check if they are in sorted order
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }

        [Fact]
        public void Sort_EmptyQueue_DoesNotThrow() // Test for sorting an empty queue
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Sort the empty queue
            queue.Sort((a, b) => a.CompareTo(b));
            Assert.True(queue.IsEmpty()); // Verifies that the queue is still empty after sorting
        }

        [Fact]
        public void Search_FindsExistingItem() // Test for searching an existing item
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            bool found = queue.Search(20); // Search for an existing item
            Assert.True(found); // Verifies that the item was found
        }

        [Fact]
        public void Search_ReturnsFirstMatchingItem() // Test for searching and returning the first matching item
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items with duplicates
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(20);
            bool found = queue.Search(20); // Search for an existing item
            Assert.True(found); // Verifies that the item was found
        }

        [Fact]
        public void Search_DoesNotFindNonExistingItem() // Test for searching a non-existing item
        {
            var queue = new CustomQueue<int>(); // Create a new CustomQueue
            // Add multiple items
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            bool found = queue.Search(40); // Search for a non-existing item
            Assert.False(found); // Verifies that the item was not found
        }
    }
}
