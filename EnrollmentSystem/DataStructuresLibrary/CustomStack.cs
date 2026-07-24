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
            get { get _top; } 
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
            throw new InvalidOperationException9("Stack is Empty.");

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
    }
}