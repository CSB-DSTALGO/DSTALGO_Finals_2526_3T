namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new(); // Queue for admission applications
    private readonly CustomQueue<Ticket> _tickets = new(); // Queue for tickets

    public int Count => _applications.Count; // Number of applications
    public void IssueAdmissionsTicket(AdmissionApplication app) => _applications.Enqueue(app); // Enqueue an admission application
    public void IssueAdmissionsTicket(Ticket ticket) => _tickets.Enqueue(ticket); // Enqueue a ticket
    public AdmissionApplication ServeNextStudent() => _applications.Dequeue(); // Dequeue to serve the next student
    public Ticket ServeNextTicket() => _tickets.Dequeue(); // Dequeue to serve the next ticket
    public AdmissionApplication ViewNextTicket() => _applications.Peek(); // Peek to view the next admission application
    public bool CheckQueueEmpty() => _applications.IsEmpty(); // Checks if the application queue is empty
    public int GetQueueCount() => Count; // Count of application in the queue

    // Hint: Delegate search and sort to CustomQueue<T>
    public bool SearchApplication(AdmissionApplication app) => _applications.Search(app); // Search for an application in the queue
    public void SortApplicationsByPriority() => _applications.Sort((a, b) => a.PriorityScore.CompareTo(b.PriorityScore)); // Sort applications by priority score
}

