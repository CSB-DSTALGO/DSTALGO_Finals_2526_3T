namespace EnrollmentSystem.Core;

using DataStructuresLibrary;
using System.Net.Sockets;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();
    private CustomQueue<Ticket> _tickets = new CustomQueue<Ticket>();


    public int Count => _applications.Count;
    
   
    public void IssueAdmissionsTicket(AdmissionApplication app)
    {
        _applications.Enqueue(app);
    }
    public void IssueAdmissionsTicket(Ticket ticket)
    {
        _tickets.Enqueue(ticket);

<<<<<<< HEAD
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
        if (_applications.IsEmpty())
        {
            return true;
        }
        else
        {
            Console.WriteLine("Queue is not empty, remaining: " +  _applications.Count);
            return false;
        }
    }
=======
    public void IssueAdmissionsTicket(Ticket ticket) => throw new NotImplementedException();
    public AdmissionApplication ServeNextStudent() => throw new NotImplementedException();
    public Ticket ServeNextTicket() => throw new NotImplementedException();
    public AdmissionApplication ViewNextTicket() => throw new NotImplementedException();
    public bool CheckQueueEmpty() => throw new NotImplementedException();
>>>>>>> origin/main
    public int GetQueueCount() => Count;

    // Hint: Delegate search and sort to CustomQueue<T>
    public bool SearchApplication(AdmissionApplication app) => throw new NotImplementedException();
    public void SortApplicationsByPriority() => throw new NotImplementedException();
}
