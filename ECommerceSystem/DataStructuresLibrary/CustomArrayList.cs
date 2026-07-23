namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    public void Add(T item)
    {
        // parking lot is full, need a bigger lot before we can park this one
        if (Count == _items.Length)
        {
            Grow();
        }

        _items[Count] = item;
        Count++;
    }

    private void Grow()
    {
        // just doubling the size, same idea as List<T> under the hood
        T[] biggerLot = new T[_items.Length == 0 ? 4 : _items.Length * 2];

        for (int i = 0; i < Count; i++)
        {
            biggerLot[i] = _items[i];
        }

        _items = biggerLot;
    }

    public bool Remove(T item)
    {
        int index = Search(item);

        // -1 means we never found it, nothing to remove
        if (index == -1)
        {
            return false;
        }

        // shift everything after the removed spot one slot to the left
        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;
        return true;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is out of range. Count is {Count}.");
        }

        return _items[index];
    }

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

    public void Sort()
    {
        // basic bubble sort, fine for this ADT's scale
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - 1 - i; j++)
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