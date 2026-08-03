// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
    public class Node<T> // node class for singly linked list
    {
        public T Data { get; set; } // get data stored in the node
        public Node<T>? Next { get; set; } // get next node in  the list

        public Node(T data) // constructor to create a new node with given or current data
        {
            Data = data; // set or save new data
            Next = null; // set next node to null
        }
    }

    public class CustomSinglyLinkedList<T> 
    {
        private Node<T>? _head; // first node in the list

        public Node<T>? Head // get the first node in the list
        {
            get { return _head; } // return the first node in the list
        }

        public int Count { get; private set; } // number of nodes in the list

        public CustomSinglyLinkedList() // constructor to create a new empty list
        {
            _head = null;
            Count = 0;
        }

        public void AddLast(T item) // add a new node with given data to the end of the list
        {
            Node<T> newNode = new Node<T>(item); // create a new node with given data

            if (_head == null) // if the list is empty, set the new node as the head
            {
                _head = newNode; // set the new node as the head
            }
            else
            {
                Node<T> current = _head; // start from the head and traverse to the end of the list

                while (current.Next != null) // while the next node is not null, move to the next node
                {
                    current = current.Next; // move to the next node
                }

                current.Next = newNode; // set the next node of the last node to the new node
            }

            Count++;
        }

        public bool Remove(T item)
        {
            if (_head == null) // if the list is empty, return false
                return false;

            // Remove head node
            if (_head.Data!.Equals(item))
            {
                _head = _head.Next; // set the head to the next node
                Count--;
                return true;
            }

            Node<T> current = _head;

            while (current.Next != null)
            {
                if (current.Next.Data!.Equals(item)) // if the next node's data matches the item to be removed
                {
                    current.Next = current.Next.Next; // bypass the next node, effectively removing it from the list
                    Count--;
                    return true;
                }

                current = current.Next; // move to the next node
            }

            return false; // item not found in the list
        }
    }
}