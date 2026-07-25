namespace DataStructuresLibrary.Tests;

using DataStructuresLibrary;
using Xunit;

public class CustomArrayListTests
{
    // =====================================================
    // ADD TESTS
    // =====================================================

    [Fact]
    public void Add_ShouldIncreaseCount()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);

        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Add_ShouldStoreItemsInInsertionOrder()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Add_ShouldResizeWhenInitialCapacityIsReached()
    {
        var list = new CustomArrayList<int>(2);

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(3, list.Count);
        Assert.Equal(30, list.Get(2));
    }

    // =====================================================
    // REMOVE TESTS
    // =====================================================

    [Fact]
    public void Remove_ShouldDeleteMatchingItem()
    {
        var list = BuildList(10, 20, 30);

        bool removed = list.Remove(20);

        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(-1, list.Search(20));
    }

    [Fact]
    public void Remove_ShouldShiftItemsAfterRemovedItem()
    {
        var list = BuildList(10, 20, 30);

        list.Remove(20);

        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void Remove_ShouldReturnFalseAndKeepCount_WhenItemIsMissing()
    {
        var list = BuildList(10, 20);

        bool removed = list.Remove(99);

        Assert.False(removed);
        Assert.Equal(2, list.Count);
    }

    // =====================================================
    // REMOVE AT TESTS
    // =====================================================

    [Fact]
    public void RemoveAt_ShouldRemoveItemAtSpecifiedIndex()
    {
        var list = BuildList(10, 20, 30);

        list.RemoveAt(1);

        Assert.Equal(2, list.Count);
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void RemoveAt_ShouldRemoveLastItem()
    {
        var list = BuildList(10, 20, 30);

        list.RemoveAt(2);

        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.Get(1));
    }

    [Fact]
    public void RemoveAt_ShouldThrow_WhenIndexIsInvalid()
    {
        var list = BuildList(10);

        Assert.Throws<ArgumentOutOfRangeException>(
            () => list.RemoveAt(1));
    }

    // =====================================================
    // GET TESTS
    // =====================================================

    [Fact]
    public void Get_ShouldReturnFirstItem()
    {
        var list = BuildList(10, 20, 30);

        Assert.Equal(10, list.Get(0));
    }

    [Fact]
    public void Get_ShouldReturnLastItem()
    {
        var list = BuildList(10, 20, 30);

        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Get_ShouldThrow_WhenIndexIsInvalid()
    {
        var list = BuildList(10);

        Assert.Throws<ArgumentOutOfRangeException>(
            () => list.Get(-1));
    }

    // =====================================================
    // SEARCH TESTS
    // =====================================================

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = BuildList(10, 20, 30);

        Assert.Equal(1, list.Search(20));
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemIsMissing()
    {
        var list = BuildList(10, 20);

        Assert.Equal(-1, list.Search(99));
    }

    [Fact]
    public void Search_ShouldReturnFirstIndex_WhenDuplicatesExist()
    {
        var list = BuildList(10, 20, 20, 30);

        Assert.Equal(1, list.Search(20));
    }

    // =====================================================
    // SORT TESTS
    // =====================================================

    [Fact]
    public void Sort_ShouldOrderItemsAscending()
    {
        var list = BuildList(30, 10, 20);

        list.Sort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Sort_ShouldHandleDuplicateItems()
    {
        var list = BuildList(2, 1, 2);

        list.Sort();

        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(2, list.Get(2));
    }

    [Fact]
    public void Sort_ShouldNotChangeCount()
    {
        var list = BuildList(30, 10, 20);

        list.Sort();

        Assert.Equal(3, list.Count);
    }

    private static CustomArrayList<int> BuildList(params int[] values)
    {
        var list = new CustomArrayList<int>();

        foreach (int value in values)
        {
            list.Add(value);
        }

        return list;
    }
}
