// CustomSinglyLinkedList.cs
using System.Collections.Generic;

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
    }
}