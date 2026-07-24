// CustomArrayList.cs
using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T>
    {
        private T[] _items;
        private int _count;

        public int Count => _count;

        public CustomArrayList(int initialCapacity = 4)
        {
            _items = new T[initialCapacity];
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
            {
                throw new IndexOutOfRangeException();
            }

            return _items[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default!;
            _count--;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public int Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Sort()
        {
            for (int i = 1; i < _count; i++)
            {
                var current = _items[i];
                int j = i - 1;

                while (j >= 0 && Comparer<T>.Default.Compare(_items[j], current) > 0)
                {
                    _items[j + 1] = _items[j];
                    j--;
                }

                _items[j + 1] = current;
            }
        }

        private void Resize()
        {
            var doubled = new T[_items.Length * 2];
            Array.Copy(_items, doubled, _items.Length);
            _items = doubled;
        }
    }
}