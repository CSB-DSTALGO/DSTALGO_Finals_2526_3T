namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count => _logs.Count; // Number of log entries currently stored.

    // Pushes a new log entry onto the top of the stack.
    public void PushSystemLog(Log log) => _logs.Push(log);

    // Removes and returns the most recent log (undo/rollback the last action).
    public Log RollbackLastLog() => _logs.Pop();

    // Returns the most recent log without removing it.
    public Log ViewLatestLog() => _logs.Peek();

    // Alias for ViewLatestLog - looks at the top log without removing it.
    public Log PeekLatestLog() => _logs.Peek();

    // Alias for RollbackLastLog - pops the top log off the stack.
    public Log PopSystemLog() => _logs.Pop();

    // True if there are no logs currently stored.
    public bool CheckLogsEmpty() => _logs.IsEmpty();

    // Returns how many logs are currently stored.
    public int GetLogCount() => Count;

    // Delegates search to CustomStack<Log>.Search, comparing by LogId.
    public int SearchLog(Log log) =>
        _logs.Search(log, (a, b) => string.Compare(a.LogId, b.LogId, StringComparison.Ordinal));

    // Delegates sort to CustomStack<Log>.Sort, ordering by LogId.
    public void SortLogsById() =>
        _logs.Sort((a, b) => string.Compare(a.LogId, b.LogId, StringComparison.Ordinal));
}