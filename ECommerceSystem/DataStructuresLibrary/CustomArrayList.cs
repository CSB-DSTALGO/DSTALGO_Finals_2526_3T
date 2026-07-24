namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    /// Adds an item to the end of the array list.

    public void Add(T item)
    {
        if (Count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        _items[Count++] = item;
    }

    /// Removes the first matching item.
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

    /// Returns the item at the specified index.

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return _items[index];
    }

    /// Performs a linear search.

    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
                return i;
        }

        return -1;
    }

    /// Sorts the array using Bubble Sort.
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