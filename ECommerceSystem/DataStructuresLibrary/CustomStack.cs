namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] items;
    private int capacity;

    public int Count { get; private set; }

    public CustomStack(int initialCapacity = 4)
    {
        capacity = initialCapacity < 1 ? 4 : initialCapacity;
        items = new T[capacity];
        Count = 0;
    }

    public void Push(T item)
    {
        if (Count == capacity)
            Resize(capacity * 2);

        items[Count] = item;
        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        Count--;
        T item = items[Count];
        items[Count] = default!;
        return item;
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return items[Count - 1];
    }

    public int Search(T item)
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            if (items[i].CompareTo(item) == 0)
                return Count - i;
        }
        return -1;
    }

    public void Sort()
    {
        var aux = new CustomStack<T>(capacity);

        while (Count > 0)
        {
            T temp = Pop();

            while (aux.Count > 0 && aux.Peek().CompareTo(temp) > 0)
            {
                Push(aux.Pop());
            }

            aux.Push(temp);
        }

        while (aux.Count > 0)
        {
            Push(aux.Pop());
        }
    }

    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        Array.Copy(items, newArray, Count);
        items = newArray;
        capacity = newCapacity;
    }
}