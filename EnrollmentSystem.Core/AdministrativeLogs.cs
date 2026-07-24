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
            throw new NotImplementedException();
        }

        public Log RollbackLastLog()
        {
            throw new NotImplementedException();
        }

        public Log ViewLatestLog()
        {
            throw new NotImplementedException();
        }

        public bool CheckLogsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}