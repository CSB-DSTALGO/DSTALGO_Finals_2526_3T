namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{
    //Test if Pop() follows LIFO behavior
    [Fact]
    public void Pop_ShouldMaintainStrictLIFOOrder()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Assert.Equal(30, stack.Pop());
        Assert.Equal(20, stack.Pop());
        Assert.Equal(10, stack.Pop());
    }

    //Test if Push() increases stack count by one
    [Fact]
    public void Push_ShouldIncreaseCount()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);

        Assert.Equal(1, stack.Count);
    }

    //Test if multiple Push() operations correctly updates the count
    [Fact]
    public void Push_MultipleItems_ShouldIncreaseCountCorrectly()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Assert.Equal(3, stack.Count);
    }


    //Test if recently pushed item is on top of the stack
    [Fact]
    public void Push_ShouldPlaceNewestItemOnTop()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        Assert.Equal(20, stack.Peek());
    }


    // Test if Pop() decreases the stack count after removing an item.
    [Fact]
    public void Pop_ShouldDecreaseCount()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        stack.Pop();

        Assert.Equal(1, stack.Count);
    }

    //Test if Pop() throws an exception when the stack is empty.
    [Fact]
    public void Pop_EmptyStack_ShouldThrowException()
    {
        var stack = new CustomStack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    //Test if Peek() returns the top element without removing it
    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        Assert.Equal(20, stack.Peek());
        Assert.Equal(2, stack.Count);
    }

    //Test if repeated Peek() calls return the same top element
    [Fact]
    public void Peek_MultipleCalls_ShouldReturnSameValue()
    {
        var stack = new CustomStack<int>();

        stack.Push(100);

        Assert.Equal(100, stack.Peek());
        Assert.Equal(100, stack.Peek());
    }

    //Test if Peek() throws an exception when the stack is empty.
    [Fact]
    public void Peek_EmptyStack_ShouldThrowException()
    {
        var stack = new CustomStack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    //Test if Search() returns the correct one-based depth from the top.
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
    }

    // Test if Search() returns -1 when the item is not found.
    [Fact]
    public void Search_ItemNotFound_ShouldReturnMinusOne()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        Assert.Equal(-1, stack.Search(99));
    }

    //Test if Search() returns -1 when searching an empty stack.
    [Fact]
    public void Search_EmptyStack_ShouldReturnMinusOne()
    {
        var stack = new CustomStack<int>();

        Assert.Equal(-1, stack.Search(5));
    }


    //Test if Sort() arranges stack in ascendin order
    [Fact]
    public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
    {
        var stack = new CustomStack<int>();

        stack.Push(5);
        stack.Push(1);
        stack.Push(3);

        stack.Sort();

        Assert.Equal(1, stack.Peek());
    }


    // Test if Sort() keeps an already sorted stack unchanged.
    [Fact]
    public void Sort_AlreadySorted_ShouldRemainSorted()
    {
        var stack = new CustomStack<int>();

        stack.Push(3);
        stack.Push(2);
        stack.Push(1);

        stack.Sort();

        Assert.Equal(1, stack.Peek());
    }


    // Test if Sort() leaves a single-element stack unchanged.
    [Fact]
    public void Sort_SingleElement_ShouldRemainUnchanged()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);

        stack.Sort();

        Assert.Equal(10, stack.Peek());
        Assert.Equal(1, stack.Count);
    }
}