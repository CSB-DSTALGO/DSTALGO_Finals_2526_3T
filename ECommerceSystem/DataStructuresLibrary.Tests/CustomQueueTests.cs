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

        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(5);
        queue.Enqueue(15);

        Assert.Equal(5, queue.Peek());
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        bool found = queue.Search(2);

        Assert.True(found);
        Assert.Equal(3, queue.Count);
        Assert.Equal(1, queue.Peek());
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
}