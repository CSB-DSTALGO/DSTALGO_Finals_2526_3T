using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class CustomSinglyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data;
            public Node? Next;

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node? _head;

        public int Count { get; private set; }

        // ✅ Add item
        public void Add(T item)
        {
            var newNode = new Node(item);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            Count++;
        }

        // ✅ Remove item
        public bool Remove(T item)
        {
            if (_head == null) return false;

            if (_head.Data.CompareTo(item) == 0)
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            var current = _head;

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

        // ✅ Search item
        public bool Search(T item)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Data.CompareTo(item) == 0)
                    return true;

                current = current.Next;
            }

            return false;
        }

        // ✅ Required by your error (Contains)
        public bool Contains(T item)
        {
            return Search(item);
        }

        // ✅ Required by your error (Clear)
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        // ✅ Sort list
        public void Sort()
        {
            if (_head == null || _head.Next == null) return;

            var list = new List<T>();
            var current = _head;

            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            list.Sort();

            _head = null;
            Count = 0;

            foreach (var item in list)
            {
                Add(item);
            }
        }

        // ✅ Required for foreach
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