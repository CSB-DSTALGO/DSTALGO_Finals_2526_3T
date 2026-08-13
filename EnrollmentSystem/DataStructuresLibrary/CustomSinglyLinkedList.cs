// CustomSinglyLinkedList.cs
// A manually implemented singly linked list, where each node only knows about
// the node that comes after it.
using System;

namespace DataStructuresLibrary
{
    /// <summary>
    /// A single node in the chain. Holds a piece of data and a reference to the
    /// next node (or null if it is the last node).
    /// </summary>
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; } // Mark as nullable with '?'

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    /// <summary>
    /// A generic singly linked list implemented from scratch. Keeps a reference to
    /// both the head (first node) and tail (last node) so that appending to the end
    /// (AddLast) is O(1) instead of requiring a full traversal.
    /// </summary>
    public class CustomSinglyLinkedList<T>
    {
        private Node<T>? _head; // Mark as nullable with '?'
        private Node<T>? _tail;
        private int _count;

        /// <summary>
        /// The first node in the chain, or null if the list is empty. Callers use
        /// this to walk the list manually (current = current.Next) when they need
        /// read-only traversal, e.g. for printing or searching.
        /// </summary>
        public Node<T>? Head
        {
            get { return _head; }
        }

        /// <summary>
        /// Number of nodes currently in the list.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        public CustomSinglyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Appends a new node containing the given item to the end of the chain.
        /// O(1) because we keep a direct reference to the tail node.
        /// </summary>
        public void AddLast(T item)
        {
            var node = new Node<T>(item);

            if (_head == null)
            {
                // Empty list: the new node becomes both head and tail.
                _head = node;
                _tail = node;
            }
            else
            {
                // Non-empty list: link the current tail to the new node, then
                // advance the tail pointer.
                _tail!.Next = node;
                _tail = node;
            }

            _count++;
        }

        /// <summary>
        /// Removes the first node whose Data matches the given item (using
        /// Equals). O(n) because in the worst case we must walk the entire chain
        /// to find the target node.
        /// </summary>
        public bool Remove(T item)
        {
            Node<T>? current = _head;
            Node<T>? previous = null;

            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    if (previous == null)
                    {
                        // Removing the head node.
                        _head = current.Next;
                    }
                    else
                    {
                        // Bypass the target node by relinking its neighbors.
                        previous.Next = current.Next;
                    }

                    if (current == _tail)
                    {
                        // We just removed the last node, so the tail pointer must move.
                        _tail = previous;
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }
    }
}
