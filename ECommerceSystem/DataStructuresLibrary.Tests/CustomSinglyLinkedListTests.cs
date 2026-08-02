namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        // TODO: Test appending items to the linked list
        var list = new CustomSinglyLinkedList<string>();
        string testItem = "TestItem_A";

        list.Add(testItem);

        Assert.Equal(1, list.Count);
        Assert.True(list.Search(testItem));
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        // TODO: Test removing head, middle, and tail nodes
        var list = new CustomSinglyLinkedList<int>();
        list.Add(100);
        list.Add(200);
        list.Add(300);
        
        // Remove head
        Assert.True(list.Remove(100));
        Assert.False(list.Search(100));
        Assert.Equal(2, list.Count);
        
        // Remove tail/middle
                
        Assert.True(list.Remove(200));
        Assert.False(list.Search(200));
        Assert.Equal(1, list.Count);
        
        Assert.True(list.Remove(300));
        Assert.False(list.Search(300));
        Assert.Equal(0, list.Count);

    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        // TODO: Test linear node traversal finding existing data
        var list = new CustomSinglyLinkedList<string>();
        string existingItem = "TargetItem";
        list.Add("OtherItem");
        list.Add(existingItem);
        
        Assert.True(list.Search(existingItem));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        // TODO: Test linear search returning false for missing data
        var list = new CustomSinglyLinkedList<string>();
        list.Add("ExistingItem");
        
        Assert.False(list.Search("NonExistentItem"));
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
        
        list.Sort();
        
        Assert.Equal(4, list.Count);
        Assert.True(list.Search(10));
        Assert.True(list.Search(20));
        Assert.True(list.Search(30));
        Assert.True(list.Search(40));
    }
}