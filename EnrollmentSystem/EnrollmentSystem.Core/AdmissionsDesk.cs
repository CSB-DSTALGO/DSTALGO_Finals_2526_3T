namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    public int Count => _applications.Count;

    public void IssueAdmissionsTicket(AdmissionApplication app)
    {
        _applications.Enqueue(app);
    }

    public AdmissionApplication ServeNextStudent()
    {
        return _applications.Dequeue();
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

    public bool SearchApplication(AdmissionApplication app)
    {
        return _applications.Search(app) != -1;
    }

    public void SortApplicationsByPriority()
    {
        _applications.Sort();
    }
}