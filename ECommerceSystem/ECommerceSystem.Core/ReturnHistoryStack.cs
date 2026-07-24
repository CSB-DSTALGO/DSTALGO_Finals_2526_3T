namespace ECommerceSystem.Core;

using System;
using DataStructuresLibrary;

public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();

    public int Count => _returns.Count;

    // Pushes a return request onto the stack
    public void PushReturn(ReturnRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        _returns.Push(request);
    }

    // Pops the latest return request from the stack
    public ReturnRequest PopReturn() => _returns.Pop();

    // Peeks at the latest return request without removing it from the stack
    public ReturnRequest PeekLatestReturn() => _returns.Peek();

    // Checks if the return history stack is empty
    public bool CheckHistoryEmpty() => Count == 0;

    // Searches for a return request in the stack and returns its index, or -1 if not found
    public int SearchReturn(ReturnRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _returns.Search(request);
    }

    // Sorts the return requests in the stack based on their natural ordering
    public void SortReturns() => _returns.Sort();
}