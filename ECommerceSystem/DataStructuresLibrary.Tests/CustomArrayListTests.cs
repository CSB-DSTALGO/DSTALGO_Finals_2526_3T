namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    // ---------- Add() ----------
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
    }

    [Fact]
    public void Add_BeyondInitialCapacity_TriggersResizeAndKeepsData()
    {
        var list = new CustomArrayList<int>(initialCapacity: 2);
        list.Add(1); list.Add(2); list.Add(3);
        Assert.Equal(3, list.Count);
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void Add_SingleItem_StoresAtIndexZero()
    {
        var list = new CustomArrayList<int>();
        list.Add(99);
        Assert.Equal(99, list.Get(0));
    }

    // ---------- Remove() ----------
    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();
        list.Add(1); list.Add(2); list.Add(3);
        bool removed = list.Remove(2);
        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(3, list.Get(1));
    }

    [Fact]
    public void Remove_ItemNotInList_ReturnsFalse()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        bool removed = list.Remove(99);
        Assert.False(removed);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Remove_WithDuplicates_RemovesOnlyFirstOccurrence()
    {
        var list = new CustomArrayList<int>();
        list.Add(5); list.Add(5); list.Add(5);
        list.Remove(5);
        Assert.Equal(2, list.Count);
    }

    // ---------- Get() ----------
    [Fact]
    public void Get_ValidIndex_ReturnsCorrectItem()
    {
        var list = new CustomArrayList<int>();
        list.Add(42);
        Assert.Equal(42, list.Get(0));
    }

    [Fact]
    public void Get_NegativeIndex_ThrowsException()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
    }

    [Fact]
    public void Get_IndexEqualToCount_ThrowsException()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(1));
    }

    // ---------- Search() ----------
    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = new CustomArrayList<int>();
        list.Add(100); list.Add(200);
        Assert.Equal(1, list.Search(200));
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();
        list.Add(1); list.Add(2);
        Assert.Equal(-1, list.Search(999));
    }

    [Fact]
    public void Search_EmptyList_ReturnsMinusOne()
    {
        var list = new CustomArrayList<int>();
        Assert.Equal(-1, list.Search(5));
    }

    // ---------- Sort() ----------
    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        var list = new CustomArrayList<int>();
        list.Add(50); list.Add(10); list.Add(30);
        list.Sort();
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
        Assert.Equal(50, list.Get(2));
    }

    [Fact]
    public void Sort_AlreadySortedList_RemainsUnchanged()
    {
        var list = new CustomArrayList<int>();
        list.Add(1); list.Add(2); list.Add(3);
        list.Sort();
        Assert.Equal(1, list.Get(0));
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void Sort_ListWithDuplicates_SortsCorrectly()
    {
        var list = new CustomArrayList<int>();
        list.Add(5); list.Add(1); list.Add(5); list.Add(2);
        list.Sort();
        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(5, list.Get(2));
        Assert.Equal(5, list.Get(3));
    }
}