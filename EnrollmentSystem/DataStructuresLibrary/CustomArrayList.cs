using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    // Custom implementation of a dynamic array.
    public class CustomArrayList<T>
    {
        private T[] _items;
        private int _count;

        // Returns the number of items.
        public int Count => _count;

        // Creates an empty list.
        public CustomArrayList()
        {
            _items = new T[4];
            _count = 0;
        }

        // Adds an item.
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        // Returns an item by index.
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            return _items[index];
        }

        // Allows list[index].
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }

                return _items[index];
            }

            set
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }

                _items[index] = value;
            }
        }

        // Removes an item.
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

        // Doubles the array size.
        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }

        // Linear search.
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

        // Wrapper for IndexOf().
        public int Search(T item)
        {
            return IndexOf(item);
        }

        // Insertion Sort.
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