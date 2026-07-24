namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    // Initializes the array list with a starting capacity.
    public CustomArrayList(int initialCapacity = 4)
    {
        // Uses the default capacity if the provided capacity is invalid.
        if (initialCapacity <= 0)
        {
            initialCapacity = 4;
        }

        _items = new T[initialCapacity];
        Count = 0;
    }

    // Adds an item to the end of the array list.
    public void Add(T item)
    {
        // Doubles the array size when the current array is full.
        if (Count == _items.Length)
        {
            T[] newItems = new T[_items.Length * 2];

            // Copies the existing items into the larger array.
            for (int i = 0; i < Count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        _items[Count] = item;
        Count++;
    }

    // Removes the first matching item from the array list.
    public bool Remove(T item)
    {
        // Searches for the item and gets its index.
        int index = Search(item);

        // Returns false if the item does not exist.
        if (index == -1)
        {
            return false;
        }

        // Shifts the items after the removed item one position to the left.
        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        // Clears the last item and decreases the item count.
        _items[Count - 1] = default!;
        Count--;

        return true;
    }

    // Returns the item at the specified index.
    public T Get(int index)
    {
        // Checks whether the index is within the valid range.
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException(
                "Index is outside the bounds of the list."
            );
        }

        return _items[index];
    }

    // Searches for an item and returns its index.
    public int Search(T item)
    {
        // Checks each item in the array list for a match.
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return i;
            }
        }

        // Returns -1 when the item is not found.
        return -1;
    }

    // Sorts the items in ascending order using insertion sort.
    public void Sort()
    {
        // Starts from the second item and inserts each item into its correct position.
        for (int i = 1; i < Count; i++)
        {
            T currentItem = _items[i];
            int j = i - 1;

            // Shifts larger items to the right until the correct position is found.
            while (j >= 0 &&
                   _items[j].CompareTo(currentItem) > 0)
            {
                _items[j + 1] = _items[j];
                j--;
            }

            _items[j + 1] = currentItem;
        }
    }
}