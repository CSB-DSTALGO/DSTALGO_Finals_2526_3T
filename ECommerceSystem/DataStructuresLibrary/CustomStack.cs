namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items;
    private const int DefaultCapacity = 4;
    public int Count { get; private set; }

    public CustomStack(int initialCapacity = DefaultCapacity)
    {
        _items = new T[initialCapacity];
        Count = 0;
    }

    //LIFO
    public void Push(T item)
    {
        //add at the top of stack
        if (Count == _items.Length)
        {
            Resize(_items.Length * 2);
        }

        _items[Count] = item;
        Count++;
    }
    public T Pop()
    {
        //remove last element of stack
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        Count--;
        T item = _items[Count];
        _items[Count] = default;

        return item;
    }
    public T Peek()
    {
        //return the last element
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return _items[Count - 1];
    }

    public int Search(T item)
    {
        //search
        for (int i = Count - 1; i >= 0; i--)
        {
            if (Equals(_items[i], item))
            {
                return Count - i;
            }
        }

        return -1;
    }

    //insertion sort
    public void Sort()
    {
        // 0 or 1 item is already sorted
        if (Count <= 1) return;

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

    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _items[i];
        }
        _items = newArray;
    }
}