using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core;

public class AdmissionsDesk
{
    private readonly CustomQueue<Ticket> _tickets = new();

    public int Count => _tickets.Count;

    public void IssueAdmissionsTicket(Ticket ticket) 
    {
        _tickets.Enqueue(ticket);
    }
   
    public Ticket ServeNextStudent() 
    {
        return _tickets.Dequeue();
    }

    public Ticket ServeNextTicket() 
    {
        return ServeNextStudent();
    }

    public Ticket ViewNextTicket() 
    {
        return _tickets.Peek();
    }

    public bool CheckQueueEmpty() 
    {
       return _tickets.IsEmpty();
    }

    public int GetQueueCount() => Count;

    

    // Hint: Delegate search and sort to CustomQueue<T>
    public bool SearchApplication(AdmissionApplication app) => throw new NotImplementedException();
    public void SortApplicationsByPriority() => throw new NotImplementedException();
}
