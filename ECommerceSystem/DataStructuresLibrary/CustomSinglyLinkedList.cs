using System;

namespace DataStructuresLibrary
{
    public class CustomSinglyLinkedList<T> where T : IComparable<T>
    {
        // Node that stores the data and points to the next node
        private class Node
        {
            public T Data;
            public Node Next;

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        // Stores the first node of the list
        private Node _head;

        // Counts how many items are inside the list
        public int Count { get; private set; }

        // Adds a new item at the end of the list
        public void Add(T item)
        {
            Node newNode = new Node(item);

            // If there is no data yet, make this the first node
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node current = _head;

                // Move until the last node
                while (current.Next != null)
                {
                    current = current.Next;
                }

                // Add the new node at the end
                current.Next = newNode;
            }

            Count++;
        }

        // Removes the first matching item from the list
        public bool Remove(T item)
        {
            if (_head == null) return false;

            // Check if the first node is the one to remove
            if (_head.Data.CompareTo(item) == 0)
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node current = _head;

            // Search for the item while keeping track of the previous node
            while (current.Next != null)
            {
                if (current.Next.Data.CompareTo(item) == 0)
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        // Checks if an item exists in the list
        public bool Search(T item)
        {
            Node current = _head;

            while (current != null)
            {
                if (current.Data.CompareTo(item) == 0)
                    return true;

                current = current.Next;
            }

            return false;
        }

        // Same function as Search but easier to understand when calling
        public bool Contains(T item)
        {
            return Search(item);
        }

        // Removes all nodes in the list
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        // Sorts the list using bubble sort
        public void Sort()
        {
            if (_head == null || _head.Next == null)
                return;

            bool swapped;

            do
            {
                swapped = false;
                Node current = _head;

                // Compare each node with the next node
                while (current.Next != null)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        // Swap the values of the nodes
                        T temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;

                        swapped = true;
                    }

                    current = current.Next;
                }

            } while (swapped);
        }


        // Gets the first item in the list
        public T PeekFirst()
        {
            if (_head == null)
                throw new InvalidOperationException("List is empty.");

            return _head.Data;
        }

        // Gets the last item in the list
        public T PeekLast()
        {
            if (_head == null) throw new InvalidOperationException("List is empty.");

            Node current = _head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Data;
        }

        // Reverses the order of the linked list
        public void Reverse()
        {
            Node previous = null;
            Node current = _head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            _head = previous;
        }

        // Used for displaying the linked list values
        public void Print()
        {
            Node current = _head;

            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }

            Console.WriteLine("null");
        }
    }
}