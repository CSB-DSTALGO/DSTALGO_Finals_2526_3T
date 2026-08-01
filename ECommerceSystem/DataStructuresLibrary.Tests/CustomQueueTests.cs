namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomQueueTests
{
    [Fact]
    public void Enqueue_SingleItem_IncreasesCountByOne()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Enqueue_MultipleItems_IncreasesCountForEachItem()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Enqueue_ToEmptyQueue_MakesItemBothFrontAndRear()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(99);

        Assert.Equal(99, queue.Peek());
        Assert.Equal(99, queue.Dequeue());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void EnqueueAndDequeue_ShouldMaintainStrictFIFOOrder()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
    }

    [Fact]
    public void Dequeue_RemovesItem_DecreasesCountByOne()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(5);
        queue.Enqueue(6);

        queue.Dequeue();

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Dequeue_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(7);
        queue.Enqueue(8);

        int result = queue.Peek();

        Assert.Equal(7, result);
        Assert.Equal(2, queue.Count);
        Assert.Equal(7, queue.Peek());
    }

    [Fact]
    public void Peek_DoesNotChangeCount()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        int before = queue.Count;

        queue.Peek();

        Assert.Equal(before, queue.Count);
    }

    [Fact]
    public void Peek_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        bool found = queue.Search(20);

        Assert.True(found);
        Assert.Equal(3, queue.Count);
        Assert.Equal(10, queue.Peek());
    }

    [Fact]
    public void Search_ItemNotPresent_ReturnsFalse()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        bool found = queue.Search(999);

        Assert.False(found);
    }

    [Fact]
    public void Search_OnEmptyQueue_ReturnsFalse()
    {
        var queue = new CustomQueue<int>();

        bool found = queue.Search(1);

        Assert.False(found);
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
    public void Sort_AlreadySortedQueue_RemainsInSameOrder()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        queue.Sort();

        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
    }

    [Fact]
    public void Sort_SingleElementQueue_RemainsUnchanged()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(42);

        queue.Sort();

        Assert.Equal(1, queue.Count);
        Assert.Equal(42, queue.Dequeue());
    }
}