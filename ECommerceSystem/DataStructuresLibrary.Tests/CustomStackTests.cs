namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{
    [Fact]
    public void PushAndPop_ShouldMaintainStrictLIFOOrder()
    {
        // Arrange  
        CustomStack<int> stack = new();

        // Act
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        int first = stack.Pop();
        int second = stack.Pop();
        int third = stack.Pop();

        // Assert
        Assert.Equal(3, first);
        Assert.Equal(2, second);
        Assert.Equal(1, third);
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        // Arrange
        CustomStack<int> stack = new();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Act
        int top = stack.Peek();

        // Assert
        Assert.Equal(30, top);
        Assert.Equal(3, stack.Count);
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
        // Arrange
        CustomStack<int> stack = new();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        stack.Push(40);

        // Act
        int depth = stack.Search(20);

        // Assert
        Assert.Equal(3, depth);
    }

    [Fact]
    public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
    {
        // Arrange
        CustomStack<int> stack = new();

        stack.Push(3);
        stack.Push(1);
        stack.Push(2);

        // Act
        stack.Sort();

        // Assert
        Assert.Equal(1, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(3, stack.Pop());
        Assert.Equal(0, stack.Count);
    }
}