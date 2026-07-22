using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
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

    public class CustomSinglyLinkedList<T> : IEnumerable<T>
    {
        private CustomSinglyLinkedListNode<T>? _head;
        private int _count;

        public int Count => _count;
        public bool IsEmpty => _count == 0;

        public void Add(T data)
        {
            var newNode = new CustomSinglyLinkedListNode<T>(data);

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
            _count++;
        }

        public void InsertAt(int index, T data)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var newNode = new CustomSinglyLinkedListNode<T>(data);

            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {
                var current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }
                newNode.Next = current!.Next;
                current.Next = newNode;
            }
            _count++;
        }

        public bool Remove(T data)
        {
            if (_head == null) return false;

            if (_head.Data!.Equals(data))
            {
                _head = _head.Next;
                _count--;
                return true;
            }

            var current = _head;
            while (current.Next != null)
            {
                if (current.Next.Data!.Equals(data))
                {
                    current.Next = current.Next.Next;
                    _count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

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

        public T GetAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }
            return current!.Data;
        }

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

        public void Clear()
        {
            _head = null;
            _count = 0;
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
}