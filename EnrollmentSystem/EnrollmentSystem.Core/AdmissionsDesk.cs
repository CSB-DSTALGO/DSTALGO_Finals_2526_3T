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
            _queue.Enqueue(ticket);
        }

        public Ticket ServeNextStudent()
        {
            return _queue.Dequeue();
        }

       
        public Ticket ServeNextTicket()
        {
            return ServeNextStudent();
        }

        public Ticket ViewNextTicket()
        {
            return _queue.Peek();
        }

        public bool CheckQueueEmpty()
        {
            return _queue.IsEmpty();
        }

        
        public int GetQueueCount()
        {
            return _queue.Count;
        }
    }
}