namespace DataStructuresLibrary;


public class CustomQueue<T> where T : IComparable<T>
{
    private T[] _items = new T[4];
    private int _front;
    private int _rear = -1;

    public int Count { get; private set; }

    
    public void Enqueue(T item)
    {
        if (Count == _items.Length)
            Resize();

        _rear = (_rear + 1) % _items.Length; 
        _items[_rear] = item;
        Count++;
    }

    
    public T Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Cannot dequeue: the queue is empty.");

        T item = _items[_front];
        _items[_front] = default!;
        _front = (_front + 1) % _items.Length;
        Count--;
        return item;
    }

   
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Cannot peek: the queue is empty.");

        return _items[_front];
    }

  
    public bool Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            int idx = (_front + i) % _items.Length;
            if (_items[idx].CompareTo(item) == 0)
                return true;
        }

        return false;
    }

   
    public void Sort()
    {
        if (Count < 2) return;

        T[] temp = new T[Count];
        for (int i = 0; i < Count; i++)
            temp[i] = _items[(_front + i) % _items.Length];

        for (int i = 0; i < Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < Count; j++)
            {
                if (temp[j].CompareTo(temp[minIndex]) < 0)
                    minIndex = j;
            }

            (temp[i], temp[minIndex]) = (temp[minIndex], temp[i]);
        }

        for (int i = 0; i < Count; i++)
            _items[i] = temp[i];

        _front = 0;
        _rear = Count - 1;
    }

    
    private void Resize()
    {
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        T[] newArray = new T[newCapacity];

        for (int i = 0; i < Count; i++)
            newArray[i] = _items[(_front + i) % _items.Length];

        _items = newArray;
        _front = 0;
        _rear = Count - 1;
    }
}
namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    public int Count { get; private set; }

    public void Enqueue(T item) => throw new NotImplementedException();
    public T Dequeue() => throw new NotImplementedException();
    public T Peek() => throw new NotImplementedException();

    public bool Search(T item) => throw new NotImplementedException();

    public void Sort() => throw new NotImplementedException();
}
