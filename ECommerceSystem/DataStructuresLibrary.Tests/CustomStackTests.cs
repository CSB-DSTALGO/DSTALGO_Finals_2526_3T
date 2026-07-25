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

    [Fact]
    public void Push_ShouldAutomaticallyResize_WhenStackExceedsCapacity()
    {
        //test for automatic resizing of the stack when the number of elements exceeds the initial capacity
        //Arrange
        var stack = new CustomStack<int>();

        // Act
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        stack.Push(40);
        stack.Push(50);

        // Assert
        Assert.Equal(5, stack.Count);
    }

    [Fact]
    public void Push_ShouldThrowArgumentNullException_WhenPushingNullValue()
    {
        // Test to ensure that pushing a null value throws an ArgumentNullException
        // Arrange
        var stack = new CustomStack<string>();
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => stack.Push(null!));
    }

    [Fact]
    public void Push_ShouldMaintainCorrectCount_WhenPushingMultipleItems()
    {
        // Test to ensure that pushing multiple items maintains the correct count
        // Arrange
        var stack = new CustomStack<int>();
        // Act
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        // Assert
        Assert.Equal(3, stack.Count);
    }

    [Fact]
    public void Pop_ShouldThrowInvalidOperationException_WhenStackIsEmpty()
    {
        // Test to ensure that popping from an empty stack throws an InvalidOperationException
        // Arrange
        var stack = new CustomStack<int>();
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Pop_ShouldReturnTopElement_AndDecreaseCount()
    {
        // Test to ensure that popping returns the top element and decreases the count
        // Arrange
        var stack = new CustomStack<string>();
        stack.Push("First");
        stack.Push("Second");
        // Act
        string poppedItem = stack.Pop();
        // Assert
        Assert.Equal("Second", poppedItem);
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Pop_ShouldRemoveTopElement_FromStack()
    {
        // Test to ensure that popping removes the top element from the stack
        // Arrange
        var stack = new CustomStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        
        // Assert
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Count);
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

    [Fact]
    public void Peek_ShouldThrowInvalidOperationException_WhenStackIsEmpty()
    {
        // Test to ensure that peeking into an empty stack throws an InvalidOperationException
        // Arrange
        var stack = new CustomStack<int>();
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Peek_ShouldNotChangeCount_WhenStackIsNotEmpty()
    {
        // Test to ensure that peeking does not change the count of the stack
        // Arrange
        var stack = new CustomStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Assert
        Assert.Equal(3, stack.Peek());
        Assert.Equal(3, stack.Count); 
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

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        // Test to ensure that searching for a non-existent item returns -1
        // Arrange
        var stack = new CustomStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        // Act & Assert
        Assert.Equal(-1, stack.Search(4));
    }

    [Fact]
    public void Search_ShouldReturnMostRecentOccurrence_WhenItemExistsMultipleTimes()
    {
        // Test to ensure that searching for an item that exists multiple times returns the depth of the most recent occurrence
        // Arrange
        var stack = new CustomStack<string>();
        stack.Push("apple");
        stack.Push("banana");
        stack.Push("apple");
        // Act & Assert
        Assert.Equal(1, stack.Search("apple"));
        Assert.Equal(2, stack.Search("banana"));
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

    [Fact]
    public void Sort_ShouldNotChangeCount_WhenStackIsSorted()
    {
        // Test to ensure that sorting the stack does not change the count of elements
        // Arrange
        var stack = new CustomStack<int>();
        stack.Push(5);
        stack.Push(1);
        stack.Push(3);
        // Act
        stack.Sort();
        // Assert
        Assert.Equal(3, stack.Count);
    }

    [Fact]
    public void Sort_ShouldHandleEmptyStack_WithoutErrors()
    {
        // Test to ensure that sorting an empty stack does not throw any errors
        // Arrange
        var stack = new CustomStack<int>();
        // Act & Assert
        var exception = Record.Exception(() => stack.Sort());
        Assert.Null(exception); // No exception should be thrown
    }

    [Fact]
    public void Sort_ShouldNotChangeOrder_WhenStackIsAlreadySorted()
    {
        // Test to ensure that sorting an already sorted stack does not change the order of elements
        // Arrange
        var stack = new CustomStack<int>();
        stack.Push(3);
        stack.Push(2);
        stack.Push(1);
        // Act
        stack.Sort();
        // Assert
        Assert.Equal(1, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(3, stack.Pop());
    }
}