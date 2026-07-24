// 12521269 Joaquin Bryan G. Ross
namespace ECommerceSystem.Core;

using DataStructuresLibrary;

// The stack module for the eCommerce system. The requirements table calls the
// class ReturnHistory and the directory listing calls the file
// ReturnHistoryStack.cs, which is also what the project scaffold ships, so the
// scaffold name is used. PeekLastReturn is the table's name for the scaffold's
// PeekLatestReturn and both are provided.
public class ReturnHistoryStack
{
    private readonly CustomStack<ReturnRequest> _returns = new();

    public int Count => _returns.Count;

    /// <summary>
    /// Pushes a return request onto the history. O(1) amortised.
    /// </summary>
    public void PushReturn(ReturnRequest request) => _returns.Push(request);

    /// <summary>
    /// Pops the most recent return off the history. O(1).
    /// A stack suits return history because it is reviewed newest first.
    /// Throws InvalidOperationException when the history is empty.
    /// </summary>
    public ReturnRequest PopReturn() => _returns.Pop();

    /// <summary>
    /// Peeks at the newest return without removing it. O(1).
    /// Throws InvalidOperationException when the history is empty.
    /// </summary>
    public ReturnRequest PeekLatestReturn() => _returns.Peek();

    /// <summary>
    /// The requirements table's name for the same peek operation, kept alongside
    /// the scaffold's PeekLatestReturn so code written against either compiles.
    /// O(1). Throws InvalidOperationException when the history is empty.
    /// </summary>
    public ReturnRequest PeekLastReturn() => _returns.Peek();

    /// <summary>
    /// Evaluates and returns whether any returns have been logged. O(1).
    /// </summary>
    public bool CheckHistoryEmpty() => _returns.IsEmpty();

    /// <summary>
    /// Search algorithm: linear search from the top down, delegated to
    /// CustomStack.Search. Best case O(1) at the top, worst and average O(n).
    /// Returns how many returns back the request sits, counting the newest as
    /// 1, or -1 when it is not in the history. Depth is reported rather than an
    /// array index because a caller reasoning about a stack thinks in terms of
    /// how many entries back something is.
    /// </summary>
    public int SearchReturn(ReturnRequest request) => _returns.Search(request);

    /// <summary>
    /// Sorting algorithm: insertion sort, delegated to CustomStack.Sort. The
    /// comparison is inverted against the array list and queue modules, because
    /// ascending for a stack means popping yields ascending order, which puts
    /// the smallest id on top and leaves the backing array descending from
    /// bottom to top.
    /// Best case O(n) when already ordered, worst and average case O(n^2), with
    /// O(1) extra space.
    /// ReturnRequest.CompareTo orders by ReturnId, so after sorting the lowest
    /// return id is the next one off the stack.
    /// </summary>
    public void SortReturns() => _returns.Sort();
}
