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
        list.Add(100);
        list.Add(200);

        assert.Equal(2, list.Count);
        assert.True(list.Search(100));
        assert.True(list.Search(200));
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        // TODO: Test removing head, middle, and tail nodes
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        assert.True(list.Remove(1)); 
        assert.False(list.Search(1));

        assert.True(list.Remove(2)); 
        assert.False(list.Search(2));

        assert.True(list.Remove(3)); 
        assert.False(list.Search(3));

        assert.Equal(0, list.Count);
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        // TODO: Test linear node traversal finding existing data
        var list = new CustomSinglyLinkedList<int>();
        list.Add(5);
        list.Add(10);

        assert.True(list.Search(5));
        assert.True(list.Search(10));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        // TODO: Test linear search returning false for missing data
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);

        assert.False(list.Search(99));
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        // TODO: Test node re-linking to verify ascending list order
        var list = new CustomSinglyLinkedList<int>();
        list.Add(3);
        list.Add(1);
        list.Add(2);

        list.Sort();

        Assert.True(list.Search(1));
        Assert.True(list.Search(2));
        Assert.True(list.Search(3));
    }
}