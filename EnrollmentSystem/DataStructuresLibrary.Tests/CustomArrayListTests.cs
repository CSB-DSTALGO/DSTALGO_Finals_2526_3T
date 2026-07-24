namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.Equal(3, list.Count);
        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void RemoveAt_ShouldRemoveElement()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.RemoveAt(2);

        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
    }

    [Fact]
    public void Get_ShouldThrowIndexOutOfRange_WhenInvalidIndex()
    {
        var list = new CustomArrayList<int>();
        list.Add(30);

        Assert.Throws<IndexOutOfRangeException>(() => list.Get(5));
    }

    [Fact]
    public void Get_ShouldThrowIndexOutOfRange_WhenEmpty()
    {
        var list = new CustomArrayList<int>();
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(0));
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.RemoveAt(1);

        Assert.Equal(2, list.Count);
        Assert.Equal(1, list.Get(0));
        Assert.Equal(3, list.Get(1));
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(10);
        list.Add(15);

        Assert.Equal(1, list.Search(10));
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(10);

        Assert.Equal(-1, list.Search(99));
    }

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
}