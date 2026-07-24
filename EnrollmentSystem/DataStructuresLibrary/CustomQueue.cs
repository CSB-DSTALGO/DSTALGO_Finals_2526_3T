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
            if(_count == _items.Length)
            {
                Resize();
            }

            _items[_rear++] = item;
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
            _items[_front] = default;
            _front = (_front + 1) % _items.Length;
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

        public int Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                int actualIndex = (_front + i) % _items.Length;
                if (EqualityComparer<T>.Default.Equals(_items[actualIndex], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Sort()
        {
            if (_count <= 1) return;

            T[] temp = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _items[(_front + i) % _items.Length];
            }

            for (int i = 1; i < temp.Length; i++)
            {
                T key = temp[i];
                int j = i - 1;
                while (j >= 0 && Comparer<T>.Default.Compare(temp[j], key) > 0)
                {
                    temp[j + 1] = temp[j];
                    j--;
                }
                temp[j + 1] = key;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                _items[i] = temp[i];
            }

            _front = 0;
            _rear = _count % _items.Length;
        }

        public bool Contains(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));

            for (int i = 0; i < _count; i++)
            {
                int actualIndex = (_front + i) % _items.Length;
                if (match(_items[actualIndex]))
                {
                    return true;
                }
            }

            return false;
        }

        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newItems = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[(_front + i) % _items.Length];
            }

            _items = newItems;
            _front = 0;
            _rear = _count;
        }
    }
}