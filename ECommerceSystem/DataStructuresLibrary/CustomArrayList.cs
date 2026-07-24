namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    /// <summary>
    /// Adds an item to the end of the array list.
    /// </summary>
    public void Add(T item)
    {
        if (Count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        _items[Count++] = item;
    }

    /// <summary>
    /// Removes the first matching item.
    /// </summary>
    public bool Remove(T item)
    {
        int index = Search(item);

        if (index == -1)
            return false;

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;
        _items[Count] = default!;

        return true;
    }

    /// <summary>
    /// Returns the item at the specified index.
    /// </summary>
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return _items[index];
    }

    /// <summary>
    /// Performs a linear search.
    /// </summary>
    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
                return i;
        }

        return -1;
    }

    /// <summary>
    /// Sorts the array using Bubble Sort.
    /// </summary>
    public void Sort()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - i - 1; j++)
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
}