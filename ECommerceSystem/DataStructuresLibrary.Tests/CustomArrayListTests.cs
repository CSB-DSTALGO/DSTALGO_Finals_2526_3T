namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact] // TODO: Implement test for Add and Get indexing
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
    }

    [Fact] // TODO: Implement test verifying element removal and index shifting

    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.Remove(20);

        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    [Fact] // TODO: Test Search returning zero-based index for existing element
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        int result = list.Search(20);

        Assert.Equal(1, result);
    }

    [Fact] // TODO: Test Search returning -1 when element is absent
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);

        int result = list.Search(99);

        Assert.Equal(-1, result);
    }

    [Fact] // TODO: Test Sort ordering an unsorted CustomArrayList<int>
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