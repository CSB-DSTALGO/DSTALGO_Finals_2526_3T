namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        // TODO: Implement test for Add and Get indexing
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        Assert.Equal(2, list.Count);
        list.Add(21);
        Assert.Equal(3, list.Count);
        list.Add(22);
        list.Add(23);
        Assert.Equal(5, list.Count);
        
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
