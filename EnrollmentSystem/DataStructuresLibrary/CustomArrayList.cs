// CustomArrayList.cs
using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T>
    {
        private T[] _items;   // backing array that stores the elements
        private int _count;   // number of elements currently stored

        // Returns how many elements are currently in the list
        public int Count
        {
            get { return _count; }
        }

        // Constructor: starts with a small array of size 4
        public CustomArrayList()
        {
            _items = new T[4];
            _count = 0;
        }

        // Adds an item to the end of the list
        // If the array is full, it grows first (Resize)
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        // Returns the item at the given index
        // Throws an exception if the index is invalid
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");
            }

            return _items[index];
        }

        // Removes the item at the given index
        // Shifts every item after it one spot to the left to fill the gap
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

            _items[_count - 1] = default(T)!; // clear the now-empty last slot
            _count--;
        }

        // Doubles the size of the backing array when it's full
        // Copies all existing items into the new, bigger array
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

        // Linear search: checks each item one by one
        // Returns the index of the first match, or -1 if not found
        // Time complexity: O(n)
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

        // Insertion sort: builds a sorted section one item at a time
        // Takes each item and moves it left until it's in the correct order
        // Uses Comparer<T>.Default so it works with any type that supports comparison
        // Time complexity: O(n^2) worst case, O(n) best case (already sorted)
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