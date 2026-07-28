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

    public CustomSinglyLinkedList()
    {
        _head = null;
        Count = 0;
    }

    public void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        Node newNode = new(item);

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

    public bool Remove(T item)
    {
        if (_head == null)
            return false;

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
                current.Next = current.Next.Next;
                Count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    // Required by ProductCatalog
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException("Index was out of range.");

        Node current = _head!;

        for (int i = 0; i < index; i++)
        {
            current = current.Next!;
        }

        return current.Data;
    }

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
        if (Count <= 1)
            return;

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
}