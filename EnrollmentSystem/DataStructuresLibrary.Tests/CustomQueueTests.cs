using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void Enqueue_And_Dequeue_ShouldMaintainFifoOrder()
        {
            // Arrange
            var queue = new CustomQueue<string>();

            // Act
            queue.Enqueue("Ticket-1");
            queue.Enqueue("Ticket-2");
            queue.Enqueue("Ticket-3");

            // Assert
            Assert.Equal(3, queue.Count);
            Assert.Equal("Ticket-1", queue.Dequeue());
            Assert.Equal("Ticket-2", queue.Dequeue());
            Assert.Equal("Ticket-3", queue.Dequeue());
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Peek_ShouldReturnFrontItem_WithoutRemovingIt()
        {
            // Arrange
            var queue = new CustomQueue<int>();
            queue.Enqueue(100);

            // Act
            int frontItem = queue.Peek();

            // Assert
            Assert.Equal(100, frontItem);
            Assert.Equal(1, queue.Count); // Ensure count remains unchanged
        }

        [Fact]
        public void Dequeue_OnEmptyQueue_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var queue = new CustomQueue<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Queue_ShouldAutoResize_WhenExceedingDefaultCapacity()
        {
            // Arrange
            var queue = new CustomQueue<int>();

            // Act - Default capacity is 4, adding 6 items forces a resize
            for (int i = 1; i <= 6; i++)
            {
                queue.Enqueue(i);
            }

            // Assert
            Assert.Equal(6, queue.Count);
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
        }
    }
}