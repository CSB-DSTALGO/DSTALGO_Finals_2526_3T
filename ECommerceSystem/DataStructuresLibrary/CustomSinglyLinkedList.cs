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
        var newMode = new Node(item);
        if (_head == null)
        {
            _head = newMode;
        }
        else
        {
            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newMode;
        }
        Count++;
    }
    public bool Remove(T item)
    {
        if (head == null) return false;
        if (head.Data.CompareTo(item) == 0)
        {
            head = head.Next;
            Count--;
            return true;
        }

        var current = _head;
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

    public bool Search(T item)
    {
        var current = _head;
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
        if (head == null || _head.Next == null) return;

        var list = new List<T>();
        var current = _head;
        while (current != null)
        {
            list.Add(current.Data);
            current = current.Next;
        }

        list.Sort();

        _head = null;
        Count = 0;
        foreach (var item in list)
        {
            Add(item);
        }
    }

    public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
}