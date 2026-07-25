// CustomArrayList.cs
using System;
using System.Collections.Generic; // needed only for EqualityComparer<T>, not for any banned collection types

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
                throw new IndexOutOfRangeException("That index does not exist in the list.");
            }
            return _items[index];
        }

        public void Set(int index, T item)
{
    if (index < 0 || index >= _count)
    {
        throw new IndexOutOfRangeException("That index does not exist in the list.");
    }
    _items[index] = item;
}
        public void RemoveAt(int index)
        {
           if (index < 0 || index >= _count)
            {
               throw new IndexOutOfRangeException("That index does not exist in the list."); 
            }
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
        }

        public int Search(T item)
{
    var comparer = System.Collections.Generic.EqualityComparer<T>.Default;
    for (int i = 0; i < _count; i++)
    {
        if (comparer.Equals(_items[i], item))
        {
            return i;
        }
    }
    return -1;
}

public void Sort(Comparison<T> comparison)
{
    // Insertion sort using a caller-supplied comparison delegate,
    // so StudentRegistry can sort by GPA without CustomArrayList
    // needing to know what "GPA" is.
    for (int i = 1; i < _count; i++)
    {
        T key = _items[i];
        int j = i - 1;
        while (j >= 0 && comparison(_items[j], key) > 0)
        {
            _items[j + 1] = _items[j];
            j--;
        }
        _items[j + 1] = key;
    }
}

        private void Resize()
        {
           T[] biggerArray = new T[_items.Length * 2];
           for (int i = 0; i < _items.Length; i++)
            {
                biggerArray[i] = _items[i];
            }
            _items = biggerArray;
        }
    }
}