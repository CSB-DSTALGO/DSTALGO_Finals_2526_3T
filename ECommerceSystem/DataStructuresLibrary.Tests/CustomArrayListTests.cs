using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCount()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Get_ShouldReturnCorrectItem()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        Assert.Equal(20, list.Get(1));
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(1, list.Search(20));
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        Assert.Equal(-1, list.Search(50));
    }

    [Fact]
    public void Remove_ShouldRemoveItem()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Remove(20);

        Assert.True(result);
        Assert.Equal(2, list.Count);
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);

        bool result = list.Remove(50);

        Assert.False(result);
    }

    [Fact]
    public void Sort_ShouldArrangeItemsInAscendingOrder()
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
    public void Get_ShouldThrowException_WhenIndexIsInvalid()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);

        Assert.Throws<IndexOutOfRangeException>(() => list.Get(5));
    }
}
