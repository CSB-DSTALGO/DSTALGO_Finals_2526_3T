// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private const int DefaultCapacity = 4;
        private T[] _items;
        private int _top;

        public int Count 
        { 
             get { return _top; } 
        }

        public CustomStack()
        {
            _items = new T[DefaultCapacity];
            _top = 0;
        }

        public void Push(T item)
        {
            if (_top == _items.Length)
            {
                Resize();
            }
            _items[_top] = item;
            _top++;
        }

        public T Pop()
        {
             if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot pop from an empty stack.");
            }

            _top--;
            T item = _items[_top];
            _items[_top] = default!; // release reference so it can be GC'd
            return item;  
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek an empty stack.");
            }

            return _items[_top - 1];
        }

        public bool IsEmpty()
        {
             return _top == 0;
        }
        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }


    }
}