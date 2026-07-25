namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

// Code by: Victor Tarra

public class CustomArrayListTests
{
    // Checks if adding items increases the count
    // and stores the values in the correct position
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        var list = new CustomArrayList<int>();

        // Add sample values to the list
        list.Add(10);
        list.Add(20);

        // Check if count and stored values are correct
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
    }

    // Checks if removing an item works correctly
    // and shifts the remaining elements properly
    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();

        // Add values to test removal
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Remove the middle value
        bool removed = list.Remove(20);

        // Check if the item was removed and other items moved correctly
        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    // Checks if searching an existing item
    // returns the correct index
    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = new CustomArrayList<int>();

        // Add values for searching
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Search for existing item
        int index = list.Search(20);

        // The item should be found at index 1
        Assert.Equal(1, index);
    }

    // Checks if searching for a missing item
    // returns -1
    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();

        // Add values to the list
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Search for a value that is not in the list
        int index = list.Search(40);

        // Should return -1 if item is not found
        Assert.Equal(-1, index);
    }

    // Checks if sorting arranges items
    // from smallest to largest value
    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        var list = new CustomArrayList<int>();

        // Add values in random order
        list.Add(30);
        list.Add(10);
        list.Add(20);

        // Sort the list
        list.Sort();

        // Check if values are now arranged correctly
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }
}