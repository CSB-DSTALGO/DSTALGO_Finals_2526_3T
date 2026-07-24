namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    // Verifies that adding items increases the count and stores the items correctly.
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    // Verifies that the list expands its capacity when the original array becomes full.
    [Fact]
    public void Add_ShouldExpandCapacity_WhenArrayIsFull()
    {
        var list = new CustomArrayList<int>(2);

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(3, list.Count);
        Assert.Equal(30, list.Get(2));
    }

    // Verifies that added items remain in the order they were inserted.
    [Fact]
    public void Add_ShouldStoreItemsInCorrectOrder()
    {
        var list = new CustomArrayList<int>();

        list.Add(5);
        list.Add(15);

        Assert.Equal(5, list.Get(0));
        Assert.Equal(15, list.Get(1));
    }

    // Verifies that removing an item shifts the remaining elements correctly.
    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Remove(20);

        Assert.True(result);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    // Verifies that removing an item that does not exist returns false and does not change the list.
    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        bool result = list.Remove(99);

        Assert.False(result);
        Assert.Equal(2, list.Count);
    }

    // Verifies that the first matching item is removed from the list.
    [Fact]
    public void Remove_ShouldRemoveFirstMatchingItem()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Remove(10);

        Assert.True(result);
        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.Get(0));
    }

    // Verifies that Get returns the item stored at the requested index.
    [Fact]
    public void Get_ShouldReturnItemAtCorrectIndex()
    {
        var list = new CustomArrayList<int>();

        list.Add(100);
        list.Add(200);

        Assert.Equal(100, list.Get(0));
        Assert.Equal(200, list.Get(1));
    }

    // Verifies that Get throws an exception when the index is greater than the valid range.
    [Fact]
    public void Get_ShouldThrowException_WhenIndexIsInvalid()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);

        Assert.Throws<IndexOutOfRangeException>(() => list.Get(5));
    }

    // Verifies that Get throws an exception when a negative index is provided.
    [Fact]
    public void Get_ShouldThrowException_WhenIndexIsNegative()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);

        Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
    }

    // Verifies that Search returns the correct index when the item exists.
    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        int index = list.Search(20);

        Assert.Equal(1, index);
    }

    // Verifies that Search returns -1 when the item cannot be found.
    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        int index = list.Search(99);

        Assert.Equal(-1, index);
    }

    // Verifies that Search returns index 0 when the matching item is the first item.
    [Fact]
    public void Search_ShouldReturnZero_WhenItemIsFirst()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        int index = list.Search(10);

        Assert.Equal(0, index);
    }

    // Verifies that Sort arranges the items in ascending order.
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

    // Verifies that Sort keeps items in the correct order when the list is already sorted.
    [Fact]
    public void Sort_ShouldWorkWithAlreadySortedItems()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.Sort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    // Verifies that Sort places the largest item at the end of the list.
    [Fact]
    public void Sort_ShouldPlaceLargestItemAtTheEnd()
    {
        var list = new CustomArrayList<int>();

        list.Add(5);
        list.Add(50);
        list.Add(1);

        list.Sort();

        Assert.Equal(50, list.Get(2));
    }

    // Verifies that removing an item from an empty list returns false and leaves the count at zero.
    [Fact]
    public void Remove_ShouldReturnFalse_WhenListIsEmpty()
    {
        var list = new CustomArrayList<int>();

        bool result = list.Remove(10);

        Assert.False(result);
        Assert.Equal(0, list.Count);
    }
}