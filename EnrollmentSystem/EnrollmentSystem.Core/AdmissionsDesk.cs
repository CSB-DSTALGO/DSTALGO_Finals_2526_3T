namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();
    private readonly CustomQueue<Ticket> _tickets = new();//Front end queue for students
    public int Count => _applications.Count;

    public void IssueAdmissionsTicket(AdmissionApplication app)
    {
        _applications.Enqueue(app);
    }
    public void IssueAdmissionsTicket(Ticket ticket) 
    {
        _tickets.Enqueue(ticket);
    }
    public AdmissionApplication ServeNextStudent()
    {
        return _applications.Dequeue();
    }
    public Ticket ServeNextTicket()
    {
        return _tickets.Dequeue();
    }
        public AdmissionApplication ViewNextTicket()
    {
        return _applications.Peek();
    }
    public bool CheckQueueEmpty()
    {
        return _applications.IsEmpty();
    }
    public int GetQueueCount() => Count;

    // Hint: Delegate search and sort to CustomQueue<T>
    public bool SearchApplication(AdmissionApplication app)
    {
        return _applications.Search(app);
    }
    public void SortApplicationsByPriority()
    {
        _applications.Sort();
    }
}