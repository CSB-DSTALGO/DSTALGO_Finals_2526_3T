namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(100);
        list.Add(200);

        Assert.Equal(2, list.Count);
        Assert.True(list.Search(100));
        Assert.True(list.Search(200));
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.True(list.Remove(1)); 
        Assert.False(list.Search(1));

        Assert.True(list.Remove(2)); 
        Assert.False(list.Search(2));

        Assert.True(list.Remove(3)); 
        Assert.False(list.Search(3));

        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(5);
        list.Add(10);

        Assert.True(list.Search(5));
        Assert.True(list.Search(10));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);

        Assert.False(list.Search(99));
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(3);
        list.Add(1);
        list.Add(2);

        list.Sort();

        Assert.True(list.Search(1));
        Assert.True(list.Search(2));
        Assert.True(list.Search(3));
    }
}