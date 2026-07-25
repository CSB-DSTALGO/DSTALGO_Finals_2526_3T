// CustomStack.cs
using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

        public int Count 
        { 
            get { return _top; } 
        }

        public CustomStack()
        {
            _items = new T[4];
            _top = 0;
        }

        public void Push(T item)
        {
            if (_top ==_items.Length)
              Resize();
            

           _items[_top] = item;
           _top++;   
        }

        public T Pop()
        {
            if (IsEmpty())
            throw new InvalidOperationException("Stack is Empty.");

            _top--;
            T item = _items[_top];
            _items[_top] = default!;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            throw new InvalidOperationException("Stack is Empty");

            return _items[_top - 1 ];
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }
        public int Search( T item)
        {
            var comparer = EqualityComparer<T>.Default;
            for (int i = _top - 1; i >= 0; i--)
            {
                if (comparer.Equals(_items[i], item))
                return i;
            }
            return -1;
        }

        private void Resize()
        {
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                var newItems = new T[newCapacity];
                Array.Copy(_items, newItems, _top);
                _items = newItems;
            }
            
        }
    }
}