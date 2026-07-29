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

    // Adds an item to the end of the list
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

    // Removes the first occurrence of an item
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

    // Returns true if the item exists
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

    // Returns the item at the specified index
    public T GetAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        Node? current = _head;

        for (int i = 0; i < index; i++)
        {
            current = current!.Next;
        }

        return current!.Data;
    }

    // Bubble sort
    public void Sort()
    {
        if (_head == null || _head.Next == null)
            return;

        bool swapped;

        do
        {
            swapped = false;
            Node? current = _head;

            while (current!.Next != null)
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

    // Traverses the list
    public IEnumerable<T> GetAll()
    {
        Node? current = _head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}
