// CustomQueue.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T>
    {
        private T[] _items;
        private int _front;
        private int _rear;
        private int _count;

        public int Count 
        { 
            get { return _count; } 
        }

        public CustomQueue()
        {
            _items = new T[10];
            _front  = 0;
            _rear = 0;
            _count = 0;

        }

        public void Enqueue(T item)
        {
            if(_count == _items.Length)
            {
                throw new InvalidOperationException("Queue is full");
            }

            _rear++;
            _items[_rear] = item;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
             
            T item = _items[_front];
            _front++;
            _count--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _items[_front];
        }

        public bool IsEmpty()
        {
           return _count == 0;
        }
    }
}