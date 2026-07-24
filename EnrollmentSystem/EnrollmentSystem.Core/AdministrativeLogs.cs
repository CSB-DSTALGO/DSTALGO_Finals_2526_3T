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

        public void PushSystemLog(Log log)
        {
            _stack.Push(log);
        }

        public Log RollbackLastLog()
        {
            return _stack.Pop();
        }

        public Log ViewLatestLog()
        {
            return _stack.Peek();
        }

        public bool CheckLogsEmpty()
        {
            return _stack.IsEmpty();
        }

        // METHODS REQUIRED BY EnrollmentCoreTest.cs
        public Log PopSystemLog()
        {
            return RollbackLastLog();
        }

        public Log PeekLatestLog()
        {
            return ViewLatestLog();
        }

        public int GetLogCount()
        {
            return _stack.Count;
        }
    }
}