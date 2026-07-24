namespace EnrollmentSystem.Core;

using System;
using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    private int _nextTicketNumber = 101;

    public int Count => _applications.Count;

    // Adds an admission application to the queue
    // Adds a ticket to the ticket queue
    public void IssueAdmissionsTicket(Ticket ticket)
    {
        if (ticket == null) throw new ArgumentNullException(nameof(ticket));

        string ticketId = string.IsNullOrEmpty(ticket.TicketId)
            ? $"T-{_nextTicketNumber++}"
            : ticket.TicketId;

        var application = new AdmissionApplication(ticket.LogId, ticket.StudentId, priorityScore: 0)
        {
            TicketId = ticketId
        };

        _applications.Enqueue(application);
    }

    // Serves the next student application
    public AdmissionApplication ServeNextStudent()
    {
        return _applications.Dequeue();
    }

    // Serves the next ticket
    public Ticket ServeNextTicket()
    {
        var application = _applications.Dequeue();
        return ToTicket(application);
    }

    // Views the next application without removing it
    public AdmissionApplication ViewNextTicket()
    {
        return _applications.Peek();
    }

    // Checks if both queues are empty
    public bool CheckQueueEmpty()
    {
        return _applications.IsEmpty();
    }

    // Returns the total number of queued items
    public int GetQueueCount()
    {
        return Count;
    }

    // Searches for an application by ApplicationId
    public bool SearchApplication(AdmissionApplication app)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }
        return _applications.Contains(a => a.TicketId == app.TicketId);
    }

    // Sorts the applications queue
    public void SortApplicationsByPriority()
    {
        _applications.Sort();
    }

    private static Ticket ToTicket(AdmissionApplication application)
    {
        return new Ticket
        {
            TicketId = application.TicketId,
            StudentId = application.StudentName,
            LogId = application.ApplicationId,
            Action = "Served",
            Timestamp = DateTime.Now
        };
    }
}