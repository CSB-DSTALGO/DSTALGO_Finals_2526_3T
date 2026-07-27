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

    public bool CheckHistoryEmpty()
    {
        return Count == 0;
    }

    public int SearchReturn(ReturnRequest request)
    {
        return _returns.Search(request);
    }

    public void SortReturns()
    {
        _returns.Sort();
    }
}