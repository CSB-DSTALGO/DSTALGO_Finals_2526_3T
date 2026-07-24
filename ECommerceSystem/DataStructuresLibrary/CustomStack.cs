namespace DataStructuresLibrary
{
<<<<<<< Updated upstream
    private class Node
    {
        public T Data;
        public Node? Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node? top;

    public int Count { get; private set; }

    public void Push(T item)
    {
        Node newNode = new Node(item);
        newNode.Next = top;
        top = newNode;
        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        T item = top!.Data;
        top = top.Next;
        Count--;

        return item;
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return top!.Data;
    }

    public int Search(T item)
    {
        Node? current = top;
        int position = 1;

        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
                return position;

            current = current.Next;
            position++;
        }

        return -1;
    }

    public void Sort()
    {
        if (Count <= 1)
            return;

        bool swapped;

        do
        {
            swapped = false;
            Node? current = top;

            while (current != null && current.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }

                current = current.Next;
            }

        } while (swapped);
    }
}
=======
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
>>>>>>> Stashed changes
