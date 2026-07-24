namespace DataStructuresLibrary.Tests;

namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
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
    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<string>();
        list.Add("Apple");
        list.Add("Banana");
        list.Add("Cherry");

        bool removed = list.Remove("Banana");

        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal("Apple", list.Get(0));
        Assert.Equal("Cherry", list.Get(1));
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(15);
        list.Add(25);

        int index = list.Search(15);

        Assert.Equal(1, index);
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(15);

        int index = list.Search(99);

        Assert.Equal(-1, index);
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        var list = new CustomArrayList<int>();
        list.Add(42);
        list.Add(12);
        list.Add(89);
        list.Add(5);

        list.Sort();

        Assert.Equal(5, list.Get(0));
        Assert.Equal(12, list.Get(1));
        Assert.Equal(42, list.Get(2));
        Assert.Equal(89, list.Get(3));
    }
}