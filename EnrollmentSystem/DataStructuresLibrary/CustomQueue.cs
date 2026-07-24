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
            get{return _count;}
        }

        public CustomQueue()
        {
            _items = new T[4];
            _front = 0;
            _rear = 0;
            _count = 0;
        }

        public void Enqueue(T item)
        {
           if (_count == _items.Length)
            {
                Grow();
            }

            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length;
            _count++;   
        }

       public T Dequeue()
       {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Cannot dequeue: the queue is empty.");

        }
        T item = _items[_front];
        _items[_front] = default!;
        _front = (_front + 1) %_items.Length;
        _count--;
        return item;
       }
public T Peek()
        {
        if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek: the queue is empty.");
            }

            return _items[_front];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
        private void Grow()
        {
            T[]biggerArray = new T[_items.Length * 2];
            for (int i = 0; i < _count; i++)
            {
                biggerArray[i] = _items[(_front + i) % _items.Length];
            }
            _items = biggerArray;
            _front = 0;
            _rear = _count;
        }
    }
}
hello 
