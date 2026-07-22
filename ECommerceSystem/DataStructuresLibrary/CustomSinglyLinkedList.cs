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
            public Node(T data) => Data = data;
        }

        private Node? _head;
        public int Count { get; private set; }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (_head == null)
                _head = newNode;
            else
            {
                var current = _head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }
            Count++;
        }

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
            while (current.Next != null && current.Next.Data.CompareTo(item) != 0)
                current = current.Next;

            if (current.Next == null) return false;

            current.Next = current.Next.Next;
            Count--;
            return true;
        }

        public T? Find(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data.CompareTo(item) == 0)
                    return current.Data;
                current = current.Next;
            }
            return default;
        }

        public void Sort()
        {
            if (_head == null || _head.Next == null) return;

            var list = new List<T>();
            foreach (var item in this)
                list.Add(item);

            list.Sort();

            _head = null;
            foreach (var item in list)
                AddLast(item);
        }

        public T GetProductDetails(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var current = _head;
            for (int i = 0; i < index; i++)
                current = current!.Next;

            return current!.Data;
        }

        public void ShowAllProfiles()
        {
            var current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
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

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
