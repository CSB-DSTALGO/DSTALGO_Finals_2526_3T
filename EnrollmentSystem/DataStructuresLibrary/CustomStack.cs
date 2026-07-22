// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top; 

        private const int DefaultCapacity = 4;

        public int Count
        {
            get { return _top + 1; }
        }

        public CustomStack()
        {
            _items = new T[DefaultCapacity];
            _top = -1;
        }


        public void Push(T item)
        {
            if (_top + 1 == _items.Length)
            {
                Resize();
            }

            _top++;
            _items[_top] = item;
        }

  
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot Pop: the stack is empty.");
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
                throw new InvalidOperationException("Cannot Peek: the stack is empty.");
            }

            return _items[_top];
        }


        public bool IsEmpty()
        {
            return _top == -1;
        }


        public T[] ToArray()
        {
            T[] snapshot = new T[Count];
            for (int i = 0; i < Count; i++)
            {
     
                snapshot[i] = _items[_top - i];
            }
            return snapshot;
        }


        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];
            for (int i = 0; i < _items.Length; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }
    }
}
