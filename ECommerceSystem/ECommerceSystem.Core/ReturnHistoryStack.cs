namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _stack = new();

    public int Count => _stack.Count;

    public void PushReturn(ReturnRequest request)
    {
        _stack.Push(request);
    }

    public ReturnRequest PopReturn()
    {
        return _stack.Pop();
    }

    public ReturnRequest PeekLatestReturn()
    {
        return _stack.Peek();
    }

    // change return type to int to match unit tests
    public int SearchReturn(ReturnRequest request)
    {
        return _stack.Search(request);
    }

    public void SortReturns()
    {
        _stack.Sort();
    }
}