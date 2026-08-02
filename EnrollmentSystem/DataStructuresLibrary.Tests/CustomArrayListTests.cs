namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

// Unit tests for the CustomArrayList class.
public class CustomArrayListTests
{
    // Verifies that adding elements increases the count
    // and stores items in the correct order.
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        Assert.Equal(2, list.Count);

        list.Add(21);
        Assert.Equal(3, list.Count);

        list.Add(22);
        list.Add(23);

        Assert.Equal(5, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(21, list.Get(2));
        Assert.Equal(22, list.Get(3));
        Assert.Equal(23, list.Get(4));
    }

    // Verifies that removing an element shifts the remaining
    // elements to fill the empty position.
    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.RemoveAt(1);

        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    // Verifies that Search returns the correct zero-based index
    // when the specified element exists.
    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(1, list.Search(20));
    }

    // Verifies that Search returns -1 when the
    // specified element is not found.
    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        Assert.Equal(-1, list.Search(30));
    }

    // Verifies that Sort arranges the elements
    // in ascending order.
    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }
}