namespace DataStructuresLibrary
{
    public class CustomSinglyLinkedList<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data;
            public Node? Next;
            public Node(T data) => Data = data;
        }

        private Node? _head;
        public int Count { get; private set; }

        public void Add(T item) => throw new NotImplementedException();
        public bool Remove(T item) => throw new NotImplementedException();

        public bool Search(T item) => throw new NotImplementedException();


        public void Sort() => throw new NotImplementedException();
    }
}