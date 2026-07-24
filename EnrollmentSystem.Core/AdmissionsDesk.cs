// AdmissionsDesk.cs
using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class AdmissionsDesk
    {
        private readonly CustomQueue<Ticket> _queue;

        public AdmissionsDesk()
        {
            _queue = new CustomQueue<Ticket>();
        }

        public void IssueAdmissionsTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket ServeNextStudent()
        {
            throw new NotImplementedException();
        }

        public Ticket ViewNextTicket()
        {
            throw new NotImplementedException();
        }

        public bool CheckQueueEmpty()
        {
            throw new NotImplementedException();
        }
    }
}