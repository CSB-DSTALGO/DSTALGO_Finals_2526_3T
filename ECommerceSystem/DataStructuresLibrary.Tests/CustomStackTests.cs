namespace DataStructuresLibrary.Tests;
using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{
    [Fact]
    public void PushAndPop_ShouldMaintainStrictLIFOOrder()
    {
        var stack = new CustomStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        int peeked = stack.Peek();

        Assert.Equal(20, peeked);
        Assert.Equal(2, stack.Count); // Count unchanged
        Assert.Equal(20, stack.Pop()); // still there for real
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
        var stack = new CustomStack<int>();

        stack.Push(5);  // bottom
        stack.Push(10);
        stack.Push(15); // top

        Assert.Equal(1, stack.Search(15)); // top item
        Assert.Equal(2, stack.Search(10));
        Assert.Equal(3, stack.Search(5));  // bottom item
        Assert.Equal(-1, stack.Search(99)); // not found
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

        // Smallest should now be on top, popping should yield ascending order
        Assert.Equal(10, stack.Pop());
        Assert.Equal(20, stack.Pop());
        Assert.Equal(30, stack.Pop());
        Assert.Equal(50, stack.Pop());
        Assert.Equal(0, stack.Count);
    }
}