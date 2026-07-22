// CustomQueue.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T> where T : IComparable<T>
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
            //Constructor
            _items = new T[4]; //size
            _front = 0;
            _rear =  0;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if(_count == _items.Length)
            {
                // Resize the array if it's full
                T[] temp = new T[_items.Length * 2];
                Array.Copy(_items, _front, temp, 0, _count);
                _items = temp;
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
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = _items[_front];
            _front = (_front + 1) % _items.Length;  //wrap around
            _count --;
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

        public void Sort()
        {
            int n = _count;
            bool swapped;

            for(int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for(int j = 0; j < n - i - 1; j++)
                {
                    if(_items[j].CompareTo(_items[j + 1]) > 0)
                    {
                        T temp = _items[j];
                        _items[j] = _items[j +1];
                        _items[j + 1] = temp;

                        swapped = true;
                    }
                }

                if(!swapped)
                {break;}
            }
            
        }

        public bool Search(T item)
        {
            int n = _count;

            for(int i = 0; i < n ; i++)
            {
                int ai = (_front + i) % _items.Length;

                if(_items[ai].CompareTo(item)==0)
                    {
                        return true;
                    }

            }

            return false;
        }
    }
}