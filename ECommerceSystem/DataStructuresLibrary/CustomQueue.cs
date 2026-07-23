namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    private T[] _items = new T[4];

    public int Count { get; private set; }

   
    public void Enqueue(T item)
    {
       
        if (Count == _items.Length)
        {
            T[] largerArray = new T[_items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                largerArray[i] = _items[i];
            }

            _items = largerArray;
        }

        _items[Count] = item;
        Count++;
    }

   
    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        T frontItem = _items[0];

        
        for (int i = 0; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;
        _items[Count] = default!;

        return frontItem;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        return _items[0];
    }

 
    public bool Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void Sort()
    {
        for (int pass = 0; pass < Count - 1; pass++)
        {
            bool swapped = false;

            for (int i = 0; i < Count - pass - 1; i++)
            {
                if (_items[i].CompareTo(_items[i + 1]) > 0)
                {
                    T temporary = _items[i];
                    _items[i] = _items[i + 1];
                    _items[i + 1] = temporary;

                    swapped = true;
                }
            }

            
            if (!swapped)
            {
                break;
            }
        }
    }
}