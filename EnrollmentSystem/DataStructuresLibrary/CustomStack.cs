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
            get => _top;
        }

        public CustomStack()
        {
            _items = new T[2]; //initial capacity
        }

        public void Push(T item)
        {
            //inline expansion when array capacity is reached
            if (_top == _items.Length)
            {
                T[] newArray = new T[+_items.Length * 2];
                for (int i = 0; i < _top; i++)
                {
                    newArray[i] = _items[i];
                }
                _items = newArray;
            }
            _items[_top] = item;
            _top++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("[ ERROR: Stack is empty! ]");
            }
            _top--;
            T item = _items[_top];
            _items[_top] = default;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("[ ERROR: Stack is empty! ]");
            }

            return _items[_top - 1];
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }
    }
}