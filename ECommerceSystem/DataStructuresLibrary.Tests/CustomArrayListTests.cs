namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        // TODO: Implement test for Add and Get indexing
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        // TODO: Implement test verifying element removal and index shifting
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool removed = list.Remove(20);

        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        // TODO: Test Search returning zero-based index for existing element
        var list = new CustomArrayList<int>();

        list.Add(5);
        list.Add(10);
        list.Add(15);

        Assert.Equal(1, list.Search(10));
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        // TODO: Test Search returning -1 when element is absent
        var list = new CustomArrayList<int>();

        list.Add(5);
        list.Add(10);

        Assert.Equal(-1, list.Search(100));
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        // TODO: Test Sort ordering an unsorted CustomArrayList<int>
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
    public void Add_ShouldResizeArray_WhenCapacityIsExceeded()
    {
        // TEST FOR: RESIZING
        var list = new CustomArrayList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);

        Assert.Equal(5, list.Count);
        Assert.Equal(5, list.Get(4));
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        // TEST FOR: REMOVING AN ITEM THAT DOES NOT EXIST
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        bool result = list.Remove(30);

        Assert.False(result);
        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Get_ShouldThrowException_WhenIndexIsInvalid()
    {
        // TEST FOR: IF INVALID INDEXES ARE HANDLED CORRECTLY. 
        var list = new CustomArrayList<int>();

        list.Add(10);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(5));
    }


}