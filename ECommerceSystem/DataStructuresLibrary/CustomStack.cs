namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items;
    private const int DefaultCapacity = 4;

    public int Count { get; private set; }

    public CustomStack()
    {
        _items = new T[DefaultCapacity];
        Count = 0;
    }

    //Pushes an item onto the top of the stack.
    public void Push(T item)
    {
        if (Count == _items.Length)
        {
            Resize(_items.Length * 2);
        }

        _items[Count] = item;
        Count++;
    }

    //Removes and returns the top item.
    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        Count--;

        T item = _items[Count];
        _items[Count] = default!;

        return item;
    }

    //Returns the top item without removing it.
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return _items[Count - 1];
    }

    //Searches for an item and returns its one-based depth from the top.
    //Returns -1 if not found.
    public int Search(T item)
    {
        int depth = 1;

        for (int i = Count - 1; i >= 0; i--)
        {
            if (_items[i].CompareTo(item) == 0)
                return depth;

            depth++;
        }

        return -1;
    }

    //Sorts the stack so that the SMALLEST item becomes the TOP item.
    public void Sort()
    {
        //Bubble Sort in descending order.
        //Since the top of the stack is the last element,
        //descending order places the smallest item on top.
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - i - 1; j++)
            {
                if (_items[j].CompareTo(_items[j + 1]) < 0)
                {
                    T temp = _items[j];
                    _items[j] = _items[j + 1];
                    _items[j + 1] = temp;
                }
            }
        }
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];

        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _items[i];
        }

        _items = newArray;
    }
}