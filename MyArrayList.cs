using System;

public class MyArrayList<T>
{
    private T[] items;
    private int count;

    public MyArrayList()
    {
        items = new T[2];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    private void Resize()
    {
        T[] newArray = new T[items.Length * 2];

        for (int i = 0; i < items.Length; i++)
        {
            newArray[i] = items[i];
        }

        items = newArray;
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            Resize();
        }

        items[count] = item;
        count++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        return items[index];
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[count - 1] = default(T);
        count--;
    }
}