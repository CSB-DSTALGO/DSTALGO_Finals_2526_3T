namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        
        var list = new CustomArrayList<int>();

        list.Add(100);
        list.Add(200);
        list.Add(300);

        Assert.Equal(3, list.Count);
        Assert.True(list.Get(0).Equals(100));
        Assert.True(list.Get(1).Equals(200));
        Assert.True(list.Get(2).Equals(300));
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
       

        var list = new CustomArrayList<int>();

        list.Add(100);
        list.Add(200);
        list.Add(300);

        list.Remove(200);

        Assert.Equal(2, list.Count);
        Assert.True(list.Get(0).Equals(100));
        Assert.True(list.Get(1).Equals(300));        
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        

        var list = new CustomArrayList<int>();

        list.Add(100);
        list.Add(200);
        list.Add(300);

        int index = list.Search(100);

        Assert.Equal(0, index);
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        
        var list = new CustomArrayList<int>();

        list.Add(100);
        list.Add(200);
        list.Add(300);

        int notFound = list.Search(400);

        Assert.Equal(-1, notFound);
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
       
        var list = new CustomArrayList<int>();
        
        list.Add(200);
        list.Add(100);
        list.Add(300);

        list.Sort();

       
        Assert.Equal(100, list.Get(0));
        Assert.Equal(200, list.Get(1));
        Assert.Equal(300, list.Get(2));
    }
}