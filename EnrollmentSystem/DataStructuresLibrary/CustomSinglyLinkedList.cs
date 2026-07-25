
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

        // Returns the first node in the list.
        public Node<T>? Head
        {
            get { return _head; }
        }

        // Returns the total number of nodes.
        public int Count { get; private set; }

        public CustomSinglyLinkedList()
        {
            _head = null;
            Count = 0;
        }

        // Adds a new node to the end of the linked list.
        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (_head == null)
            {
                _head = newNode;
                Count++;
                return;
            }

            Node<T> current = _head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            Count++;
        }

        // Removes the first node that matches the given item.
        public bool Remove(T item)
        {
            if (_head == null)
            {
                return false;
            }

            if (_head.Data!.Equals(item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T> current = _head;

            while (current.Next != null)
            {
                if (current.Next.Data!.Equals(item))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
    }
}