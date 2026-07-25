namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();

    public int Count => _returns.Count;


    public void PushReturn(ReturnRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request), "Cannot push a null return request.");

        _returns.Push(request);
    }

    public ReturnRequest PopReturn() => _returns.Pop();

    public ReturnRequest PeekLatestReturn() => _returns.Peek();

    public bool CheckHistoryEmpty() => _returns.Count == 0;

    public int SearchReturn(ReturnRequest request)
    {
        if (request is null) return -1;
        return _returns.Search(request);
    }

  
    public void SortReturns() => _returns.Sort();
}
namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();

    public int Count => _returns.Count;

    public void PushReturn(ReturnRequest request) => throw new NotImplementedException();
    public ReturnRequest PopReturn() => throw new NotImplementedException();
    public ReturnRequest PeekLatestReturn() => throw new NotImplementedException();

    
    public int SearchReturn(ReturnRequest request) => throw new NotImplementedException();
    public void SortReturns() => throw new NotImplementedException();
}
