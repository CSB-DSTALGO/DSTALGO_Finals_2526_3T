using System;

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
                Resize();
            _items[_count++] = item;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _items[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // shift elements left
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _count--;
            _items[_count] = default(T); // clear reference for GC
        }

        // SEARCH: Uses standard object.Equals instead of EqualityComparer
        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (object.Equals(_items[i], item))
                    return i;
            }
            return -1;
        }

        // SORT: Uses a manual Bubble Sort instead of Array.Sort with Comparer<T>
        public void Sort(Comparison<T> comparison)
        {
            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = 0; j < _count - i - 1; j++)
                {
                    // If the comparison returns greater than 0, they are out of order
                    if (comparison(_items[j], _items[j + 1]) > 0)
                    {
                        // Swap the items
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }

        private void Resize()
        {
            int newSize = _items.Length == 0 ? 4 : _items.Length * 2;
            T[] newArr = new T[newSize];
            Array.Copy(_items, newArr, _count);
            _items = newArr;
        }
    }
}