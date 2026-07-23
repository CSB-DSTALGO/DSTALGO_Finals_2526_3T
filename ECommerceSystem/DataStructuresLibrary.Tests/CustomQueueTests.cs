namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomQueueTests
{
    // Tests that Enqueue increases the queue count.
    [Fact]
    public void Enqueue_ShouldIncreaseCount()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);

        Assert.Equal(1, queue.Count);
    }

    // Tests that Enqueue adds items to the rear.
    [Fact]
    public void Enqueue_ShouldAddItemsToRear()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
    }

    // Tests that the internal array expands when it becomes full.
    [Fact]
    public void Enqueue_ShouldResize_WhenCapacityIsExceeded()
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

    // Tests that Dequeue returns the first item added.
    [Fact]
    public void Dequeue_ShouldReturnFrontItem()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        int result = queue.Dequeue();

        Assert.Equal(10, result);
    }

    // Tests that Dequeue decreases the queue count.
    [Fact]
    public void Dequeue_ShouldDecreaseCount()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        queue.Dequeue();

        Assert.Equal(1, queue.Count);
    }

    // Tests that Dequeue rejects an empty queue.
    [Fact]
    public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    // Tests that Peek returns the item at the front.
    [Fact]
    public void Peek_ShouldReturnFrontItem()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        Assert.Equal(10, queue.Peek());
    }

    // Tests that Peek does not remove the front item.
    [Fact]
    public void Peek_ShouldNotRemoveFrontItem()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        int result = queue.Peek();

        Assert.Equal(10, result);
        Assert.Equal(2, queue.Count);
        Assert.Equal(10, queue.Dequeue());
    }

    // Tests that Peek rejects an empty queue.
    [Fact]
    public void Peek_ShouldThrowException_WhenQueueIsEmpty()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    // Tests that Search returns true for an existing item.
    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExists()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        bool result = queue.Search(20);

        Assert.True(result);
    }

    // Tests that Search returns false for a missing item.
    [Fact]
    public void Search_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        bool result = queue.Search(100);

        Assert.False(result);
    }

    // Tests that Search does not modify the queue.
    [Fact]
    public void Search_ShouldNotChangeQueueOrderOrCount()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(30);
        queue.Enqueue(10);
        queue.Enqueue(20);

        bool result = queue.Search(10);

        Assert.True(result);
        Assert.Equal(3, queue.Count);
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
    }

    // Tests that Sort arranges items in ascending order.
    [Fact]
    public void Sort_ShouldArrangeItemsInAscendingOrder()
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

    // Tests that Sort handles an already sorted queue.
    [Fact]
    public void Sort_ShouldKeepAlreadySortedItemsInOrder()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        queue.Sort();

        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
    }

    // Tests that Sort does not change the queue count.
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
}