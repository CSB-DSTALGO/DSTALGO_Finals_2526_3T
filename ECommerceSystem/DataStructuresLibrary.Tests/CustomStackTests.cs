namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{
    [Fact]
    public void PushAndPop_ShouldMaintainStrictLIFOOrder()
    {
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
        var stack = new CustomStack<int>();

        stack.Push(5);
        stack.Push(10);

        Assert.Equal(10, stack.Peek());
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
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
        var stack = new CustomStack<int>();

        stack.Push(3);
        stack.Push(1);
        stack.Push(4);
        stack.Push(2);

        stack.Sort();

        Assert.Equal(1, stack.Peek());
    }
}