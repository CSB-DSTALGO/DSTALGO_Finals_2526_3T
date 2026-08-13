// AdministrativeLogs.cs
// Member 4's module: wraps a CustomStack<Log> and exposes the business-level
// operations needed by the Enrollment Management System.
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

        /// <summary>
        /// Pushes a new log entry onto the top of the execution stack. O(1) amortized.
        /// </summary>
        public void PushSystemLog(Log log)
        {
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            _stack.Push(log);
        }

        /// <summary>
        /// Pops and returns the most recently pushed log entry. O(1).
        /// </summary>
        public Log RollbackLastLog()
        {
            return _stack.Pop();
        }

        /// <summary>
        /// Returns the most recently pushed log entry without removing it. O(1).
        /// </summary>
        public Log ViewLatestLog()
        {
            return _stack.Peek();
        }

        /// <summary>
        /// True if there are no log entries currently on the stack. O(1).
        /// </summary>
        public bool CheckLogsEmpty()
        {
            return _stack.IsEmpty();
        }

        // ------------------------------------------------------------------
        // Convenience/compatibility helpers used by the provided ConsoleApp
        // and the provided EnrollmentSystem.Tests scaffold.
        // ------------------------------------------------------------------

        /// <summary>Number of log entries currently on the stack. O(1).</summary>
        public int GetLogCount()
        {
            return _stack.Count;
        }

        /// <summary>Alias of RollbackLastLog for the console/test scaffold. O(1).</summary>
        public Log PopSystemLog()
        {
            return _stack.Pop();
        }

        /// <summary>Alias of ViewLatestLog for the console/test scaffold. O(1).</summary>
        public Log PeekLatestLog()
        {
            return _stack.Peek();
        }

        // ------------------------------------------------------------------
        // Sorting and Search Algorithm Integration
        //
        // Algorithm chosen: Insertion Sort + Linear Search.
        //
        // Mechanism: Like a queue, a stack only exposes its top, so it cannot
        // be sorted in place without violating LIFO semantics. SortLogsById
        // copies every log entry out into a plain array (via CustomStack.
        // ToArray, which does not mutate the stack), sorts that array with
        // Insertion Sort, then clears the stack and pushes the log entries
        // back on in the new order. Insertion Sort works by growing a sorted
        // section at the front of the array one element at a time: it takes
        // the next unsorted element and shifts it backwards past any larger
        // elements until it reaches its correct position.
        //
        // SearchLogById performs a Linear Search over a snapshot of the stack
        // (again via ToArray) so that looking up a log does not require
        // popping every entry above it.
        //
        // Efficiency / time complexity:
        //  - Insertion Sort: O(n^2) average/worst case, O(n) best case (data
        //    already sorted), because each new element may need to shift past
        //    many already-sorted elements. O(1) extra space beyond the
        //    snapshot array. Insertion Sort is a reasonable choice here since
        //    logs are naturally close to time-ordered already.
        //  - Linear Search: O(n) worst case, since log entries are ordered by
        //    recency (LIFO), not by LogId, so every entry may need checking.
        // ------------------------------------------------------------------

        /// <summary>
        /// Reorders the log entries by LogId (ascending) using Insertion Sort.
        /// The stack's top-to-bottom position of each entry is rebuilt to
        /// reflect the new sorted order (smallest LogId ends up at the
        /// bottom, largest on top). O(n^2) worst case, O(n) best case.
        /// </summary>
        public void SortLogsById()
        {
            Log[] logs = _stack.ToArray(); // index 0 = bottom ... last index = top

            for (int i = 1; i < logs.Length; i++)
            {
                Log key = logs[i];
                int j = i - 1;

                while (j >= 0 && string.Compare(logs[j].LogId, key.LogId, StringComparison.Ordinal) > 0)
                {
                    logs[j + 1] = logs[j];
                    j--;
                }

                logs[j + 1] = key;
            }

            _stack.Clear();
            foreach (Log l in logs)
            {
                _stack.Push(l);
            }
        }

        /// <summary>
        /// Finds a log entry by LogId using a Linear Search over a snapshot of
        /// the stack, without popping anything. Returns null if no matching
        /// entry is currently on the stack. O(n).
        /// </summary>
        public Log? SearchLogById(string logId)
        {
            Log[] logs = _stack.ToArray();

            foreach (Log l in logs)
            {
                if (l.LogId == logId)
                {
                    return l;
                }
            }

            return null;
        }
    }
}
