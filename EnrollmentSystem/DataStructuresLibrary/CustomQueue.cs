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
            _items = new T[4];
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length) //if our count is equals to the length of our _items
            {
                T[] resize = new T[_items.Length * 2]; //resize by doubling the items.Length
                for (int i = 0; i < _count; i++) //for loop to move items into the newly made resized array
                {
                    resize[i] = _items[(_front + i) % _items.Length]; //copies the queue in order   
                                                                      //starts from the front, then when you reach the end it wraps around
                                                                      //previous implementation copied the empty indexes
                                                                      
                }
                _items = resize;
                _front = 0;
                _rear = _count;
            }
            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No items in queue");
                return default(T);
            }
            T removedItem = _items[_front];
            _front = (_front + 1) % _items.Length;
            _count--;
            return removedItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No items in queue");
                return default(T);
            }
            else
            {
                return _items[_front];
            }

        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        

    }
}