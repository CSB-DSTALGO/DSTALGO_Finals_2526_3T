namespace ECommerceSystem.Core; //LIAM 

using DataStructuresLibrary;

public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();

    public int Count => _orders.Count;

<<<<<<< Updated upstream
=======
    // Adds a new order to the processing queue.
>>>>>>> Stashed changes
    public void EnqueueOrder(Order order)
    {
        _orders.Enqueue(order);
    }

<<<<<<< Updated upstream
=======
    // Processes the next order (FIFO).
>>>>>>> Stashed changes
    public Order ProcessNextOrder()
    {
        return _orders.Dequeue();
    }

<<<<<<< Updated upstream
=======
    // Returns the next order without removing it.
>>>>>>> Stashed changes
    public Order PeekNextOrder()
    {
        return _orders.Peek();
    }

<<<<<<< Updated upstream
=======
    // Searches for an order in the queue.
>>>>>>> Stashed changes
    public bool SearchOrder(Order order)
    {
        return _orders.Search(order);
    }

<<<<<<< Updated upstream
=======
    // Sorts the orders by TotalAmount.
>>>>>>> Stashed changes
    public void SortOrders()
    {
        _orders.Sort();
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
