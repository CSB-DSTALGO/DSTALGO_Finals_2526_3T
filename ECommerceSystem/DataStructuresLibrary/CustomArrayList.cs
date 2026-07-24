namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        if (initialCapacity <= 0)
        {
            initialCapacity = 4;
        }

        _items = new T[initialCapacity];
        Count = 0;
    }

    public void Add(T item)
    {
        EnsureCapacity();
        _items[Count] = item;
        Count++;
    }

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

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException("Index was out of range.");
        }

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[Count - 1] = default!;
        Count--;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException("Index was out of range.");
        }

        return _items[index];
    }

    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i] != null && _items[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

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

    private void EnsureCapacity()
    {
        if (Count == _items.Length)
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }
    }
}