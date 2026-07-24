namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomStackTests
{

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

    [Fact]
    public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        Assert.Equal(20, stack.Peek());
        Assert.Equal(2, stack.Count);
    }

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



    [Fact]
    public void Push_ShouldIncreaseCount()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);

        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Push_MultipleItems_ShouldIncreaseCountCorrectly()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Assert.Equal(3, stack.Count);
    }

    [Fact]
    public void Push_ShouldPlaceNewestItemOnTop()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        Assert.Equal(20, stack.Peek());
    }



    [Fact]
    public void Pop_ShouldDecreaseCount()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        stack.Pop();

        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Pop_EmptyStack_ShouldThrowException()
    {
        var stack = new CustomStack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }


    [Fact]
    public void Peek_MultipleCalls_ShouldReturnSameValue()
    {
        var stack = new CustomStack<int>();

        stack.Push(100);

        Assert.Equal(100, stack.Peek());
        Assert.Equal(100, stack.Peek());
    }

    [Fact]
    public void Peek_EmptyStack_ShouldThrowException()
    {
        var stack = new CustomStack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }


    [Fact]
    public void Search_ItemNotFound_ShouldReturnMinusOne()
    {
        var stack = new CustomStack<int>();

        stack.Push(10);
        stack.Push(20);

        Assert.Equal(-1, stack.Search(99));
    }

    [Fact]
    public void Search_EmptyStack_ShouldReturnMinusOne()
    {
        var stack = new CustomStack<int>();

        Assert.Equal(-1, stack.Search(5));
    }



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