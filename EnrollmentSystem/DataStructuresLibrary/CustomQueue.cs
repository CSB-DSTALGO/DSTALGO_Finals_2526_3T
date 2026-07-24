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

        public int Count ();
        { 
            get { return _count; } 
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
            if (_count == _items.Length) //increases the array size when full
            {
                Resize();
            }

            _items[_rear] = item; // stores the new item at the rear position

            _rear++;// move the rear forward 

            if (_rear == _items.Length)  // if the rear reaches the end of array, move it back to beginning
            {
                _rear = 0;
            }

            _count++; //increase the number of items in queue
        }

        public T Dequeue()
        {
           if (_count == 0) 
           {
            throw new InvalidOperationException("Queue is empty");
           }

           T removedItem = _items[_front];

           _front++;

           if (_front == _items.Length) 
           {
            _front = 0;
           }

           _count--;

           return removedItem;
        }

        public T Peek()
        {
            if (_count == 0) 
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[_front];
        }

        public bool IsEmpty()
        {
           return _count == 0;
        }

        private void Resize() 
        {
            T[] biggerArray = new T[_items.Length * 2]; //creates a new array with 2x the capacity

            for (int i = 0; i < _count; i++) 
            {
                int oldIndex = _front + i;

                if (oldIndex >= _items.Length) 
                {
                    oldIndex = oldIndex - _items.Length;
                }

                biggerArray[i] = _items[oldIndex];
            }

            _items = biggerArray;

            _front = 0;
            _rear = _count;

        }
    }
}