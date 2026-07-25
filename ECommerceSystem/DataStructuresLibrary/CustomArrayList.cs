namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        if (initialCapacity <= 0) initialCapacity = 4;
        _items = new T[initialCapacity];
    }

    public void Add(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    public bool Remove(T item)
    {
        int index = Search(item);
        if (index == -1) return false;

        RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is outside the bounds of the list.");
        }

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[Count - 1] = default!;
        Count--;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is outside the bounds of the list.");
        }

        return _items[index];
    }

    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return i;
            }
        }

        return -1;
    }

    public void Sort()
    {
        for (int i = 1; i < Count; i++)
        {
            T current = _items[i];
            int j = i - 1;

            while (j >= 0 && _items[j].CompareTo(current) > 0)
            {
                _items[j + 1] = _items[j];
                j--;
            }

            _items[j + 1] = current;
        }
    }

    private void Resize()
    {
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        var newItems = new T[newCapacity];

        for (int i = 0; i < Count; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }
}