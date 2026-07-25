// AdmissionsDesk.cs
using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    // Admissions Desk module backed by CustomQueue<Ticket>.
    public class AdmissionsDesk
    {
        private readonly CustomQueue<Ticket> _queue;

        public AdmissionsDesk()
        {
            _queue = new CustomQueue<Ticket>();
        }

        // Enqueues a new ticket at the rear of the line.
        public void IssueAdmissionsTicket(Ticket ticket)
        {
            _queue.Enqueue(ticket);
        }

        // Dequeues and returns the ticket at the front of the line.
        public Ticket ServeNextStudent()
        {
            return _queue.Dequeue();
        }

        // Returns the front ticket without removing it.
        public Ticket ViewNextTicket()
        {
            return _queue.Peek();
        }

        // Returns true if there are no tickets waiting.
        public bool CheckQueueEmpty()
        {
            return _queue.IsEmpty();
        }

        // Sorting algorithm: Selection Sort.
        // Sorts a snapshot copy of the waiting tickets by TicketId. This does NOT reorder the
        // real queue - admissions must still be served strictly FIFO - it's only for
        // reporting/lookup purposes.
        public Ticket[] GetTicketsSortedById()
        {
            Ticket[] snapshot = _queue.ToArray();

            for (int i = 0; i < snapshot.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < snapshot.Length; j++)
                {
                    if (string.Compare(snapshot[j].TicketId, snapshot[minIndex].TicketId, StringComparison.Ordinal) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    (snapshot[i], snapshot[minIndex]) = (snapshot[minIndex], snapshot[i]);
                }
            }

            return snapshot;
        }

        // Search algorithm: Binary Search.
        // Runs against the sorted snapshot from GetTicketsSortedById(), so the real
        // (unsorted, FIFO) queue is never disturbed.
        public Ticket? SearchTicketById(string ticketId)
        {
            Ticket[] sorted = GetTicketsSortedById();

            int low = 0;
            int high = sorted.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int comparison = string.Compare(sorted[mid].TicketId, ticketId, StringComparison.Ordinal);

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
    }
}