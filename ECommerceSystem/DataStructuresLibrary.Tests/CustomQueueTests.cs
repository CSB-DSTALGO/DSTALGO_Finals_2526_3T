namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomQueueTests
{
    [Fact]
    public void EnqueueAndDequeue_ShouldMaintainStrictFIFOOrder()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.Equal(3, queue.Count);
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
    {
        var queue = new CustomQueue<string>();
        queue.Enqueue("First");
        queue.Enqueue("Second");

        string item = queue.Peek();

        Assert.Equal("First", item);
        Assert.Equal(2, queue.Count);
        Assert.Equal("First", queue.Dequeue());
    }

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(5);
        queue.Enqueue(15);
        queue.Enqueue(25);

        bool foundExisting = queue.Search(15);
        bool foundMissing = queue.Search(99);

        Assert.True(foundExisting);
        Assert.False(foundMissing);
        
        Assert.Equal(3, queue.Count);
        Assert.Equal(5, queue.Dequeue());
        Assert.Equal(15, queue.Dequeue());
        Assert.Equal(25, queue.Dequeue());
    }

    [Fact]
    public void Sort_ShouldReorderQueueElementsInAscendingSequence()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(42);
        queue.Enqueue(10);
        queue.Enqueue(99);
        queue.Enqueue(1);

        queue.Sort();

        Assert.Equal(4, queue.Count);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(42, queue.Dequeue());
        Assert.Equal(99, queue.Dequeue());
    }

    [Fact]
    public void Dequeue_EmptyQueue_ShouldThrowInvalidOperationException()
    {
        var queue = new CustomQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_EmptyQueue_ShouldThrowInvalidOperationException()
    {
        var queue = new CustomQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }
}
