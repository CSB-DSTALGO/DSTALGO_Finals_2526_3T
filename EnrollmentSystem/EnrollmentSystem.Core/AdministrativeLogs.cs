using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class AdministrativeLogs
    {
        private readonly CustomStack<Log> _stack = new CustomStack<Log>();

        public int Count => _stack.Count;

        public void PushSystemLog(Log log)
        {
            _stack.Push(log);
        }

        public Log PopSystemLog()
        {
            return _stack.Pop();
        }

        public Log PeekLatestLog()
        {
            return _stack.Peek();
        }

        public int GetLogCount() => Count;

        // Hint: Delegate search and sort to CustomStack<T>
        public void SortLogsById()
        {
            _stack.Sort((log1, log2) => string.Compare(log1.LogId, log2.LogId));
        }

        public Log? SearchLogById(string logId)
        {
            return _stack.Search(log => log.LogId == logId);
        }
    }
}