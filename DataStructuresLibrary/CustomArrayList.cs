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
            get
            {
                return _count;
            } 
        }

        public CustomArrayList()
        {
            _items = new T[2];
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
                throw new IndexOutOfRangeException();
            }
            return _items[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < _count - 1; i++)
            {

                _items[i] = _items[i + 1];

            }
            _count--;
            _items[_count] = default(T);
        }

        private void Resize()
        {
            T[] NewArray = new T[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                NewArray[i] = _items[i];
            }
            _items = NewArray;
        }
        public void Set(int index, T item)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }

            _items[index] = item;
        }
    }
}