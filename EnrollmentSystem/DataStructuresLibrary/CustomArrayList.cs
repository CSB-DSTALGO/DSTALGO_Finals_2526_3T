// 12521269 Joaquin Bryan G. Ross
// CustomArrayList.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T> where T : IComparable<T>
    {
        private T[] _items;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        // Starts with a small array. Resize doubles it whenever it fills up.
        public CustomArrayList()
        {
            _items = new T[4];
            _count = 0;
        }

        // Amortised O(1). The write itself is constant, and the doubling in
        // Resize happens rarely enough to average out to a constant cost.
        public void Add(T item)
        {
            if (_count == _items.Length) Resize();
            _items[_count] = item;
            _count++;
        }

        // O(1). Computing the slot address directly is what an array list is for.
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is outside the list of {_count} item(s).");

            return _items[index];
        }

        // O(n), since every item after the removed slot shifts one place left
        // to close the gap.
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is outside the list of {_count} item(s).");

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _count--;
            _items[_count] = default!; // release the duplicate reference in the vacated slot
        }

        // Linear search. Returns the zero-based position of the item, or -1 if
        // it is not in the list.
        public int Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_items[i], item)) return i;
            }

            return -1;
        }

        // Insertion sort, ascending by CompareTo. Stable, sorts in place, and
        // runs in O(n) on nearly sorted input, which suits a registry that is
        // mostly appended to.
        public void Sort()
        {
            for (int i = 1; i < _count; i++)
            {
                T key = _items[i];
                int j = i - 1;

                while (j >= 0 && _items[j].CompareTo(key) > 0)
                {
                    _items[j + 1] = _items[j];
                    j--;
                }

                _items[j + 1] = key;
            }
        }

        private void Resize()
        {
            T[] larger = new T[_items.Length * 2];

            for (int i = 0; i < _count; i++)
            {
                larger[i] = _items[i];
            }

            _items = larger;
        }
    }
}
