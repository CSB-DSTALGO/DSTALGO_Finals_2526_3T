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

        var application = new AdmissionApplication(ticket.LogId, ticket.StudentId, 0)
        {
            TicketId = ticketId,
            Timestamp = ticket.Timestamp
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
            Timestamp = application.Timestamp
        };
    }

    public void ShowQueue()
    {
        if (_applications.IsEmpty())
        {
            Console.WriteLine("No tickets in the queue.");
            return;
        }

        int count = _applications.Count;
        var temp = new List<AdmissionApplication>();

        Console.WriteLine("\nCurrent Queue:");

        for (int i = 0; i < count; i++)
        {
            AdmissionApplication application = _applications.Dequeue();

            Console.WriteLine($"[{i + 1}] Ticket: {application.TicketId} | Student: {application.StudentName} | Issued: {application.Timestamp:hh:mm:ss tt}");

            temp.Add(application);
        }

        foreach (var application in temp)
        {
            _applications.Enqueue(application);
        }
    }


}