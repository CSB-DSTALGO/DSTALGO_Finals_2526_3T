// 12521269 Joaquin Bryan G. Ross
// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; } // Mark as nullable with '?'

        // A chain link holding one item and a pointer to the next.
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class CustomSinglyLinkedList<T> where T : IComparable<T>
    {
        private Node<T>? _head; // Mark as nullable with '?'

        public Node<T>? Head // Mark as nullable to match the field
        {
            get { return _head; }
        }

        public int Count { get; set; }

        // An empty chain has no head node yet.
        public CustomSinglyLinkedList()
        {
            _head = null;
        }

        // Appends to the tail so curriculum order matches insertion order.
        // O(n), because no tail pointer is kept and the chain has to be walked.
        public void AddLast(T item)
        {
            Node<T> node = new Node<T>(item);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                Node<T> current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }

            Count++;
        }

        // O(n). Finding the node is a linear walk, the unlink itself is O(1)
        // once the predecessor is known.
        public bool Remove(T item)
        {
            if (_head == null) return false;

            // Removing the head needs no predecessor, so it is handled separately.
            if (Equals(_head.Data, item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T> previous = _head;
            while (previous.Next != null)
            {
                if (Equals(previous.Next.Data, item))
                {
                    previous.Next = previous.Next.Next;
                    Count--;
                    return true;
                }

                previous = previous.Next;
            }

            return false;
        }

        // Linear traversal. A chain has no index to report, so membership is
        // all this can answer.
        public bool Search(T item)
        {
            Node<T>? current = _head;
            while (current != null)
            {
                if (Equals(current.Data, item)) return true;
                current = current.Next;
            }

            return false;
        }

        // Insertion sort by re-linking nodes, ascending by CompareTo. Nodes are
        // moved rather than their payloads, so no data is ever copied.
        public void Sort()
        {
            if (_head == null || _head.Next == null) return;

            Node<T>? sorted = null;
            Node<T>? remaining = _head;

            while (remaining != null)
            {
                Node<T>? next = remaining.Next; // remaining gets re-linked below, so capture it first

                if (sorted == null || sorted.Data.CompareTo(remaining.Data) > 0)
                {
                    // The node belongs at the front of the sorted run.
                    remaining.Next = sorted;
                    sorted = remaining;
                }
                else
                {
                    // Walk the sorted run to find the last node that still precedes it.
                    Node<T> scan = sorted;
                    while (scan.Next != null && scan.Next.Data.CompareTo(remaining.Data) <= 0)
                    {
                        scan = scan.Next;
                    }

                    remaining.Next = scan.Next;
                    scan.Next = remaining;
                }

                remaining = next;
            }

            _head = sorted;
        }
    }
}
