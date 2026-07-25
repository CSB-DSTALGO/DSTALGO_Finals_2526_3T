namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    // Returns the number of logs.
    public int Count => _logs.Count;

    // Pushes a log onto the stack.
    public void PushSystemLog(Log log)
    {
        _logs.Push(log);
    }

    // Removes and returns the latest log.
    public Log RollbackLastLog()
    {
        return _logs.Pop();
    }

    // Returns the latest log without removing it.
    public Log ViewLatestLog()
    {
        return _logs.Peek();
    }

    // Alias for ViewLatestLog().
    public Log PeekLatestLog()
    {
        return _logs.Peek();
    }

    // Alias for RollbackLastLog().
    public Log PopSystemLog()
    {
        return _logs.Pop();
    }

    // Returns true if the log stack is empty.
    public bool CheckLogsEmpty()
    {
        return _logs.IsEmpty();
    }

    // Returns the number of logs.
    public int GetLogCount()
    {
        return Count;
    }

    // Searches for a log.
    public bool SearchLog(Log log)
    {
        return _logs.Search(log);
    }

    // Sorts logs by LogId.
    public void SortLogsById()
    {
        _logs.Sort();
    }
}