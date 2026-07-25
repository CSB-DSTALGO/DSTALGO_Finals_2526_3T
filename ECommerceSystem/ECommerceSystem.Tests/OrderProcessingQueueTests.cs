namespace ECommerceSystem.Tests;

using System;
using ECommerceSystem.Core;
using Xunit;

public class OrderProcessingQueueTests
{
    // =====================================================
    // ENQUEUE ORDER TESTS
    // =====================================================

    [Fact]
    public void EnqueueOrder_ShouldIncreaseCount()
    {
        var queue = new OrderProcessingQueue();

        queue.EnqueueOrder(CreateOrder(1, 100.00m));

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void EnqueueOrder_ShouldPlaceOrderAtBackOfLine()
    {
        var queue = BuildQueue(100.00m, 200.00m);

        Assert.Equal(1001, queue.PeekNextOrder().OrderId);
    }

    [Fact]
    public void EnqueueOrder_ShouldThrowWhenOrderIsNull()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<ArgumentNullException>(
            () => queue.EnqueueOrder(null!));
    }

    // =====================================================
    // PROCESS NEXT ORDER TESTS
    // =====================================================

    [Fact]
    public void ProcessNextOrder_ShouldFollowFifoOrder()
    {
        var queue = BuildQueue(100.00m, 200.00m, 300.00m);

        Assert.Equal(1001, queue.ProcessNextOrder().OrderId);
        Assert.Equal(1002, queue.ProcessNextOrder().OrderId);
        Assert.Equal(1003, queue.ProcessNextOrder().OrderId);
    }

    [Fact]
    public void ProcessNextOrder_ShouldDecreaseCount()
    {
        var queue = BuildQueue(100.00m, 200.00m);

        queue.ProcessNextOrder();

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void ProcessNextOrder_ShouldThrowWhenQueueIsEmpty()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<InvalidOperationException>(
            () => queue.ProcessNextOrder());
    }

    // =====================================================
    // PEEK NEXT ORDER TESTS
    // =====================================================

    [Fact]
    public void PeekNextOrder_ShouldReturnOldestOrder()
    {
        var queue = BuildQueue(100.00m, 200.00m);

        Assert.Equal(1001, queue.PeekNextOrder().OrderId);
    }

    [Fact]
    public void PeekNextOrder_ShouldNotRemoveOrder()
    {
        var queue = BuildQueue(100.00m, 200.00m);

        queue.PeekNextOrder();

        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void PeekNextOrder_ShouldThrowWhenQueueIsEmpty()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<InvalidOperationException>(
            () => queue.PeekNextOrder());
    }

    // =====================================================
    // VIEW NEXT ORDER TESTS
    // =====================================================

    [Fact]
    public void ViewNextOrder_ShouldReturnOldestOrder()
    {
        var queue = BuildQueue(100.00m, 200.00m);

        Assert.Equal(1001, queue.ViewNextOrder().OrderId);
    }

    [Fact]
    public void ViewNextOrder_ShouldNotRemoveOrder()
    {
        var queue = BuildQueue(100.00m, 200.00m);

        queue.ViewNextOrder();

        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void ViewNextOrder_ShouldThrowWhenQueueIsEmpty()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<InvalidOperationException>(
            () => queue.ViewNextOrder());
    }

    // =====================================================
    // CHECK ORDER QUEUE EMPTY TESTS
    // =====================================================

    [Fact]
    public void CheckOrderQueueEmpty_ShouldReturnTrue_WhenQueueIsEmpty()
    {
        var queue = new OrderProcessingQueue();

        Assert.True(queue.CheckOrderQueueEmpty());
    }

    [Fact]
    public void CheckOrderQueueEmpty_ShouldReturnFalse_WhenQueueHasOrder()
    {
        var queue = new OrderProcessingQueue();

        queue.EnqueueOrder(CreateOrder(1, 100.00m));

        Assert.False(queue.CheckOrderQueueEmpty());
    }

    [Fact]
    public void CheckOrderQueueEmpty_ShouldReturnTrue_AfterAllOrdersProcessed()
    {
        var queue = BuildQueue(100.00m);

        queue.ProcessNextOrder();

        Assert.True(queue.CheckOrderQueueEmpty());
    }

    // =====================================================
    // SEARCH ORDER TESTS
    // =====================================================

    [Fact]
    public void SearchOrder_ShouldReturnTrue_WhenOrderExists()
    {
        var queue = BuildQueue(100.00m, 200.00m, 300.00m);

        bool result = queue.SearchOrder(
            CreateOrder(2, 200.00m));

        Assert.True(result);
    }

    [Fact]
    public void SearchOrder_ShouldReturnFalse_WhenOrderIsMissing()
    {
        var queue = BuildQueue(100.00m, 200.00m);

        bool result = queue.SearchOrder(
            CreateOrder(99, 999.00m));

        Assert.False(result);
    }

    [Fact]
    public void SearchOrder_ShouldNotChangeQueueOrderOrCount()
    {
        var queue = BuildQueue(100.00m, 200.00m, 300.00m);

        queue.SearchOrder(CreateOrder(2, 200.00m));

        Assert.Equal(3, queue.Count);
        Assert.Equal(1001, queue.PeekNextOrder().OrderId);
    }

    // =====================================================
    // SORT ORDERS TESTS
    // =====================================================

    [Fact]
    public void SortOrders_ShouldPlaceSmallestTotalAmountFirst()
    {
        var queue = BuildQueue(900.00m, 30.00m, 250.00m);

        queue.SortOrders();

        Assert.Equal(
            30.00m,
            queue.PeekNextOrder().TotalAmount);
    }

    [Fact]
    public void SortOrders_ShouldProcessInAscendingOrderByAmount()
    {
        var queue = BuildQueue(900.00m, 30.00m, 250.00m);

        queue.SortOrders();

        Assert.Equal(
            30.00m,
            queue.ProcessNextOrder().TotalAmount);

        Assert.Equal(
            250.00m,
            queue.ProcessNextOrder().TotalAmount);

        Assert.Equal(
            900.00m,
            queue.ProcessNextOrder().TotalAmount);
    }

    [Fact]
    public void SortOrders_ShouldNotChangeCount()
    {
        var queue = BuildQueue(900.00m, 30.00m, 250.00m);

        queue.SortOrders();

        Assert.Equal(3, queue.Count);
    }

    private static OrderProcessingQueue BuildQueue(
        params decimal[] amounts)
    {
        var queue = new OrderProcessingQueue();
        int orderIdOffset = 1;

        foreach (decimal amount in amounts)
        {
            queue.EnqueueOrder(
                CreateOrder(orderIdOffset, amount));

            orderIdOffset++;
        }

        return queue;
    }

    private static Order CreateOrder(
        int orderIdOffset,
        decimal totalAmount)
    {
        return new Order(
            1000 + orderIdOffset,
            $"Customer{orderIdOffset}",
            totalAmount);
    }
}