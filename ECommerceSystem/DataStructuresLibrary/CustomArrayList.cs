namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        //if someone declares 0 or a negative number, we will use 1 instead
        //doing so we will always start with a usable array
        if (initialCapacity < 1)
        {
            initialCapacity = 1;
        }
        _items = new T[initialCapacity];
    }

    //when the array is full, we will implement this method 
    //this allows to make a bigger one and can copy everything 
    private void Resize()
    {
        int newCapacity;
        if (_items.Length == 0)
        {
            newCapacity = 4;
        }
        else
        {
            newCapacity = _items.Length * 2;
        }

        T[] newArray = new T[newCapacity];
        Array.Copy(_items, newArray, Count);
        _items = newArray;
    }

    //now we add a new item to the end of the list
    public void Add(T item)
    {
        //adding an if statement if there is no more room, this if statement can use Resize to make it bigger
        if (Count == _items.Length)
        {
            Resize();
        }
        _items[Count] = item;
        Count++;
    }

    //This finds an item and removes it from the list
    public bool Remove(T item)
    {
        int index = Search(item);
        if (index == -1)
        {
            //if item was not on the list then we simply return false
            return false;
        }

        //using this for loop will make us move every item one spot to the left
        //this fills the gap left by the removed item
        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        //clear out the last slot since it's now a duplicate
        _items[Count - 1] = default!;
        Count--;
        return true;
    }

    //using this get method we can get an item at a specific spot in the list
    public T Get(int index)
    {
        //creating this loops checks if the index we are asking for exists
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException("Index " + index + " is out of range.");
        }
        return _items[index];
    }

    //this lets people use an indexer to grab an item
    //this method is the same as calling Get()
    public T this[int index]
    {
        get
        {
            return Get(index);
        }
    }

    //this searches through the list one by one until we find a match
    //returns the spot it is currently at
    //returns -1 if it is not there
    public int Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].CompareTo(item) == 0)
            {
                return i;
            }
        }
        return -1;
    }

    //put the list in order using insertion sort
    //this sorts each item one at a time 
    public void Sort()
    {
        for (int i = 1; i < Count; i++)
        {
            T key = _items[i];
            int j = i - 1;

            //slides bigger items to the right
            while (j >= 0 && _items[j].CompareTo(key) > 0)
            {
                _items[j + 1] = _items[j];
                j--;
            }

            //drops key into the empty spot we made
            _items[j + 1] = key;
        }
    }
}