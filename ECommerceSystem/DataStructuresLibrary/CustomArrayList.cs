using System;
using System.Collections.Specialized;

namespace DataStructuresLibrary;

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
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    public bool Remove(T item)
    {   
        int index = Count;
        
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].Equals(item))
            {
                index = i; 
                break;
            }
        }

        //if the item is not within the array
        if (index == Count)
        {
            throw new ArgumentOutOfRangeException("Item not found");
        }

        for (int i = index; i < Count - 1 ; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[Count - 1] = default;
        Count--;

        return true;

    }
    public T Get(int index)
    { 
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return _items[index]; 
    }

    public void Resize()
    {
        int Resize = _items.Length * 2;
        T[] newArray = new T[Resize];

        for(int i = 0; i < Count;  i++)
        {
            newArray[i] = _items[i];
        }

        _items = newArray;
    }
   
    public int Search(T item)//linear search
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
                return i;
        }

        return -1;
    }

    public void Sort() //insertion algorithm
    {
        for (int i = 1; i < Count ; i++)
        {
            T key = _items[i];
            int j = i - 1;

            while(j >= 0 && _items[j].CompareTo(key) > 0)
            {
                _items[j+1] = _items[j];
                j = j - 1;
            }

            _items[j + 1] = key;
        }
    }
}