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

        public int Count // returns the number of items in the queue
        { 
            get { return _count; } 
        }

        public CustomQueue() // creates empty queue with initial capacity of 4
        {
            _items = new T[4];
            _front = 0;
            _rear = 0;
            _count = 0;

        }

        public void Enqueue(T item) // adds an item at the back of the qeueue
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

        public T Dequeue() // removes and returns the item at the fron of the queue
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

        public T Peek() // returns the front item without removing it from the queue
        {
            if (_count == 0) 
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[_front];
        }

        public bool IsEmpty() // checks wheter the queue is empty or not
        {
           return _count == 0;
        }

        private void Resize() // doubles the queue size while maintaining FIFO order
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