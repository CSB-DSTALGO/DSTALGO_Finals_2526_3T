namespace DataStructuresLibrary; //LIAM

public class CustomQueue<T> where T : IComparable<T>
{
    private T[] items;
    private int front;
    private int rear;
    private int count;


    //Initializes queue starting w 4
    public CustomQueue()
    {
        items = new T[4];
        front = 0;
        rear = 0;
        count = 0;
    }

    public int Count => count;

    // Adds item to the rear of the queue
    public void Enqueue(T item)
    {
        if (count == items.Length)
        {
            Resize();
        }

        items[rear] = item;
        rear = (rear + 1) % items.Length;
        count++;
    }

    // Removes and returns the front item
    public T Dequeue()
    {
        if (count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T item = items[front];
        front = (front + 1) % items.Length;
        count--;

        return item;
    }

    // Returns the front item without removing it
    public T Peek()
    {
        if (count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return items[front];
    }

    // Searches the queue for a specific item
    public bool Search(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[(front + i) % items.Length].CompareTo(item) == 0)
                return true;
        }

        return false;
    }

    // Sorts the queue in ascending order using Bubble Sort
    public void Sort()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                int first = (front + j) % items.Length;
                int second = (front + j + 1) % items.Length;

                if (items[first].CompareTo(items[second]) > 0)
                {
                    T temp = items[first];
                    items[first] = items[second];
                    items[second] = temp;
                }
            }
        }
    }

    // Doubles the size of the array when it becomes full
    private void Resize()
    {
        T[] newItems = new T[items.Length * 2];

        for (int i = 0; i < count; i++)
        {
            newItems[i] = items[(front + i) % items.Length];
        }

        items = newItems;
        front = 0;
        rear = count;
    }
}

