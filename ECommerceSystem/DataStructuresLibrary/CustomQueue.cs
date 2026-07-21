namespace DataStructuresLibrary
{
    public class CustomQueue<T> where T : IComparable<T>
    {
        public int Count { get; private set; }

        public void Enqueue(T item) => throw new NotImplementedException();
        public T Dequeue() => throw new NotImplementedException();
        public T Peek() => throw new NotImplementedException();

        public bool Search(T item) => throw new NotImplementedException();

        public void Sort() => throw new NotImplementedException();
    }
}