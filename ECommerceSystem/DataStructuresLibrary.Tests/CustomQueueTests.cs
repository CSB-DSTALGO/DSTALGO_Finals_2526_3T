<<<<<<< Updated upstream
=======
using Xunit;
>>>>>>> Stashed changes
using DataStructuresLibrary;
using Xunit;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
<<<<<<< Updated upstream
        public void EnqueueAndDequeue_ShouldMaintainStrictFIFOOrder()
        {
            // TODO: Test First-In, First-Out behavior
            throw new NotImplementedException();
        }

        [Fact]
        public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
        {
            // TODO: Test Peek maintaining Count and queue head state
            throw new NotImplementedException();
        }

        [Fact]
        public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
        {
            // TODO: Verify Search finds item and leaves queue order intact
            throw new NotImplementedException();
        }

        [Fact]
        public void Sort_ShouldReorderQueueElementsInAscendingSequence()
        {
            // TODO: Test sorting elements inside the FIFO queue
            throw new NotImplementedException();
=======
        public void Dequeue_ShouldFollowFIFOOrder()
        {
            // Arrange
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Act & Assert
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
        {
            // Arrange
            var queue = new CustomQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);

            // Act
            var front = queue.Peek();

            // Assert
            Assert.Equal(5, front);
            Assert.Equal(2, queue.Count); // Count should remain unchanged
            Assert.Equal(5, queue.Dequeue()); // Front element should still be there
        }

        [Fact]
        public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
        {
            // Arrange
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Act
            bool found = queue.Search(2);

            // Assert
            Assert.True(found);

            // Ensure queue order is unchanged
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
        }

        [Fact]
        public void Sort_ShouldReorderQueueElementsInAscendingSequence()
        {
            // Arrange
            var queue = new CustomQueue<int>();
            queue.Enqueue(30);
            queue.Enqueue(10);
            queue.Enqueue(20);

            // Act
            queue.Sort();

            // Assert
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
>>>>>>> Stashed changes
        }
    }
}