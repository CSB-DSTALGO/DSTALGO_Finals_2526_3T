// 12521269 Joaquin Bryan G. Ross
namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class OrderProcessingQueue
{
    private readonly CustomQueue<Order> _orders = new();

    public int Count => _orders.Count;

    /// <summary>
    /// Enqueues an order to the rear. O(1) amortised: the circular buffer
    /// writes straight to the rear slot, and growth doubles the capacity so
    /// the copying averages out to a constant cost per order.
    /// </summary>
    public void EnqueueOrder(Order order) => _orders.Enqueue(order);

    /// <summary>
    /// Dequeues and returns the front order. O(1), because the front index
    /// moves forward instead of the remaining orders shifting left.
    /// Throws InvalidOperationException when the queue is empty.
    /// </summary>
    public Order ProcessNextOrder() => _orders.Dequeue();

    /// <summary>
    /// Peeks at the front order without removal. O(1).
    /// Throws InvalidOperationException when the queue is empty.
    /// </summary>
    public Order ViewNextOrder() => _orders.Peek();

    /// <summary>
    /// The name the project scaffold shipped for the same peek operation, kept
    /// alongside ViewNextOrder so code written against either name compiles.
    /// O(1).
    /// </summary>
    public Order PeekNextOrder() => _orders.Peek();

    /// <summary>
    /// Evaluates and returns whether any orders are pending. O(1).
    /// </summary>
    public bool CheckOrderQueueEmpty() => _orders.IsEmpty();

    /// <summary>
    /// Search algorithm: linear search, delegated to CustomQueue.Search.
    /// It steps from the front through Count slots, wrapping with modulo when
    /// it runs off the end of the buffer.
    /// Best case O(1) at the front, worst and average case O(n).
    /// The important property is that it is non-destructive. Searching a queue
    /// naively means draining it and rebuilding it, which is O(n) anyway but
    /// disturbs the order. Indexing the buffer directly avoids that.
    /// </summary>
    public bool SearchOrder(Order order) => _orders.Search(order);

    /// <summary>
    /// Sorting algorithm: insertion sort, delegated to CustomQueue.Sort.
    /// The buffer is realigned to index 0 first so the wrapped region becomes
    /// contiguous, then the sort grows a sorted region from the front.
    /// Best case O(n) when already ordered, worst and average case O(n^2), with
    /// O(n) extra space only when a realign is needed, otherwise O(1).
    /// Order.CompareTo orders by total amount, so after sorting the smallest
    /// order is processed first. This turns the FIFO queue into a priority pass,
    /// which is why it is an explicit call and not automatic on enqueue.
    /// </summary>
    public void SortOrders() => _orders.Sort();
}