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
        if (Count == _items.Length)
        {
            // yan new array 2x the size of the prev array
            T[] newItems = new T[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        // new item = vacant slot/spaceeee
        _items[Count] = item;

        Count++;
    }
    public bool Remove(T item)
    {
        int indexToRemove = -1;
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].Equals(item))
            {
                indexToRemove = i;
                break;
            }
        }

        if (indexToRemove == -1)
        {
            return false;
        }

        for (int i = indexToRemove; i < Count - 1; i++)
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
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        return _items[index];
    }

    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].Equals(item))
            {
                return i; // item found sa part na 2
            }
        }

        return -1; // if not found yet, then return ... :/
    }

    public void Sort() // this ones a bubble sort
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - 1 - i; j++)
            {
                if (_items[j].CompareTo(_items[j + 1]) > 0)
                {
                    // swappp
                    T temp = _items[j];
                    _items[j] = _items[j + 1];
                    _items[j + 1] = temp;
                }
            }
        }
    }
}