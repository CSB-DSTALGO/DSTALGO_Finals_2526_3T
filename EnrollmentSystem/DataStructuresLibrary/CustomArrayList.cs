
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
            _items = new T[4];
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
                throw new IndexOutOfRangeException($"Index {index} is out of range.");

            return _items[index];
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException($"Index {index} is out of range.");

            _items[index] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException($"Index {index} is out of range.");

            for (int i = index; i < _count - 1; i++)
                _items[i] = _items[i + 1];

            _items[_count - 1] = default!;
            _count--;
        }

        private void Resize()
        {
            T[] newItems = new T[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }
    }
}