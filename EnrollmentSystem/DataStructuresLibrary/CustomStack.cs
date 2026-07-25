// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

//Number of items currently on the stack
        public int Count 
        { 
            get { return _top; } 
        }
// starts with a small fixed sizearray it will grow automatically via Resize()
        public CustomStack()
        {
            _items = new T[4];
            _top = 0;
        }
//adds an item to the top of the stack
        public void Push(T item)
        {
            if (_top ==_items.Length)
              Resize();
            

           _items[_top] = item;
           _top++;   
        }
// Remove and returns the item on top of the stack
        public T Pop()
        {
            if (IsEmpty())
            throw new InvalidOperationException("Stack is Empty.");

            _top--;
            T item = _items[_top];
            _items[_top] = default!;
            return item;
        }
// rerturns the item on top of the stack without removing it.
        public T Peek()
        {
            if (IsEmpty())
            throw new InvalidOperationException("Stack is Empty");

            return _items[_top - 1 ];
        }
// True if the stack has no items
        public bool IsEmpty()
        {
            return _top == 0;
        }
        // uses linear search to find an item, scanning from the top down
        // Time complexity: O(n)
        public int Search( T item)
        {
            for (int i = _top - 1; i >= 0; i--)
            {
                if (object.Equals(_items[i], item))
            
                return i;
            }
            return -1;
        }
        //doublea the arrays capcity when its full. no built in array.copy
// copied manually to satisft the " no built in collections" requirement
        private void Resize()
        {
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                var newItems = new T[newCapacity];
                for (int i = 0; i < _top; i ++)
                newItems[i] = _items[i];

                _items = newItems;
            }
            
        }
    }
}