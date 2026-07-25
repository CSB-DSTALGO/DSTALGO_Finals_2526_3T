using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core;




public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count => _logs.Count; // returns number of logs in the stack

    public void PushSystemLog(Log log) // adds a new log to the stack
    {
        _logs.Push(log);
    }

    public Log RollbackLastLog() // removes and returns the last log
    {
        return _logs.Pop();
    }

    public Log ViewLatestLog() // views the latest log without removing it
    {
        return _logs.Peek();
    }

    public Log PeekLatestLog() // views the latest log without removing it
    {
        return ViewLatestLog();
    }

    public Log PopSystemLog() // removes and returns the last log
    {
        return RollbackLastLog();
    }

    public bool CheckLogsEmpty() 
    {
        return _logs.IsEmpty();
    }

    public int GetLogCount() 
    {
        return Count;
    }

    // Uses linear search to find a log in stack

  
    public int SearchLog(Log log)  
    {
        return _logs.Search(log);
    }

    // uses insertion sort to arrange logs by LogId
    public void SortLogsById()
    {
        int logCount = _logs.Count;
        Log[] logs = new Log[logCount];

        for (int i = 0; i < logCount; i++)
        {
            logs[i] = _logs.Pop();
        }

        for (int i = 1; i < logs.Length; i++)
        {
            Log currentLog = logs[i];
            int previousIndex = i - 1;

            while (
                previousIndex >= 0 && 
                string.Compare(logs[previousIndex].LogId, currentLog.LogId, StringComparison.Ordinal) 
                > 0
            )
            {
                logs[previousIndex + 1] = logs[previousIndex];
                previousIndex--;
            }

            logs[previousIndex + 1] = currentLog;
        }

        //Push in reverse so the smallest LogId becomes the top
        for (int i = logs.Length - 1; i >= 0; i--)
        {
            _logs.Push(logs[i]);
        }
    }
            
}