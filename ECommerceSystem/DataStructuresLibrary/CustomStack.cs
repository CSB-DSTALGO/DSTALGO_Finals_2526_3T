namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items;

    public int Count { get; private set; }

    public CustomStack(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    private void Resize()
    {
        T[] newItems = new T[_items.Length * 2];

        for (int i = 0; i < Count; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }

    public void Push(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        Count--;
        T item = _items[Count];
        _items[Count] = default!;
        return item;
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return _items[Count - 1];
    }

    public int Search(T item)
    {
        int depth = 1;

        for (int i = Count - 1; i >= 0; i--)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return depth;
            }

            depth++;
        }

        return -1;
    }

    public void Sort()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = i + 1; j < Count; j++)
            {
                if (_items[i].CompareTo(_items[j]) < 0)
                {
                    T temp = _items[i];
                    _items[i] = _items[j];
                    _items[j] = temp;
                }
            }
        }
    }
}