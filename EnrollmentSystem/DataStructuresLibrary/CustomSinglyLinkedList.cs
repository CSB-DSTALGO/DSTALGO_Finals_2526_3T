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
        }

        public CustomSinglyLinkedList()
        {
            _head = null; 
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            //if list empty, new node becomes head
            if (_head == null)
            {
                _head = newNode;
                return;
            }

            //traverse to last node
            Node<T> current = _head;
            while(current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        public bool Remove(T item)
        {
            if (_head == null)
            {
                return false;
            }

            //If the head holds the value to remove
            if (EqualityComparer<T>.Default.Equals(_head.Data, item))
            {
                _head = _head.Next;
                return true;
            }

            //searching rest of the list for item
            Node<T> current = _head;
            while (current.Next != null)
            {
                if(EqualityComparer<T>.Default.Equals(current.Next.Data, item))
                {
                    //bypassing target node to unlink it
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false; //item not found
        }
    }
}