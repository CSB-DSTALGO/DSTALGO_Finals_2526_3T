namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomStack(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
        Count = 0;
    }

    public void Push(T item)
    {
        if (Count == _items.Length)
        {
            Grow();
        }

        _items[Count] = item;
        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        Count--;
        T item = _items[Count];
        _items[Count] = default!;
        return item;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return _items[Count - 1];
    }

    // 1-based depth from top (Top item = 1, item under top = 2, etc.)
    public int Search(T item)
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            if (_items[i] != null && _items[i].CompareTo(item) == 0)
            {
                return Count - i; // 1-based depth from top
            }
        }
        return -1;
    }

    public void Sort()
    {
        if (Count <= 1) return;

        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - 1 - i; j++)
            {
                if (_items[j].CompareTo(_items[j + 1]) > 0)
                {
                    T temp = _items[j];
                    _items[j] = _items[j + 1];
                    _items[j + 1] = temp;
                }
            }
        }
    }

    private void Grow()
    {
        T[] newArray = new T[_items.Length * 2];
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _items[i];
        }
        _items = newArray;
    }
}