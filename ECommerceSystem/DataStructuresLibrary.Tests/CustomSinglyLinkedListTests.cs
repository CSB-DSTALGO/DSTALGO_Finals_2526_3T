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

        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.Equal(3, list.Count);
        Assert.Equal(new[] { 1, 2, 3 }, list);
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        // TODO: Test removing head, middle, and tail nodes
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        // remove the head
        Assert.True(list.Remove(1));
        Assert.Equal(new[] { 2, 3 }, list);

        // remove the tail
        Assert.True(list.Remove(3));
        Assert.Equal(new[] { 2 }, list);

        // remove the only remaining node
        Assert.True(list.Remove(2));
        Assert.Empty(list);
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        // TODO: Test linear node traversal finding existing data
        var list = new CustomSinglyLinkedList<int>();
        list.Add(7);
        list.Add(14);

        Assert.True(list.Search(14));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        // TODO: Test linear search returning false for missing data
        var list = new CustomSinglyLinkedList<int>();
        list.Add(7);

        Assert.False(list.Search(999));
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        // TODO: Test node re-linking to verify ascending list order
        var list = new CustomSinglyLinkedList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.Equal(new[] { 10, 20, 30 }, list);
    }
}