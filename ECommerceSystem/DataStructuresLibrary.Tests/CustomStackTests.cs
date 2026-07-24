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
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Assert.Equal(30, stack.Pop());
        Assert.Equal(20, stack.Pop());
        Assert.Equal(10, stack.Pop());
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        // TODO: Test Peek returning top item while keeping Count intact
        var stack = new CustomStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Peek());
        Assert.Equal(3, stack.Count);
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
        // TODO: Verify Search returns depth from top (1 = top item)
        var stack = new CustomStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Assert.Equal(1, stack.Search(30));
        Assert.Equal(2, stack.Search(20));
        Assert.Equal(3, stack.Search(10));
        Assert.Equal(-1, stack.Search(99));
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

        Assert.Equal(10, stack.Pop());
        Assert.Equal(20, stack.Pop());
        Assert.Equal(30, stack.Pop());
    }
}