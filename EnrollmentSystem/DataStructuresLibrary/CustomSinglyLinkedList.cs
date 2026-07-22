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

        public int Count { get; set; }

        public CustomSinglyLinkedList()
        {
            _head = null;
        }

        // New node at the end of the list.
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

        // Remove the first node that matches the item and return false if not found.
        public bool Remove(T item)
        {
            Node<T>? previous = null;
            Node<T>? current = _head;

            while (current != null)
            {
                if (object.Equals(current.Data, item))
                {
                    if (previous == null)
                    {
                        _head = current.Next; // item was the first node
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        // Linear search to return the index of the item, or -1 if not found.
        public int LinearSearch(T item)
        {
            Node<T>? current = _head;
            int index = 0;

            while (current != null)
            {
                if (object.Equals(current.Data, item))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }

        // Bubble sort to keep passing through the list and swapping neighbours that are out of order until no more swaps are needed.
        public void Sort()
        {
            if (_head == null)
            {
                return;
            }

            bool swapped = true;

            while (swapped)
            {
                swapped = false;
                Node<T>? current = _head;

                while (current != null && current.Next != null)
                {
                    IComparable<T> left = (IComparable<T>)current.Data!;

                    if (left.CompareTo(current.Next.Data) > 0)
                    {
                        // swap the data of the two nodes
                        T temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }

                    current = current.Next;
                }
            }
        }
    }
}