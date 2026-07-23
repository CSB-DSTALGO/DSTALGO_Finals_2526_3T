namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        // TODO: Implement test for Add and Get indexing
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        Assert.Equal(2, list.Count);
        list.Add(21);
        Assert.Equal(3, list.Count);
        list.Add(22);
        list.Add(23);
        Assert.Equal(5, list.Count);
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        CustomArrayList<int> list = new();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.RemoveAt(1);

        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        CustomArrayList<int> list = new();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        int index = list.Search(20);

        Assert.Equal(1, index);
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        CustomArrayList<int> list = new();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        int index = list.Search(100);

        Assert.Equal(-1, index);
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        CustomArrayList<int> list = new();

        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }
}