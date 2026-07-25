namespace DataStructuresLibrary
{
    public class CustomArrayList
    {
        private T[] _items;
        private int _count;
    public int Count
    {
        get { return _count; }
    }

    public CustomArrayList()
    {
        _items = new T[4];
        _count = 0;
    }

    public void Add(T item)
    {
        if (_count == _items.Length)
            Resize();
        _items[_count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index));
        return _items[index];
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index));

        // shift elements left
        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _count--;
        _items[_count] = default(T); // clear reference for GC
    }

    private void Resize()
    {
        int newSize = _items.Length == 0 ? 4 : _items.Length * 2;
        T[] newArr = new T[newSize];
        Array.Copy(_items, newArr, _count);
        _items = newArr;
    }
}
