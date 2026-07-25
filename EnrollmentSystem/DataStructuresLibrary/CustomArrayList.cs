using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList
    {
        private T[] _items;
        private int _count;
        private const int DefaultCapacity = 4;
    }

    public int Count
    {
        get { return _count; }
    }

    public CustomArrayList()
    {
        _items = new T[DefaultCapacity];
        _count = 0;
    }

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }
        _items[_count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index));
        return _items[index];
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index));

        int shiftStart = index + 1;
        if (shiftStart < _count)
        {
            Array.Copy(_items, shiftStart, _items, index, _count - shiftStart);
        }
        _items[--_count] = default!;
    }

    private void Resize()
    {
        int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
