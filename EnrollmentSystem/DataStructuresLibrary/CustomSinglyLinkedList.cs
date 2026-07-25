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
            get { throw new NotImplementedException(); }
        }

        public int Count { get; set; }

        public CustomSinglyLinkedList()
        {
            _head = null; 
        }

        public void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}