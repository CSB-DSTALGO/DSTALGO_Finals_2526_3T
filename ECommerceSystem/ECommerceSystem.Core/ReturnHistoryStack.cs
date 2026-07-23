namespace ECommerceSystem.Core;
using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();
    public int Count => _returns.Count;

    public void PushReturn(ReturnRequest request) => _returns.Push(request);

    public ReturnRequest PopReturn() => _returns.Pop();

    public ReturnRequest PeekLatestReturn() => _returns.Peek();

    public int SearchReturn(ReturnRequest request) => _returns.Search(request);

    public void SortReturns() => _returns.Sort();
}