using System;
 
namespace DataStructuresLibrary
{
    public class CustomArrayList<T>
    {
        private T[] _items;
        private int _count;
 
        public CustomArrayList(int initialCapacity = 4)
        {
            if (initialCapacity < 1) initialCapacity = 4;
            _items = new T[initialCapacity];
            _count = 0;
        }
 
      
        public int Count => _count;
 
       
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count] = item;
            _count++;
        }
 
      
        public void RemoveAt(int index)
        {
            ValidateIndex(index);
 
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
 
            _items[_count - 1] = default!; // clear the now-unused last slot
            _count--;
        }
 
        /// Returns the item at the given index
        public T GetAt(int index)
        {
            ValidateIndex(index);
            return _items[index];
        }
 
        /// Replaces the item at the given index.
        public void SetAt(int index, T value)
        {
            ValidateIndex(index);
            _items[index] = value;
        }
 
        
        /// Returns a snapshot array of exactly Count length (no unused trailing slots).
        /// Used for printing, sorting, and searching.
   
        public T[] ToArray()
        {
            T[] result = new T[_count];
            Array.Copy(_items, result, _count);
            return result;
        }
 
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException($"Index {index} is out of range. Valid range: 0 to {_count - 1}.");
        }
 
        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }
    }
}
 