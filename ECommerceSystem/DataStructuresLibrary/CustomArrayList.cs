namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    // Initializes the array with a default capacity of 4.
    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    // Adds a new item to the end of the array.
    public void Add(T item)
    {
        // Resize the array if it is full.
        if (Count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        _items[Count] = item;
        Count++;
    }

    // Removes the first matching item from the array.
    public bool Remove(T item)
    {
        int index = Search(item);

        // Return false if the item is not found.
        if (index == -1)
        {
            return false;
        }

        // Shift the remaining elements to the left.
        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;
        return true;
    }

    // Returns the item at the specified index.
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return _items[index];
    }

    // Searches for an item and returns its index.
    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return i;
            }
        }

        // Return -1 if the item does not exist.
        return -1;
    }

    // Sorts the array in ascending order using Bubble Sort.
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
