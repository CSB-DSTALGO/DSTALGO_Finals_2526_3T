namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    // Returns the number of applications currently in the queue.
    public int Count => _applications.Count;

    // Adds a new admission ticket to the end of the queue.
    public void IssueAdmissionsTicket(Ticket ticket)
    {
        AdmissionApplication application = new AdmissionApplication(
            _applications.Count + 1,
            ticket.StudentId,
            0);

        application.TicketId = string.IsNullOrEmpty(ticket.TicketId)
            ? $"T-{100 + _applications.Count + 1}"
            : ticket.TicketId;

        _applications.Enqueue(application);
    }

    // Removes and returns the next admission application.
    public AdmissionApplication ServeNextStudent()
    {
        return _applications.Dequeue();
    }

    // Removes and returns the next ticket.
    public Ticket ServeNextTicket()
    {
        AdmissionApplication application = _applications.Dequeue();

        return new Ticket
        {
            TicketId = application.TicketId,
            StudentId = application.StudentName
        };
    }

    // Returns the next ticket without removing it.
    public Ticket ViewNextTicket()
    {
        AdmissionApplication application = _applications.Peek();

        return new Ticket
        {
            TicketId = application.TicketId,
            StudentId = application.StudentName
        };
    }

    // Returns true if there are no tickets in the queue.
    public bool CheckQueueEmpty()
    {
        return _applications.IsEmpty();
    }

    // Returns the current queue size.
    public int GetQueueCount()
    {
        return Count;
    }

    // Searches for a specific admission application in the queue.
    public bool SearchApplication(AdmissionApplication app)
    {
        return _applications.Search(app);
    }

    // Sorts applications by priority score.
    public void SortApplicationsByPriority()
    {
        _applications.Sort();
    }
}