namespace DataStructuresLibrary.Tests;

using System;
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

        Assert.Equal(3, stack.Count);
        Assert.Equal(30, stack.Pop());
        Assert.Equal(20, stack.Pop());
        Assert.Equal(10, stack.Pop());
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        var stack = new CustomStack<string>();
        stack.Push("Item 1");
        stack.Push("Item 2");

        var top = stack.Peek();

        Assert.Equal("Item 2", top);
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
        var stack = new CustomStack<int>();
        stack.Push(10); // Depth 3
        stack.Push(20); // Depth 2
        stack.Push(30); // Depth 1 (Top)

        Assert.Equal(1, stack.Search(30));
        Assert.Equal(2, stack.Search(20));
        Assert.Equal(3, stack.Search(10));
        Assert.Equal(-1, stack.Search(99)); // Not present
    }

    [Fact]
    public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
    {
        var stack = new CustomStack<int>();
        stack.Push(30);
        stack.Push(10);
        stack.Push(50);
        stack.Push(20);

        stack.Sort();

        // Expect ascending order from top to bottom (10, 20, 30, 50)
        Assert.Equal(10, stack.Pop());
        Assert.Equal(20, stack.Pop());
        Assert.Equal(30, stack.Pop());
        Assert.Equal(50, stack.Pop());
    }
}