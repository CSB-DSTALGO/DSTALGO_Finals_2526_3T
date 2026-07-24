using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    // Application-level log manager, backed by CustomStack<Log>.
    public class AdministrativeLogs
    {
        private readonly CustomStack<Log> _stack;

        public AdministrativeLogs()
        {
            _stack = new CustomStack<Log>();
        }

        // Pushes a new log entry onto the stack.
        public void PushSystemLog(Log log)
        {
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log), "Cannot push a null log.");
            }

            _stack.Push(log);
        }

        // Removes and returns the most recent log entry.
        public Log RollbackLastLog() => _stack.Pop();

        // Returns the most recent log entry without removing it.
        public Log ViewLatestLog() => _stack.Peek();

        // Returns true if there are no logs.
        public bool CheckLogsEmpty() => _stack.IsEmpty();

        // Sorting algorithm: Insertion Sort.
        // Sorts a snapshot copy of the logs by LogId (does not affect the real stack).
        public Log[] GetLogsSortedById()
        {
            Log[] snapshot = _stack.ToArray();

            for (int i = 1; i < snapshot.Length; i++)
            {
                Log current = snapshot[i];
                int j = i - 1;

                while (j >= 0 && string.Compare(snapshot[j].LogId, current.LogId, StringComparison.Ordinal) > 0)
                {
                    snapshot[j + 1] = snapshot[j];
                    j--;
                }

                snapshot[j + 1] = current;
            }

            return snapshot;
        }

        // Search algorithm: Binary Search.
        // Requires the sorted snapshot from GetLogsSortedById().
        public Log? SearchLogById(string logId)
        {
            Log[] sorted = GetLogsSortedById();

            int low = 0;
            int high = sorted.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int comparison = string.Compare(sorted[mid].LogId, logId, StringComparison.Ordinal);

                if (comparison == 0)
                {
                    return sorted[mid];
                }
                else if (comparison < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return null;
        }

        // Compatibility methods for the provided Program.cs / test scaffolding,
        // which use these older names instead of the spec method names above.
        public Log PeekLatestLog() => ViewLatestLog();

        public Log PopSystemLog() => RollbackLastLog();

        public int GetLogCount() => _stack.Count;
    }
}