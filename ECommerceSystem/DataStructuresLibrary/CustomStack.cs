namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items;
    private const int DefaultCapacity = 4;
    public int Count { get; private set; }

    //contructor for intializing the stack with a default capacity
    //if the user wants to specify a different initial capacity, they can do so by passing it as an argument
    public CustomStack(int initialCapacity = DefaultCapacity)
    {
        _items = new T[initialCapacity];
        Count = 0;
    }

    //LIFO
    //push adds an item to the top of the stack
    //pop removes the item from the top of the stack
    public void Push(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        //add at the top of stack
        if (Count == _items.Length)
        {
            Resize(_items.Length * 2); // double the size of the array if it's full
        }

        //add item to the top of stack
        _items[Count] = item;
        Count++; // increment the count
    }

    //pop removes the item from the top of the stack and returns it
    public T Pop()
    {
        //remove last element of stack
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        //decrement the count and return the last item
        Count--;
        T item = _items[Count]; //store the item to return
        _items[Count] = default!; // clear the reference to the popped item

        return item; //return the popped item
    }

    //peek returns the item at the top of the stack without removing it
    public T Peek()
    {
        //return the last element
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty."); // throw an exception if the stack is empty
        }

        return _items[Count - 1]; //return the last item without removing it
    }

    //search returns the position of the item in the stack, counting from the top (1-based index)
    //O(n) time complexity
    public int Search(T item)
    {
        //search 
        for (int i = Count - 1; i >= 0; i--) // iterate from the top of the stack to the bottom
        {
            if (Equals(_items[i], item)) // check if the current item is equal to the searched item
            {
                return Count - i; // return the position from the top of the stack (1-based index)
            }
        }

        return -1; // return -1 if the item is not found
    }

    //insertion sort
    //O(n^2) time complexity
    public void Sort()
    {
        // 0 or 1 item is already sorted
        if (Count <= 1) return;

        for (int i = 1; i < Count; i++) // iterate through the stack starting from the second item
        {
            // Store the current item to be inserted
            T key = _items[i]; // store the current item to be inserted into the sorted portion of the stack
            int j = i - 1; // index of the last item in the sorted portion of the stack

            while (j >= 0 && _items[j].CompareTo(key) < 0)
            {
                _items[j + 1] = _items[j]; // shift the item to the right to make space for the key
                j--; // move to the previous item in the sorted portion of the stack
            }

            _items[j + 1] = key; // insert the key into the correct position in the sorted portion of the stack
        }
    }

    // Resize the internal array to a new capacity
    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity]; // create a new array with the specified capacity
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _items[i]; // copy the existing items to the new array
        }
        _items = newArray; // replace the old array with the new array
    }
}