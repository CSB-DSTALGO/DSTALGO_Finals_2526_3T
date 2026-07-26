namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

// Contains unit tests for the CustomStack class.
public class CustomStackTests
{
    // Verifies that the stack follows the Last-In, First-Out (LIFO) principle.
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

    // Verifies that Peek returns the top element without removing it.
    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        Assert.Equal(20, stack.Peek());
        Assert.Equal(2, stack.Count);
    }

    // Verifies that Search returns the correct position from the top of the stack.
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
        Assert.Equal(-1, stack.Search(100));
    }

    // Verifies that Sort rearranges the stack correctly.
    [Fact]
    public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
    {
        var stack = new CustomStack<int>();

        stack.Push(8);
        stack.Push(2);
        stack.Push(5);

        stack.Sort();

        Assert.Equal(2, stack.Peek());
    }
}