namespace DataStructuresLibrary;

public class CustomSinglyLinkedList<T> where T : IComparable<T>
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

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;
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

        Node current = _head;
        while (current.Next != null)
        {
            if (current.Next.Data.CompareTo(item) == 0)
            {
                current.Next = current.Next.Next; // unlink the node
                Count--;
                return true;
            }
            current = current.Next;
        }

        return false; // not found
    }

    // Linear traversal search.
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

    public void Sort()
    {
        if (_head == null || _head.Next == null) return;

        Node? sorted = null;
        Node? current = _head;

        while (current != null)
        {
            Node next = current.Next; // remember where we were

            if (sorted == null || sorted.Data.CompareTo(current.Data) >= 0)
            {
                // Insert at the front of the sorted section
                current.Next = sorted;
                sorted = current;
            }
            else
            {
                Node temp = sorted;
                while (temp.Next != null && temp.Next.Data.CompareTo(current.Data) < 0)
                {
                    temp = temp.Next;
                }
                current.Next = temp.Next;
                temp.Next = current;
            }

            current = next;
        }

        _head = sorted;
    }

    public void ForEach(Action<T> action)
    {
        Node? current = _head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }
}