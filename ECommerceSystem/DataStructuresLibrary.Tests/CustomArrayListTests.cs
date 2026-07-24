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
        list.Add(30);

        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        bool wasRemoved = list.Remove(2);

        Assert.True(wasRemoved);
        Assert.Equal(3, list.Count);
        // everything after the removed item should have shifted left by one
        Assert.Equal(1, list.Get(0));
        Assert.Equal(3, list.Get(1));
        Assert.Equal(4, list.Get(2));
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
        // TODO: Test Search returning -1 when element is absent
        var list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(15);

        int index = list.Search(999);

        Assert.Equal(-1, index);
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