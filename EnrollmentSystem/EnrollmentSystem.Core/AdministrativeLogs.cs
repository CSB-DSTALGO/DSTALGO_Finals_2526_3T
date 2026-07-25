namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

// Manages administrative system logs using a custom stack.
// Follows the Last-In, First-Out (LIFO) principle.
public class AdministrativeLogs
{
    // Stores all administrative logs.
    private readonly CustomStack<Log> _logs = new();

    // Returns the current number of logs in the stack.
    public int Count => _logs.Count;

    // Adds a new log to the top of the stack.
    public void PushSystemLog(Log log)
    {
        _logs.Push(log);
    }

    // Removes and returns the most recently added log.
    public Log RollbackLastLog()
    {
        return _logs.Pop();
    }

    // Returns the latest log without removing it.
    public Log ViewLatestLog()
    {
        return _logs.Peek();
    }

    // Retrieves the latest log without modifying the stack.
    public Log PeekLatestLog()
    {
        return _logs.Peek();
    }

    // Removes and returns the latest log from the stack.
    public Log PopSystemLog()
    {
        return _logs.Pop();
    }

    // Checks whether there are any logs stored.
    public bool CheckLogsEmpty()
    {
        return _logs.IsEmpty();
    }

    // Returns the total number of stored logs.
    public int GetLogCount()
    {
        return Count;
    }

    // Searches for a specific log.
    // Reserved for future implementation.
    public int SearchLog(Log log)
    {
        throw new NotImplementedException();
    }

    // Sorts logs by Log ID.
    // Reserved for future implementation.
    public void SortLogsById()
    {
        throw new NotImplementedException();
    }
}