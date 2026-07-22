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
            //get { throw new NotImplementedException(); }
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
                return;
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
            //throw new NotImplementedException();
        }

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
            //throw new NotImplementedException();
        }
    }
}