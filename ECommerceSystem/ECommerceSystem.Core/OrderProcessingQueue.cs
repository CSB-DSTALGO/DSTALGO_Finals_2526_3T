namespace ECommerceSystem.Core; //LIAM 

using DataStructuresLibrary;

public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();

    public int Count => _orders.Count;

    // Adds a new order
    public void EnqueueOrder(Order order)
    {
        _orders.Enqueue(order);
    }

    // Processes the next order
    public Order ProcessNextOrder()
    {
        return _orders.Dequeue();
    }

    // Returns the next order without removing it
    public Order PeekNextOrder()
    {
        return _orders.Peek();
    }

    // Searches for an order in queue
    public bool SearchOrder(Order order)
    {
        return _orders.Search(order);
    }

    // Sorts the orders by TotalAmount.
    public void SortOrders()
    {
        _orders.Sort();
    }
}