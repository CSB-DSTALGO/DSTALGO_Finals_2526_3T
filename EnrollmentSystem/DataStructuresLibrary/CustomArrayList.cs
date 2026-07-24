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
            _items = new T[2];
            _count = 0; // Initialize the backing field
        }

        public void Add(T item)
        {
            if (Count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("[ ERROR: Index is out of bounds! ]");
            }
            return _items[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("[ ERROR: Index is out of bounds! ]");
            }

            for (int i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default;
            _count--;
        }

        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }
    }
}