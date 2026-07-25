namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{
    [Fact]
    public void PushAndPop_ShouldMaintainStrictLIFOOrder()
    {
        // Arrange: Create a stack and add multiple elements
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Act: Remove elements using Pop
        var firstPop = stack.Pop();
        var secondPop = stack.Pop();
        var thirdPop = stack.Pop();

        // Assert: Verify Last-In, First-Out behavior
        Assert.Equal(30, firstPop);
        Assert.Equal(20, secondPop);
        Assert.Equal(10, thirdPop);
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        // Arrange: Create a stack and add elements
        var stack = new CustomStack<int>();

        stack.Push(5);
        stack.Push(15);

        // Act: Get the top element without removing it
        var result = stack.Peek();

        // Assert: Verify Peek returns the top item and Count remains unchanged
        Assert.Equal(15, result);
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
    {
        // Arrange: Create a stack with multiple values
        var stack = new CustomStack<int>();

        stack.Push(100);
        stack.Push(200);
        stack.Push(300);

        // Act: Search for an existing element
        var result = stack.Search(200);

        // Assert: Verify Search returns depth from the top (1 = top element)
        Assert.Equal(2, result);
    }

    [Fact]
    public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
    {
        // Arrange: Create a stack with unsorted values
        var stack = new CustomStack<int>();

        stack.Push(30);
        stack.Push(10);
        stack.Push(20);

        // Act: Sort the stack
        stack.Sort();

        // Assert: Verify the smallest item is placed at the top
        Assert.Equal(10, stack.Peek());
    }
}