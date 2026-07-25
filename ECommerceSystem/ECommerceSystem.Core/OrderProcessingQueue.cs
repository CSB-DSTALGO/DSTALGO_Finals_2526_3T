namespace ECommerceSystem.Core;

using DataStructuresLibrary;

/// <summary>
/// Handles incoming customer orders using CustomQueue.
///
/// Orders are processed in the exact order they were received
/// using FIFO: First In, First Out.
/// </summary>
public class OrderProcessingQueue
{
    // Stores pending orders using the custom queue.
    private readonly CustomQueue<Order> _orders = new();

    /// <summary>
    /// Returns the number of pending orders.
    /// </summary>
    public int Count => _orders.Count;

    /// <summary>
    /// Adds an order to the back of the queue.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public void EnqueueOrder(Order order)
    {
        if (order is null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        _orders.Enqueue(order);
    }

    /// <summary>
    /// Removes and returns the oldest pending order.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public Order ProcessNextOrder()
    {
        return _orders.Dequeue();
    }

    /// <summary>
    /// Views the next order without removing it.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public Order PeekNextOrder()
    {
        return _orders.Peek();
    }

    /// <summary>
    /// Views the next order without removing it.
    /// This method follows the exact name in the requirements.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public Order ViewNextOrder()
    {
        return _orders.Peek();
    }

    /// <summary>
    /// Checks whether the order queue is empty.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public bool CheckOrderQueueEmpty()
    {
        return _orders.Count == 0;
    }

    /// <summary>
    /// Searches for an order in the queue.
    ///
    /// Time complexity: O(n)
    /// </summary>
    public bool SearchOrder(Order order)
    {
        if (order is null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        return _orders.Search(order);
    }

    /// <summary>
    /// Sorts pending orders by TotalAmount.
    /// The smallest amount will be at the front.
    ///
    /// Time complexity: O(n²)
    /// </summary>
    public void SortOrders()
    {
        _orders.Sort();
    }
}