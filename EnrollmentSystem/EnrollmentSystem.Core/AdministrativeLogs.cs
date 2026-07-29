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
    public int GetLogCount() => Count;

    // Hint: Delegate search and sort to CustomStack<T>
    public int SearchLog(Log log)
    {
        return _logs.Search(log, (a, b) => a.LogId.CompareTo(b.LogId));
    }

    public void SortLogsById()
    {
        _logs.Sort((a, b) => a.LogId.CompareTo(b.LogId));
    }
}