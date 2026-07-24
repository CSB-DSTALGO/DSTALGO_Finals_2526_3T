// 12521269 Joaquin Bryan G. Ross
namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    // =========================================================================
    // Add
    // =========================================================================

    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);

        Assert.Equal(2, list.Count);
        Assert.True(list.Search(10));
        Assert.True(list.Search(20));
    }

    [Fact]
    public void Add_ShouldAppendToTail_NotToHead()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        // Removing 1 then 2 exercises the head each time, which only holds if
        // Add appended rather than prepended.
        Assert.True(list.Remove(1));
        Assert.True(list.Remove(2));
        Assert.True(list.Search(3));
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Add_ShouldAcceptDuplicateValues()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(5);
        list.Add(5);

        Assert.Equal(2, list.Count);
    }

    // =========================================================================
    // Remove
    // =========================================================================

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        // Exercises all three positions: middle, head, and tail.
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.True(list.Remove(2)); // middle
        Assert.False(list.Search(2));
        Assert.Equal(2, list.Count);

        Assert.True(list.Remove(1)); // head
        Assert.True(list.Remove(3)); // tail, by now also the head
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);

        Assert.False(list.Remove(99));
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenListIsEmpty()
    {
        var list = new CustomSinglyLinkedList<int>();

        Assert.False(list.Remove(1));
        Assert.Equal(0, list.Count);
    }

    // =========================================================================
    // GetAt
    // =========================================================================

    [Fact]
    public void GetAt_ShouldReturnTheNodeDataAtThatPosition()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(10, list.GetAt(0));
        Assert.Equal(30, list.GetAt(2)); // the tail costs a full traversal
    }

    [Fact]
    public void GetAt_ShouldThrow_WhenIndexIsNegative()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetAt(-1));
    }

    [Fact]
    public void GetAt_ShouldThrow_WhenIndexIsBeyondTheChain()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetAt(1));
    }

    // =========================================================================
    // Search
    // =========================================================================

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.True(list.Search(30)); // the tail requires a full traversal
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);

        Assert.False(list.Search(999));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenListIsEmpty()
    {
        var list = new CustomSinglyLinkedList<int>();

        Assert.False(list.Search(1));
    }

    // =========================================================================
    // Sort
    // =========================================================================

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        // Remove always matches the earliest node holding the value, so removing
        // 10, then 20, then 30 succeeds only if the chain is in ascending order.
        Assert.True(list.Remove(10));
        Assert.True(list.Remove(20));
        Assert.True(list.Remove(30));
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Sort_ShouldPreserveCountAndMembership()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(3);
        list.Add(1);
        list.Add(2);

        list.Sort();

        Assert.Equal(3, list.Count);
        Assert.True(list.Search(1));
        Assert.True(list.Search(2));
        Assert.True(list.Search(3));
    }

    [Fact]
    public void Sort_ShouldHandleEmptyAndSingleNodeLists()
    {
        var empty = new CustomSinglyLinkedList<int>();
        var single = new CustomSinglyLinkedList<int>();
        single.Add(42);

        empty.Sort();
        single.Sort();

        Assert.Equal(0, empty.Count);
        Assert.Equal(1, single.Count);
        Assert.True(single.Search(42));
    }
}