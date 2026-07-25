using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core;

public class AdmissionsDesk
{
    private readonly CustomQueue<Ticket> _tickets = new(); // stores tickets in FIFO order
    private readonly CustomQueue<AdmissionApplication> _applications = new(); // stores applications for searching and sorting

    public int Count => _tickets.Count; // returns number of tickets in the queue

    public void IssueAdmissionsTicket(Ticket ticket) // adds a new ticket to the queue
    {
        _tickets.Enqueue(ticket);
    }

    public Ticket ServeNextStudent() // removes and returns the next ticket =
    {
        return _tickets.Dequeue();
    }

    public Ticket ServeNextTicket() 
    {  // calls ServeNextStudent() to serve the next ticket
        return ServeNextStudent();
    }

    public Ticket ViewNextTicket() // views the next ticket without removing
    {
        return _tickets.Peek();
    }

    public bool CheckQueueEmpty() // checks whether the ticket queue is empty or not
    {
       return _tickets.IsEmpty();
    }

    public int GetQueueCount() => Count; // returns the number of tickets in the queue  

    public void SubmitApplication(AdmissionApplication application) // adds an application the the application queue
    {
        _applications.Enqueue(application);
    }

    public AdmissionApplication ViewNextApplication() // views the first application without removing it
    {
        return _applications.Peek();
    }

    // Hint: Delegate search and sort to CustomQueue<T>

    public bool SearchApplication(AdmissionApplication app) //
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
