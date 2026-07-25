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
        var queue = new CustomQueue<int>();
        queue.Enqueue(100);
        queue.Enqueue(200);

        int front = queue.Peek();

        Assert.Equal(100, front);
        Assert.Equal(2, queue.Count);
        Assert.Equal(100, queue.Peek());
    }

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(5);
        queue.Enqueue(15);
        queue.Enqueue(25);

        bool found = queue.Search(15);
        bool notFound = queue.Search(99);

        Assert.True(found);
        Assert.False(notFound);
        Assert.Equal(3, queue.Count);
        Assert.Equal(5, queue.Peek());
    }

    [Fact]
    public void Sort_ShouldReorderQueueElementsInAscendingSequence()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(300);
        queue.Enqueue(100);
        queue.Enqueue(200);

        queue.Sort();

        Assert.Equal(100, queue.Dequeue());
        Assert.Equal(200, queue.Dequeue());
        Assert.Equal(300, queue.Dequeue());
    }
}