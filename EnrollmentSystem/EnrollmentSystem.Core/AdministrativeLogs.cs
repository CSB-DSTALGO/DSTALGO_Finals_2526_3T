// 12521269 Joaquin Bryan G. Ross
namespace EnrollmentSystem.Core;

using DataStructuresLibrary;

public class AdministrativeLogs
{
    private readonly CustomStack<Log> _logs = new();

    public int Count => _logs.Count;

    /// <summary>
    /// Pushes an action to the top index of the log stack. O(1) amortised.
    /// </summary>
    public void PushSystemLog(Log log) => _logs.Push(log);

    /// <summary>
    /// Pops the top item off the execution stack. O(1).
    /// A stack is the right structure for rollback because the action to
    /// reverse is always the newest one, which is exactly what a stack returns.
    /// Throws InvalidOperationException when there is nothing left to roll back.
    /// </summary>
    public Log RollbackLastLog() => _logs.Pop();

    /// <summary>
    /// Peeks at the topmost active log record without removing it. O(1).
    /// Throws InvalidOperationException when no logs have been recorded.
    /// </summary>
    public Log ViewLatestLog() => _logs.Peek();

    /// <summary>
    /// The name the project scaffold shipped for the same pop operation, kept
    /// alongside RollbackLastLog so code written against either name compiles.
    /// O(1).
    /// </summary>
    public Log PopSystemLog() => _logs.Pop();

    /// <summary>
    /// The name the project scaffold shipped for the same peek operation, kept
    /// alongside ViewLatestLog. O(1).
    /// </summary>
    public Log PeekLatestLog() => _logs.Peek();

    /// <summary>
    /// Evaluates and returns whether any logs have been recorded. O(1).
    /// </summary>
    public bool CheckLogsEmpty() => _logs.IsEmpty();

    /// <summary>Returns how many logs are on the stack. O(1).</summary>
    public int GetLogCount() => Count;

    /// <summary>
    /// Search algorithm: linear search from the top down, delegated to
    /// CustomStack.Search. It scans from the highest index toward the bottom.
    /// Best case O(1) at the top, worst and average case O(n).
    /// It reports depth rather than an array index, counting the top as 1,
    /// because an administrator reasoning about a log stack thinks in "how many
    /// rollbacks away" terms and not in storage positions.
    /// Returns -1 when the log is not on the stack.
    /// </summary>
    public int SearchLog(Log log) => _logs.Search(log);

    /// <summary>
    /// Sorting algorithm: insertion sort, delegated to CustomStack.Sort. The
    /// comparison is deliberately inverted against the other three modules.
    /// Ascending for a stack means popping yields ascending order, so the
    /// smallest id has to finish on top, and the top is the highest array
    /// index. The backing array therefore ends up descending bottom to top.
    /// Best case O(n) when already ordered, worst and average case O(n^2), with
    /// O(1) extra space.
    /// Log.CompareTo orders by LogId using an ordinal string comparison, so
    /// after sorting the earliest log id is the next one to roll back.
    /// </summary>
    public void SortLogsById() => _logs.Sort();
}
