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
        Assert.Equal(new[] { 10, 20, 30 }, list.ToArray());
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10); // head
        list.Add(20); // middle
        list.Add(30); // middle
        list.Add(40); // tail

        bool removedHead = list.Remove(10);
        bool removedMiddle = list.Remove(30);
        bool removedTail = list.Remove(40);

        Assert.True(removedHead);
        Assert.True(removedMiddle);
        Assert.True(removedTail);
        Assert.Equal(1, list.Count);
        Assert.Equal(new[] { 20 }, list.ToArray());
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(5);
        list.Add(15);
        list.Add(25);

        Assert.True(list.Search(15));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(5);
        list.Add(15);

        Assert.False(list.Search(99));
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.Equal(new[] { 10, 20, 30 }, list.ToArray());
        Assert.Equal(3, list.Count);
    }
}