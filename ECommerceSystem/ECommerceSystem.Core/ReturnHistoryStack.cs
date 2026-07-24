namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();

    public int Count => _returns.Count;

    public void PushReturn(ReturnRequest request)
    {
        _returns.Push(request);
    }

    public ReturnRequest PopReturn()
    {
        return _returns.Pop();
    }

    public ReturnRequest PeekLatestReturn()
    {
        return _returns.Peek();
    }

    public int SearchReturn(ReturnRequest request)
    {
        return _returns.Search(request);
    }

    public void SortReturns()
    {
        _returns.Sort();
    }

    public bool CheckHistoryEmpty()
    {
        return _returns.Count == 0;
    }
}