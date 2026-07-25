namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count
    {
        get { return _logs.Count; }
    }

    public void PushSystemLog(Log log)
    {
        _logs.Push(log);
    }

    public Log RollbackLastLog()
    {
        if (_logs.IsEmpty())
            throw new InvalidOperationException("No logs to rollback.");

        return _logs.Pop();
    }

    public Log ViewLatestLog()
    {
        if (_logs.IsEmpty())
            throw new InvalidOperationException("No logs available.");

        return _logs.Peek();
    }

    public Log PeekLatestLog()
    {
        if (_logs.IsEmpty())
            throw new InvalidOperationException("No logs available.");

        return _logs.Peek();
    }

    public Log PopSystemLog()
    {
        if (_logs.IsEmpty())
            throw new InvalidOperationException("No logs to pop.");

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