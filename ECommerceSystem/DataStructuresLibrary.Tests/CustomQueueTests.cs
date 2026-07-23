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
    public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        int result = queue.Peek();

        Assert.Equal(10, result);
        Assert.Equal(2, queue.Count);
        Assert.Equal(10, queue.Dequeue());
    }

    [Fact]
    public void Peek_ShouldThrowException_WhenQueueIsEmpty()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(30);
        queue.Enqueue(10);
        queue.Enqueue(20);

        bool found = queue.Search(10);

        Assert.True(found);
        Assert.Equal(3, queue.Count);
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenElementDoesNotExist()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        bool found = queue.Search(100);

        Assert.False(found);
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Sort_ShouldReorderQueueElementsInAscendingSequence()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(30);
        queue.Enqueue(10);
        queue.Enqueue(20);

        queue.Sort();

        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
    }

    [Fact]
    public void Sort_ShouldKeepCountUnchanged()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(30);
        queue.Enqueue(10);
        queue.Enqueue(20);

        queue.Sort();

        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Enqueue_ShouldResizeQueue_WhenCapacityIsExceeded()
    {
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
}