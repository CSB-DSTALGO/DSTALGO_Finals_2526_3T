namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    // ===================== Add =====================

    [Fact]
    public void Add_SingleItem_CountBecomesOne()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Add_MultipleItems_CountMatchesNumberAdded()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Add_Item_BecomesSearchableAfterwards()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(99);
        Assert.True(list.Search(99));
    }

    // ===================== Remove =====================

    [Fact]
    public void Remove_ExistingItem_ReturnsTrueAndDecrementsCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(5);
        list.Add(10);

        bool result = list.Remove(5);

        Assert.True(result);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Remove_NonExistingItem_ReturnsFalse()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);

        bool result = list.Remove(999);

        Assert.False(result);
        Assert.Equal(1, list.Count); 
    }

    [Fact]
    public void Remove_HeadItem_RestOfListStillWorks()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1); 
        list.Add(2);
        list.Add(3);

        list.Remove(1);

        Assert.False(list.Search(1));
        Assert.True(list.Search(2));
        Assert.True(list.Search(3));
        Assert.Equal(2, list.Count);
    }

    // ===================== Search =====================

    [Fact]
    public void Search_ItemExists_ReturnsTrue()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(42);
        Assert.True(list.Search(42));
    }

    [Fact]
    public void Search_ItemDoesNotExist_ReturnsFalse()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        Assert.False(list.Search(500));
    }

    [Fact]
    public void Search_AfterRemoval_ReturnsFalseForRemovedItem()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(7);
        list.Remove(7);
        Assert.False(list.Search(7));
    }

    // ===================== Sort =====================

    [Fact]
    public void Sort_EmptyList_DoesNotThrow()
    {
        var list = new CustomSinglyLinkedList<int>();
        var exception = Record.Exception(() => list.Sort());
        Assert.Null(exception);
    }

    [Fact]
    public void Sort_UnsortedItems_AllItemsStillPresentAfterSort()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        Assert.True(list.Search(10));
        Assert.True(list.Search(20));
        Assert.True(list.Search(30));
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Sort_SingleItem_CountUnchanged()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Sort();
        Assert.Equal(1, list.Count);
    }
}