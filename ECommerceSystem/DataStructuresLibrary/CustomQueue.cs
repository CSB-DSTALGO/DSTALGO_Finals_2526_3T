namespace DataStructuresLibrary; //LIAM 

public class CustomQueue<T> where T : IComparable<T>
{
    private readonly List<T> _items = new();

    public int Count => _items.Count;

<<<<<<< Updated upstream
=======
    // Adds an item to the rear of the queue.
>>>>>>> Stashed changes
    public void Enqueue(T item)
    {
        _items.Add(item);
    }
<<<<<<< Updated upstream
    public T Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T item = _items[0];
        _items.RemoveAt(0);

        return item;
    }
    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _items[0];
    }
    public bool Search(T item)
    {
        return _items.Contains(item);
    }
    public void Sort()
    {
        _items.Sort();
    }
}
=======

    // Removes and returns the front item (FIFO).
    public T Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T item = _items[0];
        _items.RemoveAt(0);
        return item;
    }

    // Returns the front item without removing it.
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _items[0];
    }

    // Searches the queue for a specific item.
    public bool Search(T item)
    {
        return _items.Contains(item);
    }

    // Sorts the queue in ascending order using Bubble Sort.
    public void Sort()
    {
        for (int i = 0; i < _items.Count - 1; i++)
        {
            for (int j = 0; j < _items.Count - i - 1; j++)
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

>>>>>>> Stashed changes
