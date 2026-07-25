// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
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

    public class CustomSinglyLinkedList<T>
    {
        private Node<T>? _head; // Mark as nullable with '?'

        public Node<T>? Head // Mark as nullable to match the field
        {
            get { return _head; }
            set { _head = value; }
        }

        public int Count { get; set; }

        public CustomSinglyLinkedList()
        {
            _head = null;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (_head == null)
            {
                _head = newNode;
                
            }
            else
            {
                Node<T>? next = _head;
                while (next.Next != null)
                {
                    next = next.Next;
                }
                next.Next = newNode;
            }
            Count++;

        }

        public bool Remove(T item)
        {
            Node<T> current = _head;
            if (_head == null)
            {
                return false;
            }
            if (_head != null && _head.Data.Equals(item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(item))
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

