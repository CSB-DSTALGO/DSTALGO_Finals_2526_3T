namespace DataStructuresLibrary.Tests;

using System;
using DataStructuresLibrary;
using Xunit;

public class CustomSinglyLinkedListTests
{
    // ---------- Add ----------

    [Fact]
    public void Add_ShouldIncrementCount_WhenSingleItemAdded()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);

        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Add_ShouldIncrementCount_ForEachItemAdded()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Add_ShouldMakeItemFindableViaSearch()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);

        Assert.True(list.Search(10));
    }

    // ---------- Remove ----------

    [Fact]
    public void Remove_ShouldRemoveHeadNode_WhenOnlyOneItemExists()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);

        bool removed = list.Remove(10);

        Assert.True(removed);
        Assert.Equal(0, list.Count);
        Assert.False(list.Search(10));
    }

    [Fact]
    public void Remove_ShouldRemoveMiddleNode_AndKeepOthersIntact()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool removed = list.Remove(20);

        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.True(list.Search(10));
        Assert.True(list.Search(30));
        Assert.False(list.Search(20));
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);

        bool removed = list.Remove(999);

        Assert.False(removed);
        Assert.Equal(1, list.Count);
    }

    // ---------- Search ----------

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);

        Assert.True(list.Search(10));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);

        Assert.False(list.Search(20));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenListIsEmpty()
    {
        var list = new CustomSinglyLinkedList<int>();

        Assert.False(list.Search(10));
    }

    // ---------- Get ----------

    [Fact]
    public void Get_ShouldReturnFirstItem_WhenIndexIsZero()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(10, list.Get(0));
    }

    [Fact]
    public void Get_ShouldReturnCorrectItem_WhenIndexIsValid()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Get_ShouldThrow_WhenIndexIsOutsideList()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);

        Assert.Throws<IndexOutOfRangeException>(
            () => list.Get(1));
    }

    // ---------- Sort ----------

    [Fact]
    public void Sort_ShouldNotChangeCount()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Sort_ShouldOrderItemsAscending()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Sort_ShouldHandleAlreadySortedList_WithoutError()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.Sort();

        Assert.Equal(3, list.Count);
    }
}