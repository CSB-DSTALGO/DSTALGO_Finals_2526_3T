// 12521269 Joaquin Bryan G. Ross
namespace DataStructuresLibrary;

public class CustomSinglyLinkedList<T> where T : IComparable<T>
{
    private class Node
    {
        public T Data;
        public Node? Next;
        // A chain link holding one item and a pointer to the next.
        public Node(T data) => Data = data;
    }

    private Node? _head;
    public int Count { get; private set; }

    // Appends to the tail so catalog order matches insertion order.
    // No tail pointer is kept, so this walks the chain: O(n).
    public void Add(T item)
    {
        Node node = new(item);

        if (_head is null)
        {
            _head = node;
        }
        else
        {
            Node current = _head;
            while (current.Next is not null)
            {
                current = current.Next;
            }

            current.Next = node;
        }

        Count++;
    }

    // Unlinks the first node holding the item. O(n) to find it, O(1) to unlink.
    public bool Remove(T item)
    {
        if (_head is null) return false;

        // Removing the head needs no predecessor, so it is handled separately.
        if (Equals(_head.Data, item))
        {
            _head = _head.Next;
            Count--;
            return true;
        }

        // Track the previous node so the matched node can be unlinked.
        Node previous = _head;
        while (previous.Next is not null)
        {
            if (Equals(previous.Next.Data, item))
            {
                previous.Next = previous.Next.Next;
                Count--;
                return true;
            }

            previous = previous.Next;
        }

        return false;
    }

    // Retrieves by position. A linked list has no random access, so reaching
    // index i costs i hops. That is the trade for O(1) insertion at a known node.
    public T GetAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is outside the list of {Count} node(s).");

        Node current = _head!;
        for (int i = 0; i < index; i++)
        {
            current = current.Next!;
        }

        return current.Data;
    }

    // Linear traversal: the list has no index, so membership is all we can report.
    public bool Search(T item)
    {
        Node? current = _head;
        while (current is not null)
        {
            if (Equals(current.Data, item)) return true;
            current = current.Next;
        }

        return false;
    }

    // Insertion sort by re-linking nodes, ascending by CompareTo.
    // Nodes are moved rather than their payloads, so no data is copied.
    public void Sort()
    {
        if (_head is null || _head.Next is null) return;

        Node? sorted = null;
        Node? remaining = _head;

        while (remaining is not null)
        {
            Node? next = remaining.Next; // remaining gets re-linked below, so capture it first

            if (sorted is null || sorted.Data.CompareTo(remaining.Data) > 0)
            {
                // The node belongs at the front of the sorted run.
                remaining.Next = sorted;
                sorted = remaining;
            }
            else
            {
                // Walk the sorted run to find the last node that still precedes it.
                Node scan = sorted;
                while (scan.Next is not null && scan.Next.Data.CompareTo(remaining.Data) <= 0)
                {
                    scan = scan.Next;
                }

                remaining.Next = scan.Next;
                scan.Next = remaining;
            }

            remaining = next;
        }

        _head = sorted;
    }
}