// 12521269 Joaquin Bryan G. Ross
namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    // =========================================================================
    // Add
    // =========================================================================

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
    public void Add_ShouldPreserveItems_WhenGrowingBeyondInitialCapacity()
    {
        // The default capacity is 4, so this forces at least two resizes.
        var list = new CustomArrayList<int>();

        for (int i = 0; i < 20; i++)
        {
            list.Add(i);
        }

        Assert.Equal(20, list.Count);
        for (int i = 0; i < 20; i++)
        {
            Assert.Equal(i, list.Get(i));
        }
    }

    [Fact]
    public void Add_ShouldKeepDuplicates_AsSeparateEntries()
    {
        var list = new CustomArrayList<int>();

        list.Add(7);
        list.Add(7);

        Assert.Equal(2, list.Count);
        Assert.Equal(7, list.Get(0));
        Assert.Equal(7, list.Get(1));
    }

    // =========================================================================
    // Get
    // =========================================================================

    [Fact]
    public void Get_ShouldReturnItem_AtRequestedIndex()
    {
        var list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(15);
        list.Add(25);

        Assert.Equal(25, list.Get(2));
    }

    [Fact]
    public void Get_ShouldThrow_WhenIndexIsNegative()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
    }

    [Fact]
    public void Get_ShouldThrow_WhenIndexIsBeyondCount()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);

        // Index 1 sits inside the backing array but outside the used region.
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(1));
    }

    // =========================================================================
    // Remove
    // =========================================================================

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool removed = list.Remove(20);

        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1)); // 30 slid down from index 2
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);

        bool removed = list.Remove(99);

        Assert.False(removed);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Remove_ShouldRemoveOnlyFirstOccurrence_WhenDuplicatesExist()
    {
        var list = new CustomArrayList<int>();
        list.Add(4);
        list.Add(4);

        list.Remove(4);

        Assert.Equal(1, list.Count);
        Assert.Equal(4, list.Get(0));
    }

    // =========================================================================
    // RemoveAt
    // =========================================================================

    [Fact]
    public void RemoveAt_ShouldRemoveByPositionAndShiftLaterElementsDown()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.RemoveAt(0);

        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void RemoveAt_ShouldThrow_WhenIndexIsNegative()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
    }

    [Fact]
    public void RemoveAt_ShouldThrow_WhenIndexEqualsCount()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));
    }

    // =========================================================================
    // Search
    // =========================================================================

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = new CustomArrayList<int>();
        list.Add(100);
        list.Add(200);
        list.Add(300);

        Assert.Equal(1, list.Search(200));
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();
        list.Add(100);

        Assert.Equal(-1, list.Search(999));
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenListIsEmpty()
    {
        var list = new CustomArrayList<int>();

        Assert.Equal(-1, list.Search(1));
    }

    // =========================================================================
    // Sort
    // =========================================================================

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        var list = new CustomArrayList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Sort_ShouldLeaveAlreadySortedListUnchanged()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Sort();

        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void Sort_ShouldHandleEmptyAndSingleItemLists()
    {
        var empty = new CustomArrayList<int>();
        var single = new CustomArrayList<int>();
        single.Add(42);

        empty.Sort();
        single.Sort();

        Assert.Equal(0, empty.Count);
        Assert.Equal(1, single.Count);
        Assert.Equal(42, single.Get(0));
    }
}