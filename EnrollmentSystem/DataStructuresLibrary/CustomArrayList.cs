// CustomArrayList.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T> where T : IComparable<T> // Added where T : IComparable<T> for easier sort implementation
    {
        private T[] _items;
        private int _count;

        public int Count
        {
            get { return _count; }
           
        }

        public CustomArrayList()
        {
            _items = new T[0];
            _count = 0;
            
        }

        public void Add(T item)
        {
            if (_count == _items.Length) // If Array is Full
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
        public void Set(int index, T item) // Added Set to enable replacement of an element in a specifix index (for Sorting)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            _items[index] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
            
        }

        private void Resize()
        {
            // Increases the array capacity by one intially then multiplied by 2 onwards. 
            int newSize = (_items.Length == 0) ? 1 : _items.Length * 2;

            T[] newItems = new T[newSize];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
           
        }

        public void Sort() // Added sort to enable sort method in StudentRegistry.cs
        {
            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = 0; j < _count - i - 1; j++)
                {
                    if (_items[j].CompareTo(_items[j + 1]) > 0)
                    {
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }

        public int Search(T item) // Added search for search method in StudentRegistry.cs
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}