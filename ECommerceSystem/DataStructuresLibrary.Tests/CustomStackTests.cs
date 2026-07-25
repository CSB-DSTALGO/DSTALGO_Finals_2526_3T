namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{
    [Fact]
    public void PushAndPop_ShouldMaintainStrictLIFOOrder()
    {
        // TODO: Test Last-In, First-Out behavior
        var stack = new CustomStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // last thing pushed should be the first thing popped off
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        // TODO: Test Peek returning top item while keeping Count intact
        var stack = new CustomStack<int>();
        stack.Push(5);
        stack.Push(10);

        int top = stack.Peek();

        Assert.Equal(10, top);
        // just checking, not popping, so count stays the same
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
        // TODO: Verify Search returns depth from top (1 = top item)
        var stack = new CustomStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3); // top of the stack

        Assert.Equal(1, stack.Search(3)); // its on top so depth is 1
        Assert.Equal(2, stack.Search(2)); // one down from top
        Assert.Equal(3, stack.Search(1)); // all the way at the bottom
        Assert.Equal(-1, stack.Search(999)); // doesnt exist in here
    }

    [Fact]
    public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
    {
        // TODO: Verify stack sorting order relative to the top reference
        var stack = new CustomStack<int>();
        stack.Push(30);
        stack.Push(10);
        stack.Push(20);

        stack.Sort();

        // after sorting the smallest one should be sitting on top
        Assert.Equal(10, stack.Peek());
    }
}