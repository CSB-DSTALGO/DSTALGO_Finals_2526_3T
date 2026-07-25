namespace DataStructuresLibrary;

/// <summary>
/// A generic dynamic array data structure that automatically resizes when full.
/// Built manually without any System.Collections.Generic types.
/// </summary>
public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        if (initialCapacity < 1) initialCapacity = 4;
        _items = new T[initialCapacity];
    }

    /// <summary>Appends an item, doubling capacity automatically when full.</summary>
    public void Add(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }
        _items[Count] = item;
        Count++;
    }

    /// <summary>Removes the first occurrence of the given item, shifting later elements left.</summary>
    public bool Remove(T item)
    {
        int index = Search(item);
        if (index == -1) return false;

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        _items[Count - 1] = default!;
        Count--;
        return true;
    }

    /// <summary>Returns the element at the given 0-based index.</summary>
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException("Index is out of range.");

        return _items[index];
    }

    /// <summary>
    /// Linear Search: scans sequentially using CompareTo() == 0.
    /// Time Complexity: O(n) worst case, O(1) best case.
    /// </summary>
    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (item.CompareTo(_items[i]) == 0)
                return i;
        }
        return -1;
    }

    /// <summary>
    /// Insertion Sort: builds a sorted section at the front, shifting larger
    /// elements right. Time Complexity: O(n^2) worst/average, O(n) best case.
    /// Space Complexity: O(1), in-place.
    /// </summary>
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

    private void Resize()
    {
        T[] newArray = new T[_items.Length * 2];
        Array.Copy(_items, newArray, Count);
        _items = newArray;
    }
}