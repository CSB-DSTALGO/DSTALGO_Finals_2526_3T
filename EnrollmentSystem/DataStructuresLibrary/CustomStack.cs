// CustomStack.cs
using System;

namespace EnrollmentSystem.Core
{
    public class AdministrativeLogs
    {
        private readonly CustomStack<Log> _logs;

        public AdministrativeLogs()
        {
            _logs = new CustomStack<Log>();
        }

        // Pushes an action to the top index.
        public void PushSystemLog(Log log)
        {
            _logs.Push(log);
        }

        // Pops the top item off the execution stack.
        public Log RollbackLastLog()
        {
            return _logs.Pop();
        }

        // Peeks at the topmost active log record.
        public Log ViewLatestLog()
        {
            return _logs.Peek();
        }

        // Returns true if the stack is empty.
        public bool CheckLogsEmpty()
        {
            return _logs.IsEmpty();
        }
    }
}