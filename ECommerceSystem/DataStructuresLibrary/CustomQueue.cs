namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
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

    public void Enqueue(T item)
    {
        var newNode = new Node(item);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }
        Count++;
    }

    public T Dequeue()
    {
        if (_head == null)
            throw new InvalidOperationException("Queue is empty.");

        T data = _head.Data;
        _head = _head.Next;
        if (_head == null)
            _tail = null;
        Count--;
        return data;
    }

    public T Peek()
    {
        if (_head == null)
            throw new InvalidOperationException("Queue is empty.");

        return _head.Data;
    }

    public bool Search(T item)
    {
        var current = _head;
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
        if (_head == null || _head.Next == null)
            return;

        T[] items = new T[Count];
        var current = _head;
        int i = 0;
        while (current != null)
        {
            items[i++] = current.Data;
            current = current.Next;
        }

        // Insertion sort, ascending
        for (int j = 1; j < items.Length; j++)
        {
            T key = items[j];
            int k = j - 1;
            while (k >= 0 && items[k].CompareTo(key) > 0)
            {
                items[k + 1] = items[k];
                k--;
            }
            items[k + 1] = key;
        }

        _head = null;
        _tail = null;
        Count = 0;
        foreach (var item in items)
            Enqueue(item);
    }
}