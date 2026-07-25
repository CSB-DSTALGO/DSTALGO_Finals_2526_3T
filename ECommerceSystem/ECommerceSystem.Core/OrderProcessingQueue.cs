namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();

    public int Count => _orders.Count;

    public void EnqueueOrder(Order order) => _orders.Enqueue(order);
    public Order ProcessNextOrder() => _orders.Dequeue();
    public Order PeekNextOrder() => _orders.Peek();

    public bool SearchOrder(Order order) => _orders.Search(order);
    public void SortOrders() => _orders.Sort();
}