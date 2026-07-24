namespace ECommerceSystem.Tests;

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
        Assert.Throws<ArgumentNullException>(() => queue.EnqueueOrder(null!));
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
        Assert.Throws<InvalidOperationException>(() => queue.ProcessNextOrder());
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
        Assert.Throws<InvalidOperationException>(() => queue.PeekNextOrder());
    }

    // =====================================================
    // SEARCH ORDER TESTS
    // =====================================================

    [Fact]
    public void SearchOrder_ShouldReturnTrue_WhenOrderExists()
    {
        var queue = BuildQueue(100.00m, 200.00m, 300.00m);
        Assert.True(queue.SearchOrder(CreateOrder(2, 200.00m)));
    }

    [Fact]
    public void SearchOrder_ShouldReturnFalse_WhenOrderIsMissing()
    {
        var queue = BuildQueue(100.00m, 200.00m);
        Assert.False(queue.SearchOrder(CreateOrder(99, 999.00m)));
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
        Assert.Equal(30.00m, queue.PeekNextOrder().TotalAmount);
    }

    [Fact]
    public void SortOrders_ShouldProcessInAscendingOrderByAmount()
    {
        var queue = BuildQueue(900.00m, 30.00m, 250.00m);
        queue.SortOrders();
        Assert.Equal(30.00m, queue.ProcessNextOrder().TotalAmount);
        Assert.Equal(250.00m, queue.ProcessNextOrder().TotalAmount);
        Assert.Equal(900.00m, queue.ProcessNextOrder().TotalAmount);
    }

    [Fact]
    public void SortOrders_ShouldNotChangeCount()
    {
        var queue = BuildQueue(900.00m, 30.00m, 250.00m);
        queue.SortOrders();
        Assert.Equal(3, queue.Count);
    }

    /// <summary>
    /// Creates an order-processing queue seeded with orders in the
    /// given TotalAmount order. OrderIds are assigned sequentially
    /// starting at 1001, in the order the amounts are listed.
    /// </summary>
    private static OrderProcessingQueue BuildQueue(params decimal[] amounts)
    {
        var queue = new OrderProcessingQueue();
        int nextId = 1001;

        foreach (decimal amount in amounts)
        {
            queue.EnqueueOrder(CreateOrder(nextId - 1000, amount));
            nextId++;
        }

        return queue;
    }

    /// <summary>
    /// Creates a sample order for testing. orderIdOffset of 1 produces
    /// OrderId 1001, offset of 2 produces 1002, etc.
    /// </summary>
    private static Order CreateOrder(int orderIdOffset, decimal totalAmount)
    {
        return new Order(
            1000 + orderIdOffset,
            $"Customer{orderIdOffset}",
            totalAmount);
    }
}