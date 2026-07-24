namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    // Add

    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);

        Assert.Equal(1, list.Count);
        Assert.True(list.Search(10));
    }

    [Fact]
    public void Add_MultipleItems_ShouldIncrementCountEachTime()
    {
        var list = new CustomSinglyLinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Add_ShouldPreserveInsertionOrder()
    {
        var list = new CustomSinglyLinkedList<int>();
        var visited = new List<int>();

        list.Add(5);
        list.Add(1);
        list.Add(9);
        list.ForEach(item => visited.Add(item)); // collect in traversal order

        Assert.Equal(new List<int> { 5, 1, 9 }, visited);
    }

    // Remove

    [Fact]
    public void Remove_HeadNode_ShouldUpdateHeadAndDecrementCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        bool removed = list.Remove(1); // removes head

        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.False(list.Search(1));
    }

    [Fact]
    public void Remove_MiddleNode_ShouldRelinkSurroundingNodes()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        bool removed = list.Remove(2); // removes middle node

        var visited = new List<int>();
        list.ForEach(item => visited.Add(item));

        Assert.True(removed);
        Assert.Equal(new List<int> { 1, 3 }, visited);
    }

    [Fact]
    public void Remove_ItemNotInList_ShouldReturnFalseAndNotChangeCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);

        bool removed = list.Remove(99); // not present

        Assert.False(removed);
        Assert.Equal(2, list.Count);
    }

    // Search

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(4);
        list.Add(8);
        list.Add(15);

        Assert.True(list.Search(8));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(4);
        list.Add(8);

        Assert.False(list.Search(100));
    }

    [Fact]
    public void Search_OnEmptyList_ShouldReturnFalse()
    {
        var list = new CustomSinglyLinkedList<int>();

        Assert.False(list.Search(1)); // empty list case
    }

    // Sort

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        var visited = new List<int>();
        list.ForEach(item => visited.Add(item));

        Assert.Equal(new List<int> { 10, 20, 30 }, visited);
    }

    [Fact]
    public void Sort_AlreadySortedList_ShouldRemainUnchanged()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Sort();

        var visited = new List<int>();
        list.ForEach(item => visited.Add(item));

        Assert.Equal(new List<int> { 1, 2, 3 }, visited);
    }

    [Fact]
    public void Sort_SingleOrEmptyList_ShouldNotThrow()
    {
        var emptyList = new CustomSinglyLinkedList<int>();
        var singleList = new CustomSinglyLinkedList<int>();
        singleList.Add(42);

        emptyList.Sort();  // 0 nodes
        singleList.Sort(); // 1 node

        Assert.Equal(0, emptyList.Count);
        Assert.Equal(1, singleList.Count);
    }
}