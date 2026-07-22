namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    // Adds a new item to the end of the array list.
    public void Add(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    // Removes the first matching item from the array list.
    public bool Remove(T item)
    {
        int index = Search(item);

        if (index == -1)
        {
            return false;
        }

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[Count - 1] = default!;
        Count--;
        return true;
    }

    // Returns the item at the specified index.
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        return _items[index];
    }

    // Searches for an item and returns its index, or -1 if not found.
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

    // Sorts the array list in ascending order using Bubble Sort.
    public void Sort()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - i - 1; j++)
            {
                if (_items[j].CompareTo(_items[j + 1]) > 0)
                {
                    (_items[j], _items[j + 1]) = (_items[j + 1], _items[j]);
                }
            }
        }
    }

    // Resizes the internal array when capacity is full.
    private void Resize()
    {
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        T[] newItems = new T[newCapacity];

        for (int i = 0; i < Count; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }
}
