namespace EnrollmentSystem.Core;

using DataStructuresLibrary;
using System;
// Simulates a line of students waiting for admission, using CustomQueue<T>.
public class AdmissionsDesk
{
   private readonly CustomQueue<AdmissionApplication> _applications = new();
   private readonly CustomQueue<Ticket> _tickets = new();
   private int _nextTicketNumber = 1;
// Returns how many students are currently in line.
public int Count => _applications.Count;
// Adds a student directly using an AdmissionApplication and gives them a ticket ID.
   public void IssueAdmissionsTicket(AdmissionApplication app)
   {
      if (app is null)
      {
    throw new ArgumentNullException(nameof(app));

   }


   app.TicketId = $"T-10{_nextTicketNumber}";
   _nextTicketNumber++;


    _applications.Enqueue(app);
// Adds a student using a Ticket, converting it into a matching AdmissionApplication.
   }

   public void IssueAdmissionsTicket(Ticket ticket)
   {
    if (ticket is null)
    {
        throw new ArgumentNullException(nameof(ticket));

    }
    ticket.TicketId = $"T-10{_nextTicketNumber}";
    _nextTicketNumber++;

    var application = new AdmissionApplication(
applicationId: ticket.LogId,
        studentName: ticket.StudentId,
        priorityScore: 0)
    {
        TicketId = ticket.TicketId

    };

    _applications.Enqueue(application);
    _tickets.Enqueue(ticket);


   }

    // Serves (removes) the student who has waited the longest, returning their application.

   public AdmissionApplication ServeNextStudent()
   {
        if (CheckQueueEmpty())
        {
            throw new InvalidOperationException("No students are waiting to be served.");
        }

  if (!_tickets.IsEmpty())
   {
    _tickets.Dequeue();
   }
   return _applications.Dequeue();
   
}

    // Serves (removes) the student who has waited the longest, returning their original ticket.
public Ticket ServeNextTicket()
{

   if(_tickets.IsEmpty())
   {
    throw new InvalidOperationException("No tickets are waiting to be served.");
   }
   _applications.Dequeue();
   return _tickets.Dequeue();
   }
// Looks at the next student in line without removing them.
    public Ticket ViewNextTicket()
    {
        if (_tickets.IsEmpty())
        {
            throw new InvalidOperationException("No tickets are waiting to be served.");
        }

        return _tickets.Peek();
    }

    // Returns true if no students are currently waiting.

    public bool CheckQueueEmpty()
{
    return _applications.IsEmpty();

}
// Returns how many students are currently waiting.
public int GetQueueCount() => Count;
// Linear search (O(n)): checks every application in line for a match, preserving
public bool SearchApplication(AdmissionApplication app)
{
    if (app is null)
    {
        return false;
    }

    int totalItems = _applications.Count;
    bool found = false;

    for (int i = 0; i < totalItems; i++)
    {
        AdmissionApplication current = _applications.Dequeue();

        if (current.ApplicationId == app.ApplicationId)
        {
            found = true;
        }
        _applications.Enqueue(current);
    }

    return found;
}
// Bubble sort (O(n^2)): reorders the line so higher PriorityScore students go first.
public void SortApplicationsByPriority()
{
    int totalItems = _applications.Count;
    var list = new CustomArrayList<AdmissionApplication>();
    for (int i = 0; i < totalItems; i++)
    {
        list.Add(_applications.Dequeue());
    }

    for (int i = 0; i < list.Count - 1; i++)
    {
        for (int j = 0; j < list.Count - i - 1; j++)
        {
            if (list[j].PriorityScore < list[j + 1].PriorityScore)
            {
               (list[j], list[j +1]) = (list[j + 1], list[j]);  
            }
        }

    }

    foreach (var app in list)
    {
        _applications.Enqueue(app);
    }

}
}









