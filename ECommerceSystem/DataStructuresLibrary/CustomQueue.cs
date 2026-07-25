using System;

namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    private T[] _items;
    private int _head;
    private int _tail;
    private const int DefaultCapacity = 4;

    public CustomQueue()
    {
        _items = new T[DefaultCapacity];
        _head = 0;
        _tail = 0;
        Count = 0;
    }

    public int Count { get; private set; }

    public void Enqueue(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");
        }

        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        Count--;
        return item;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Cannot peek at an empty queue.");
        }

        return _items[_head];
    }

    public bool Search(T item)
    {
        if (Count == 0 || item == null) return false;

        for (int i = 0; i < Count; i++)
        {
            T current = _items[(_head + i) % _items.Length];
            if (current != null && current.CompareTo(item) == 0)
            {
                return true;
            }
        }
        return false;
    }

    public void Sort()
    {
        if (Count <= 1) return;

        T[] activeItems = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            activeItems[i] = _items[(_head + i) % _items.Length];
        }

        for (int i = 0; i < activeItems.Length - 1; i++)
        {
            for (int j = 0; j < activeItems.Length - i - 1; j++)
            {
                if (activeItems[j].CompareTo(activeItems[j + 1]) > 0)
                {
                    T temp = activeItems[j];
                    activeItems[j] = activeItems[j + 1];
                    activeItems[j + 1] = temp;
                }
            }
        }

        _items = new T[Math.Max(DefaultCapacity, activeItems.Length * 2)];
        for (int i = 0; i < activeItems.Length; i++)
        {
            _items[i] = activeItems[i];
        }

        _head = 0;
        _tail = activeItems.Length;
    }

    private void Resize()
    {
        T[] newArray = new T[_items.Length * 2];
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _items[(_head + i) % _items.Length];
        }
        _items = newArray;
        _head = 0;
        _tail = Count;
    }
}
