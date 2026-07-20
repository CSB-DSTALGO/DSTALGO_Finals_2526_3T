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