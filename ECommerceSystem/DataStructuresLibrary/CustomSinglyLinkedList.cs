using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class CustomSinglyLinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public T Data;
            public Node? Next;

            public Node(T data)
            {
                Data = data;
            }
        }

        private Node? _head;

        public int Count { get; private set; }

        // Adds an item to the end of the linked list.
        public void AddLast(T item)
        {
            Node newNode = new Node(item);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node current = _head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            Count++;
        }

        // Allows the unit tests to call Add().
        public void Add(T item)
        {
            AddLast(item);
        }

        // Removes the first matching item from the linked list.
        public bool Remove(T item)
        {
            if (_head == null)
            {
                return false;
            }

            if (_head.Data.CompareTo(item) == 0)
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node current = _head;

            while (current.Next != null &&
                   current.Next.Data.CompareTo(item) != 0)
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                return false;
            }

            current.Next = current.Next.Next;
            Count--;

            return true;
        }

        // Finds and returns the matching item.
        public T? Find(T item)
        {
            Node? current = _head;

            while (current != null)
            {
                if (current.Data.CompareTo(item) == 0)
                {
                    return current.Data;
                }

                current = current.Next;
            }

            return default;
        }

        // Allows the unit tests to call Search().
        public bool Search(T item)
        {
            Node? current = _head;

            while (current != null)
            {
                if (current.Data.CompareTo(item) == 0)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        // Sorts the linked list in ascending order.
        public void Sort()
        {
            if (_head == null || _head.Next == null)
            {
                return;
            }

            List<T> list = new List<T>();

            foreach (T item in this)
            {
                list.Add(item);
            }

            list.Sort();

            _head = null;
            Count = 0;

            foreach (T item in list)
            {
                AddLast(item);
            }
        }

        // Returns the item at the specified index.
        public T GetProductDetails(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node current = _head!;

            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }

            return current.Data;
        }

        // Allows the unit tests to call Get().
        public T Get(int index)
        {
            return GetProductDetails(index);
        }

        // Displays all items in the linked list.
        public void ShowAllProfiles()
        {
            Node? current = _head;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        // Returns the generic enumerator.
        public IEnumerator<T> GetEnumerator()
        {
            Node? current = _head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // Returns the non-generic enumerator.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}