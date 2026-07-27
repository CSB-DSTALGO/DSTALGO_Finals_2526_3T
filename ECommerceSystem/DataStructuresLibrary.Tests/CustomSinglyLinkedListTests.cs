namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;
using System.Reflection;

public class CustomSinglyLinkedListTests
{
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        // arrange
        var list = new CustomSinglyLinkedList<int>();

        // act
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // assert
        Assert.Equal(3, list.Count);
        Assert.True(list.Search(10));
        Assert.True(list.Search(20));
        Assert.True(list.Search(30));
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        // arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        // act
        bool removed = list.Remove(20);

        // assert
        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.False(list.Search(20));
        Assert.True(list.Search(10));
        Assert.True(list.Search(30));
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        // arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        // act
        bool found = list.Search(20);

        // assert
        Assert.True(found);
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        // arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);

        // act
        bool found = list.Search(50);

        // assert
        Assert.False(found);
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        // arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(30);
        list.Add(10);
        list.Add(20);

        // act
        list.Sort();

        // assert

        // to access the private _head field
        var headField = typeof(CustomSinglyLinkedList<int>)
            .GetField("_head", BindingFlags.NonPublic | BindingFlags.Instance);

        var head = headField!.GetValue(list); //_head is private, used headField for testing

        Assert.NotNull(head);

        var nodeType = head!.GetType();

        var dataField = nodeType.GetField("Data");
        var nextField = nodeType.GetField("Next");

        Assert.Equal(10, dataField!.GetValue(head));

        var second = nextField!.GetValue(head);
        Assert.NotNull(second);
        Assert.Equal(20, dataField.GetValue(second));

        var third = nextField.GetValue(second);
        Assert.NotNull(third);
        Assert.Equal(30, dataField.GetValue(third));

        Assert.Null(nextField.GetValue(third));
    }
}