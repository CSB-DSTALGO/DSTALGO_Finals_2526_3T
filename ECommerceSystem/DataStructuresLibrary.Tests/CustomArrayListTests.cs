namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        // Arrange
        var list = new CustomArrayList<int>();

        // Act
        list.Add(10);
        list.Add(20);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        // Arrange
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        bool removed = list.Remove(20);

        // Assert
        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        // Arrange
        var list = new CustomArrayList<int>();

        list.Add(5);
        list.Add(10);
        list.Add(15);

        // Act
        int index = list.Search(10);

        // Assert
        Assert.Equal(1, index);
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        // Arrange
        var list = new CustomArrayList<int>();

        list.Add(5);
        list.Add(10);

        // Act
        int index = list.Search(100);

        // Assert
        Assert.Equal(-1, index);
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        // Arrange
        var list = new CustomArrayList<int>();

        list.Add(40);
        list.Add(10);
        list.Add(30);
        list.Add(20);

        // Act
        list.Sort();

        // Assert
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
        Assert.Equal(40, list.Get(3));
    }
}