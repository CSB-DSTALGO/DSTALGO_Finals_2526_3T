// CustomArrayList.cs
namespace DataStructuresLibrary
{
    public interface ICustomArrayList<T>
    {
        int Count { get; }

        void Add(T item);
        T Get(int index);
        void RemoveAt(int index);
    }
}