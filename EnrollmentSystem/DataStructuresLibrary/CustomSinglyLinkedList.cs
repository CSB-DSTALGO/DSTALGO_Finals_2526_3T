// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
    /// <summary>
    /// A single node in the chain. Holds a data payload and a reference to the next node.
    /// </summary>
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    /// <summary>
    /// Custom singly linked list implementation developed without using System.Collections.Generic.
    /// Supports append/remove, traversal, Merge Sort, and Linear Search.
    /// </summary>
    /// <typeparam name="T">The data type of elements stored in the chain.</typeparam>
    public class CustomSinglyLinkedList<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail; // tracked so AddLast is O(1) instead of walking the whole chain

        /// <summary>
        /// Gets the first node in the chain, or null if the list is empty.
        /// </summary>
        public Node<T>? Head
        {
            get { return _head; }
        }

        /// <summary>
        /// Number of nodes currently in the chain.
        /// </summary>
        public int Count { get; private set; }

        public CustomSinglyLinkedList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        /// Appends a new node holding the given item to the end of the chain.
        /// </summary>
        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail!.Next = newNode;
                _tail = newNode;
            }

            Count++;
        }

        /// <summary>
        /// Removes the first node whose Data equals the given item (using default equality).
        /// </summary>
        /// <returns>True if a matching node was found and removed, false otherwise.</returns>
        public bool Remove(T item)
        {
            return RemoveWhere(data => Equals(data, item));
        }

        /// <summary>
        /// Removes the first node whose Data satisfies the given predicate.
        /// More flexible than Remove(T) - lets callers match on a property (e.g. a course code)
        /// instead of full equality.
        /// </summary>
        /// <returns>True if a matching node was found and removed, false otherwise.</returns>
        public bool RemoveWhere(Func<T, bool> predicate)
        {
            Node<T>? current = _head;
            Node<T>? previous = null;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    if (previous == null)
                    {
                        _head = current.Next; // removing the head node
                    }
                    else
                    {
                        previous.Next = current.Next; // splice around the removed node
                    }

                    if (current == _tail)
                    {
                        _tail = previous; // removed node was the tail; update it
                    }

                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false; // no match found
        }

        /// <summary>
        /// Traverses the chain and returns a snapshot array (front to back).
        /// Used for display/sorting/searching without exposing internal node references.
        /// </summary>
        public T[] ToArray()
        {
            T[] snapshot = new T[Count];
            Node<T>? current = _head;
            int i = 0;

            while (current != null)
            {
                snapshot[i] = current.Data;
                i++;
                current = current.Next;
            }

            return snapshot;
        }

        /// <summary>
        /// Sorts the chain in place using Merge Sort. Merge Sort is chosen over QuickSort here
        /// because it only ever needs sequential (Next-pointer) access - no random indexing -
        /// which matches how a singly linked list is naturally traversed.
        /// </summary>
        /// <param name="comparer">Delegate comparing two items (negative, zero, or positive).</param>
        public void MergeSort(Func<T, T, int> comparer)
        {
            _head = MergeSortRecursive(_head, comparer);

            // Head pointers were relinked during the merge; walk to re-find the new tail.
            _tail = _head;
            while (_tail != null && _tail.Next != null)
            {
                _tail = _tail.Next;
            }
        }

        private Node<T>? MergeSortRecursive(Node<T>? head, Func<T, T, int> comparer)
        {
            if (head == null || head.Next == null)
            {
                return head; // base case: 0 or 1 node is already sorted
            }

            Node<T> middle = FindMiddle(head);
            Node<T>? rightHalf = middle.Next;
            middle.Next = null; // split into two independent halves

            Node<T>? left = MergeSortRecursive(head, comparer);
            Node<T>? right = MergeSortRecursive(rightHalf, comparer);

            return Merge(left, right, comparer);
        }

        // Slow/fast pointer technique to find the midpoint of a chain in one pass.
        private Node<T> FindMiddle(Node<T> head)
        {
            Node<T> slow = head;
            Node<T> fast = head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next!;
                fast = fast.Next.Next;
            }

            return slow;
        }

        // Merges two already-sorted chains into one sorted chain.
        private Node<T>? Merge(Node<T>? left, Node<T>? right, Func<T, T, int> comparer)
        {
            Node<T> dummy = new Node<T>(default!);
            Node<T> tail = dummy;

            while (left != null && right != null)
            {
                if (comparer(left.Data, right.Data) <= 0)
                {
                    tail.Next = left;
                    left = left.Next;
                }
                else
                {
                    tail.Next = right;
                    right = right.Next;
                }
                tail = tail.Next;
            }

            tail.Next = left ?? right; // attach whichever half has leftover nodes
            return dummy.Next;
        }

        /// <summary>
        /// Linear Search: walks the chain node by node looking for the first match.
        /// A singly linked list has no random access, so Binary Search isn't a good fit -
        /// Linear Search is the natural choice regardless of whether the list is sorted.
        /// </summary>
        /// <param name="predicate">Function returning true for the node that should be returned.</param>
        /// <returns>The matching node, or null if none was found.</returns>
        public Node<T>? LinearSearch(Func<T, bool> predicate)
        {
            Node<T>? current = _head;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }
    }
}