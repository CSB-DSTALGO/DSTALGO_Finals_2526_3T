namespace EnrollmentSystem.Core;

using DataStructuresLibrary;
using System;
using System.Collections.Generic;

// Manages the admissions queue using custom queue data structures.
public class AdmissionsDesk
{
    // Stores student admission applications.
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    // Stores admission tickets issued to students.
    private readonly CustomQueue<Ticket> _tickets = new();

    // Tracks the next ticket number to be assigned.
    private int _nextTicketNumber = 1;

    // Returns the current number of students waiting.
    public int Count => _applications.Count;

    // Issues an admission ticket to a student application.
    public void IssueAdmissionsTicket(AdmissionApplication app)
    {
        if (app is null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        app.TicketId = $"T-10{_nextTicketNumber}";
        _nextTicketNumber++;

        _applications.Enqueue(app);
    }

    // Issues an admission ticket using an existing Ticket object.
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

    // Serves the next student in the queue (FIFO order).
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

    // Serves and returns the next admission ticket.
    public Ticket ServeNextTicket()
    {
        if (_tickets.IsEmpty())
        {
            throw new InvalidOperationException("No tickets are waiting to be served.");
        }

        _applications.Dequeue();
        return _tickets.Dequeue();
    }

    // Returns the next ticket without removing it from the queue.
    public Ticket ViewNextTicket()
    {
        if (_tickets.IsEmpty())
        {
            throw new InvalidOperationException("No tickets are waiting to be served.");
        }

        return _tickets.Peek();
    }

    // Checks whether there are any students waiting.
    public bool CheckQueueEmpty()
    {
        return _applications.IsEmpty();
    }

    // Returns the total number of students currently waiting.
    public int GetQueueCount() => Count;

    // Searches for an application by its Application ID.
    // Time Complexity: O(n)
    public bool SearchApplication(AdmissionApplication app)
    {
        if (app is null)
        {
            return false;
        }

        int totalItems = _applications.Count;
        bool found = false;

        // Preserve the queue order while searching.
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

    // Sorts applications by PriorityScore using Bubble Sort.
    // Higher priority applications are placed at the front of the queue.
    // Time Complexity: O(n²)
    public void SortApplicationsByPriority()
    {
        int totalItems = _applications.Count;
        var list = new List<AdmissionApplication>();

        // Transfer queue items into a temporary list.
        for (int i = 0; i < totalItems; i++)
        {
            list.Add(_applications.Dequeue());
        }

        // Bubble Sort by descending priority score.
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j].PriorityScore < list[j + 1].PriorityScore)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }

        // Restore the sorted applications back into the queue.
        foreach (var app in list)
        {
            _applications.Enqueue(app);
        }
    }
}