namespace DataStructuresLibrary.Tests;

using System;
using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    // Add tests
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
    }

    [Fact]
    public void Add_ShouldTriggerResizeWhenCapacityExceeded()
    {
        var list = new CustomArrayList<int>();
        // Default capacity is 4. Add 5 items to trigger resize.
        for (int i = 0; i < 5; i++)
        {
            list.Add(i);
        }
        Assert.Equal(5, list.Count);
        Assert.Equal(4, list.Get(4));
    }

    [Fact]
    public void Add_NullString_ShouldHandleNullValues()
    {
        var list = new CustomArrayList<string>();
        list.Add(null!);
        Assert.Equal(1, list.Count);
        Assert.Null(list.Get(0));
    }

    // Get tests
    [Fact]
    public void Get_ValidIndex_ShouldReturnCorrectItem()
    {
        var list = new CustomArrayList<int>();
        list.Add(55);
        Assert.Equal(55, list.Get(0));
    }

    [Fact]
    public void Get_NegativeIndex_ShouldThrowIndexOutOfRangeException()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
    }

    [Fact]
    public void Get_IndexOutOfRange_ShouldThrowIndexOutOfRangeException()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(1));
    }

    // RemoveAt tests
    [Fact]
    public void RemoveAt_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.RemoveAt(1); // Remove 2
        Assert.Equal(2, list.Count);
        Assert.Equal(3, list.Get(1));
    }

    [Fact]
    public void RemoveAt_NegativeIndex_ShouldThrowException()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(-1));
    }

    [Fact]
    public void RemoveAt_IndexOutOfRange_ShouldThrowException()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(1));
    }

    // Search tests
    [Fact]
    public void Search_ShouldReturnCorrectItem_WhenItemExists()
    {
        var list = new CustomArrayList<int>();
        list.Add(100);
        list.Add(200);
        
        var result = list.Search(x => x == 200);
        Assert.Equal(200, result);
    }

    [Fact]
    public void Search_ShouldReturnDefault_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();
        list.Add(100);
        
        var result = list.Search(x => x == 50);
        Assert.Equal(default, result); // int default is 0
    }

    [Fact]
    public void Search_EmptyList_ShouldReturnDefault()
    {
        var list = new CustomArrayList<string>();
        var result = list.Search(x => x == "test");
        Assert.Null(result); // string default is null
    }

    // Sort tests
    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        var list = new CustomArrayList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);
        
        list.Sort((a, b) => a.CompareTo(b));
        
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Sort_AlreadySortedList_ShouldRemainSorted()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        list.Sort((a, b) => a.CompareTo(b));
        
        Assert.Equal(1, list.Get(0));
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void Sort_EmptyList_ShouldNotThrow()
    {
        var list = new CustomArrayList<int>();
        list.Sort((a, b) => a.CompareTo(b));
        Assert.Equal(0, list.Count);
    }
}
