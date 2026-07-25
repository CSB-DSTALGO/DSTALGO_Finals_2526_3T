namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdmissionsDesk
{
    private readonly CustomQueue<AdmissionApplication> _applications = new();

    public int Count
    {
        get {return _applications.Count;}
    }

    public void IssueAdmissionsTicket(Ticket ticket)
    {
        ticket.TicketId = (_applications.Count + 1).ToString();
        
        var application = new AdmissionApplication(ticket.LogId, ticket.StudentId, 0);
        application.TicketId = ticket.TicketId;
        _applications.Enqueue(application);
    }
    public AdmissionApplication ServeNextStudent()
    {
        return _applications.Dequeue();
    }
    public Ticket ServeNextTicket()
    {
        var nextApplication = _applications.Dequeue();
        return new Ticket
        {
            LogId = nextApplication.ApplicationId,
            TicketId = nextApplication.TicketId,
            StudentId = nextApplication.StudentId,
            Timestamp = DateTime.Now,
            Action = "Served"
        };
    }
    public Ticket ViewNextTicket()
    {
        var nextApplication = _applications.Peek();
        return new Ticket
        {
            LogId = nextApplication.ApplicationId,
            TicketId = nextApplication.TicketId,
            StudentId = nextApplication.StudentId,
            Timestamp = DateTime.Now,
            Action = "Viewed"
        };
    }
     public bool CheckQueueEmpty()
    {
        return _applications.Count == 0;
    }
    public int GetQueueCount()
    {
        return _applications.Count;
    }

    // Hint: Delegate search and sort to CustomQueue<T>
    public bool SearchApplication(AdmissionApplication app)
    {
        return _applications.Contains(app);
    }

    public void SortApplicationsByPriority()
    {
        _applications.Sort();
    }
    public AdmissionApplication? SearchApplication(string key)
    {
        int idValue = 0;
        bool isNumeric = true;
        
        for (int i = 0; i < key.Length; i++)
        {
            if (key [i] < '0' || key [i] > '9')
            {
                isNumeric = false;
                break;
            }
            idValue = idValue * 10 + (key[i] - '0');
        }
        var apps = ViewAllApplications();
        foreach (var app in apps)
        {
            if (isNumeric && app.ApplicationId == idValue ||
            app.StudentId.Equals(key, StringComparison.OrdinalIgnoreCase) ||
            app.StudentName.Equals(key, StringComparison.OrdinalIgnoreCase))
            {
                return app;
            }
        }
        return null;
    }
    public List<AdmissionApplication> ViewAllApplications()
    {
       var applications = new List<AdmissionApplication>();

        while (_applications.Count > 0)
        {
            var app = _applications.Dequeue();
            applications.Add(app);
        }

        foreach (var app in applications)
        {
            _applications.Enqueue(app);
        }
        return applications;
    }
}