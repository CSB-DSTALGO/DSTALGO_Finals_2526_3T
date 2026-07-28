// AdministrativeLogs.cs
using System;
using DataStructuresLibrary;
namespace EnrollmentSystem.Core
{
    public class AdministrativeLogs
    {
        private readonly CustomStack<Log> _stack;

        public AdministrativeLogs()
        {
            _stack = new CustomStack<Log>();
        }

        // Pushes a new log entry onto the top of the stack.
        public void PushSystemLog(Log log)
        {
            _stack.Push(log);
        }

        // Removes and returns the most recent log (top of stack).
        public Log RollbackLastLog()
        {
            return _stack.Pop();
        }

        // Returns the most recent log without removing it.
        public Log ViewLatestLog()
        {
            return _stack.Peek();
        }

        // Returns true if there are no logs currently recorded.
        public bool CheckLogsEmpty()
        {
            return _stack.IsEmpty();
        }

        // SORTING ALGORITHM: Insertion Sort.
        // Returns a sorted copy of all logs ordered alphabetically by LogId,
        // without modifying the actual stack order.
        // Why Insertion Sort: consistent with the approach used in AdmissionsDesk,
        // and efficient for the typically small, near-ordered log sets expected here.
        // Time Complexity: O(n^2) worst case, O(n) best case. Space: O(n) for the copy.

        // Alias for ViewLatestLog — matches naming used in Program.cs and tests.
        public Log PeekLatestLog()
        {
            return ViewLatestLog();
        }

        // Alias for RollbackLastLog — matches naming used in Program.cs and tests.
        public Log PopSystemLog()
        {
            return RollbackLastLog();
        }

        // Returns the current number of logs recorded in the stack.
        public int GetLogCount()
        {
            return _stack.Count;
        }
        public Log[] GetLogsSortedById()
        {
            Log[] logs = _stack.ToArray();

            for (int i = 1; i < logs.Length; i++)
            {
                Log key = logs[i];
                int j = i - 1;

                while (j >= 0 && string.Compare(logs[j].LogId, key.LogId) > 0)
                {
                    logs[j + 1] = logs[j];
                    j--;
                }
                logs[j + 1] = key;
            }

            return logs;
        }

        // SEARCH ALGORITHM: Binary Search.
        // Searches for a log by LogId within the sorted snapshot.
        // Precondition: input must be sorted (see GetLogsSortedById).
        // Time Complexity: O(log n).
        public Log? FindLogById(string logId)
        {
            Log[] sorted = GetLogsSortedById();

            int low = 0;
            int high = sorted.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int comparison = string.Compare(sorted[mid].LogId, logId);

                if (comparison == 0)
                    return sorted[mid];
                else if (comparison < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return null;
        }
    }
}
