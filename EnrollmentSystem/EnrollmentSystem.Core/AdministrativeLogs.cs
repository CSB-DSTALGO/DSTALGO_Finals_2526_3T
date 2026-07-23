namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

/// <summary>
/// Manages a stack-based log of administrative actions.
/// Uses CustomStack&lt;Log&gt; internally, so the most recently
/// pushed log is always the one on top (LIFO order).
/// </summary>
public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    /// <summary>Number of logs currently stored.</summary>
    public int Count => _logs.Count;

    /// <summary>
    /// Pushes a new system log entry onto the top of the stack.
    /// </summary>
    public void PushSystemLog(Log log)
    {
        _logs.Push(log);
    }

    /// <summary>
    /// Removes and returns the most recently pushed log,
    /// effectively "rolling back" the last recorded action.
    /// </summary>
    public Log RollbackLastLog()
    {
        return _logs.Pop();
    }

    /// <summary>
    /// Returns the most recent log without removing it from the stack.
    /// </summary>
    public Log ViewLatestLog()
    {
        return _logs.Peek();
    }

    /// <summary>
    /// Alias for ViewLatestLog(), kept for naming consistency
    /// with other modules that use "Peek" terminology.
    /// </summary>
    public Log PeekLatestLog()
    {
        return _logs.Peek();
    }

    /// <summary>
    /// Alias for RollbackLastLog(), kept for naming consistency
    /// with other modules that use "Pop" terminology.
    /// </summary>
    public Log PopSystemLog()
    {
        return _logs.Pop();
    }

    /// <summary>
    /// Returns true if there are no logs currently stored.
    /// </summary>
    public bool CheckLogsEmpty()
    {
        return _logs.IsEmpty();
    }

    /// <summary>
    /// Returns the current number of stored logs.
    /// </summary>
    public int GetLogCount()
    {
        return Count;
    }

    /// <summary>
    /// Searches for a log by matching LogId.
    /// Delegates to CustomStack&lt;T&gt;.Search using a predicate,
    /// since Log doesn't override Equals().
    /// Returns the index of the match (0 = bottom of stack), or -1 if not found.
    /// </summary>
    public int SearchLog(Log log)
    {
        return _logs.Search(l => l.LogId == log.LogId);
    }

    /// <summary>
    /// Sorts the logs in place by LogId, ascending.
    /// Delegates to CustomStack&lt;T&gt;.Sort, which uses insertion sort
    /// internally — O(n^2) worst case, but efficient and stable for
    /// small, mostly-ordered collections like a log history.
    /// </summary>
    public void SortLogsById()
    {
        _logs.Sort((a, b) => string.Compare(a.LogId, b.LogId));
    }
}