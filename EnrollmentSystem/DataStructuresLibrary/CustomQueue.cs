using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T>
    {
        private T[] _items;   
        private int _front;   
        private int _rear;    
        private int _count;   
        private const int DefaultCapacity = 4;

        
        public int Count
        {
            get { return _count; }
        }

        public CustomQueue()
        {
            _items = new T[DefaultCapacity];
            _front = 0;
            _rear = 0;
            _count = 0;
        }

        
        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length; 
            _count++;
        }

       
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot Dequeue: the queue is empty.");
            }

            T item = _items[_front];
            _items[_front] = default!;
            _front = (_front + 1) % _items.Length; 
            _count--;
            return item;
        }

        
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot Peek: the queue is empty.");
            }

            return _items[_front];
        }

        
        public bool IsEmpty()
        {
            return _count == 0;
        }

        
        public T[] ToArray()
        {
            T[] snapshot = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                snapshot[i] = _items[(_front + i) % _items.Length];
            }
            return snapshot;
        }

        
        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];
            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[(_front + i) % _items.Length];
            }
            _items = newArray;
            _front = 0;
            _rear = _count;
        }
    }
}
