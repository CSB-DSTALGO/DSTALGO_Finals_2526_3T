// CustomArrayList.cs
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

        public CustomArrayList(int capacity = 4)
        {
            _items = new T[capacity];
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
                throw new ArgumentOutOfRangeException(nameof(index));;
            }
            return _items[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));;
            }

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default(T);
            _count--;
        }

        private void Resize()
        {
            if (_count == _items.Length)
            {
                T[] new_items = new T[_items.Length*2];

                for (int i = 0; i < _count; i++)
                {
                    new_items[i] = _items[i];
                }

                _items = new_items;
            }
        }

    }
}