namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items; // array that stores the data and it initially contains empty values
    public int Count { get; private set; } // stores how many elements are being used

    public CustomArrayList(int initialCapacity = 4) // when the var list is created it will have 4 slots
    {
        _items = new T[initialCapacity];
    }

    //  adds an item to the end of the list
    public void Add(T item) // pag na call si list.Add
    {
        if (Count == _items.Length)
        {
            T[] newArray = new T[_items.Length * 2]; // when full this makes bigger array so if 4 * 2 = 8

            for (int i = 0; i < Count; i++) // this puts the old array to da new bcuz it  copies it
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }

        _items[Count] = item;
        Count++;
    }

    // removes the first occurrence of the item
    public bool Remove(T item)
    {
        int index = Search(item);

        if (index == -1)
            return false;

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;
        _items[Count] = default!;

        return true;
    }

    // returns the item at the specified index
    public T Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return _items[index];
    }

    // returns the index of an item
    public int Search(T item)
    {
        for (int i = 0; i < Count; i++) // checks 1 by 1
        {
            if (_items[i].CompareTo(item) == 0)
                return i;
        }

        return -1;
    }

    // i used bubble sort
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