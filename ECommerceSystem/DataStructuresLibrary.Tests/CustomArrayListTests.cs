namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
<<<<<<< HEAD
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
=======
<<<<<<< Updated upstream
    public class CustomArrayListTests
>>>>>>> 6129a35d1a33a76f2ad7a428a8dee8075999ee7d
    {
        // TODO: Implement test for Add and Get indexing
        throw new NotImplementedException();
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        // TODO: Implement test verifying element removal and index shifting
        throw new NotImplementedException();
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        // TODO: Test Search returning zero-based index for existing element
        throw new NotImplementedException();
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        // TODO: Test Search returning -1 when element is absent
        throw new NotImplementedException();
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        // TODO: Test Sort ordering an unsorted CustomArrayList<int>
        throw new NotImplementedException();
    }
}
=======
    [Fact]
    public void Add_ShouldAddItemToList()
    {
        // Arrange
        var list = new CustomArrayList<int>();

        // Act 
        list .Add(10);
        list .Add(20);
        list .Add(30);

        // Assert
        Assert.Equal(3, list.Count);
        Assert .Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));

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
        
        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert .Equal(20, list.Get(1));
        Assert .Equal(30, list.Get(2));


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
        list.Remove(20);

        // Assert
         Assert.Equal(2, list.Count);
         Assert .Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void search_shouldReturnCorrectIndex_whenItemExists()
    {
        // Arrange
        var list = new CustomArrayList<int>();
        {
            list.Add(5);
            list.Add(15);
            list.Add(25);

            // Act 
            int index = list.Search(15);

            // Assert
            Assert.Equal(1, index);

        }
    }

    [Fact]
    public void Search_shouldReturnMinusOne_WhenItemDoesNotExist()
    {
        // Arrange 
        var list = new CustomArrayList<int>();
        list.Add(5);
        list.Add(15);
        list.Add(25);

        // Act
        int index = list.Search(100);

        // Assert
        Assert.Equal(-1, index);
    }

    [Fact]
     public void Sort_ShouldOrderElementsInAscendingOrder()
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
>>>>>>> Stashed changes
