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
            get { return _top + 1; }
        }

        public CustomStack()
        {
            _items = new T[4];
            _top = -1;
        }

        public void Push(T item)
        {
            if (Count == _items.Length)
            {
                Grow();
            }

            _items[++_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot pop: the stack is empty.");
            }

            T item = _items[_top];
            _items[_top] = default!;
            _top--;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek: the stack is empty.");
            }

            return _items[_top];
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        private void Grow()
        {
            T[] biggerArray = new T[_items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                biggerArray[i] = _items[i];
            }

            _items = biggerArray;
        }
    }
}