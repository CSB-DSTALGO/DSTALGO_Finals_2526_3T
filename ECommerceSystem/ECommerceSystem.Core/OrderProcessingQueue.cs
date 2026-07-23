namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class OrderProcessingQueue
{
    // Stores the orders using the custom queue
    private readonly CustomQueue<Order> _orders = new();

    // Returns the number of orders in the queue
    public int Count => _orders.Count;

    // Adds an order to the back of the queue
    public void EnqueueOrder(Order order)
    {
        _orders.Enqueue(order);
    }

    // Removes and returns the first order
    public Order ProcessNextOrder()
    {
        return _orders.Dequeue();
    }

    // Returns the first order without removing it
    public Order PeekNextOrder()
    {
        return _orders.Peek();
    }

    // Searches for an order in the queue
    public bool SearchOrder(Order order)
    {
        return _orders.Search(order);
    }

    // Sorts the orders by total amount
    public void SortOrders()
    {
        _orders.Sort();
    }
}