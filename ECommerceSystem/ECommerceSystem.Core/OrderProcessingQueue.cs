namespace ECommerceSystem.Core;

using DataStructuresLibrary;


public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();

    // Number of orders currently waiting to be processed.
    public int Count => _orders.Count;

    // Adds a new order to the rear of the processing queue.
    public void EnqueueOrder(Order order) => _orders.Enqueue(order);

    // Removes and returns the order at the front of the queue.
    public Order ProcessNextOrder() => _orders.Dequeue();

    // Returns the next order to be processed without removing it from the queue.
    public Order PeekNextOrder() => _orders.Peek();

    // Checks whether the given order is present anywhere in the queue, without altering queue order.
    public bool SearchOrder(Order order) => _orders.Search(order);

    // Reorders the queue by ascending TotalAmount.
    public void SortOrders() => _orders.Sort();
}