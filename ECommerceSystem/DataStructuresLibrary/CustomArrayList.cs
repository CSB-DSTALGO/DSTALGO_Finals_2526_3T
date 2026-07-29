using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T> where T : IComparable<T>
    {
        private T[] _items;
        public int Count { get; private set; }

        public CustomArrayList(int initialCapacity = 4)
        {
            _items = new T[initialCapacity];
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count == _items.Length)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
            _items[Count++] = item;
        }

        public bool Remove(T item)
        {
            int index = Search(item);
            if (index == -1) return false;

            for (int i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            Count--;
            return true;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _items[index];
        }

        public int Search(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].CompareTo(item) == 0)
                    return i;
            }
            return -1;
        }

        public void Sort()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - i - 1; j++)
                {
                    if (_items[j].CompareTo(_items[j + 1]) > 0)
                    {
                        // Swap elements
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }

        public void ShowAllItems()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(_items[i]);
            }
        }
    }
}
