// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _count;

        public int Count 
        { 
            get { return _count; } 
        }

        public CustomStack()
        {
            _items = new T[4];
            _count = 0;
        }

        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count] = item;
            _count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
 
            _count--;
            T item = _items[_count];
            _items[_count] = default(T)!;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
 
            return _items[_count - 1];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
        private void Resize()
{
    T[] newItems = new T[_items.Length * 2];
    for (int i = 0; i < _count; i++)
    {
        newItems[i] = _items[i];
    }
    _items = newItems;
}
    }
}