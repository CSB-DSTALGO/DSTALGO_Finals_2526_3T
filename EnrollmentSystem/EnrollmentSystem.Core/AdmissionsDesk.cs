// AdmissionsDesk.cs
// Member 3's module: wraps a CustomQueue<Ticket> and exposes the
// business-level operations needed by the Enrollment Management System.
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

        /// <summary>
        /// Enqueues a new admissions ticket at the rear of the line. O(1) amortized.
        /// </summary>
        public void IssueAdmissionsTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            _queue.Enqueue(ticket);
        }

        /// <summary>
        /// Dequeues and returns the ticket at the front of the line. O(1).
        /// </summary>
        public Ticket ServeNextStudent()
        {
            return _queue.Dequeue();
        }

        /// <summary>
        /// Returns the ticket at the front of the line without removing it. O(1).
        /// </summary>
        public Ticket ViewNextTicket()
        {
            return _queue.Peek();
        }

        /// <summary>
        /// True if there are no tickets currently waiting. O(1).
        /// </summary>
        public bool CheckQueueEmpty()
        {
            return _queue.IsEmpty();
        }

        // ------------------------------------------------------------------
        // Convenience/compatibility helpers used by the provided ConsoleApp
        // and the provided EnrollmentSystem.Tests scaffold.
        // ------------------------------------------------------------------

        /// <summary>Number of tickets currently waiting in line. O(1).</summary>
        public int GetQueueCount()
        {
            return _queue.Count;
        }

        /// <summary>Alias of ServeNextStudent for the console/test scaffold. O(1).</summary>
        public Ticket ServeNextTicket()
        {
            return _queue.Dequeue();
        }

        // ------------------------------------------------------------------
        // Sorting and Search Algorithm Integration
        //
        // Algorithm chosen: Selection Sort + Linear Search.
        //
        // Mechanism: A queue only allows access at its two ends (front and
        // rear), so it cannot be sorted "in place" the way an array or linked
        // list can without breaking the FIFO contract. SortQueueByStudentId
        // therefore copies every ticket out into a plain array (via
        // CustomQueue.ToArray, which does not mutate the queue), sorts that
        // array with Selection Sort, then clears the queue and re-enqueues the
        // tickets in the new order. Selection Sort works by repeatedly
        // scanning the remaining unsorted portion of the array to find its
        // smallest element and swapping it into place at the front of that
        // unsorted portion.
        //
        // SearchTicketByStudentId performs a Linear Search over a snapshot of
        // the queue (again via ToArray) so that looking up a ticket does not
        // require dequeuing every ticket ahead of it.
        //
        // Efficiency / time complexity:
        //  - Selection Sort: O(n^2) in all cases (best, average, worst) since
        //    it always scans the remaining unsorted elements looking for the
        //    minimum, regardless of the input's initial order. O(1) extra
        //    space beyond the snapshot array.
        //  - Linear Search: O(n) worst case, since tickets are only ordered by
        //    arrival time (FIFO), not by StudentId, so every ticket may need
        //    to be checked.
        // ------------------------------------------------------------------

        /// <summary>
        /// Reorders the waiting tickets by StudentId (ascending) using
        /// Selection Sort. The queue's FIFO position of each ticket is
        /// rebuilt to reflect the new sorted order. O(n^2).
        /// </summary>
        public void SortQueueByStudentId()
        {
            Ticket[] tickets = _queue.ToArray();
            int n = tickets.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (string.Compare(tickets[j].StudentId, tickets[minIndex].StudentId, StringComparison.Ordinal) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    (tickets[i], tickets[minIndex]) = (tickets[minIndex], tickets[i]);
                }
            }

            _queue.Clear();
            foreach (Ticket t in tickets)
            {
                _queue.Enqueue(t);
            }
        }

        /// <summary>
        /// Finds a waiting ticket by StudentId using a Linear Search over a
        /// snapshot of the queue, without dequeuing anything. Returns null if
        /// no matching ticket is currently waiting. O(n).
        /// </summary>
        public Ticket? SearchTicketByStudentId(string studentId)
        {
            Ticket[] tickets = _queue.ToArray();

            foreach (Ticket t in tickets)
            {
                if (t.StudentId == studentId)
                {
                    return t;
                }
            }

            return null;
        }
    }
}
