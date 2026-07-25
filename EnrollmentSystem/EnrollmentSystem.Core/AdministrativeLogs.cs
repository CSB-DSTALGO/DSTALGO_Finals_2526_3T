namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count => _logs.Count;

    public void PushSystemLog(Log log)
    {
        if (log is null)
        {
            throw new ArgumentNullException(nameof(log));
        }

        _logs.Push(log);
    }
    
    public Log RollbackLastLog() => _logs.Pop();
    
    public Log ViewLatestLog() => _logs.Peek();
    
    public Log PeekLatestLog() => _logs.Peek();
    
    public Log PopSystemLog() => _logs.Pop();
    
    public bool CheckLogsEmpty() => _logs.IsEmpty();
    
    public int GetLogCount() => Count;

    
    // Hint: Delegate search and sort to CustomStack<T>
    
    public int SearchLog(Log log)
    {
        if (log is null)
        {
            throw new ArgumentNullException(nameof(log));
        }

        return _logs.IndexOf(candidate => string.Equals(candidate.LogId, log.LogId, StringComparison.Ordinal));
    }
    
    
    public void SortLogsById() =>
        _logs.Sort((a, b) => string.Compare(a.LogId, b.LogId, StringComparison.Ordinal));
}
