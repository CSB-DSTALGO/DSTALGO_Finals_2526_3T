namespace DataStructuresLibrary;


public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items = new T[4];
    private int _top = -1; 

    public int Count { get; private set; }

    
    public void Push(T item)
    {
        if (_top + 1 == _items.Length)
            Resize();

        _top++;
        _items[_top] = item;
        Count++;
    }

   
    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Cannot pop: the stack is empty.");

        T item = _items[_top];
        _items[_top] = default!;
        _top--;
        Count--;
        return item;
    }

    
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Cannot peek: the stack is empty.");

        return _items[_top];
    }

   
    public int Search(T item)
    {
        for (int i = _top; i >= 0; i--)
        {
            if (_items[i].CompareTo(item) == 0)
                return _top - i + 1;
        }

        return -1;
    }

    
    public void Sort()
    {
        QuickSort(_items, 0, _top);
    }

    private void QuickSort(T[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    private int Partition(T[] arr, int low, int high)
    {
        T pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            
            if (arr[j].CompareTo(pivot) >= 0)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }

   
    private void Resize()
    {
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        T[] newArray = new T[newCapacity];
        Array.Copy(_items, newArray, _items.Length);
        _items = newArray;
    }
}
namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    public int Count { get; private set; }

    public void Push(T item) => throw new NotImplementedException();
    public T Pop() => throw new NotImplementedException();
    public T Peek() => throw new NotImplementedException();

    public int Search(T item) => throw new NotImplementedException();

    public void Sort() => throw new NotImplementedException();
}
