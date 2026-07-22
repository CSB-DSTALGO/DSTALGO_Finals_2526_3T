namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count => _logs.Count;

    public void PushSystemLog(Log log) => throw new NotImplementedException();
    public Log RollbackLastLog() => throw new NotImplementedException();
    public Log ViewLatestLog() => throw new NotImplementedException();
    public Log PeekLatestLog() => throw new NotImplementedException();
    public Log PopSystemLog() => throw new NotImplementedException();
    public bool CheckLogsEmpty() => throw new NotImplementedException();
    public int GetLogCount() => Count;

    // Hint: Delegate search and sort to CustomStack<T>
    public int SearchLog(Log log) => throw new NotImplementedException();
    public void SortLogsById() => throw new NotImplementedException();
}