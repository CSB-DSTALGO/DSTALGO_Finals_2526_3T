// CustomArrayList.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T>
    {
        private T[] _items;
        private int _count;

        public int Count => _count;

        public CustomArrayList()
        {
            _items = new T[4];
            _count = 0;
        }

        public void Add(T item)
        {
            if (_count == _items.Length) //if array is full
            {
                Resize();
            }
            _items[_count] = item; //adds item to the next available slot
            _count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
            return _items[index]; //retrieves item at specific index
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count) throw new IndexOutOfRangeException();

            for (int i = index; i < _count - 1; i++) //Changes all subsequent elements to the left
            {
                _items[i] = _items[i + 1];
            }
            _items[_count - 1] = default!; //Clears the duplicated last slot
            _count--;
        }

        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2]; //Double the size
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }

        //Insertion Sort
        //Builds a sorted array one element at a time by shifting larger items to the right.

        public void Sort(Comparison<T> comparison)
        {
            for (int i = 1; i < _count; i++)
            {
                T key = _items[i];
                int j = i - 1;

                while (j >= 0 && comparison(_items[j], key) > 0) //if left item is greater, shift it right
                {
                    _items[j + 1] = _items[j];
                    j = j - 1;
                }
                _items[j + 1] = key; //drop the key into its correct sorted position
            }
        }

        //Linear Search
        //Scans the array sequentially from index 0 up to _count.
        public T? Search(Func<T, bool> match)
        {
            for (int i = 0; i < _count; i++) //loops through active items only
            {
                if (match(_items[i])) return _items[i]; //eturns if match is found
            }
            return default;
        }
    }
}