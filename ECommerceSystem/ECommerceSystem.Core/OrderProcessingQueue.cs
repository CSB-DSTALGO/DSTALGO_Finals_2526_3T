namespace ECommerceSystem.Core;

using System;
using DataStructuresLibrary;

public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();

    public int Count => _orders.Count;

    public void EnqueueOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        _orders.Enqueue(order);
    }

    public Order ProcessNextOrder()
    {
        return _orders.Dequeue();
    }

    public Order PeekNextOrder()
    {
        return _orders.Peek();
    }

    public bool SearchOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        return _orders.Search(order);
    }

    public void SortOrders()
    {
        _orders.Sort();
    }
}