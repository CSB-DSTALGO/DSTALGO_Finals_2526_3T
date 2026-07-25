namespace DataStructuresLibrary.Tests; //LIAM

using Xunit;
using DataStructuresLibrary;

public class CustomQueueTests
{
    // -------------------- Enqueue --------------------

    [Fact]
    public void Enqueue_ShouldIncreaseCount()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Enqueue_MultipleItems_ShouldIncreaseCountCorrectly()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Enqueue_ShouldMaintainFIFOOrder()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(5);
        queue.Enqueue(10);

        Assert.Equal(5, queue.Dequeue());
        Assert.Equal(10, queue.Dequeue());
    }

    // -------------------- Dequeue --------------------

    [Fact]
    public void Dequeue_ShouldRemoveFrontItem()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        Assert.Equal(10, queue.Dequeue());
    }

    [Fact]
    public void Dequeue_OnSingleItemQueue_ShouldLeaveQueueEmpty()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(100);

        Assert.Equal(100, queue.Dequeue());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Dequeue_OnEmptyQueue_ShouldThrowException()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    // -------------------- Peek --------------------

    [Fact]
    public void Peek_ShouldReturnFrontItem()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(5);
        queue.Enqueue(10);

        Assert.Equal(5, queue.Peek());
    }

    [Fact]
    public void Peek_ShouldNotRemoveItem()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(7);

        queue.Peek();

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Peek_OnEmptyQueue_ShouldThrowException()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    // -------------------- Search --------------------

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExists()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.True(queue.Search(2));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);

        Assert.False(queue.Search(5));
    }

    [Fact]
    public void Search_OnEmptyQueue_ShouldReturnFalse()
    {
        var queue = new CustomQueue<int>();

        Assert.False(queue.Search(1));
    }

    // -------------------- Sort --------------------

    [Fact]
    public void Sort_ShouldArrangeItemsAscending()
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
    public void Sort_AlreadySortedQueue_ShouldRemainSorted()
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
    public void Sort_WithDuplicateValues_ShouldSortCorrectly()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(5);
        queue.Enqueue(2);
        queue.Enqueue(5);
        queue.Enqueue(1);

        queue.Sort();

        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(5, queue.Dequeue());
        Assert.Equal(5, queue.Dequeue());
    }
}






