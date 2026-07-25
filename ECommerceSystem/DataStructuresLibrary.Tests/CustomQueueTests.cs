namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomQueueTests
{
    [Fact]
    public void EnqueueAndDequeue_ShouldMaintainStrictFIFOOrder()
    {
        // TODO: Test First-In, First-Out behavior
        var queue = new CustomQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // whoever got in first should come out first
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
    {
        // TODO: Test Peek maintaining Count and queue head state
        var queue = new CustomQueue<int>();
        queue.Enqueue(5);
        queue.Enqueue(10);

        int front = queue.Peek();

        Assert.Equal(5, front);
        // count shouldnt change, peek is just looking not taking
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        // TODO: Verify Search finds item and leaves queue order intact
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        bool found = queue.Search(2);

        Assert.True(found);
        // make sure searching didnt mess up the order after
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
    }

    [Fact]
    public void Sort_ShouldReorderQueueElementsInAscendingSequence()
    {
        // TODO: Test sorting elements inside the FIFO queue
        var queue = new CustomQueue<int>();
        queue.Enqueue(30);
        queue.Enqueue(10);
        queue.Enqueue(20);

        queue.Sort();

        // smallest number should be the one that comes out first now
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
    }
}