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
        var queue = new CustomQueue<string>();
        queue.Enqueue("Order_1");
        queue.Enqueue("Order_2");

        var frontItem = queue.Peek();

        Assert.Equal("Order_1", frontItem);
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Search_ShouldFindElement_WithoutAlteringQueueOrder()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(100);
        queue.Enqueue(200);
        queue.Enqueue(300);

        bool exists = queue.Search(200);
        bool missing = queue.Search(999);

        Assert.True(exists);
        Assert.False(missing);
        Assert.Equal(3, queue.Count);
        Assert.Equal(100, queue.Dequeue());
    }

    [Fact]
    public void Sort_ShouldReorderQueueElementsInAscendingSequence()
    {
        var queue = new CustomQueue<int>();
        queue.Enqueue(50);
        queue.Enqueue(10);
        queue.Enqueue(30);

        queue.Sort();

        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(50, queue.Dequeue());
    }
}