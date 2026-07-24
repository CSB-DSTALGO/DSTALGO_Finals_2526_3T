namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
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
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        T value = _head.Value;
        _head = _head.Next;

        if (_head == null)
        {
            _tail = null;
        }

        Count--;
        return value;
    }

    public T Peek()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _head.Value;
    }

    public bool Search(T item)
    {
        var current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item) || 
                (current.Value != null && current.Value.CompareTo(item) == 0))
            {
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void Sort()
    {
        if (Count <= 1 || _head == null) return;

        bool swapped;
        do
        {
            swapped = false;
            var current = _head;

            while (current?.Next != null)
            {
                if (current.Value.CompareTo(current.Next.Value) > 0)
                {
                    (current.Value, current.Next.Value) = (current.Next.Value, current.Value);
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }
}
