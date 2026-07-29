namespace DataStructuresLibrary
{
    public class CustomStack<T> where T : IComparable<T>
    {
        private readonly List<T> items = new List<T>();
        public int Count { get; private set; }

        public void Push(T item)
        {
            items.Add(item);
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T item = items[Count - 1];

            items.RemoveAt(Count - 1);
            Count--;

            return item;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return items[Count - 1];
        }
        public int Search(T item)
        {
            for (int i = Count - 1, depth = 1; i >= 0; i--, depth++)
            {
                if (items[i].CompareTo(item) == 0)
                {
                    return depth;
                }
            }

            return -1;
        }

        public void Sort()
        {
            items.Sort();
            items.Reverse();
        }
    }
}
