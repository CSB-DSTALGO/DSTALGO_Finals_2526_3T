// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

        public int Count => _top;

        public CustomStack(int initialCapacity = 4)
        {
            _items = new T[initialCapacity];
            _top = 0;
        }

        public void Push(T item)
        {
            if (_top == _items.Length)
            {
                Resize();
            }

            _items[_top++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _items[--_top];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _items[_top - 1];
        }

        public bool IsEmpty() => _top == 0;

        private void Resize()
        {
            var doubled = new T[_items.Length * 2];
            Array.Copy(_items, doubled, _items.Length);
            _items = doubled;
        }
    }
}