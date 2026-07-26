namespace ECommerceSystem.Core;

using DataStructuresLibrary;

// Manages the history of customer return requests using a custom stack.
public class ReturnHistoryStack
{
    // Stores all return requests in a stack.
    private readonly CustomStack<ReturnRequest> _returns = new();

    // Gets the current number of stored return requests.
    public int Count => _returns.Count;

    // Adds a new return request to the stack.
    public void PushReturn(ReturnRequest request)
    {
        _returns.Push(request);
    }

    // Removes and returns the most recent return request.
    public ReturnRequest PopReturn()
    {
        return _returns.Pop();
    }

    // Returns the most recent return request without removing it.
    public ReturnRequest PeekLatestReturn()
    {
        return _returns.Peek();
    }

    // Searches for a return request in the stack.
    // Returns its position from the top or -1 if not found.
    public int SearchReturn(ReturnRequest request)
    {
        return _returns.Search(request);
    }

    // Sorts the return requests in the stack.
    public void SortReturns()
    {
        _returns.Sort();
    }
}