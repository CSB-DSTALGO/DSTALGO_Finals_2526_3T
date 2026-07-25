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

        public int Search(T item, Func<T, T, bool> comparer) 
        {
            for (int i = 0; i < _count; i++) // search through the array for a matching item
            {
                if (comparer(_items[i], item)) // item found
                {
                    return i; // return index of the matching item
                }
            }

            return -1; // item not found
        }

        public void Sort(Func<T, T, bool> shouldSwap)
        {
            for (int i = 0; i < _count - 1; i++) // bubble sort the array based on the given condition
            {
                for (int j = 0; j < _count - i - 1; j++)
                {
                    if (shouldSwap(_items[j], _items[j + 1])) // swap if out of order
                    {
                        T temp = _items[j]; // store current item
                        _items[j] = _items[j + 1]; // move next item left
                        _items[j + 1] = temp; // place stored item to the right
                    }
                }
            }
        }
    }
}