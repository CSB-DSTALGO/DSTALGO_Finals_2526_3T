namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();

    public int Count => _returns.Count;

    public void PushReturn(ReturnRequest request) => throw new NotImplementedException();
    public ReturnRequest PopReturn() => throw new NotImplementedException();
    public ReturnRequest PeekLatestReturn() => throw new NotImplementedException();

    public bool CheckHistoryEmpty() => throw new NotImplementedException();
    
    public int SearchReturn(ReturnRequest request) => throw new NotImplementedException();
    public void SortReturns() => throw new NotImplementedException();
}
