// CustomQueue.cs
using System;
using System.Collections.Generic;

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
            _front = 0;
            _rear = 0;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                T[] newItems = new T[_items.Length * 2];

                for (int i = 0; i < _count; i++)
                {
                    newItems[i] = _items[(_front + i) % _items.Length];
                }

                _items = newItems;
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
                throw new InvalidOperationException("The queue is empty.");
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
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items[_front];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                int currentIndex = (_front + i) % _items.Length;

                if (EqualityComparer<T>.Default.Equals(_items[currentIndex], item))
                {
                    return true;
                }
            }

            return false;
        }

        public void SortDescending()
        {
            T[] sortedItems = new T[_count];

            for (int i = 0; i < _count; i++)
            {
                sortedItems[i] = _items[(_front + i) % _items.Length];
            }

            for (int i = 1; i < sortedItems.Length; i++)
            {
                T currentItem = sortedItems[i];
                int j = i - 1;

                while (j >= 0 &&
                       Comparer<T>.Default.Compare(sortedItems[j], currentItem) < 0)
                {
                    sortedItems[j + 1] = sortedItems[j];
                    j--;
                }

                sortedItems[j + 1] = currentItem;
            }

            for (int i = 0; i < sortedItems.Length; i++)
            {
                _items[i] = sortedItems[i];
            }

            _front = 0;
            _rear = _count % _items.Length;
        }
    }
}