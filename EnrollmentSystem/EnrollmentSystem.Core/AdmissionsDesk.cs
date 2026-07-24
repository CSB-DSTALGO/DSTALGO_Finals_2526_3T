namespace EnrollmentSystem.Core;

using System;
using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();
    private readonly CustomQueue<Ticket> _tickets = new();

    public int Count => _applications.Count + _tickets.Count;

    public void IssueAdmissionsTicket(AdmissionApplication app) => _applications.Enqueue(app);

    public void IssueAdmissionsTicket(Ticket ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket.TicketId))
        {
            ticket.TicketId = $"T-{100 + _tickets.Count + 1}";
        }

        _tickets.Enqueue(ticket);
    }

    public AdmissionApplication ServeNextStudent() => _applications.Dequeue();

    public Ticket ServeNextTicket()
    {
        if (_tickets.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _tickets.Dequeue();
    }

    public AdmissionApplication ViewNextTicket() => _applications.Peek();

    public bool CheckQueueEmpty() => Count == 0;

    public int GetQueueCount() => Count;

    public bool SearchApplication(AdmissionApplication app)
    {
        if (_applications.Count == 0)
        {
            return false;
        }

        var current = _applications.Peek();
        return current != null && current.ApplicationId == app.ApplicationId;
    }

    public void SortApplicationsByPriority() { }
}