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

    
    public int SearchLog(Log log) => _logs.Search(log);
    public void SortLogsById()
    {
        int logCount = _logs.Count;
        Log[] buffer = new Log[logCount];

        
        for (int i = 0; i < logCount; i++)
        {
            buffer[i] = _logs.Pop();
        }

        // Manual insertion sort by LogId.
        for (int i = 1; i < buffer.Length; i++)
        {
            Log currentLog = buffer[i];
            int previousIndex = i - 1;

            while (previousIndex >= 0 &&
                   string.Compare(buffer[previousIndex].LogId, currentLog.LogId, StringComparison.Ordinal) > 0)
            {
                buffer[previousIndex + 1] = buffer[previousIndex];
                previousIndex--;
            }

            buffer[previousIndex + 1] = currentLog;
        }
        
        for (int i = buffer.Length - 1; i >= 0; i--)
        {
            _logs.Push(buffer[i]);
        }
    }
}