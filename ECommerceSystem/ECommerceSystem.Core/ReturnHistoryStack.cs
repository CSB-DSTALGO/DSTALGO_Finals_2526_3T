namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();
    public int Count => _returns.Count;

    public void PushReturn(ReturnRequest request)
    {
        //Adds a new return request to the top of the history
        _returns.Push(request);
    }
    public ReturnRequest PopReturn()
    {
        //Removes the most recent return request
        return _returns.Pop();
    }
    public ReturnRequest PeekLatestReturn()
    {
        //Views the most recent return request without removing it
        return _returns.Peek();
    }
    public int SearchReturn(ReturnRequest request)
    {
        //Searches for a specific return request
        return _returns.Search(request);
    }
    public void SortReturns()
    {
        //Sorts the return requests
        _returns.Sort();
    }
}