using DataStructuresLibrary;

namespace ECommerceSystem.Core
{
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
}