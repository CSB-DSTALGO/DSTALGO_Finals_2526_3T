namespace DataStructuresLibrary.Tests;

using System.Collections.Generic;
using System.Linq;
using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        // TODO: Test appending items to the linked list
        var list = new CustomSinglyLinkedList<int>();

        list.Add(2);
        list.Add(4);
        list.Add(6);
        list.Add(8);
        list.Add(10);

        Assert.Equal(5, list.Count);
        Assert.Equal(new List<int> { 2, 4, 6, 8, 10 }, list.ToList());
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        // TODO: Test removing head, middle, and tail nodes
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);

        bool removedHead = list.Remove(1);
        Assert.True(removedHead);
        Assert.Equal(4, list.Count);
        Assert.Equal(new List<int> { 2, 3, 4, 5 }, list.ToList());

        bool removedMiddle = list.Remove(3);
        Assert.True(removedMiddle);
        Assert.Equal(3, list.Count);
        Assert.Equal(new List<int> { 2, 4, 5 }, list.ToList());

        bool removedTail = list.Remove(5);
        Assert.True(removedTail);
        Assert.Equal(2, list.Count);
        Assert.Equal(new List<int> { 2, 4 }, list.ToList());

        list.Add(6);
        Assert.Equal(new List<int> { 2, 4, 6 }, list.ToList());

        bool removedMissing = list.Remove(99);
        Assert.False(removedMissing);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        // TODO: Test linear node traversal finding existing data
        var list = new CustomSinglyLinkedList<int>();
        list.Add(55);
        list.Add(35);
        list.Add(25);
        list.Add(15);
        list.Add(45);

        Assert.True(list.Search(15));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        // TODO: Test linear search returning false for missing data
        var list = new CustomSinglyLinkedList<int>();
        list.Add(55);
        list.Add(35);
        list.Add(25);
        list.Add(15);
        list.Add(45);

        Assert.False(list.Search(999));
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        // TODO: Test node re-linking to verify ascending list order
        var list = new CustomSinglyLinkedList<int>();
        list.Add(40);
        list.Add(10);
        list.Add(30);
        list.Add(20);
        list.Add(50);

        list.Sort();

        Assert.Equal(new List<int> { 10, 20, 30, 40, 50 }, list.ToList());
        Assert.Equal(5, list.Count);

        list.Add(60);
        Assert.Equal(new List<int> { 10, 20, 30, 40, 50, 60 }, list.ToList());
    }
}