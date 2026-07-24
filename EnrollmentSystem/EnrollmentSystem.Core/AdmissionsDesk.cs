// 12521269 Joaquin Bryan G. Ross
namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<Ticket> _tickets = new();

    public int Count => _tickets.Count;

    /// <summary>
    /// Enqueues a ticket to the rear of the line. O(1) amortised: the circular
    /// buffer writes straight to the rear slot, and growth doubles the capacity
    /// so the copying averages out to a constant cost per ticket.
    /// </summary>
    public void IssueAdmissionsTicket(Ticket ticket)
    {
        // The desk issues the number, which is what "issue a ticket" means. A
        // caller may supply its own TicketId, and the console app does, but a
        // ticket handed over without one is numbered here using the same
        // formula the console uses, so the first ticket of the day is T-101.
        if (string.IsNullOrEmpty(ticket.TicketId))
        {
            ticket.TicketId = $"T-{100 + _tickets.Count + 1}";
        }

        _tickets.Enqueue(ticket);
    }

    /// <summary>
    /// Dequeues and returns the front ticket. O(1), because the front index
    /// moves forward instead of the remaining tickets shifting left. A queue is
    /// the right structure for an admissions line precisely because arriving
    /// first should mean being served first.
    /// Throws InvalidOperationException when nobody is waiting.
    /// </summary>
    public Ticket ServeNextStudent() => _tickets.Dequeue();

    /// <summary>
    /// The name the project scaffold shipped for the same dequeue operation,
    /// kept alongside ServeNextStudent so code written against either name
    /// compiles. O(1).
    /// </summary>
    public Ticket ServeNextTicket() => _tickets.Dequeue();

    /// <summary>
    /// Peeks at the front ticket without removing it. O(1).
    /// Throws InvalidOperationException when the queue is empty.
    /// </summary>
    public Ticket ViewNextTicket() => _tickets.Peek();

    /// <summary>
    /// Evaluates and returns whether the line is empty. O(1).
    /// </summary>
    public bool CheckQueueEmpty() => _tickets.IsEmpty();

    /// <summary>Returns how many tickets are waiting. O(1).</summary>
    public int GetQueueCount() => Count;

    /// <summary>
    /// Search algorithm: linear search, delegated to CustomQueue.Search. It
    /// steps from the front through Count slots, wrapping with modulo when it
    /// runs off the end of the buffer.
    /// Best case O(1) at the front, worst and average case O(n).
    /// The property that matters is that it is non-destructive. Searching a
    /// queue naively means draining it into another structure and rebuilding
    /// it, which costs the same O(n) but disturbs the waiting order. Indexing
    /// the buffer directly avoids that entirely.
    /// </summary>
    public bool SearchTicket(Ticket ticket) => _tickets.Search(ticket);

    /// <summary>
    /// Sorting algorithm: insertion sort, delegated to CustomQueue.Sort. The
    /// buffer is realigned to index 0 first so the wrapped region becomes
    /// contiguous, then the sort grows a sorted region from the front.
    /// Best case O(n) when already ordered, worst and average case O(n^2), with
    /// O(n) extra space only when a realign is needed and O(1) otherwise.
    /// Ticket.CompareTo orders by LogId, so after sorting the lowest ticket
    /// number is served first. This turns the FIFO line into a priority pass,
    /// which is why it is an explicit call rather than automatic on enqueue.
    /// </summary>
    public void SortTicketsById() => _tickets.Sort();
}
