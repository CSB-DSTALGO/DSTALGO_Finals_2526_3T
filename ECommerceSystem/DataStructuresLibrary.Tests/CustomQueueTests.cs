namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomQueueTests
{
    // =====================================================
    // ENQUEUE TESTS
    // =====================================================

    [Fact]
    public void Enqueue_ShouldIncrementCount_WhenSingleItemAdded()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(10);
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Enqueue_ShouldIncrementCount_ForEachItemAdded()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Enqueue_ShouldPlaceFirstItemAddedAtFront()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        Assert.Equal(10, queue.Peek());
    }

    // =====================================================
    // DEQUEUE TESTS
    // =====================================================

    [Fact]
    public void Dequeue_ShouldRemoveItemsInFIFOOrder()
    {
        var queue = BuildQueue(10, 20, 30);
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
    }

    [Fact]
    public void Dequeue_ShouldDecreaseCount()
    {
        var queue = BuildQueue(10, 20);
        queue.Dequeue();
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Dequeue_ShouldThrowWhenQueueIsEmpty()
    {
        var queue = new CustomQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Dequeue_ShouldAllowEnqueueingAgain_AfterQueueBecomesEmpty()
    {
        var queue = BuildQueue(10);
        queue.Dequeue();
        queue.Enqueue(99);
        Assert.Equal(1, queue.Count);
        Assert.Equal(99, queue.Peek());
    }

    // =====================================================
    // PEEK TESTS
    // =====================================================

    [Fact]
    public void Peek_ShouldReturnFrontItem()
    {
        var queue = BuildQueue(10, 20);
        Assert.Equal(10, queue.Peek());
    }

    [Fact]
    public void Peek_ShouldNotRemoveFrontItem()
    {
        var queue = BuildQueue(10, 20);
        queue.Peek();
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Peek_ShouldThrowWhenQueueIsEmpty()
    {
        var queue = new CustomQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    // =====================================================
    // SEARCH TESTS
    // =====================================================

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExists()
    {
        var queue = BuildQueue(10, 20, 30);
        Assert.True(queue.Search(20));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var queue = BuildQueue(10, 20, 30);
        Assert.False(queue.Search(99));
    }

    [Fact]
    public void Search_ShouldNotAlterQueueOrderOrCount()
    {
        var queue = BuildQueue(10, 20, 30);
        queue.Search(20);
        Assert.Equal(3, queue.Count);
        Assert.Equal(10, queue.Peek());
    }

    // =====================================================
    // SORT TESTS
    // =====================================================

    [Fact]
    public void Sort_ShouldOrderElementsAscending_WhenDequeuedInSequence()
    {
        var queue = BuildQueue(30, 10, 20);
        queue.Sort();
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
    }

    [Fact]
    public void Sort_ShouldNotChangeCount()
    {
        var queue = BuildQueue(30, 10, 20);
        queue.Sort();
        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Sort_ShouldHandleDuplicateItems()
    {
        var queue = BuildQueue(2, 1, 2);
        queue.Sort();
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
    }

    /// <summary>
    /// Helper method that creates a queue for the tests.
    /// </summary>
    private static CustomQueue<int> BuildQueue(params int[] values)
    {
        var queue = new CustomQueue<int>();
        foreach (int value in values)
        {
            queue.Enqueue(value);
        }
        return queue;
    }
}