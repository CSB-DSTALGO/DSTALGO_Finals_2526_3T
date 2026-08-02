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

        // Creates a matching ticket to keep both queues synchronized.
        Ticket ticket = new Ticket
        {
            LogId = app.ApplicationId,
            StudentId = app.StudentName,
            TicketId = app.TicketId,
            Timestamp = DateTime.Now,
            Action = "Admission Application"
        };

        _tickets.Enqueue(ticket);
    }

    // Adds a student using a Ticket and creates a matching AdmissionApplication.
    public void IssueAdmissionsTicket(Ticket ticket)
    {
        if (ticket is null)
        {
            throw new ArgumentNullException(nameof(ticket));
        }

        ticket.TicketId = $"T-10{_nextTicketNumber}";
        _nextTicketNumber++;

        AdmissionApplication application = new AdmissionApplication(
            applicationId: ticket.LogId,
            studentName: ticket.StudentId,
            priorityScore: 0)
        {
            TicketId = ticket.TicketId
        };

        _applications.Enqueue(application);
        _tickets.Enqueue(ticket);
    }

    // Removes and returns the next student.
    public AdmissionApplication ServeNextStudent()
    {
        if (_applications.IsEmpty() || _tickets.IsEmpty())
        {
            throw new InvalidOperationException("No students are waiting.");
        }

        _tickets.Dequeue();
        return _applications.Dequeue();
    }

    // Removes and returns the next ticket.
    public Ticket ServeNextTicket()
    {
        if (_applications.IsEmpty() || _tickets.IsEmpty())
        {
            throw new InvalidOperationException("No tickets are waiting.");
        }

        _applications.Dequeue();
        return _tickets.Dequeue();
    }

    // Returns the next ticket without removing it.
    public Ticket ViewNextTicket()
    {
        if (_tickets.IsEmpty())
        {
            throw new InvalidOperationException("No tickets are waiting.");
        }

        return _tickets.Peek();
    }

    // Returns true if the queue is empty.
    public bool CheckQueueEmpty()
    {
        return _applications.IsEmpty();
    }

    // Returns the number of students waiting.
    public int GetQueueCount()
    {
        return Count;
    }

    // Linear Search O(n)
    public bool SearchApplication(AdmissionApplication app)
    {
        if (app == null)
        {
            return false;
        }

        int count = _applications.Count;
        bool found = false;

        for (int i = 0; i < count; i++)
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

    // Bubble Sort O(n²)
    public void SortApplicationsByPriority()
    {
        int count = _applications.Count;

        CustomArrayList<AdmissionApplication> list = new();

        for (int i = 0; i < count; i++)
        {
            list.Add(_applications.Dequeue());
        }

        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j].PriorityScore < list[j + 1].PriorityScore)
                {
                    AdmissionApplication temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            _applications.Enqueue(list.Get(i));
        }
    }
}