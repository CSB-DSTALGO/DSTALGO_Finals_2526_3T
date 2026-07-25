// CustomSinglyLinkedList.cs
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
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

    public class CustomSinglyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T>? _head;

        public Node<T>? Head => _head;

        public int Count { get; set; }

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
                Count++;
                return;
            }

            Node<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            Count++;
        }

        public bool Remove(T item)
        {
            
            if (_head == null)
                return false;

            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(_head.Data, item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node<T> current = _head;
            while (current.Next != null)
            {
                if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(current.Next.Data, item))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Sort()
        {
            
            _head = MergeSort(_head);
        }

        private static Node<T>? MergeSort(Node<T>? head)
        {
            if (head == null || head.Next == null)
                return head;

            Node<T> secondHalf = Split(head);
            Node<T>? left = MergeSort(head);
            Node<T>? right = MergeSort(secondHalf);
            return Merge(left, right);
        }

        private static Node<T> Split(Node<T> head)
        {
            
            Node<T> slow = head;
            Node<T> fast = head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next!;
                fast = fast.Next.Next;
            }

            Node<T> secondHalf = slow.Next!;
            slow.Next = null;
            return secondHalf;
        }

        private static Node<T>? Merge(Node<T>? a, Node<T>? b)
        {
            
            if (a == null)
                return b;
            if (b == null)
                return a;

            if (a.Data.CompareTo(b.Data) <= 0)
            {
                a.Next = Merge(a.Next, b);
                return a;
            }
            else
            {
                b.Next = Merge(a, b.Next);
                return b;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}