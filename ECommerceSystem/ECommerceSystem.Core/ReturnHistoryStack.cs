namespace ECommerceSystem.Core;

using DataStructuresLibrary;

/// <summary>
/// Handles return requests using CustomStack.
///
/// The newest return request is always placed
/// at the top of the stack.
/// </summary>
public class ReturnHistoryStack
{
    // Stores return requests using the manually created stack.
    private readonly CustomStack<ReturnRequest> _returns = new();

    /// <summary>
    /// Returns the current number of return requests.
    /// </summary>
    public int Count => _returns.Count;

    /// <summary>
    /// Adds a return request to the top of the stack.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public void PushReturn(ReturnRequest request)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        _returns.Push(request);
    }

    /// <summary>
    /// Removes and returns the newest return request.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public ReturnRequest PopReturn()
    {
        return _returns.Pop();
    }

    /// <summary>
    /// Views the newest return request without removing it.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public ReturnRequest PeekLatestReturn()
    {
        return _returns.Peek();
    }

    /// <summary>
    /// Same function as PeekLatestReturn.
    /// This method name matches the wording in the project guide.
    /// </summary>
    public ReturnRequest PeekLastReturn()
    {
        return _returns.Peek();
    }

    /// <summary>
    /// Returns true when there are no return requests.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public bool CheckHistoryEmpty()
    {
        return _returns.Count == 0;
    }

    /// <summary>
    /// Searches for a return request.
    ///
    /// Returns its depth from the top or -1 if not found.
    ///
    /// Time complexity: O(n)
    /// </summary>
    public int SearchReturn(ReturnRequest request)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return _returns.Search(request);
    }

    /// <summary>
    /// Sorts return requests by ReturnId.
    ///
    /// After sorting, the request with the smallest
    /// ReturnId is placed at the top.
    ///
    /// Time complexity: O(n²)
    /// </summary>
    public void SortReturns()
    {
        _returns.Sort();
    }
}