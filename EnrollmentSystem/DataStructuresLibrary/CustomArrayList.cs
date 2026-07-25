// CustomArrayList.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T>
    {
        private T[] _items;
        private int _count;

        public int Count 
        { 
            get { return _count; }
        }

        public CustomArrayList()
        {
            _items = Array.Empty<T>();
            _count = 0;
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
                Resize();

            _items[_count] = item;
            _count++;
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

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default!;
            _count--;
        }

        private void Resize()
        {
           int newCapacity = _items.Length == 0 ? 1 : _items.Length * 2;
            T[] newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }

        public int IndexOf(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        for (int i = 0; i < _count; i++)
       {
        if (comparer.Equals(_items[i], item))
            return i;
        }
    return -1;
    }

    public void Sort(IComparer<T> comparer)
    {
        if (comparer == null)
        throw new ArgumentNullException(nameof(comparer));

        Array.Sort(_items, 0, _count, comparer);
        }
    }
}