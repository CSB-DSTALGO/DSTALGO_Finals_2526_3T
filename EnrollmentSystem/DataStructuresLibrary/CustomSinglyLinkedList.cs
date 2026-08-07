using System;

namespace DataStructuresLibrary
{
    // A single node in the chain. Holds one value (Data) and a pointer to the next node.
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

    // Manual singly linked list — no System.Collections.Generic used.
    // Keeps a Head (first node) and Tail (last node) pointer so adding to the end is fast.
    public class CustomSinglyLinkedList<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;
        private int _count;

        // Exposes the first node so other classes (like CourseCurriculum) can walk the list.
        public Node<T>? Head => _head;

        // Number of items currently in the list.
        public int Count => _count;

        public CustomSinglyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        // Inserts 'item' at the end of the list.
        // Uses the _tail pointer so it doesn't need to walk the whole list first (O(1)).
        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (_head == null)
            {
                // list was empty — new node becomes both head and tail
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                // attach after the current last node, then move the tail pointer
                _tail!.Next = newNode;
                _tail = newNode;
            }

            _count++;
        }

        // Finds the first node whose Data matches 'item' and unlinks it from the chain.
        // Returns true if something was removed, false if 'item' wasn't found.
        public bool Remove(T item)
        {
            if (_head == null) return false; // nothing to remove

            // special case: the item to remove is the very first node
            if (object.Equals(_head.Data, item))
            {
                _head = _head.Next;
                if (_head == null) _tail = null; // list is now empty, clear tail too
                _count--;
                return true;
            }

            // general case: walk the list one step behind (previous) and one step ahead (current)
            Node<T>? previous = _head;
            Node<T>? current = _head.Next;

            while (current != null)
            {
                if (object.Equals(current.Data, item))
                {
                    previous!.Next = current.Next; // skip over 'current', unlinking it
                    if (current == _tail) _tail = previous; // update tail if we removed the last node
                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false; // walked the whole list, item not found
        }

        // Checks whether 'item' exists anywhere in the list, by walking node by node.
        // Used by CourseCurriculum.SearchCourse instead of duplicating traversal logic there.
        public bool Contains(T item)
        {
            Node<T>? current = _head;
            while (current != null)
            {
                if (object.Equals(current.Data, item)) return true;
                current = current.Next;
            }
            return false;
        }

        // Sorts the list in ascending order in place.
        // Algorithm: bubble sort — repeatedly compares neighboring nodes and swaps their Data
        // if they're out of order, until a full pass makes no swaps.
        // Requires T to implement IComparable<T> (checked at runtime via 'as').
        public void Sort()
        {
            if (_head == null || _head.Next == null) return; // 0 or 1 items = already sorted

            bool swapped;
            do
            {
                swapped = false;
                Node<T>? current = _head;

                while (current != null && current.Next != null)
                {
                    IComparable<T>? comparable = current.Data as IComparable<T>;

                    // compare current node's value against the next node's value
                    if (comparable != null && comparable.CompareTo(current.Next.Data) > 0)
                    {
                        // out of order — swap the VALUES, not the nodes themselves
                        T temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }

                    current = current.Next;
                }
            } while (swapped); // keep looping until a pass with zero swaps happens
        }

        // Copies all node values into a plain array, in head-to-tail order.
        // Handy for displaying the list or asserting order in unit tests.
        public T[] ToArray()
        {
            T[] result = new T[_count];
            Node<T>? current = _head;
            int i = 0;

            while (current != null)
            {
                result[i] = current.Data;
                i++;
                current = current.Next;
            }

            return result;
        }

    public void ReverseList()
        {
            // Empty or single-node list is already reversed
            if (_head == null || _head.Next == null) return;

            Node<T> previous = null;
            Node<T> current = _head;
            Node<T> next = null;

            // Update Tail pointer BEFORE loop (old head becomes new tail)
            _tail = _head;

            while (current != null)
            {
                next = current.Next;     // 1. Save next node pointer
                current.Next = previous; // 2. Reverse current node link direction
                previous = current;      // 3. Move previous forward
                current = next;          // 4. Move current forward
            }

            // Update Head pointer (last non-null node becomes new head)
            _head = previous;
        }
    }
}