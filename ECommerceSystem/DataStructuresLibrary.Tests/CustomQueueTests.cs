namespace DataStructuresLibrary.Tests;

using Xunit;
using System;
using DataStructuresLibrary;

public class CustomQueueTests
{
    
    // ENQUEUE TESTS (3 Tests)
    
    [Fact]
    public void Enqueue_SingleItem_AddsItemToQueue()
    {
        CustomQueue<string> queue = new CustomQueue<string>();
        queue.Enqueue("Order_101");

        Assert.Equal(1, queue.Count);
        Assert.Equal("Order_101", queue.Peek());
    }

    [Fact]
    public void Enqueue_ExceedsCapacity_ResizesWithoutLosingData()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        for (int i = 1; i <= 10; i++) // Initial capacity is 4, tests resizing
        {
            queue.Enqueue(i);
        }

        Assert.Equal(10, queue.Count);
        Assert.Equal(1, queue.Peek());
    }

    [Fact]
    public void Enqueue_NullItem_ThrowsArgumentNullException()
    {
        CustomQueue<string> queue = new CustomQueue<string>();
        Assert.Throws<ArgumentNullException>(() => queue.Enqueue(null!));
    }

    
    // DEQUEUE TESTS (3 Tests)
    
    [Fact]
    public void EnqueueAndDequeue_ShouldMaintainStrictFIFOOrder()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Dequeue_WrapAroundBuffer_DequeuesCorrectly()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue(); // Head moves to index 1
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5); // Triggers circular wrap-around / resize

        Assert.Equal(2, queue.Dequeue());
    }

    [Fact]
    public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    
    // PEEK TESTS (3 Tests)
    
    [Fact]
    public void Peek_ShouldReturnFrontElement_WithoutRemovingIt()
    {
        CustomQueue<string> queue = new CustomQueue<string>();
        queue.Enqueue("ItemA");

        string result = queue.Peek();

        Assert.Equal("ItemA", result);
        Assert.Equal(1, queue.Count); // Ensures count is unmodified
    }

    [Fact]
    public void Peek_MultipleCalls_ReturnsSameElement()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(42);

        Assert.Equal(42, queue.Peek());
        Assert.Equal(42, queue.Peek());
    }

    [Fact]
    public void Peek_EmptyQueue_ThrowsInvalidOperationException()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    
    // SEARCH TESTS (3 Tests)
    
    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        CustomQueue<string> queue = new CustomQueue<string>();
        queue.Enqueue("Apple");
        queue.Enqueue("Banana");
        queue.Enqueue("Cherry");

        bool found = queue.Search("Banana");

        Assert.True(found);
        Assert.Equal("Apple", queue.Dequeue()); // Confirms queue order was intact
    }

    [Fact]
    public void Search_NonExistingItem_ReturnsFalse()
    {
        CustomQueue<string> queue = new CustomQueue<string>();
        queue.Enqueue("Apple");

        Assert.False(queue.Search("Orange"));
    }

    [Fact]
    public void Search_EmptyQueue_ReturnsFalse()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        Assert.False(queue.Search(5));
    }

    
    // SORT TESTS (3 Tests)
    
    [Fact]
    public void Sort_ShouldReorderQueueElementsInAscendingSequence()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(50);
        queue.Enqueue(10);
        queue.Enqueue(30);

        queue.Sort();

        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(50, queue.Dequeue());
    }

    [Fact]
    public void Sort_EmptyOrSingleItem_HandlesGracefully()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Sort(); // Should not throw on empty

        queue.Enqueue(10);
        queue.Sort(); // Should handle 1 element without error

        Assert.Equal(10, queue.Peek());
    }

    [Fact]
    public void Sort_WrappedBuffer_SortsAndResetsBufferCorrectly()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(100);
        queue.Enqueue(200);
        queue.Dequeue(); // Unaligns head from index 0
        queue.Enqueue(15);
        queue.Enqueue(5);

        queue.Sort();

        Assert.Equal(5, queue.Dequeue());
        Assert.Equal(15, queue.Dequeue());
        Assert.Equal(200, queue.Dequeue());
    }
}