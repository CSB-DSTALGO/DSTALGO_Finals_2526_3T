// CustomStack.cs
using System;

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
            if (_top == _items.Length)
            {
                T[] newItems = new T[_items.Length * 2];

                for (int i = 0; i < _items.Length; i++)
                {
                    newItems[i] = _items[i];
                }

                _items = newItems;
            }

            _items[_top] = item;
            _top++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            _top--;
            return _items[_top];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[_top - 1];
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }
    }
}