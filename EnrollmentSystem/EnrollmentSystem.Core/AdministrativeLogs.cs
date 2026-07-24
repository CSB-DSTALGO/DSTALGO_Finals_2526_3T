namespace EnrollmentSystem.Core;

using DataStructuresLibrary;
using System.Collections.Generic;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count => _logs.Count;

    public void PushSystemLog(Log log) => _logs.Push(log);
    public Log RollbackLastLog() => _logs.Pop();
    public Log ViewLatestLog() => _logs.Peek();
    public Log PeekLatestLog() => _logs.Peek();
    public Log PopSystemLog() => _logs.Pop();
    public bool CheckLogsEmpty() => _logs.IsEmpty();
    public int GetLogCount() => Count;

    // Hint: Delegate search and sort to CustomStack<T>
    public int SearchLog(Log log) => _logs.Search(log);
    public void SortLogsById()
    {
        var buffer = new List<Log>();
        while (!_logs.IsEmpty())
        buffer.Add(_logs.Pop());

        buffer.Sort((a, b) => string.Compare(a.LogId, b.LogId, System.StringComparison.Ordinal));

        for (int i = buffer.Count - 1; i >= 0; i--)
         _logs.Push(buffer[i]);
    }

}