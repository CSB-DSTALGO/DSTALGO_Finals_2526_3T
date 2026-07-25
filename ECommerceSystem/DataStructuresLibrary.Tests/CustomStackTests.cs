using DataStructuresLibrary;
using Xunit;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void PushAndPop_ShouldMaintainStrictLIFOOrder()
        {
            // TODO: Test Last-In, First-Out behavior
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(30, stack.Pop());
            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Peek_ShouldReturnTopElement_WithoutRemovingIt()
        {
            // TODO: Test Peek returning top item while keeping Count intact
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            int countBefore = stack.Count;

            Assert.Equal(30, stack.Peek());
            Assert.Equal(countBefore, stack.Count);
        }

        [Fact]
        public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
        {
            // TODO: Verify Search returns depth from top (1 = top item)
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);

            Assert.Equal(1, stack.Search(40));
            Assert.Equal(2, stack.Search(30));
            Assert.Equal(3, stack.Search(20));
            Assert.Equal(4, stack.Search(10));
        }

        [Fact]
        public void Sort_ShouldReorderStack_WithSmallestItemAtTop()
        {
            // TODO: Verify stack sorting order relative to the top reference
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(30);
            stack.Push(10);
            stack.Push(40);
            stack.Push(20);

            stack.Sort();

            Assert.Equal(10, stack.Pop());
            Assert.Equal(20, stack.Pop());
            Assert.Equal(30, stack.Pop());
            Assert.Equal(40, stack.Pop());
        }
    }
}








       



