namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();

    public int Count => _returns.Count;

    // Push new return request onto the top of the stack
    public void PushReturn(ReturnRequest request)
    {
        _returns.Push(request);
    }

    // Pops the most recently added return request
    public ReturnRequest PopReturn()
    {
        return _returns.Pop();
    }

    // Returns the latest return request
    public ReturnRequest PeekLatestReturn()
    {
        return _returns.Peek();
    }

    // Checks if the return history stack is empty.
    public bool CheckHistoryEmpty()
    {
        return _returns.Count == 0;
    }

    // Searches for a return request using linear search.
    public int SearchReturn(ReturnRequest request)
    {
        return _returns.Search(request);
    }

    // Sorts the return requests in ascending order using insertion sort.
    public void SortReturns()
    {
        _returns.Sort();
    }

}