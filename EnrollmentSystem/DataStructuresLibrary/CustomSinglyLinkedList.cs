// CustomSinglyLinkedList.cs
// GUYS TINATAMAD PA AKU MAG CUMENT SURI

using System;

namespace DataStructuresLibrary
{
    // This represents a single node in the linked list. Each node stores data and a reference to the next node.
    public class Node<T>
    {
        // Stores the actual data held by this node.
        public T Data { get; set; }

        // Stores the reference to the next node in the chain and null indicates this is the last node.
        public Node<T>? Next { get; set; }

        // Initializes a new node with the given data. Next is set to null by default since the node is not yet linked.
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // generic singly linked list that supports insertion, deletion, searching, traversal, and sorting.
    public class CustomSinglyLinkedList<T>
    {
        // The first node in the list. Null if the list is empty.
        private Node<T>? _head;

        // Provides read-only access to the head node.
        public Node<T>? Head
        {
            get { return _head; }
        }

        // Tracks the number of nodes currently in the list.
        public int Count { get; private set; }

        // Initializes an empty linked list.
        public CustomSinglyLinkedList()
        {
            _head = null;
            Count = 0;
        }

        // Appends a new node containing the specified item to the end of the list. If the list is empty, the new node becomes the head.
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

        // Removes the first node that matches the specified item. Uses linear search to locate the target node.
        // Returns true if removal was successful, false otherwise.
        public bool Remove(T item)
        {
            if (_head == null)
                return false;

            if (_head.Data != null && _head.Data.Equals(item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T>? current = _head;
            while (current.Next != null)
            {
                if (current.Next.Data != null && current.Next.Data.Equals(item))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // Removes the first node that satisfies the given predicate condition. More flexible than Remove(T item) as it supports custom matching logic.
        public bool RemoveByPredicate(Func<T, bool> predicate)
        {
            if (_head == null)
                return false;

            if (predicate(_head.Data))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T>? current = _head;
            while (current.Next != null)
            {
                if (predicate(current.Next.Data))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // Searches for the first node that satisfies the given predicate. Returns the matching data if found; otherwise returns the default value.
        public T? Find(Func<T, bool> predicate)
        {
            Node<T>? current = _head;
            while (current != null)
            {
                if (predicate(current.Data))
                    return current.Data;
                current = current.Next;
            }
            return default;
        }

        // Iterates through every node in the list and applies the specified action.
        public void Traverse(Action<T> action)
        {
            Node<T>? current = _head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }

        // Sorts the linked list using the Bubble Sort algorithm.  Only the data values are swapped; node links remain unchanged.
        // The comparer function should return a negative value if a < b,
        // zero if a == b, and a positive value if a > b.
        public void Sort(Func<T, T, int> comparer)
        {
            if (_head == null || _head.Next == null)
                return;

            bool swapped;
            do
            {
                swapped = false;
                Node<T>? current = _head;
                while (current != null && current.Next != null)
                {
                    if (comparer(current.Data, current.Next.Data) > 0)
                    {
                        T temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }
    }
}
