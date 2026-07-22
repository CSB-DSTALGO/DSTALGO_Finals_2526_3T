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
            Count++;
            return;
        }

        Node current = _head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
        Count++;
    }

    public bool Remove(T item)
    {
        Node? current = _head;
        Node? previous = null;

        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
            {
                if (previous == null)
                {
                    // removing the very first node
                    _head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                Count--;
                return true;
            }

            previous = current;
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
        if (_head == null)
        {
            return;
        }

        bool swapped = true;

        while (swapped)
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
        }
    }

    public T[] ToArray()
    {
        T[] result = new T[Count];
        Node? current = _head;
        int i = 0;

        while (current != null)
        {
            result[i] = current.Data;
            i++;
            current = current.Next;
        }

        return result;
    }
}