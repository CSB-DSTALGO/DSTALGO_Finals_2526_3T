namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        CustomSinglyLinkedList<int> list = new();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(3, list.Count);
        Assert.True(list.Search(10));
        Assert.True(list.Search(20));
        Assert.True(list.Search(30));
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        CustomSinglyLinkedList<int> list = new();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.True(list.Remove(20));
        Assert.Equal(2, list.Count);

        Assert.False(list.Search(20));
        Assert.True(list.Search(10));
        Assert.True(list.Search(30));
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        CustomSinglyLinkedList<int> list = new();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.True(list.Search(20));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        CustomSinglyLinkedList<int> list = new();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.False(list.Search(100));
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        CustomSinglyLinkedList<int> list = new();

        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.True(list.Search(10));
        Assert.True(list.Search(20));
        Assert.True(list.Search(30));
        Assert.Equal(3, list.Count);
    }
}