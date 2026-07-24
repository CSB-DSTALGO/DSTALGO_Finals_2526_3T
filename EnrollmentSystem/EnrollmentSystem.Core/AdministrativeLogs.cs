namespace EnrollmentSystem.Core;

using System;
using System.Collections.Generic;
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

    public int SearchLog(Log log) // searches log by extracting items temporarily
    {
        if (log == null || _logs.IsEmpty()) return -1; // return -1 if null or empty

        var tempStack = new CustomStack<Log>(); // temporary stack to preserve order
        int foundIndex = -1;
        int distance = 0;

        while (!_logs.IsEmpty())
        {
            Log current = _logs.Pop();
            tempStack.Push(current);

            if (foundIndex == -1 && current.LogId == log.LogId) // check if log id matches
            {
                foundIndex = distance;
            }
            distance++;
        }

        while (!tempStack.IsEmpty()) // restore original stack order
        {
            _logs.Push(tempStack.Pop());
        }

        return foundIndex; // return 0-based distance from top or -1
    }

    public void SortLogsById() // sorts logs by log id using domain logic
    {
        if (_logs.IsEmpty()) return; // skip if empty

        var logList = new List<Log>(); // temporary list to collect stack items
        while (!_logs.IsEmpty())
        {
            logList.Add(_logs.Pop()); // pop all items into list
        }

        // sort by log id descending so smallest id ends up at top when pushed back
        logList.Sort((a, b) => string.Compare(b.LogId, a.LogId, StringComparison.Ordinal));

        foreach (var log in logList) // push sorted items back to stack
        {
            _logs.Push(log);
        }
    }
}