namespace EnrollmentSystem.Core;

using System;
using DataStructuresLibrary;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new(); // stack for storing system logs

    public int Count => _logs.Count; // returns number of logs in stack

    public void PushSystemLog(Log log) // pushes an action log to top of stack
    {
        if (log == null) // check for null log
        {
            throw new ArgumentNullException(nameof(log), "Log record cannot be null.");
        }
        _logs.Push(log); // push log to stack
    }

    public Log RollbackLastLog() // pops top item off stack to rollback
    {
        return _logs.Pop(); // remove and return last log
    }

    public Log ViewLatestLog() // peeks at latest log record
    {
        return _logs.Peek(); // view top log without removing
    }

    public Log PeekLatestLog() => ViewLatestLog();

    public Log PopSystemLog() => RollbackLastLog();

    public bool CheckLogsEmpty() // checks if logs stack is empty
    {
        return _logs.IsEmpty(); // returns true if empty
    }

    public int GetLogCount() => Count; // returns total log count

    public int SearchLog(Log log) // searches log in stack by delegating to CustomStack
    {
        if (log == null) return -1;
        return _logs.Search(log, (a, b) => a.LogId == b.LogId); // search by log id
    }

    public void SortLogsById() // sorts logs by log id delegating to CustomStack
    {
        _logs.Sort((a, b) => string.Compare(a.LogId, b.LogId, StringComparison.Ordinal) > 0); // sort by id ascending
    }
}