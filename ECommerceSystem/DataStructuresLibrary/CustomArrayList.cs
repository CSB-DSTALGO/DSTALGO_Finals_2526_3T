namespace DataStructuresLibrary;

// Code by: Victor Tarra

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    // Initializes the array list with a default capacity.
    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    // Adds a new item to the end of the array list.
    // If capacity is full, it resizes the internal array.
    public void Add(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    // Removes the first matching item using Linear Search.
    // After removal, elements are shifted left to maintain order.
    public bool Remove(T item)
    {
        int index = Search(item); // Linear Search used here

        if (index == -1)
        {
            return false;
        }

        // Shift elements to the left
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

    // Linear Search Algorithm:
    // Iterates through each element to find a match.
    // Time Complexity: O(n)
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

    // Bubble Sort Algorithm:
    // Repeatedly compares adjacent elements and swaps them if out of order.
    // Largest elements "bubble" to the end after each pass.
    // Time Complexity: O(n^2)
    public void Sort()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - i - 1; j++)
            {
                if (_items[j].CompareTo(_items[j + 1]) > 0)
                {
                    // Swap elements
                    (_items[j], _items[j + 1]) = (_items[j + 1], _items[j]);
                }
            }
        }
    }

    // Doubles the capacity of the internal array when full.
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