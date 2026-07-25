namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    private readonly CustomQueue<Ticket> _ticketQueue = new();

    public int Count => _ticketQueue.Count; // number of tickets in queue

    public void IssueAdmissionsTicket(AdmissionApplication app) // issues a ticket for the student to be served
    {
        if (app == null) // check for null application
        {
            throw new ArgumentNullException(nameof(app), "Admission application cannot be null."); // throws exception if null
        }
        _applications.Enqueue(app); // enqueue (ADD) the application to the queue
    }

    public void IssueAdmissionsTicket(Ticket ticket) // issues a ticket for the student to be served
    {
        if (ticket == null) // check for null ticket
        {
            throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null."); // throws exception if null
        }

        if (string.IsNullOrEmpty(ticket.TicketId)) // auto-generate ID if not already set
        {
            ticket.TicketId = $"T-{100 + _ticketQueue.Count + 1}";
        }

        _ticketQueue.Enqueue(ticket); // enqueue (ADD) the ticket to the queue
    }

    public AdmissionApplication ServeNextStudent() // serves the next student in line
    {
        return _applications.Dequeue();          //   dequeue (REMOVE) the application from the queue
    }

    public Ticket ServeNextTicket()       // serves the next ticket in line
    {
        return _ticketQueue.Dequeue();  //   dequeue (REMOVE) the ticket from the queue   
    }

    public AdmissionApplication ViewNextTicket() // peeks at front application 
    {
        return _applications.Peek();
    }

    public bool CheckQueueEmpty() // checks if the queue is empty
    {
        return _applications.IsEmpty();
    }

    public int GetQueueCount() => Count; // returns the number of applications in the queue

    // Hint: Delegate search and sort to CustomQueue<T>
    public bool SearchApplication(AdmissionApplication app) // searches for an application in the queue
    {
        return _applications.Contains(app);
    }

    public void SortApplicationsByPriority() // sorts the applications in the queue by priority
    {
        _applications.Sort();
    }

}