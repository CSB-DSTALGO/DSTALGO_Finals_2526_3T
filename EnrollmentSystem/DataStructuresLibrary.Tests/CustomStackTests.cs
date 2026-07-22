using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests;

public class CustomStackTests
{
    [Fact]
    public void NewStack_IsEmpty()
    {
        var stack = new CustomStack<int>();
        Assert.True(stack.IsEmpty());
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Push_SingleItem_IncreasesCountAndIsNoLongerEmpty()
    {
        var stack = new CustomStack<int>();
        stack.Push(10);
        Assert.Equal(1, stack.Count);
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void Push_MultipleItems_TriggersResizeWithoutLosingData()
    {
        var stack = new CustomStack<int>();
        for (int i = 1; i <= 10; i++) // forces resize past default capacity of 4
        {
            stack.Push(i);
        }
        Assert.Equal(10, stack.Count);
        Assert.Equal(10, stack.Peek()); // last pushed item is still on top
    }

    [Fact]
    public void Pop_ReturnsMostRecentlyPushedItem()
    {
        var stack = new CustomStack<string>();
        stack.Push("first");
        stack.Push("second");
        var popped = stack.Pop();
        Assert.Equal("second", popped);
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
    {
        var stack = new CustomStack<int>();
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_DoesNotRemoveItem()
    {
        var stack = new CustomStack<int>();
        stack.Push(5);
        var peeked = stack.Peek();
        Assert.Equal(5, peeked);
        Assert.Equal(1, stack.Count); 
    }

    [Fact]
    public void Peek_OnEmptyStack_ThrowsInvalidOperationException()
    {
        var stack = new CustomStack<int>();
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void IsEmpty_ReturnsFalseAfterPushAndTrueAfterPoppingAll()
    {
        var stack = new CustomStack<int>();
        stack.Push(1);
        Assert.False(stack.IsEmpty());
        stack.Pop();
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Sort_OrdersElementsAscending()
    {
        var stack = new CustomStack<int>();
        stack.Push(3);
        stack.Push(1);
        stack.Push(2);
        stack.Sort((a, b) => a.CompareTo(b));
        Assert.Equal(3, stack.Peek()); 
    }

    [Fact]
    public void Search_FindsExistingItem()
    {
        var stack = new CustomStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        int index = stack.Search(20, (a, b) => a.CompareTo(b));
        Assert.Equal(1, index); 
    }

    [Fact]
    public void Search_ReturnsMinusOne_WhenItemNotFound()
    {
        var stack = new CustomStack<int>();
        stack.Push(10);
        stack.Push(20);
        int index = stack.Search(99, (a, b) => a.CompareTo(b));
        Assert.Equal(-1, index);
    }
}