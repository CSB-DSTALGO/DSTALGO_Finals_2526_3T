namespace EnrollmentSystem.Core;

using System;
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
        if (_logs.IsEmpty())
        {
            return true;
        }
        else
        {
            Console.WriteLine("Logs are not empty, remaining: " + _logs.Count);
            return false;
        }
    }

    public int GetLogCount() => Count;

    // Hint: Delegate search and sort to CustomStack<T>
    public int SearchLog(Log log)
    {
        var foundLog = _logs.Search(l => l.Equals(log));
        return foundLog != null ? 1 : -1;
    }

    public void SortLogsById()
    {
        _logs.Sort((log1, log2) => string.Compare(log1.LogId, log2.LogId));
    }
}