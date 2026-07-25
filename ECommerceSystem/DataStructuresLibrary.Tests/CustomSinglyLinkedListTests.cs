namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

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
        Assert.Equal(10, list.GetAt(0));
        Assert.Equal(20, list.GetAt(1));
        Assert.Equal(30, list.GetAt(2));
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

        // Act & Assert - Remove head
        Assert.True(list.Remove(10));
        Assert.Equal(3, list.Count);
        Assert.Equal(20, list.GetAt(0));

        // Act & Assert - Remove middle
        Assert.True(list.Remove(30));
        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.GetAt(0));
        Assert.Equal(40, list.GetAt(1));

        // Act & Assert - Remove tail
        Assert.True(list.Remove(40));
        Assert.Equal(1, list.Count);
        Assert.Equal(20, list.GetAt(0));
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
        bool result = list.Search(10);

        // Assert
        Assert.True(result);
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
        bool result = list.Search(100);

        // Assert
        Assert.False(result);
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
        Assert.Equal(10, list.GetAt(0));
        Assert.Equal(20, list.GetAt(1));
        Assert.Equal(30, list.GetAt(2));
        Assert.Equal(40, list.GetAt(3));
    }
}
