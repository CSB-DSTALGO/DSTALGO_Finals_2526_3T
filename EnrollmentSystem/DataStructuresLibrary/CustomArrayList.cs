// CustomArrayList.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T>
    {
        private T[] _items; // store elements in array
        private int _count; // count

        public int Count
        {
            get { return _count; } // return count of stored elements
        }

        public CustomArrayList() // empty arraylist
        {
            _items = new T[4]; // initial cap
            _count = 0; // starts empty
        }

        public void Add(T item)
        {
            if (_count == _items.Length) // resize
            {
                Resize();
            }

            _items[_count] = item; // store item
            _count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _items[index]; // return the requested item
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            for (int i = index; i < _count - 1; i++) // shift elem to left
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default(T); // clear the last elem
            _count--;
        }

        private void Resize()
        {
            T[] newItems = new T[_items.Length * 2];

            for (int i = 0; i < _count; i++) // copy existing items
            {
                newItems[i] = _items[i];
            }

            _items = newItems; // make _item the reference of the larger array
        }
    }
}