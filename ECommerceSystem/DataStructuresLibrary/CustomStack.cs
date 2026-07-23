namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items;
    private const int DefaultCapacity = 4;
    public int Count { get; private set; }

    //contructor for intializing the stack with a default capacity
    //if the user wants to specify a different initial capacity, they can do so by passing it as an argument
    public CustomStack(int initialCapacity = DefaultCapacity)
    {
        _items = new T[initialCapacity];
        Count = 0;
    }

    //LIFO
    //push adds an item to the top of the stack
    //pop removes the item from the top of the stack
    public void Push(T item)
    {
        //add at the top of stack
        if (Count == _items.Length)
        {
            Resize(_items.Length * 2);
        }

        //add item to the top of stack
        _items[Count] = item;
        Count++;
    }

    //pop removes the item from the top of the stack and returns it
    public T Pop()
    {
        //remove last element of stack
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        //decrement the count and return the last item
        Count--;
        T item = _items[Count];
        _items[Count] = default;

        return item;
    }

    //peek returns the item at the top of the stack without removing it
    public T Peek()
    {
        //return the last element
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return _items[Count - 1];
    }

    //search returns the position of the item in the stack, counting from the top (1-based index)
    //O(n) time complexity
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
    //O(n^2) time complexity
    public void Sort()
    {
        // 0 or 1 item is already sorted
        if (Count <= 1) return;

        for (int i = 1; i < Count; i++)
        {
            // Store the current item to be inserted
            T key = _items[i];
            int j = i - 1;

            while (j >= 0 && _items[j].CompareTo(key) < 0)
            {
                _items[j + 1] = _items[j];
                j--;
            }

            _items[j + 1] = key;
        }
    }

    // Resize the internal array to a new capacity
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