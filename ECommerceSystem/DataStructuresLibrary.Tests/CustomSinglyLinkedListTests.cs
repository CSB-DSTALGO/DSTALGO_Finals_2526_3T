namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary.

public class CustomSinglyLinkedListTests
{
    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        // Act
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Remove_ShouldUpdateNodePointersCorrectly()
    {
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);

        // Remove head
        list.Remove(10);
        Assert.Equal(3, list.Count);
        Assert.Equal(20, list.Get(0));

        // Remove middle
        list.Remove(30);
        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.Get(0));
        Assert.Equal(40, list.Get(1));

        // Remove tail
        list.Remove(40);
        Assert.Equal(1, list.Count);
        Assert.Equal(20, list.Get(0));
    }

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(5);
        list.Add(10);
        list.Add(15);

        // Act
        bool found = list.Search(10);

        // Assert
        Assert.True(found);
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(5);
        list.Add(10);
        list.Add(15);

        // Act
        bool found = list.Search(100);

        // Assert
        Assert.False(found);
    }

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(30);
        list.Add(10);
        list.Add(20);
        list.Add(40);

        // Act
        list.Sort();

        // Assert
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
        Assert.Equal(40, list.Get(3));
    }
}

