namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
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

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);

        list.RemoveAt(1);

        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
        Assert.Equal(40, list.Get(2));
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(15);
        list.Add(25);

        int index = list.IndexOf(15);

        Assert.Equal(1, index);
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(15);
        list.Add(25);

        int index = list.IndexOf(999);

        Assert.Equal(-1, index);
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(40);
        list.Add(10);
        list.Add(30);
        list.Add(20);

        list.Sort(Comparer<int>.Default);

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
        Assert.Equal(40, list.Get(3));
    }
}