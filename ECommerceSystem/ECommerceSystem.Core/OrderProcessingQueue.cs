namespace ECommerceSystem.Core;

using DataStructuresLibrary;


public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();

    public int Count => _orders.Count;

 
    public void EnqueueOrder(Order order)
    {
        if (order is null)
            throw new ArgumentNullException(nameof(order), "Cannot enqueue a null order.");

        _orders.Enqueue(order);
    }

    public Order ProcessNextOrder() => _orders.Dequeue();


    public Order PeekNextOrder() => _orders.Peek();


    public bool CheckOrderQueueEmpty() => _orders.Count == 0;


    public bool SearchOrder(Order order)
    {
        if (order is null) return false;
        return _orders.Search(order);
    }


    public void SortOrders() => _orders.Sort();
}
namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();

    public int Count => _orders.Count;

    public void EnqueueOrder(Order order) => throw new NotImplementedException();
    public Order ProcessNextOrder() => throw new NotImplementedException();
    public Order PeekNextOrder() => throw new NotImplementedException();

    
    public bool SearchOrder(Order order) => throw new NotImplementedException();
    public void SortOrders() => throw new NotImplementedException();
}
