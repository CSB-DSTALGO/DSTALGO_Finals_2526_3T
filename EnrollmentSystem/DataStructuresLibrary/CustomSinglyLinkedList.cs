// CustomSinglyLinkedList.cs
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

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node<T> current = _head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            Count++;
        }

        public bool Remove(T item)
        {
            if (_head == null)
                return false;

            if (Equals(_head.Data, item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T> current = _head;

            while (current.Next != null)
            {
                if (Equals(current.Next.Data, item))
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