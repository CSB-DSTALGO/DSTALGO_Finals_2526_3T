namespace DataStructuresLibrary;

public class CustomArrayList<T>
{
    private T?[] _items;
    public int Count { get; private set; }

    public void Sort(Comparison<T> comparison)
    {
        if (Count <= 1) return;

        var items = new List<T>();
        for (int i = 0; i < Count; i++)
        {
            items.Add(_items[i]!);
        }

        items.Sort(comparison);

        for (int i = 0; i < Count; i++)
        {
            _items[i] = items[i];
        }
    }

    public CustomArrayList(int capacity = 10)
    {
        _items = new T[capacity];
        Count = 0;
    }

    public void Add(T value)
    {
        if (Count == _items.Length)
            Resize(_items.Length * 2);

        _items[Count] = value;
        Count++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException("Index out of range.");

        return _items[index]!;
    }

    public void Set(int index, T value)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException("Index out of range.");

        _items[index] = value;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException("Index out of range.");

        for (int i = index; i < Count - 1; i++)
            _items[i] = _items[i + 1];

        Count--;
    }

    public void RemoveAt(int index) => Remove(index);

    public bool Contains(T value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i]?.Equals(value) ?? false)
                return true;
        }
        return false;
    }

    public int Search(Func<T, bool> predicate)
    {
        for (int i = 0; i < Count; i++)
        {
            if (predicate(_items[i]!))
                return i;
        }
        return -1;
    }

    private void Resize(int newCapacity)
    {
        var newItems = new T[newCapacity];
        Array.Copy(_items, newItems, Count);
        _items = newItems;
    }
}
