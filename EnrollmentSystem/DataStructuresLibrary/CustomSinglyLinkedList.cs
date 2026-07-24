using System;
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

    public class CustomSinglyLinkedList<T>
    {
        public Node<T>? Head { get; private set; }
        public int Count { get; private set; }

        public CustomSinglyLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (Head is null)
            {
                Head = newNode;
            }
            else
            {
                var current = Head;
                while (current.Next is not null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            Count++;
        }

        public bool Remove(Func<T, bool> predicate)
        {
            if (Head is null) return false;

            if (predicate(Head.Data))
            {
                Head = Head.Next;
                Count--;
                return true;
            }

            var current = Head;
            while (current.Next is not null)
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

        public Node<T>? Find(Func<T, bool> predicate)
        {
            var current = Head;
            while (current is not null)
            {
                if (predicate(current.Data))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void Sort(Func<T, T, int> comparer)
        {
            if (Head is null || Head.Next is null) return;

            for (var i = Head; i is not null; i = i.Next)
            {
                var minNode = i;
                for (var j = i.Next; j is not null; j = j.Next)
                {
                    if (comparer(j.Data, minNode.Data) < 0)
                    {
                        minNode = j;
                    }
                }

                if (minNode != i)
                {
                    T temp = i.Data;
                    i.Data = minNode.Data;
                    minNode.Data = temp;
                }
            }
        }
    }
}