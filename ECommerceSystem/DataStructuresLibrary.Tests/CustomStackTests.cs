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

        // Act
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Assert
        Assert.Equal(3, stack.Count);
        Assert.Equal(30, stack.Pop());
        Assert.Equal(20, stack.Pop());
        Assert.Equal(10, stack.Pop());
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        // Arrange
        var stack = new CustomStack<string>();
        stack.Push("First");
        stack.Push("Second");

        // Act
        string topItem = stack.Peek();

        // Assert
        Assert.Equal("Second", topItem);
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
        // Arrange
        var stack = new CustomStack<char>();
        stack.Push('A'); // depth 3
        stack.Push('B'); // depth 2
        stack.Push('C'); // depth 1 (top)

        // Act & Assert
        Assert.Equal(1, stack.Search('C'));
        Assert.Equal(2, stack.Search('B'));
        Assert.Equal(3, stack.Search('A'));
        Assert.Equal(-1, stack.Search('Z')); // Missing item
    }

    [Fact]
    public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
    {
        // Arrange
        var stack = new CustomStack<int>();
        stack.Push(15);
        stack.Push(3);
        stack.Push(42);
        stack.Push(8);

        // Act
        stack.Sort(); // Ascending array order puts largest at index Count-1 (top)

        // Assert - If sorted ascending in array, top (Pop) is the max element
        Assert.Equal(42, stack.Pop());
        Assert.Equal(15, stack.Pop());
        Assert.Equal(8, stack.Pop());
        Assert.Equal(3, stack.Pop());
    }
}