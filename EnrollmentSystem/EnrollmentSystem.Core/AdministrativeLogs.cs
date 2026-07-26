namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count => _logs.Count;

    public void PushSystemLog(Log log)
    {
        _logs.Push(log);
    }

    public Log RollbackLastLog()
    {
        return _logs.Pop();
    }

    public Log ViewLatestLog()
    {
        return _logs.Peek();
    }

    public Log PeekLatestLog()
    {
        return _logs.Peek();
    }

    public Log PopSystemLog()
    {
        return _logs.Pop();
    }

    public bool CheckLogsEmpty()
    {
        return _logs.IsEmpty();
    }

    public int GetLogCount()
    {
        return Count;
    }

    // REVIEW: these next two methods hand work off to your stack. go open the actual stack
    // class you're using and check whether it can even do the things you're asking it here
    // Hint: Delegate search and sort to CustomStack<T>
    public int SearchLog(Log log)
    {
        return _logs.Search(log);
    }

    public void SortLogsById()
    {
        _logs.Sort();
    }
}