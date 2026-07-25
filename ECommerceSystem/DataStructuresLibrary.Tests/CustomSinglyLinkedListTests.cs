namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        // TODO: Test appending items to the linked list
        var list = new CustomSinglyLinkedList<int>();

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
        // TODO: Test removing head, middle, and tail nodes
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.True(list.Remove(20));
        Assert.Equal(2, list.Count);
        Assert.False(list.Search(20));
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        // TODO: Test linear node traversal finding existing data
        var list = new CustomSinglyLinkedList<int>();

        list.Add(5);
        list.Add(10);
        list.Add(15);

        Assert.True(list.Search(10));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        // TODO: Test linear search returning false for missing data
        var list = new CustomSinglyLinkedList<int>();

        list.Add(5);
        list.Add(10);
        list.Add(15);

        Assert.False(list.Search(20));
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        // TODO: Test node re-linking to verify ascending list order
        var list = new CustomSinglyLinkedList<int>();

        list.Add(3);
        list.Add(1);
        list.Add(4);
        list.Add(2);

        list.Sort();

        Assert.Equal(4, list.Count);
        Assert.True(list.Search(1));
        Assert.True(list.Search(2));
        Assert.True(list.Search(3));
        Assert.True(list.Search(4));

    }
}