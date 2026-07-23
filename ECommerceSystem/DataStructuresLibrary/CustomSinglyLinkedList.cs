namespace DataStructuresLibrary;

using System.Collections;
using System.Collections.Generic;

public class CustomSinglyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
{
    private class Node
    {
        public T Data;
        public Node? Next;
        public Node(T data) => Data = data;
    }

    private Node? _head;
    private Node? _tail;
    public int Count { get; private set; }

    // Add function to add an item to the end of the list
    public void Add(T item)
    {
        var newNode = new Node(item);

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

    // Remove function to remove an item from the list
    public bool Remove(T item)
    {
        if (_head == null) return false;

        if (_head.Data.CompareTo(item) == 0)
        {
            _head = _head.Next;
            if (_head == null) _tail = null;
            Count--;
            return true;
        }

        Node? current = _head;
        while (current.Next != null)
        {
            if (current.Next.Data.CompareTo(item) == 0)
            {
                if (current.Next == _tail) _tail = current;
                current.Next = current.Next.Next;
                Count--;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    // Search function to check if an item exists in the list
    public bool Search(T item)
    {
        Node? current = _head;
        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
                return true;
            current = current.Next;
        }
        return false;
    }

    // Sort function to sort the list in ascending order
    public void Sort()
    {
        if (_head == null || _head.Next == null) return;

        Node? sortedHead = null;
        Node? current = _head;

        while (current != null)
        {
            Node? next = current.Next;

            if (sortedHead == null || sortedHead.Data.CompareTo(current.Data) >= 0)
            {
                current.Next = sortedHead;
                sortedHead = current;
            }
            else
            {
                Node search = sortedHead;
                while (search.Next != null && search.Next.Data.CompareTo(current.Data) < 0)
                {
                    search = search.Next;
                }
                current.Next = search.Next;
                search.Next = current;
            }

            current = next;
        }

        _head = sortedHead;

        Node tail = _head!;
        while (tail.Next != null) tail = tail.Next;
        _tail = tail;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}