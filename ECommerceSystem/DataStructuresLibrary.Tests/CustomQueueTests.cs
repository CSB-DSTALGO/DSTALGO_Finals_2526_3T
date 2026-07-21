namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomQueueTests
{
    [Fact]
    public void EnqueueAndDequeue_ShouldMaintainStrictFIFOOrder()
    {
        // Arrange
        var queue = new CustomQueue<int>();

        // Act
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        // Assert
        Assert.Equal(3, queue.Count);

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
        queue.Enqueue(15);

        // Act
        int front = queue.Peek();

        // Assert
        Assert.Equal(5, front);
        Assert.Equal(3, queue.Count);

        // Verify Peek did not remove the front element
        Assert.Equal(5, queue.Dequeue());
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(15, queue.Dequeue());

        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        // Arrange
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);

        // Act
        bool found = queue.Search(3);

        // Assert
        Assert.True(found);

        // Queue order should remain unchanged
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
        Assert.Equal(4, queue.Dequeue());

        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Sort_ShouldReorderQueueElementsInAscendingSequence()
    {
        // Arrange
        var queue = new CustomQueue<int>();
        queue.Enqueue(30);
        queue.Enqueue(10);
        queue.Enqueue(40);
        queue.Enqueue(20);

        // Act
        queue.Sort();

        // Assert
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(40, queue.Dequeue());

        Assert.Equal(0, queue.Count);
    }
}