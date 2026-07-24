// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
    public class Node<T> // set up node class
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

        public int Count { get; set; } // item count

        public CustomSinglyLinkedList()
        {
            _head = null;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item); // new node

            if (_head == null) // if empty list, assign new node as head node
            {
                _head = newNode;
            }
            else
            {
                Node<T> current = _head; // temporary pointer to the head node

                while (current.Next != null) // iterates until it finds the last node (points to null)
                {
                    current = current.Next;
                }
                current.Next = newNode; // changes the last node's pointer to the new node
            }
            Count++; // add item count
        }

        public bool Remove(T item)
        {
            if (_head == null)
            {
                return false;
            }

            if (_head.Data.Equals(item)) // if the data value given is the same as head node, remove head node
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T> current = _head;

            while (current.Next != null)  // looks for the node with the target value to remove
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