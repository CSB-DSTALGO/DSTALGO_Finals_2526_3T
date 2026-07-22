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
    public void Add_multipleItems_ShouldMaintainCorrectOrder()
    {
        //test for multiple values and order of insertion
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        Assert.Equal(5, list.Count);
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, list.ToList());
    }

    [Fact]
    public void Add_emptyList_ShouldSetHeadAndTailToSameNode()
    {
        //test for a node of a single value added to an empty list
        var list = new CustomSinglyLinkedList<int>();
        list.Add(42);
        Assert.Equal(1, list.Count);
        Assert.Equal(new List<int> { 42 }, list.ToList());
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
    public void Remove_ItemThatExists_CountGoesDown()
    {
        //test for removing an item that exists in the list and checking if the count decreases
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Remove(2);

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Remove_ItemThatDoesNotExist_ReturnsFalse()
    {
        //test for removing an item that does not exist in the list and checking if it returns false
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);

        bool result = list.Remove(999);

        Assert.False(result);
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
    public void Seach_duplicateValues_ShouldReturnTrueForExistingDuplicates()
    {
        //test for searching for a value that has duplicates in the list
        var list = new CustomSinglyLinkedList<int>();
        list.Add(5);
        list.Add(10);
        list.Add(5);
        list.Add(20);
        Assert.True(list.Search(5)); 
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

    [Fact]
    public void Sort_ListWithDuplicates_ShouldGroupEqualValuesTogether()
    {
        //test for sorting a list with duplicate values and checking if they are grouped together
        var list = new CustomSinglyLinkedList<int>();
        list.Add(5);
        list.Add(1);
        list.Add(5);
        list.Add(3);

        list.Sort();

        Assert.Equal(new List<int> { 1, 3, 5, 5 }, list.ToList());
    }

    [Fact]
    public void Sort_EmptyList_ShouldRemainEmpty()
    {
        //test for sorting an empty list and checking if it remains empty
        var list = new CustomSinglyLinkedList<int>();
        list.Sort();
        Assert.Empty(list.ToList());
    }
}