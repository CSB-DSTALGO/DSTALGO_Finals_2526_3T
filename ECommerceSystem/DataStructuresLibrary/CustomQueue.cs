namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    // Array used to store the queue items
    private T[] _items = new T[4];

    // Number of items currently in the queue
    public int Count { get; private set; }

    // Adds an item to the back of the queue
    public void Enqueue(T item)
    {
        // Checks if the array is full
        if (Count == _items.Length)
        {
            // Creates a new array with twice the capacity
            T[] largerArray = new T[_items.Length * 2];

            // Copies the items to the larger array
            for (int i = 0; i < Count; i++)
            {
                largerArray[i] = _items[i];
            }

            _items = largerArray;
        }

        // Places the new item at the back
        _items[Count] = item;
        Count++;
    }

    // Removes and returns the item at the front
    public T Dequeue()
    {
        // Prevents removal when the queue is empty
        if (Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Saves the front item before removing it
        T frontItem = _items[0];

        // Moves the remaining items forward
        for (int i = 0; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;

        // Clears the unused array position
        _items[Count] = default!;

        return frontItem;
    }

    // Returns the front item without removing it
    public T Peek()
    {
        // Prevents viewing an item when the queue is empty
        if (Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        return _items[0];
    }

    // Searches for an item in the queue
    public bool Search(T item)
    {
        // Checks each item until a match is found
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return true;
            }
        }

        return false;
    }

    // Sorts the queue items in ascending order
    public void Sort()
    {
        // Repeats the sorting process for every item
        for (int pass = 0; pass < Count - 1; pass++)
        {
            bool swapped = false;

            // Compares neighboring items
            for (int i = 0; i < Count - pass - 1; i++)
            {
                if (_items[i].CompareTo(_items[i + 1]) > 0)
                {
                    // Swaps items that are in the wrong order
                    T temporary = _items[i];
                    _items[i] = _items[i + 1];
                    _items[i + 1] = temporary;

                    swapped = true;
                }
            }

            // Stops when the queue is already sorted
            if (!swapped)
            {
                break;
            }
        }
    }
}