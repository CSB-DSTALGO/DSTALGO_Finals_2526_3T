// CustomSinglyLinkedList.cs
// GUYS TINATAMAD PA AKU MAG CUMENT SURI

using System;

namespace DataStructuresLibrary
{
    public class Node<T>
    {

        //soo this is like the ano ung kinukuha or sineset ung data sa stores node
        public T Data { get; set; }

        // here it gets or sets yung reference sa susunod na node and bull sya guys kasi wala naman nag popoint ung last node (gits?)
        public Node<T>? Next { get; set; }

        //dito create sya new node na may specific data tapos next sya kasi null kasi di pa linked ung node
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class CustomSinglyLinkedList<T>
    {
        private Node<T>? _head;

        public Node<T>? Head
        {
            get { return _head; }
        }

        public int Count { get; private set; }

        public CustomSinglyLinkedList()
        {
            _head = null;
            Count = 0;
        }

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

        public void Traverse(Action<T> action)
        {
            Node<T>? current = _head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }

}