// CustomSinglyLinkedList.cs
using System.Collections.Generic;
using System;
namespace DataStructuresLibrary
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class CustomSinglyLinkedList<T>
    {
        private Node<T>? _head;

        public Node<T>? Head
        {
            get { return _head; }
        }

        public int Count { get; private set; }

        public CustomSinglyLinkedList()
        {
            _head = null;
            Count = 0;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            // If the list is empty, the new node becomes the head.
            if (_head == null)
            {
                _head = newNode;
                Count++;
                return;
            }

            // Start at the head.
            Node<T> current = _head;

            // Move until the last node is reached.
            while (current.Next != null)
            {
                current = current.Next;
            }

            // Attach the new node to the end.
            current.Next = newNode;
            Count++;
        }

        public bool Remove(T item)
        {
            if (_head == null)
            {
                return false;
            }

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            // Check whether the head contains the target item.
            if (comparer.Equals(_head.Data, item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T> current = _head;

            // Search for the node before the target node.
            while (current.Next != null)
            {
                if (comparer.Equals(current.Next.Data, item))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }

                current = current.Next;
            }

            // The item was not found.
            return false;
        }
        public bool Search(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            Node<T>? current = _head;

            while (current != null)
            {
                if (comparer.Equals(current.Data, item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Sort(Comparison<T> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            // An empty or one-item list is already sorted.
            if (_head == null || _head.Next == null)
            {
                return;
            }

            Node<T>? sortedHead = null;
            Node<T>? current = _head;

            while (current != null)
            {
                // Save the next node before changing links.
                Node<T>? nextNode = current.Next;

                // Insert at the start of the sorted chain.
                if (sortedHead == null ||
                    comparison(current.Data, sortedHead.Data) < 0)
                {
                    current.Next = sortedHead;
                    sortedHead = current;
                }
                else
                {
                    Node<T> sortedCurrent = sortedHead;

                    // Find the correct position for the current node.
                    while (sortedCurrent.Next != null &&
                           comparison(
                               sortedCurrent.Next.Data,
                               current.Data) <= 0)
                    {
                        sortedCurrent = sortedCurrent.Next;
                    }

                    current.Next = sortedCurrent.Next;
                    sortedCurrent.Next = current;
                }

                current = nextNode;
            }

            _head = sortedHead;
        }
    }
}