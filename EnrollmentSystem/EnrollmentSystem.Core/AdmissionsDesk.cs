using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    /// <summary>
    /// Manages the admissions desk queue for student ticketing.
    /// Implements queue operations for student admission processing.
    /// </summary>
    public class AdmissionsDesk
    {
        private readonly CustomQueue<Ticket> _queue;

        /// <summary>
        /// Initializes a new instance of the AdmissionsDesk class.
        /// </summary>
        public AdmissionsDesk()
        {
            _queue = new CustomQueue<Ticket>();
        }

        /// <summary>
        /// Issues a new admissions ticket and adds it to the queue.
        /// </summary>
        /// <param name="ticket">The ticket to issue</param>
        public void IssueAdmissionsTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null.");

            _queue.Enqueue(ticket);
        }

        /// <summary>
        /// Serves the next student by dequeuing the front ticket.
        /// </summary>
        /// <returns>The next ticket in the queue</returns>
        public Ticket ServeNextStudent()
        {
            if (_queue.IsEmpty())
                throw new InvalidOperationException("No students in queue to serve.");

            return _queue.Dequeue();
        }

        /// <summary>
        /// Serves the next ticket (alias for ServeNextStudent for compatibility).
        /// </summary>
        public Ticket ServeNextTicket()
        {
            return ServeNextStudent();
        }

        /// <summary>
        /// Views the next ticket in the queue without removing it.
        /// </summary>
        public Ticket ViewNextTicket()
        {
            if (_queue.IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return _queue.Peek();
        }

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        public bool CheckQueueEmpty()
        {
            return _queue.IsEmpty();
        }

        /// <summary>
        /// Gets the current number of tickets in the queue.
        /// </summary>
        public int GetQueueCount()
        {
            return _queue.Count;
        }

        /// <summary>
        /// Sorts tickets by TicketId using Insertion Sort algorithm.
        /// Time Complexity: O(n²) average, O(n) best case
        /// Space Complexity: O(n)
        /// </summary>
        public Ticket[] GetTicketsSortedById()
        {
            Ticket[] tickets = _queue.ToArray();

            // Insertion Sort implementation
            for (int i = 1; i < tickets.Length; i++)
            {
                Ticket key = tickets[i];
                int j = i - 1;

                while (j >= 0 && string.Compare(tickets[j].TicketId, key.TicketId) > 0)
                {
                    tickets[j + 1] = tickets[j];
                    j--;
                }
                tickets[j + 1] = key;
            }

            return tickets;
        }

        /// <summary>
        /// Finds a ticket by its ID using Binary Search.
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        /// </summary>
        public Ticket? FindTicketById(string ticketId)
        {
            Ticket[] sorted = GetTicketsSortedById();

            int low = 0;
            int high = sorted.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int comparison = string.Compare(sorted[mid].TicketId, ticketId);

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