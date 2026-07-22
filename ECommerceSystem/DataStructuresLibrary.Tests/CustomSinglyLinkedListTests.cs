namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);

        // Remove head
        bool removedHead = list.Remove(10);

        Assert.True(removedHead);
        Assert.Equal(3, list.Count);
        Assert.Equal(20, list.Get(0));

        // Remove middle
        bool removedMiddle = list.Remove(30);

        Assert.True(removedMiddle);
        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.Get(0));
        Assert.Equal(40, list.Get(1));

        // Remove tail
        bool removedTail = list.Remove(40);

        Assert.True(removedTail);
        Assert.Equal(1, list.Count);
        Assert.Equal(20, list.Get(0));

        // Try removing an item that does not exist
        bool removedMissingItem = list.Remove(99);

        Assert.False(removedMissingItem);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Search(20);

        Assert.True(result);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Search(99);

        Assert.False(result);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(40);
        list.Add(10);
        list.Add(30);
        list.Add(20);

        list.Sort();

        Assert.Equal(4, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
        Assert.Equal(40, list.Get(3));
    }
}