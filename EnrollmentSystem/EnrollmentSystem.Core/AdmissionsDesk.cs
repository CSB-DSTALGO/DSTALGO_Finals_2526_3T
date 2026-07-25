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


    }
    public AdmissionApplication ServeNextStudent()
    {
       return _applications.Dequeue();
        
    }
    public Ticket ServeNextTicket()
    {
        if (_applications.IsEmpty())
        {
            throw new InvalidOperationException();
        }
        return _tickets.Dequeue();
    }
    public AdmissionApplication ViewNextTicket()
    {
        if (_applications.IsEmpty())
        {
            throw new InvalidOperationException();
        }
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

    public int GetQueueCount() => Count;

    // Hint: Delegate search and sort to CustomQueue<T>
    public bool SearchApplication(AdmissionApplication app)
    {
        return _applications.LinearSearch(app);
    }
    public void SortApplicationsByPriority()
    {
        _applications.BubbleSortQueue();
    }
}
