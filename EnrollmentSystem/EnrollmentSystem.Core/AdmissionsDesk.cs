namespace EnrollmentSystem.Core;

using DataStructuresLibrary;


public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    public int Count => _applications.Count;

   
    public void IssueAdmissionsTicket(Ticket ticket)
    {
        if (ticket is null)
            throw new ArgumentNullException(nameof(ticket), "Cannot issue a null ticket.");

        // REVIEW: you set and read a property on the application a couple lines down that i
        // dont think lives on that class anymore. go check what AdmissionApplication actually has
        ticket.TicketId = $"T-{100 + Count + 1}";

        var application = new AdmissionApplication(ticket.LogId, ticket.StudentId, priorityScore: 0)
        {
            TicketId = ticket.TicketId
        };

        _applications.Enqueue(application);
    }


    public AdmissionApplication ServeNextStudent() => _applications.Dequeue();

  
    public Ticket ServeNextTicket()
    {
        var application = _applications.Dequeue();

        return new Ticket
        {
            LogId = application.ApplicationId,
            StudentId = application.StudentName,
            TicketId = application.TicketId,
            Timestamp = DateTime.Now
        };
    }


    public AdmissionApplication ViewNextTicket() => _applications.Peek();

    public bool CheckQueueEmpty() => _applications.IsEmpty();

    public int GetQueueCount() => Count;

  
    public bool SearchApplication(AdmissionApplication app)
    {
        if (app is null) return false;
        // REVIEW: look real close at what this search hands back versus what this method
        // promises to return up top. those two dont agree
        return _applications.Search(a => a.ApplicationId == app.ApplicationId);
    }

    public void SortApplicationsByPriority()
    {
        _applications.Sort((a, b) => a.CompareTo(b));
    }
}
