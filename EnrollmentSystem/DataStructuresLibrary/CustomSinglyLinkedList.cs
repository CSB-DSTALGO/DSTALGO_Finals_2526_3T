// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
    public class Node<T> // declares a generic class
    {
        public T Data { get; set; } // stores the actual value the node holds
        public Node<T>? Next { get; set; } // points to the next node in the chain

        public Node(T data)
        {
            Data = data; // save whatever value that was passed
            Next = null; // no next node
        }
    }

    public class CustomSinglyLinkedList<T> // a list made of nodes one after another
    {
        private Node<T>? _head; // first node in the list

        public Node<T>? Head // marks it nullable to match
        {
            get { return _head; } // exposes the _head to the outside
        }

        public int Count { get; set; } // how many items are currently in the list

        public CustomSinglyLinkedList()
        {
            _head = null;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item); // make a new node

            if (_head == null) // list is empty
            {
                _head = newNode; // new node is now the whole list
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
        } // add last close

        public bool Remove(T item)
        {
            if (_head == null)
            {
                return false;
            }

            if (_head.Data.Equals(item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T> previous = _head;
            Node<T> current = _head.Next;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    previous.Next = current.Next;
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }
    }
}