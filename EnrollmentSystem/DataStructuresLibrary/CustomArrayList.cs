// CustomArrayList.cs
using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    // Custom implementation of a dynamic array.
    public class CustomArrayList<T>
    {
        // Backing array that stores the elements.
        private T[] _items;

        // Tracks the number of elements currently stored.
        private int _count;

        // Returns the number of elements in the list.
        public int Count
        {
            get { return _count; }
        }

        // Initializes the list with a default capacity of 4.
        public CustomArrayList()
        {
            _items = new T[4];
            _count = 0;
        }

        // Adds an item to the end of the list.
        // Automatically resizes the array when it becomes full.
        // Time Complexity: O(1) average, O(n) when resizing.
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        // Returns the item at the specified index.
        // Throws an exception if the index is invalid.
        // Time Complexity: O(1)
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");
            }

            return _items[index];
        }

        // Removes the element at the specified index.
        // Shifts all succeeding elements one position to the left.
        // Time Complexity: O(n)
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

            // Clear the unused last slot.
            _items[_count - 1] = default(T)!;
            _count--;
        }

        // Doubles the capacity of the backing array.
        // Copies all existing elements into the new array.
        // Time Complexity: O(n)
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

        // Performs a linear search for the specified item.
        // Returns the index if found; otherwise returns -1.
        // Time Complexity: O(n)
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

        // Wrapper method required by the unit tests.
        // Calls IndexOf() to locate the specified item.
        public int Search(T item)
        {
            return IndexOf(item);
        }

        // Sorts the elements in ascending order using insertion sort.
        // Time Complexity: O(n²) worst case, O(n) best case.
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