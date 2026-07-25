namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    public int Count => _applications.Count;

    public void IssueAdmissionsTicket(AdmissionApplication app)
    {
        _applications.Enqueue(app); //adds the application sa queueing
    }
    public void IssueAdmissionsTicket(Ticket ticket) => throw new NotImplementedException();
    public AdmissionApplication ServeNextStudent()
    {
       return _applications.Dequeue(); //removes the next student sa queue line
    }
    public Ticket ServeNextTicket() => throw new NotImplementedException();
    public AdmissionApplication ViewNextTicket()
    {
        return _applications.Peek(); //returns next student application nang di nireremove sa queue line
    }
    public bool CheckQueueEmpty()
    {
        return _applications.IsEmpty();
    }
    public int GetQueueCount()
    {
        return _applications.Count;
    }

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