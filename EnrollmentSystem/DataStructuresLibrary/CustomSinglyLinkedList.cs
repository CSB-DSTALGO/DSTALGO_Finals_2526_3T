// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
    // Represents a single node in the linked list.
    public class Node<T>
    {
        // Stores the value contained in this node.
        public T Data { get; set; }

        // Points to the next node in the linked list.
        public Node<T>? Next { get; set; }

        // Creates a new node with the specified data.
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // Custom implementation of a singly linked list.
    public class CustomSinglyLinkedList<T>
    {
        // Reference to the first node in the linked list.
        private Node<T>? _head;

        // Returns the first node of the linked list.
        public Node<T>? Head
        {
            get { return _head; }
        }

        // Returns the current number of nodes in the linked list.
        public int Count { get; private set; }

        // Initializes an empty linked list.
        public CustomSinglyLinkedList()
        {
            _head = null;
            Count = 0;
        }

        // Adds a new node to the end of the linked list.
        // Time Complexity: O(n)
        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            // If the list is empty, the new node becomes the head.
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                // Traverse to the last node.
                Node<T> current = _head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                // Link the new node to the end of the list.
                current.Next = newNode;
            }

            // Update the number of nodes.
            Count++;
        }

        // Removes the first occurrence of the specified item.
        // Returns true if the item is found and removed.
        // Time Complexity: O(n)
        public bool Remove(T item)
        {
            // Return false if the list is empty.
            if (_head == null)
                return false;

            // Check if the head node contains the target item.
            if (Equals(_head.Data, item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            // Traverse the list to locate the target item.
            Node<T> current = _head;

            while (current.Next != null)
            {
                if (Equals(current.Next.Data, item))
                {
                    // Skip over the matching node to remove it.
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }

                current = current.Next;
            }

            // Return false if the item is not found.
            return false;
        }
    }
}