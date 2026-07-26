namespace DataStructuresLibrary;

// Represents a custom stack data structure.
public class CustomStack<T> where T : IComparable<T>
{
    // Stores the elements in the stack.
    private T[] _items;

    // Gets the current number of elements in the stack.
    public int Count { get; private set; }

    // Initializes the stack with the specified initial capacity.
    public CustomStack(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }

    // Resizes the internal array when the stack reaches its capacity.
    private void Resize()
    {
        T[] newItems = new T[_items.Length * 2];

        // Copies all existing elements into the new array.
        for (int i = 0; i < Count; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }

    // Adds a new item to the top of the stack.
    public void Push(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    // Removes and returns the top item from the stack.
    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        Count--;
        T item = _items[Count];
        _items[Count] = default!;
        return item;
    }

    // Returns the top item without removing it.
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return _items[Count - 1];
    }

    // Searches for an item and returns its position from the top.
    // Returns -1 if the item is not found.
    public int Search(T item)
    {
        int depth = 1;

        for (int i = Count - 1; i >= 0; i--)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return depth;
            }

            depth++;
        }

        return -1;
    }

    // Sorts the stack in descending order.
    public void Sort()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = i + 1; j < Count; j++)
            {
                if (_items[i].CompareTo(_items[j]) < 0)
                {
                    T temp = _items[i];
                    _items[i] = _items[j];
                    _items[j] = temp;
                }
            }
        }
    }
}