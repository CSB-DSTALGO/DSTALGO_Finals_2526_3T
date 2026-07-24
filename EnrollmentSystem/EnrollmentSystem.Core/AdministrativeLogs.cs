using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class AdministrativeLogs
    {
        private readonly CustomStack<Log> _logs = new();

        public int Count => _logs.Count;

        public void PushSystemLog(Log log)
        {
            _logs.Push(log); // pushes the new log entry onto the top of the execution stack
        }

        public Log RollbackLastLog()
        {
            return _logs.Pop(); // pops (removes and returns) the most recently pushed log
        }

        public Log ViewLatestLog()
        {
            return _logs.Peek(); // returns the topmost log without removing it
        }

        public Log PeekLatestLog()
        {
            return _logs.Peek(); // same behavior as ViewLatestLog, provided as an alias
        }

        public Log PopSystemLog()
        {
            return _logs.Pop(); // same behavior as RollbackLastLog, provided as an alias
        }

        public bool CheckLogsEmpty()
        {
            return _logs.IsEmpty();
        }

        public int GetLogCount() => Count;

        // Hint: Delegate search and sort to CustomStack<T>
        public int SearchLog(Log log)
        {
            // Delegates to CustomStack<T>.Search, which performs a linear search
            // from the top of the stack down and returns the 1-based distance
            // from the top, or -1 if the log is not present.
            return _logs.Search(log);
        }

        public void SortLogsById()
        {
            // Delegates to CustomStack<T>.Sort, which performs an in-place insertion
            // sort on the underlying array. Logs are ordered ascending by LogId
            // (ordinal string comparison).
            _logs.Sort((a, b) => string.Compare(a.LogId, b.LogId, StringComparison.Ordinal));
            }
    }
}