// 12521269 Joaquin Bryan G. Ross
namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    // Starts with a small array. Grow doubles it whenever it fills up.
    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    // Amortised O(1): the doubling in Grow() happens rarely enough that the
    // average cost per Add stays constant.
    public void Add(T item)
    {
        if (Count == _items.Length) Grow();
        _items[Count] = item;
        Count++;
    }

    // Removes by value. O(n) to find it, then O(n) to close the gap.
    public bool Remove(T item)
    {
        int index = Search(item);
        if (index == -1) return false;

        // Close the gap by shifting every later element one slot left.
        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;
        _items[Count] = default!; // release the duplicate reference in the vacated slot
        return true;
    }

    // Removes by position rather than by value. Same shifting cost as Remove,
    // but it skips the linear search because the caller already knows where
    // the item sits.
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is outside the list of {Count} item(s).");

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;
        _items[Count] = default!;
    }

    // O(1). Computing the slot address directly is what an array list is for.
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is outside the list of {Count} item(s).");

        return _items[index];
    }

    // Linear search: returns the zero-based position of the item, or -1 if absent.
    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Equals(_items[i], item)) return i;
        }

        return -1;
    }

    // Insertion sort, ascending by CompareTo. Stable, and O(n) on nearly
    // sorted input, which suits the small carts this list holds.
    public void Sort()
    {
        for (int i = 1; i < Count; i++)
        {
            T key = _items[i];
            int j = i - 1;

            while (j >= 0 && _items[j].CompareTo(key) > 0)
            {
                _items[j + 1] = _items[j];
                j--;
            }

            _items[j + 1] = key;
        }
    }

    private void Grow()
    {
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        T[] larger = new T[newCapacity];

        for (int i = 0; i < Count; i++)
        {
            larger[i] = _items[i];
        }

        _items = larger;
    }
}