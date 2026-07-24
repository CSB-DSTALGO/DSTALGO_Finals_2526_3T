
using System.Collections;
namespace DataStructuresLibrary;

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

    public void Add(T item)
    {
        Node newNode = new Node(item);

        // empty list, new node just becomes the head
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            // walk to the last node using current, never move _head itself
            Node current = _head;
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
        {
            return false;
        }

        // special case: the head itself is the one we want gone
        if (_head.Data.CompareTo(item) == 0)
        {
            _head = _head.Next;
            Count--;
            return true;
        }

        // keep track of the node just behind current so we can re-link past it
        Node current = _head;
        while (current.Next != null)
        {
            if (current.Next.Data.CompareTo(item) == 0)
            {
                // skip over the matching node, works for middle or tail removal
                current.Next = current.Next.Next;
                Count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public bool Search(T item)
    {
        Node? current = _head;

        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void Sort()
    {
        // swapping the Data inside nodes is way simpler than re-wiring
        // Next pointers, and the list still ends up in the right order
        if (_head == null)
        {
            return;
        }

        bool swapped;
        do
        {
            swapped = false;
            Node? current = _head;

            while (current != null && current.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }

                current = current.Next;
            }
        } while (swapped);
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