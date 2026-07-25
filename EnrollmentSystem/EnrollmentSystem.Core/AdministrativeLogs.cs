using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count => _logs.Count;

    public void PushSystemLog(Log log)
    {
        if (log == null)
        {
            throw new ArgumentNullException(nameof(log));
        }

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

    public int GetLogCount()
    {
        return _logs.Count;
    }

    public int SearchLog(Log log)
    {
        return _logs.Search(log) ? 0 : -1;
    }

    public void SortLogsById()
    {
        _logs.Sort();
    }
}