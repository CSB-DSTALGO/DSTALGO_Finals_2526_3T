using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    /// <summary>
    /// Represents a node in the singly linked list.
    /// Each node contains data and a reference to the next node.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the node.</typeparam>
    public class CustomSinglyLinkedListNode<T>
    {
        public T Data { get; set; }
        public CustomSinglyLinkedListNode<T>? Next { get; set; }

        public CustomSinglyLinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    /// <summary>
    /// A custom implementation of a singly linked list.
    /// Like a chain where each link points to the next one.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class CustomSinglyLinkedList<T> : IEnumerable<T>
    {
        private CustomSinglyLinkedListNode<T>? _head; // First node in the chain
        private int _count; // Number of nodes in the list

        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        public bool IsEmpty => _count == 0;

        /// <summary>
        /// Adds a new item to the END of the list.
        /// Like adding a new link to the end of a chain.
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="data">The data to add.</param>
        public void Add(T data)
        {
            var newNode = new CustomSinglyLinkedListNode<T>(data);

            // If list is empty, this becomes the head
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                // Walk to the end of the chain
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                // Attach new node at the end
                current.Next = newNode;
            }
            _count++;
        }

        /// <summary>
        /// Inserts a new node at a specific position (0 = beginning).
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="index">The position to insert at.</param>
        /// <param name="data">The data to insert.</param>
        public void InsertAt(int index, T data)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be between 0 and {_count}.");

            var newNode = new CustomSinglyLinkedListNode<T>(data);

            // Insert at the beginning
            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {
                // Find the node just before the insertion point
                var current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }
                // Insert after current
                newNode.Next = current!.Next;
                current.Next = newNode;
            }
            _count++;
        }

        /// <summary>
        /// Removes the first occurrence of a specific item.
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="data">The item to remove.</param>
        /// <returns>True if found and removed; otherwise, false.</returns>
        public bool Remove(T data)
        {
            if (_head == null) return false;

            // If the item is at the head
            if (_head.Data!.Equals(data))
            {
                _head = _head.Next;
                _count--;
                return true;
            }

            // Search for the item
            var current = _head;
            while (current.Next != null)
            {
                if (current.Next.Data!.Equals(data))
                {
                    // Found it! Skip over it
                    current.Next = current.Next.Next;
                    _count--;
                    return true;
                }
                current = current.Next;
            }
            return false; // Not found
        }

        /// <summary>
        /// Removes the node at the specified index.
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="index">The zero-based index to remove.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be between 0 and {_count - 1}.");

            if (index == 0)
            {
                _head = _head!.Next;
            }
            else
            {
                var current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }
                current!.Next = current.Next!.Next;
            }
            _count--;
        }

        /// <summary>
        /// Gets the item at a specific index without removing it.
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="index">The zero-based index.</param>
        /// <returns>The item at that index.</returns>
        public T GetAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be between 0 and {_count - 1}.");

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }
            return current!.Data;
        }

        /// <summary>
        /// Finds the index of a specific item.
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="data">The item to find.</param>
        /// <returns>The zero-based index if found; otherwise, -1.</returns>
        public int IndexOf(T data)
        {
            var current = _head;
            int index = 0;
            while (current != null)
            {
                if (current.Data!.Equals(data))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Removes ALL items from the list.
        /// Time Complexity: O(1)
        /// </summary>
        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        /// <summary>
        /// Allows using foreach to iterate through the list.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}