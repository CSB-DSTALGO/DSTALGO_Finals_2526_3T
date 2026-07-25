using System;
using System.Collections.Generic;

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
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            return _items[index];
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            _items[index] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default!;
            _count--;
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
            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = 0; j < _count - i - 1; j++)
                {
                    if (Comparer<T>.Default.Compare(_items[j], _items[j + 1]) > 0)
                    {
                        T temporary = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temporary;
                    }
                }
            }
        }
        private void Resize()
        {
            T[] newItems = new T[_items.Length * 2];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }
    }
}
