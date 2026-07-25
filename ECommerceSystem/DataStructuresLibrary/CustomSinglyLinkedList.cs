namespace DataStructuresLibrary;

/// <summary>
/// A custom singly linked list implemented with nodes.
/// Each node stores one item and a reference to the next node.
/// </summary>
public class CustomSinglyLinkedList<T> where T : IComparable<T>
{
    private class Node
    {
        public T Data;
        public Node? Next;

        public Node(T data)
        {
            Data = data;
        }
    }

    private Node? _head;

    /// <summary>
    /// Gets the number of nodes currently stored in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Appends an item to the end of the linked list.
    /// Time complexity: O(n).
    /// </summary>
    public void Add(T item)
    {
        Node newNode = new Node(item);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        Count++;
    }

    /// <summary>
    /// Removes the first node whose data compares equal to the target.
    /// Returns false when the target is not found.
    /// Time complexity: O(n).
    /// </summary>
    public bool Remove(T item)
    {
        if (_head == null)
        {
            return false;
        }

        if (_head.Data.CompareTo(item) == 0)
        {
            _head = _head.Next;
            Count--;
            return true;
        }

        Node previous = _head;
        Node? current = _head.Next;

        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
            {
                previous.Next = current.Next;
                Count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Performs a linear traversal to check whether an item exists.
    /// Time complexity: O(n).
    /// </summary>
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

    /// <summary>
    /// Returns the item stored at the specified zero-based index.
    /// Time complexity: O(n).
    /// </summary>
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        Node current = _head!;

        for (int i = 0; i < index; i++)
        {
            current = current.Next!;
        }

        return current.Data;
    }

    /// <summary>
    /// Sorts node data in ascending order using bubble sort.
    /// Time complexity: O(n^2).
    /// Space complexity: O(1).
    /// </summary>
    public void Sort()
    {
        if (_head == null)
        {
            return;
        }

        bool swapped;

        do
        {
            swapped = false;
            Node current = _head;

            while (current.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    T temporary = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temporary;
                    swapped = true;
                }

                current = current.Next;
            }
        }
        while (swapped);
    }
}
