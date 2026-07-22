namespace DataStructuresLibrary;

public class CustomSinglyLinkedList<T> where T : IComparable<T>
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

    public void Add(T item)
    {
        Node newNode = new Node(item);

        // If the list is empty, the new node becomes the head.
        if (_head == null)
        {
            _head = newNode;
            Count++;
            return;
        }

        // Traverse until the last node.
        Node current = _head;

        while (current.Next != null)
        {
            current = current.Next;
        }

        // Append the new node.
        current.Next = newNode;
        Count++;
    }

    public bool Remove(T item)
    {
        if (_head == null)
        {
            return false;
        }

        EqualityComparer<T> comparer =
            EqualityComparer<T>.Default;

        // Remove the head node.
        if (comparer.Equals(_head.Data, item))
        {
            _head = _head.Next;
            Count--;
            return true;
        }

        Node current = _head;

        // Look for the node before the target node.
        while (current.Next != null)
        {
            if (comparer.Equals(current.Next.Data, item))
            {
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
        EqualityComparer<T> comparer =
            EqualityComparer<T>.Default;

        Node? current = _head;

        while (current != null)
        {
            if (comparer.Equals(current.Data, item))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index),
                "Index is outside the linked list."
            );
        }

        Node current = _head!;

        for (int i = 0; i < index; i++)
        {
            current = current.Next!;
        }

        return current.Data;
    }

    public void Sort()
    {
        // Empty and one-item lists are already sorted.
        if (_head == null || _head.Next == null)
        {
            return;
        }

        Node? sortedHead = null;
        Node? current = _head;

        while (current != null)
        {
            // Save the next node before changing links.
            Node? nextNode = current.Next;

            // Insert at the beginning of the sorted list.
            if (sortedHead == null ||
                current.Data.CompareTo(sortedHead.Data) < 0)
            {
                current.Next = sortedHead;
                sortedHead = current;
            }
            else
            {
                Node sortedCurrent = sortedHead;

                // Find the correct insertion position.
                while (sortedCurrent.Next != null &&
                       sortedCurrent.Next.Data.CompareTo(current.Data) <= 0)
                {
                    sortedCurrent = sortedCurrent.Next;
                }

                current.Next = sortedCurrent.Next;
                sortedCurrent.Next = current;
            }

            current = nextNode;
        }

        _head = sortedHead;
    }
}