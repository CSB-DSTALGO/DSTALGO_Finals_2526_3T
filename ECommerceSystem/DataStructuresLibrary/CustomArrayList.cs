namespace DataStructuresLibrary;

public class CustomArrayList<T> where T : IComparable<T>
{
    private T[] _items;
    public int Count { get; private set; }

    public CustomArrayList(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
    }


    public void Add(T item) => throw new NotImplementedException();
    public bool Remove(T item) => throw new NotImplementedException();
    public T Get(int index) => throw new NotImplementedException();


    public int Search(T item) => throw new NotImplementedException();


    public void Sort() => throw new NotImplementedException();
}