 public int Search(T item)
        {
            for (int i = _top; i >= 0; i--)
            {
                if (Equals(_items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Sort()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new InvalidOperationException("Type must implement IComparable.");

            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - i - 1; j++)
                {
                    IComparable current = (IComparable)_items[j]!;

                    if (current.CompareTo(_items[j + 1]) > 0)
                    {
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }
    }
}
