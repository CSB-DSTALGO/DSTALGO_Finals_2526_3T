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
        if (Count == 0)
        {
            throw new ArgumentOutOfRangeException("Item not found");
        }

        for (int i = index; i < Count - 1 ; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;

        return true;

    }
    public T Get(int index)
    { 
        if (index < 0 || index >= _items.Length)
        {
            throw new IndexOutOfRangeException();
        }
        return _items[index]; 
    }

    public void Resize () //added a function for resizing of arraylist
    {

    }

    public int Search(T item)//binary search
    {
        int left = 0;
        int right = _items.Length - 1;  

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int compare = _items[mid].CompareTo(item);

            if(compare == 0)
            {
                return mid;
            }
            else if (compare < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1; //returns if the index is not found
    }

    public void Sort() //insertion algorithm
    {
        for (int i = 0; i < Count ; i++)
        {
            T key = _items[i];
            int j = i - 1;

            while(j >= 0 && _items[i].CompareTo(key) > 0)
            {
                _items[j+1] = _items[j];
                j = j - 1;
            }

            _items[j + 1] = key;
        }
    }
}