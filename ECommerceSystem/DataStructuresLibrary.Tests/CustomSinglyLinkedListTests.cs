namespace DataStructuresLibrary.Tests;

using System;
using System.IO;
using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    // Add tests
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);
        Assert.Equal(1, list.Count);
        Assert.Equal(10, list.GetItemAt(0));
    }

    [Fact]
    public void Add_MultipleItems_ShouldMaintainOrderAndCount()
    {
        var list = new CustomSinglyLinkedList<string>();
        list.Add("First");
        list.Add("Second");
        list.Add("Third");
        Assert.Equal(3, list.Count);
        Assert.Equal("Third", list.GetItemAt(2));
    }

    [Fact]
    public void Add_NullString_ShouldHandleNullValues()
    {
        var list = new CustomSinglyLinkedList<string>();
        list.Add(null!);
        Assert.Equal(1, list.Count);
        Assert.Null(list.GetItemAt(0));
    }

    // Remove tests
    [Fact]
    public void Remove_HeadNode_ShouldUpdateHeadAndCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(10);
        list.Add(20);
        bool result = list.Remove(10);
        Assert.True(result);
        Assert.Equal(1, list.Count);
        Assert.Equal(20, list.GetItemAt(0));
    }

    [Fact]
    public void Remove_MiddleOrTailNode_ShouldUpdatePointersCorrectly()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        bool result = list.Remove(2);
        Assert.True(result);
        Assert.Equal(2, list.Count);
        Assert.Equal(3, list.GetItemAt(1));
    }

    [Fact]
    public void Remove_ItemNotInList_ShouldReturnFalseAndNotChangeCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(5);
        bool result = list.Remove(10);
        Assert.False(result);
        Assert.Equal(1, list.Count);
    }

    // Search tests
    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(100);
        list.Add(200);
        Assert.True(list.Search(200));
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(100);
        Assert.False(list.Search(50));
    }

    [Fact]
    public void Search_EmptyList_ShouldReturnFalse()
    {
        var list = new CustomSinglyLinkedList<int>();
        Assert.False(list.Search(10));
    }

    // Sort tests
    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);
        list.Sort();
        Assert.Equal(10, list.GetItemAt(0));
        Assert.Equal(20, list.GetItemAt(1));
        Assert.Equal(30, list.GetItemAt(2));
    }

    [Fact]
    public void Sort_AlreadySortedList_ShouldRemainSorted()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Sort();
        Assert.Equal(1, list.GetItemAt(0));
        Assert.Equal(3, list.GetItemAt(2));
    }

    [Fact]
    public void Sort_EmptyOrSingleItemList_ShouldNotThrow()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Sort();
        Assert.Equal(0, list.Count);

        list.Add(5);
        list.Sort();
        Assert.Equal(5, list.GetItemAt(0));
    }

    // GetItemAt tests
    [Fact]
    public void GetItemAt_ValidIndex_ShouldReturnCorrectItem()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(55);
        list.Add(66);
        Assert.Equal(66, list.GetItemAt(1));
    }

    [Fact]
    public void GetItemAt_NegativeIndex_ShouldThrowArgumentOutOfRangeException()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetItemAt(-1));
    }

    [Fact]
    public void GetItemAt_IndexOutOfRange_ShouldThrowArgumentOutOfRangeException()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetItemAt(1));
    }

    // PrintAll tests
    [Fact]
    public void PrintAll_ShouldWriteItemsToConsole()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(99);
        using var sw = new StringWriter();
        Console.SetOut(sw);
        
        list.PrintAll();
        
        var output = sw.ToString().Trim();
        Assert.Equal("99", output);
        
        // Reset console out
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    [Fact]
    public void PrintAll_EmptyList_ShouldNotPrintAnything()
    {
        var list = new CustomSinglyLinkedList<int>();
        using var sw = new StringWriter();
        Console.SetOut(sw);
        
        list.PrintAll();
        
        var output = sw.ToString();
        Assert.Empty(output);
        
        // Reset console out
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    [Fact]
    public void PrintAll_MultipleItems_ShouldPrintInOrder()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        using var sw = new StringWriter();
        sw.NewLine = "\n";
        Console.SetOut(sw);
        
        list.PrintAll();
        
        var output = sw.ToString().Trim();
        Assert.Equal("1\n2", output.Replace("\r\n", "\n"));
        
        // Reset console out
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }
}