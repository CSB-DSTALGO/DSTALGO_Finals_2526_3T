using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void ThisIsYourTest()
        {
                    list.Add(10);
        Assert.Equal(1, list.Count);
        Assert.Equal(10, list[0]);

        list.Add(20);
        Assert.Equal(2, list.Count);
        Assert.Equal(20, list[1]);
    }

    [Fact]
    public void Indexer_GetAndSet_Works()
    {
        var list = new CustomArrayList<string> { "a", "b", "c" };
        Assert.Equal("b", list[1]);

        list[1] = "beta";
        Assert.Equal("beta", list[1]);
    }

    [Fact]
    public void Insert_ShiftsElementsAndIncreasesCount()
    {
        var list = new CustomArrayList<int> { 1, 3 };
        list.Insert(1, 2); // [1,2,3]
        Assert.Equal(3, list.Count);
        Assert.Equal(2, list[1]);
        Assert.Equal(3, list[2]);
    }

    [Fact]
    public void RemoveAt_RemovesElementAndShifts()
    {
        var list = new CustomArrayList<int> { 1, 2, 3, 4 };
        list.RemoveAt(1); // remove 2
        Assert.Equal(3, list.Count);
        Assert.Equal(3, list[1]);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(list.Count));
    }

    [Fact]
    public void Remove_ByValue_ReturnsTrueWhenRemoved()
    {
        var list = new CustomArrayList<string> { "x", "y", "z", "y" };
        var removed = list.Remove("y");
        Assert.True(removed);
        Assert.Equal(3, list.Count);
        Assert.Equal("z", list[1]); // first "y" removed

        var notRemoved = list.Remove("not-present");
        Assert.False(notRemoved);
    }

    [Fact]
    public void Clear_ResetsCountAndRemovesItems()
    {
        var list = new CustomArrayList<int> { 1, 2, 3 };
        list.Clear();
        Assert.Equal(0, list.Count);
        Assert.Throws<ArgumentOutOfRangeException>(() => { var x = list[0]; });
    }

    [Fact]
    public void ContainsAndIndexOf_WorkCorrectly()
    {
        var list = new CustomArrayList<char> { 'a', 'b', 'c' };
        Assert.True(list.Contains('b'));
        Assert.False(list.Contains('z'));
        Assert.Equal(1, list.IndexOf('b'));
        Assert.Equal(-1, list.IndexOf('z'));
    }

    [Fact]
    public void ToArray_ReturnsCorrectArray()
    {
        var list = new CustomArrayList<int> { 5, 6, 7 };
        var arr = list.ToArray();
        Assert.IsType<int[]>(arr);
        Assert.Equal(new[] { 5, 6, 7 }, arr);
    }

    [Fact]
    public void Enumerator_EnumeratesAllItems()
    {
        var list = new CustomArrayList<int> { 1, 2, 3 };
        var seen = new List<int>();
        foreach (var v in list)
        {
            seen.Add(v);
        }
        Assert.Equal(new[] { 1, 2, 3 }, seen.ToArray());

        // Also check non-generic enumerator if implemented
        var nonGeneric = (IEnumerable)list;
        var enumerator = nonGeneric.GetEnumerator();
        var items = new List<int>();
        while (enumerator.MoveNext())
        {
            items.Add((int)enumerator.Current);
        }
        Assert.Equal(new[] { 1, 2, 3 }, items.ToArray());
    }

    [Fact]
    public void InsertAndAdd_TriggerResizeIfNeeded()
    {
        var list = new CustomArrayList<int>();
        // keep adding more than typical small initial capacity to force resize
        for (int i = 0; i < 100; i++) list.Add(i);

        Assert.Equal(100, list.Count);
        for (int i = 0; i < 100; i++) Assert.Equal(i, list[i]);

        list.Insert(50, 999);
        Assert.Equal(101, list.Count);
        Assert.Equal(999, list[50]);
        Assert.Equal(50, list[51]); // previous 50 shifted to index 51
    }

    [Fact]
    public void Indexer_OutOfRange_Throws()
    {
        var list = new CustomArrayList<int> { 1, 2 };
        Assert.Throws<ArgumentOutOfRangeException>(() => { var x = list[-1]; });
        Assert.Throws<ArgumentOutOfRangeException>(() => { var x = list[2]; });
        Assert.Throws<ArgumentOutOfRangeException>(() => list[-1] = 5);
        Assert.Throws<ArgumentOutOfRangeException>(() => list[2] = 5);
    }
}
}
        }
 
    }
}
