// CustomArrayList.cs
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
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");
            }

            return _items[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");
            }

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default(T)!;
            _count--;
        }

        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_items[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        // Insertion sort using Comparer<T>.Default (works for any T that implements IComparable)
        public void Sort()
        {
            for (int i = 1; i < _count; i++)
            {
                T key = _items[i];
                int j = i - 1;

                while (j >= 0 && Comparer<T>.Default.Compare(_items[j], key) > 0)
                {
                    _items[j + 1] = _items[j];
                    j--;
                }

                _items[j + 1] = key;
            }
        }
    }
}