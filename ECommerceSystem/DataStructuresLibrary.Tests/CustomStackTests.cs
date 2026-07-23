namespace DataStructuresLibrary.Tests;

using DataStructuresLibrary;
using Xunit;

public class CustomStackTests
{
    // =====================================================
    // PUSH TESTS
    // =====================================================

    [Fact]
    public void Push_ShouldAddFirstItemToTop()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);

        Assert.Equal(10, stack.Peek());
    }

    [Fact]
    public void Push_ShouldPlaceNewestItemOnTop()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        Assert.Equal(20, stack.Peek());
    }

    [Fact]
    public void Push_ShouldIncreaseCount()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Assert.Equal(3, stack.Count);
    }

    // =====================================================
    // POP TESTS
    // =====================================================

    [Fact]
    public void Pop_ShouldRemoveNewestItem()
    {
        var stack = BuildStack(10, 20, 30);

        int result = stack.Pop();

        Assert.Equal(30, result);
    }

    [Fact]
    public void Pop_ShouldDecreaseCount()
    {
        var stack = BuildStack(10, 20);

        stack.Pop();

        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Pop_ShouldThrowWhenStackIsEmpty()
    {
        var stack = new CustomStack<int>();

        Assert.Throws<InvalidOperationException>(
            () => stack.Pop());
    }

    // =====================================================
    // PEEK TESTS
    // =====================================================

    [Fact]
    public void Peek_ShouldReturnTopItem()
    {
        var stack = BuildStack(10, 20);

        Assert.Equal(20, stack.Peek());
    }

    [Fact]
    public void Peek_ShouldNotRemoveTopItem()
    {
        var stack = BuildStack(10, 20);

        stack.Peek();

        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Peek_ShouldThrowWhenStackIsEmpty()
    {
        var stack = new CustomStack<int>();

        Assert.Throws<InvalidOperationException>(
            () => stack.Peek());
    }

    // =====================================================
    // SEARCH TESTS
    // =====================================================

    [Fact]
    public void Search_ShouldReturnOneForTopItem()
    {
        var stack = BuildStack(10, 20, 30);

        Assert.Equal(1, stack.Search(30));
    }

    [Fact]
    public void Search_ShouldReturnCorrectDepth()
    {
        var stack = BuildStack(10, 20, 30);

        Assert.Equal(3, stack.Search(10));
    }

    [Fact]
    public void Search_ShouldReturnMinusOneWhenMissing()
    {
        var stack = BuildStack(10, 20, 30);

        Assert.Equal(-1, stack.Search(99));
    }

    // =====================================================
    // SORT TESTS
    // =====================================================

    [Fact]
    public void Sort_ShouldPlaceSmallestItemOnTop()
    {
        var stack = BuildStack(30, 10, 20);

        stack.Sort();

        Assert.Equal(10, stack.Peek());
    }

    [Fact]
    public void Sort_ShouldReturnItemsInAscendingOrder()
    {
        var stack = BuildStack(30, 10, 20);

        stack.Sort();

        Assert.Equal(10, stack.Pop());
        Assert.Equal(20, stack.Pop());
        Assert.Equal(30, stack.Pop());
    }

    [Fact]
    public void Sort_ShouldHandleDuplicateItems()
    {
        var stack = BuildStack(2, 1, 2);

        stack.Sort();

        Assert.Equal(1, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(2, stack.Pop());
    }

    /// <summary>
    /// Helper method that creates a stack for the tests.
    /// </summary>
    private static CustomStack<int> BuildStack(params int[] values)
    {
        var stack = new CustomStack<int>();

        foreach (int value in values)
        {
            stack.Push(value);
        }

        return stack;
    }
}