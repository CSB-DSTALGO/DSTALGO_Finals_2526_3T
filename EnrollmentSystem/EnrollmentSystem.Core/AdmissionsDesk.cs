namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    // Queue to hold admission applications
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    // Queue to hold tickets
    private readonly CustomQueue<Ticket> _tickets = new();

    //number of applications currently in queue
    public int Count => _applications.Count;

    // Add a Ticket to the ticket queue
    public void IssueAdmissionsTicket(Ticket ticket)
    {
        _tickets.Enqueue(ticket);
    }

    // (FIFO) Add an AdmissionApplication to the application queue
    public AdmissionApplication ServeNextStudent()
    {
        return _applications.Dequeue();
    }

    // Remove and return the next ticket (FIFO order)
    public Ticket ServeNextTicket()
    {
        return _tickets.Dequeue();
    }

    // Look at the next application without removing it
    public AdmissionApplication ViewNextApplication()
    {
        return _applications.Peek();
    }

    // Look at the next ticket without removing it
    public Ticket ViewNextTicket()
    {
        return _tickets.Peek();
    }

    // Check if the application queue is empty
    public bool CheckQueueEmpty()
    {
        return _applications.IsEmpty();
    }

    // Get the number of applications in the queue
    public int GetQueueCount() => Count;

    // Search for an application (placeholder until CustomQueue supports iteration)
    public bool SearchApplication(AdmissionApplication app)
    {
        // For now, return false. Later you can extend CustomQueue<T> with iteration.
        return false;
    }

    // Sort applications by priority (placeholder until CustomQueue supports sorting)
    public void SortApplicationsByPriority()
    {
        // Sorting logic will go here later
    }
}