namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private readonly CustomArrayList<T> _items = new();

    public int Count => _items.Count;

    public void Push(T item)
    {
        //Adds a new element to the top of the stack
        _items.Add(item);
    }
   
    public T Pop()
    {
        //Remves an element from the top of the stack
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        T item = _items.Get(Count - 1);

        if (!_items.Remove(item))
            throw new InvalidOperationException("Unable to remove item.");

        return item;
    }

    public T Peek()
    {
        //Returns the element at the top of the stack without removing it
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return _items.Get(Count - 1);
    }

    
    public int Search(T item)
    {
        //Searches for an element
        int index = _items.Search(item);

        if (index == -1)
            return -1;

        return Count - index;
    }

    public void Sort()
    {
        // Reverse the order so the smallest value becomes the top of the stack.
        _items.Sort();    
        CustomArrayList<T> temp = new();

        for (int i = Count - 1; i >= 0; i--)
        {
            temp.Add(_items.Get(i));
        }

        while (Count > 0)
        {
            _items.Remove(_items.Get(0));
        }

        for (int i = 0; i < temp.Count; i++)
        {
            _items.Add(temp.Get(i));
        }
    }
}