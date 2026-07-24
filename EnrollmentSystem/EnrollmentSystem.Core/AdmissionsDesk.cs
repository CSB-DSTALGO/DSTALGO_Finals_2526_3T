using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core;

public class AdmissionsDesk
{
    private readonly CustomQueue<Ticket> _tickets = new();
    private readonly CustomQueue<AdmissionApplication> _applications = new();

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

    public void SubmitApplication(AdmissionApplication application)
    {
        _applications.Enqueue(application);
    }

    public AdmissionApplication ViewNextApplication()
    {
        return _applications.Peek();
    }

    // Hint: Delegate search and sort to CustomQueue<T>

    public bool SearchApplication(AdmissionApplication app)
    {
        bool applicationFound = false;
        int applicationCount = _applications.Count;

        for (int i = 0; i < applicationCount; i++)
        {
            AdmissionApplication currentApplication = _applications.Dequeue();

            if (currentApplication.ApplicationId == app.ApplicationId)
            {
                applicationFound = true;
            }
            _applications.Enqueue(currentApplication);
        }
        return applicationFound;
    }

    public void SortApplicationsByPriority()
    {
        int applicationCount = _applications.Count;

        AdmissionApplication[] applications = new AdmissionApplication[applicationCount];

        for (int i = 0; i < applicationCount; i++)
        {
            applications[i] = _applications.Dequeue();
        }

        for (int i = 1; i < applications.Length; i++)
        {
            AdmissionApplication currentApplication = applications[i];
            int previousIndex = i -1;

            while (
                previousIndex >= 0 && applications[previousIndex].PriorityScore
                < currentApplication.PriorityScore
            )
            {
                applications[previousIndex + 1] = applications[previousIndex];
                previousIndex--;
            }

            applications[previousIndex + 1] = currentApplication;
        }

        for (int i = 0; i< applications.Length; i++)
        {
            _applications.Enqueue(applications[i]);
        }

    }

}
