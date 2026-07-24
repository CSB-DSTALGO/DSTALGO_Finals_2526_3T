namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    // Queue used for the required admissions ticket operations.
    private readonly CustomQueue<Ticket> _tickets = new();

    // Separate queue used for application searching and priority sorting.
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    public int Count => _tickets.Count + _applications.Count;

    public void IssueAdmissionsTicket(Ticket ticket)
    {
        _tickets.Enqueue(ticket);
    }

    // Overload for adding admission applications.
    public void IssueAdmissionsTicket(AdmissionApplication application)
    {
        _applications.Enqueue(application);
    }

    public AdmissionApplication ServeNextStudent()
    {
        return _applications.Dequeue();
    }

    public Ticket ServeNextTicket()
    {
        return _tickets.Dequeue();
    }

    public Ticket ViewNextTicket()
    {
        return _tickets.Peek();
    }

    public bool CheckQueueEmpty()
    {
        return _tickets.IsEmpty() && _applications.IsEmpty();
    }

    public int GetQueueCount()
    {
        return Count;
    }

    public bool SearchApplication(AdmissionApplication app)
    {
        return _applications.Search(app);
    }

    public void SortApplicationsByPriority()
    {
        _applications.SortDescending();
    }
}