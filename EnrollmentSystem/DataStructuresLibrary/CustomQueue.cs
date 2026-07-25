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
            _front = 0;
            _rear = -1;
            _count = 0;
        }
        public void Clear()
        {
            _items = new T[_items.Length];
            _count = 0;
            _front = 0;
            _rear = -1;
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                throw new InvalidOperationException("Queue is full");   
            }

            _rear = (_rear + 1) % _items.Length;
            _items[_rear] = item;
            _count++;
        }

        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T value = _items[_front];
            _front = (_front + 1) % _items.Length;
            _count--;

            return value;
        }

        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is Empty");
            }

            return _items[_front];
        }

        public bool IsEmpty()
        {
            return _count ==0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                int index = (_front + i) % _items.Length;
                if (EqualityComparer<T>.Default.Equals(_items[index], item))
                {
                    return true;
                }
            }
            return false;
        }
    public void Sort()
        {
            var items = new List<T>();
            while (Count > 0)
            {
                items.Add(Dequeue());
            }
            items.Sort();
            
            foreach (var item in items)
            {
                Enqueue(item);
            }
        }
    }
}