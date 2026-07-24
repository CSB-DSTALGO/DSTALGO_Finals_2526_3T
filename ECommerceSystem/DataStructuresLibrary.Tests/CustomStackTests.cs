namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{
    [Fact]
    public void PushAndPop_ShouldMaintainStrictLIFOOrder()
    {
        // Arrange
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Act
        int first = stack.Pop();
        int second = stack.Pop();
        int third = stack.Pop();

        // Assert
        Assert.Equal(30, first);
        Assert.Equal(20, second);
        Assert.Equal(10, third);
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        // Arrange
        var stack = new CustomStack<int>();

        stack.Push(5);
        stack.Push(15);

        // Act
        int top = stack.Peek();

        // Assert
        Assert.Equal(15, top);
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
        // Arrange
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        stack.Push(40);

        // Act
        int position = stack.Search(30);

        // Assert
        // Stack top: 40 (1), 30 (2), 20 (3), 10 (4)
        Assert.Equal(2, position);
    }

    [Fact]
    public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
    {
        // Arrange
        var stack = new CustomStack<int>();

        stack.Push(30);
        stack.Push(10);
        stack.Push(40);
        stack.Push(20);

        // Act
        stack.Sort();

        // Assert
        // Assuming Sort() arranges the stack so the smallest value is on top.
        Assert.Equal(10, stack.Peek());
    }
}