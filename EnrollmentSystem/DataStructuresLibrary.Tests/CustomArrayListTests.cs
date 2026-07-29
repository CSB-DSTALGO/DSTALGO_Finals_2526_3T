namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_IncreasesCount()
    {
        var list = new CustomArrayList<int>();
        list.Add(10);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Add_ResizesWhenFull()
    {
        var list = new CustomArrayList<int>(initialCapacity: 2);
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.Equal(3, list.Count);
        Assert.Equal(3, list.GetAt(2));
    }

    [Fact]
    public void Add_KeepsItemsInOrder()
    {
        var list = new CustomArrayList<string>();
        list.Add("Alice");
        list.Add("Bob");
        list.Add("Carol");

        Assert.Equal("Alice", list.GetAt(0));
        Assert.Equal("Bob", list.GetAt(1));
        Assert.Equal("Carol", list.GetAt(2));
    }

    [Fact]
    public void GetAt_ReturnsCorrectItem()
    {
        var list = new CustomArrayList<string>();
        list.Add("Alice");
        list.Add("Bob");

        Assert.Equal("Alice", list.GetAt(0));
        Assert.Equal("Bob", list.GetAt(1));
    }

    [Fact]
    public void GetAt_TooHighIndex_ThrowsError()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);

        Assert.Throws<IndexOutOfRangeException>(() => list.GetAt(5));
    }

    [Fact]
    public void GetAt_NegativeIndex_ThrowsError()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);

        Assert.Throws<IndexOutOfRangeException>(() => list.GetAt(-1));
    }

    [Fact]
    public void RemoveAt_ShiftsItemsLeft()
    {
        var list = new CustomArrayList<string>();
        list.Add("Alice");
        list.Add("Bob");
        list.Add("Carol");

        list.RemoveAt(0);

        Assert.Equal(2, list.Count);
        Assert.Equal("Bob", list.GetAt(0));
        Assert.Equal("Carol", list.GetAt(1));
    }

    [Fact]
    public void RemoveAt_InvalidIndex_ThrowsError()
    {
        var list = new CustomArrayList<int>();
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(0));
    }

    [Fact]
    public void RemoveAt_OnlyItem_CountBecomesZero()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);

        list.RemoveAt(0);

        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void SetAt_ChangesItemAtIndex()
    {
        var list = new CustomArrayList<string>();
        list.Add("Alice");

        list.SetAt(0, "Alicia");

        Assert.Equal("Alicia", list.GetAt(0));
    }

    [Fact]
    public void SetAt_InvalidIndex_ThrowsError()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);

        Assert.Throws<IndexOutOfRangeException>(() => list.SetAt(5, 100));
    }

    [Fact]
    public void SetAt_CountStaysTheSame()
    {
        var list = new CustomArrayList<int>();
        list.Add(1);
        list.Add(2);

        list.SetAt(0, 99);

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void ToArray_MatchesCount()
    {
        var list = new CustomArrayList<int>(initialCapacity: 10);
        list.Add(1);
        list.Add(2);

        int[] result = list.ToArray();

        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void ToArray_KeepsOrder()
    {
        var list = new CustomArrayList<string>();
        list.Add("Alice");
        list.Add("Bob");

        string[] result = list.ToArray();

        Assert.Equal("Alice", result[0]);
        Assert.Equal("Bob", result[1]);
    }

    [Fact]
    public void ToArray_EmptyListReturnsEmptyArray()
    {
        var list = new CustomArrayList<int>();

        int[] result = list.ToArray();

        Assert.Empty(result);
    }
}