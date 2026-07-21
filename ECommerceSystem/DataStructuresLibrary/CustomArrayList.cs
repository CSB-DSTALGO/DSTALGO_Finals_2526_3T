namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    //Initial Capacity is Set to 4 and the Count is 0
    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
        Count = 0;
    }
    
    //Dynamically Resizes the array when it is full
    //new Array called newItems is created which is a temporary array that copies everything inside the items array
    //_items is updated to reference the new array
    private void Resize()
    {
        T[] tItems = new T[_items.Length * 2]; //create new array with double the length

        for(int i = 0; i < Count; i++)//loop that copies elements in old to new array
        {
            tItems[i] = _items[i];
        }
        _items = tItems; // replace old array with the new array
    }

    //add new element at the end of the _items array
    public void Add(T item)
    {
        //first checks if the max capacity of the array is reached
        if(Count == _items.Length)
        {
            Resize();
        }
        //inserts the new element 
        _items[Count] = item;

        Count++; //increases the number of stored items
    }
    public bool Remove(T item)
    {
        int index = Search(item);//find index of item

        //if item aint found it cant be removed
        if(index == -1)
        {
            return false;
        }

        //shift all elements to the left after one position is cleared
        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[Count - 1] = default!;
        Count--; //reduces the count of array
        return true;

    }
    //find specific element
    public T Get(int index)
    {
        if(index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return _items[index];//return the element of the given index
    }

    //linear search to check each element in the array
    public int Search(T item)
    {
        for(int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return i;
            }
        }
        return -1;
    }

    //bubble sort!
    public void Sort()
    {
        for(int i =0; i < Count - 1; i++)//repeats until sorted
        {
            for(int j = 0; j < Count - i - 1; j++)//compare adjacent elements
            {
                if (_items[j].CompareTo(_items[j + 1]) > 0)//swap if wrong order
                {
                    T temp = _items[j];
                    _items[j] = _items[j + 1];
                    _items[j + 1] = temp;
                }
            }
        }
    }
}