namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    public int Count => _applications.Count;

    public void IssueAdmissionsTicket(AdmissionApplication app) => throw new NotImplementedException();
    public void IssueAdmissionsTicket(Ticket ticket) => throw new NotImplementedException();
    public AdmissionApplication ServeNextStudent() => throw new NotImplementedException();
    public Ticket ServeNextTicket() => throw new NotImplementedException();
    public AdmissionApplication ViewNextTicket() => throw new NotImplementedException();
    public bool CheckQueueEmpty() => throw new NotImplementedException();
    public int GetQueueCount() => Count;

    // Hint: Delegate search and sort to CustomQueue<T>
    public bool SearchApplication(AdmissionApplication app) => throw new NotImplementedException();
    public void SortApplicationsByPriority() => throw new NotImplementedException();
}