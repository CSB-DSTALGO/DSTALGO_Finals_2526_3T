// 12521269 Joaquin Bryan G. Ross
namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomQueueTests
{
    // =========================================================================
    // Enqueue
    // =========================================================================

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
    public void Enqueue_ShouldIncrementCount()
    {
        var queue = new CustomQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);

        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Enqueue_ShouldPreserveOrder_WhenTheBufferWrapsAndGrows()
    {
        // Interleaving keeps the front index advancing, so the circular buffer
        // wraps before it grows. This is where an off-by-one would surface.
        var queue = new CustomQueue<int>();

        for (int i = 0; i < 6; i++)
        {
            queue.Enqueue(i);
            queue.Dequeue();
        }

        for (int i = 100; i < 110; i++)
        {
            queue.Enqueue(i);
        }

        Assert.Equal(10, queue.Count);
        for (int i = 100; i < 110; i++)
        {
            Assert.Equal(i, queue.Dequeue());
        }
    }

    // =========================================================================
    // Dequeue
    // =========================================================================

    [Fact]
    public void Dequeue_ShouldDecrementCount()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        queue.Dequeue();

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Dequeue_ShouldThrow_WhenQueueIsEmpty()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Dequeue_ShouldThrow_WhenQueueIsDrained()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Dequeue();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    // =========================================================================
    // Peek
    // =========================================================================

    [Fact]
    public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        Assert.Equal(1, queue.Peek());
        Assert.Equal(2, queue.Count);
        Assert.Equal(1, queue.Peek()); // repeatable, so nothing was consumed
    }

    [Fact]
    public void Peek_ShouldFollowTheFront_AfterDequeue()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue();

        Assert.Equal(2, queue.Peek());
    }

    [Fact]
    public void Peek_ShouldThrow_WhenQueueIsEmpty()
    {
        var queue = new CustomQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    // =========================================================================
    // IsEmpty
    // =========================================================================

    [Fact]
    public void IsEmpty_ShouldReturnTrue_ForANewQueue()
    {
        var queue = new CustomQueue<int>();

        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalse_WhenOrdersArePending()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);

        Assert.False(queue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_AfterTheQueueIsDrained()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Dequeue();

        Assert.True(queue.IsEmpty());
    }

    // =========================================================================
    // Search
    // =========================================================================

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        bool found = queue.Search(30);

        Assert.True(found);
        Assert.Equal(3, queue.Count);
        Assert.Equal(10, queue.Peek()); // the front is untouched
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(10);

        Assert.False(queue.Search(999));
    }

    [Fact]
    public void Search_ShouldReturnFalse_ForItemsAlreadyDequeued()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Dequeue();

        Assert.False(queue.Search(10));
        Assert.True(queue.Search(20));
    }

    // =========================================================================
    // Sort
    // =========================================================================

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
    public void Sort_ShouldOrderCorrectly_WhenTheBufferHasWrapped()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue(); // pushes the front off index 0
        queue.Enqueue(50);
        queue.Enqueue(5);

        queue.Sort();

        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(5, queue.Dequeue());
        Assert.Equal(50, queue.Dequeue());
    }

    [Fact]
    public void Sort_ShouldHandleEmptyAndSingleItemQueues()
    {
        var empty = new CustomQueue<int>();
        var single = new CustomQueue<int>();
        single.Enqueue(42);

        empty.Sort();
        single.Sort();

        Assert.Equal(0, empty.Count);
        Assert.Equal(42, single.Peek());
    }
}