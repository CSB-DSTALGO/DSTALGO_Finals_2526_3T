namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{
    // Test to ensure that pushing and popping maintains strict LIFO order
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

    // Test to ensure that popping from an empty stack throws an InvalidOperationException
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

    // Test to ensure that searching for an item returns the correct one-based depth from the top of the stack
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

    // Test to ensure that sorting the stack reorders the elements correctly, with the smallest item at the top
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
        stack.Sort();

        // Assert - If sorted ascending in array, top (Pop) is the max element
        Assert.Equal(3, stack.Pop());
        Assert.Equal(8, stack.Pop());
        Assert.Equal(15, stack.Pop());
        Assert.Equal(42, stack.Pop());
    }
}