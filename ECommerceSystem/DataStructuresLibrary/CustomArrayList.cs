namespace DataStructuresLibrary;

/// <summary>
/// A resizable array-based list implemented without using List&lt;T&gt;.
/// Items are stored in contiguous array positions from index 0 to Count - 1.
/// </summary>
public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;

    /// <summary>
    /// Gets the number of items currently stored in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Creates an empty list using the requested initial capacity.
    /// Invalid capacities fall back to four slots.
    /// Time complexity: O(1).
    /// </summary>
    public CustomArrayList(int initialCapacity = 4)
    {
        if (initialCapacity <= 0)
        {
            initialCapacity = 4;
        }

        _items = new T[initialCapacity];
    }

    /// <summary>
    /// Adds an item to the end of the list.
    /// Amortized time complexity: O(1); O(n) when resizing is required.
    /// </summary>
    public void Add(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    /// <summary>
    /// Removes the first item that compares equal to the target.
    /// Returns false when the item is not found.
    /// Time complexity: O(n).
    /// </summary>
    public bool Remove(T item)
    {
        int index = Search(item);

        if (index == -1)
        {
            return false;
        }

        RemoveAt(index);
        return true;
    }

    /// <summary>
    /// Removes the item at the specified index and shifts later items left.
    /// Time complexity: O(n).
    /// </summary>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index),
                "Index is outside the bounds of the list.");
        }

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[Count - 1] = default!;
        Count--;
    }

    /// <summary>
    /// Returns the item stored at the specified index.
    /// Time complexity: O(1).
    /// </summary>
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index),
                "Index is outside the bounds of the list.");
        }

        return _items[index];
    }

    /// <summary>
    /// Performs a linear search and returns the first matching index.
    /// Returns -1 when the item is not found.
    /// Time complexity: O(n).
    /// </summary>
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

    /// <summary>
    /// Sorts the stored items in ascending order using insertion sort.
    /// Best-case time complexity: O(n).
    /// Average and worst-case time complexity: O(n^2).
    /// Space complexity: O(1).
    /// </summary>
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

    /// <summary>
    /// Doubles the internal array capacity and copies all current items.
    /// Time complexity: O(n).
    /// </summary>
    private void Resize()
    {
        int newCapacity = _items.Length == 0
            ? 4
            : _items.Length * 2;

        var newItems = new T[newCapacity];

        for (int i = 0; i < Count; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }
}
