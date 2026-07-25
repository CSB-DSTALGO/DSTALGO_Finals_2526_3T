namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();
    public int Count => _orders.Count;

    //Enqueues an order to the back
    public void EnqueueOrder(Order order)
    {
        if (order is null)
        {
            throw new ArgumentNullException(nameof(order));
        }
        _orders.Enqueue(order);
    }

    //Dequeues and returns the front order
    public Order ProcessNextOrder()
    {
        return _orders.Dequeue();
    }

    //Returns the front order without removing it
    public Order PeekNextOrder()
    {
        return _orders.Peek();
    }

    //Checks if a matching order exists in the queue
    //if it successfully searches for an existing order it returns it
    public bool SearchOrder(Order order)
    {
        return _orders.Search(order);
    }

    //Sorts the queues contents using CustomQueue bubble sort
    public void SortOrders()
    {
        _orders.Sort();
    }
}