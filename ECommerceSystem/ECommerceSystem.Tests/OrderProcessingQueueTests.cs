namespace ECommerceSystem.Tests;

using System;
using Xunit;
using ECommerceSystem.Core;

public class OrderProcessingQueueTests
{
    [Fact]
    public void EnqueueOrder_SingleOrder_IncreasesCountByOne()
    {
        var queue = new OrderProcessingQueue();
        var order = new Order(1, "Customer A", 50.00m);

        queue.EnqueueOrder(order);

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void EnqueueOrder_MultipleOrders_IncreasesCountForEachOrder()
    {
        var queue = new OrderProcessingQueue();

        queue.EnqueueOrder(new Order(1, "Customer A", 50.00m));
        queue.EnqueueOrder(new Order(2, "Customer B", 75.00m));
        queue.EnqueueOrder(new Order(3, "Customer C", 20.00m));

        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void EnqueueOrder_FirstOrderEnqueued_BecomesFrontOfQueue()
    {
        var queue = new OrderProcessingQueue();
        var firstOrder = new Order(1, "Customer A", 50.00m);

        queue.EnqueueOrder(firstOrder);
        queue.EnqueueOrder(new Order(2, "Customer B", 75.00m));

        Assert.Equal(firstOrder, queue.PeekNextOrder());
    }

    [Fact]
    public void ProcessNextOrder_RemovesFrontOrder_ReturnsItAndDecreasesCount()
    {
        var queue = new OrderProcessingQueue();
        var order = new Order(1, "Customer A", 50.00m);
        queue.EnqueueOrder(order);

        Order result = queue.ProcessNextOrder();

        Assert.Equal(order, result);
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void ProcessNextOrder_MultipleOrders_ProcessesInFIFOOrder()
    {
        var queue = new OrderProcessingQueue();
        var first = new Order(1, "Customer A", 50.00m);
        var second = new Order(2, "Customer B", 75.00m);
        var third = new Order(3, "Customer C", 20.00m);
        queue.EnqueueOrder(first);
        queue.EnqueueOrder(second);
        queue.EnqueueOrder(third);

        Assert.Equal(first, queue.ProcessNextOrder());
        Assert.Equal(second, queue.ProcessNextOrder());
        Assert.Equal(third, queue.ProcessNextOrder());
    }

    [Fact]
    public void ProcessNextOrder_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<InvalidOperationException>(() => queue.ProcessNextOrder());
    }

    [Fact]
    public void PeekNextOrder_ReturnsFrontOrder_WithoutRemovingIt()
    {
        var queue = new OrderProcessingQueue();
        var order = new Order(1, "Customer A", 50.00m);
        queue.EnqueueOrder(order);

        Order result = queue.PeekNextOrder();

        Assert.Equal(order, result);
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void PeekNextOrder_DoesNotChangeCount()
    {
        var queue = new OrderProcessingQueue();
        queue.EnqueueOrder(new Order(1, "Customer A", 50.00m));
        queue.EnqueueOrder(new Order(2, "Customer B", 75.00m));
        int before = queue.Count;

        queue.PeekNextOrder();

        Assert.Equal(before, queue.Count);
    }

    [Fact]
    public void PeekNextOrder_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<InvalidOperationException>(() => queue.PeekNextOrder());
    }

    [Fact]
    public void SearchOrder_ExistingOrder_ReturnsTrueWithoutModifyingQueue()
    {
        var queue = new OrderProcessingQueue();
        var order1 = new Order(1, "Customer A", 50.00m);
        var order2 = new Order(2, "Customer B", 75.00m);
        queue.EnqueueOrder(order1);
        queue.EnqueueOrder(order2);

        bool found = queue.SearchOrder(order2);

        Assert.True(found);
        Assert.Equal(2, queue.Count);
        Assert.Equal(order1, queue.PeekNextOrder());
    }

    [Fact]
    public void SearchOrder_NonExistingOrder_ReturnsFalse()
    {
        var queue = new OrderProcessingQueue();
        queue.EnqueueOrder(new Order(1, "Customer A", 50.00m));

        bool found = queue.SearchOrder(new Order(999, "Nobody", 9999.00m));

        Assert.False(found);
    }

    [Fact]
    public void SearchOrder_OnEmptyQueue_ReturnsFalse()
    {
        var queue = new OrderProcessingQueue();

        bool found = queue.SearchOrder(new Order(1, "Customer A", 50.00m));

        Assert.False(found);
    }

    [Fact]
    public void SortOrders_OrdersByTotalAmountAscending()
    {
        var queue = new OrderProcessingQueue();
        var large = new Order(1, "Bulk Client", 900.00m);
        var small = new Order(2, "Retail Client", 30.00m);
        var mid = new Order(3, "Standard Client", 250.00m);
        queue.EnqueueOrder(large);
        queue.EnqueueOrder(small);
        queue.EnqueueOrder(mid);

        queue.SortOrders();

        Assert.Equal(small, queue.ProcessNextOrder());
        Assert.Equal(mid, queue.ProcessNextOrder());
        Assert.Equal(large, queue.ProcessNextOrder());
    }

    [Fact]
    public void SortOrders_AlreadySortedQueue_RemainsInSameOrder()
    {
        var queue = new OrderProcessingQueue();
        var first = new Order(1, "Customer A", 10.00m);
        var second = new Order(2, "Customer B", 20.00m);
        var third = new Order(3, "Customer C", 30.00m);
        queue.EnqueueOrder(first);
        queue.EnqueueOrder(second);
        queue.EnqueueOrder(third);

        queue.SortOrders();

        Assert.Equal(first, queue.ProcessNextOrder());
        Assert.Equal(second, queue.ProcessNextOrder());
        Assert.Equal(third, queue.ProcessNextOrder());
    }

    [Fact]
    public void SortOrders_SingleOrderQueue_RemainsUnchanged()
    {
        var queue = new OrderProcessingQueue();
        var order = new Order(1, "Customer A", 42.00m);
        queue.EnqueueOrder(order);

        queue.SortOrders();

        Assert.Equal(1, queue.Count);
        Assert.Equal(order, queue.ProcessNextOrder());
    }
}