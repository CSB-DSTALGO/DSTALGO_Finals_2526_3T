
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


        public void PushSystemLog(Log log)
        {
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log), "Cannot push a null log.");
            }

            _stack.Push(log);
        }

        // Pops the top item off the execution stack.
        public Log RollbackLastLog()
        {
            return _stack.Pop();
        }

        // Peeks at the topmost active log record.
        public Log ViewLatestLog()
        {
            return _stack.Peek();
        }

        // Evaluates and returns boolean state.
        public bool CheckLogsEmpty()
        {
            return _stack.IsEmpty();
        }


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



        public Log PeekLatestLog() => ViewLatestLog();

        public Log PopSystemLog() => RollbackLastLog();

        public int GetLogCount() => _stack.Count;
    }
}
