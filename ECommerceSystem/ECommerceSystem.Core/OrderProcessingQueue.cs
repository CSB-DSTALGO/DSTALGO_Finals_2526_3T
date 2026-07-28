namespace ECommerceSystem.Core;

using System;
using DataStructuresLibrary;

public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orderQueue = new();

    public void EnqueueOrder(Order order)
    {
        if (order is null)
        {
            throw new ArgumentNullException(nameof(order), "Cannot enqueue a null order.");
        }

        _orderQueue.Enqueue(order);
    }

    public Order ProcessNextOrder()
    {
        return _orderQueue.Dequeue();
    }

    public Order ViewNextOrder()
    {
        return _orderQueue.Peek();
    }

    public bool CheckOrderQueueEmpty()
    {
        return _orderQueue.Count == 0;
    }
}