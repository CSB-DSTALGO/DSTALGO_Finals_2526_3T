namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{

        // =====================================
        // 1. TESTS FOR Count PROPERTY (3 Tests)
        // =====================================

        [Fact]
        public void Count_WhenNewArrayListCreated_ReturnsZero()
        {
            var list = new CustomArrayList<int>();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Count_AfterMultipleAddOperations_ReflectsCorrectCount()
        {
            var list = new CustomArrayList<string>();
            list.Add("Alpha");
            list.Add("Beta");
            list.Add("Gamma");

            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void Count_AfterAddAndRemoveOperations_ReflectsUpdatedCount()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);
            list.RemoveAt(0);

            Assert.Equal(1, list.Count);
        }

        // ===================================
        // 2. TESTS FOR Add() METHOD (3 Tests)
        // ===================================

        [Fact]
        public void Add_SingleValidElement_StoresElementAtFirstIndex()
        {
            var list = new CustomArrayList<string>();
            list.Add("First Item");

            Assert.Equal(1, list.Count);
            Assert.Equal("First Item", list.Get(0));
        }

        [Fact]
        public void Add_ExceedingInitialCapacity_ResizesArrayWithoutDataLoss()
        {
            var list = new CustomArrayList<int>(2); // Explicit capacity = 2

            for (int i = 0; i < 6; i++)
            {
                list.Add(i * 10);
            }

            Assert.Equal(6, list.Count);
            for (int i = 0; i < 6; i++)
            {
                Assert.Equal(i * 10, list.Get(i));
            }
        }

        [Fact]
        public void Add_NullObjectReference_AllowsStorageWithoutCrashing()
        {
            var list = new CustomArrayList<string>();
            list.Add(null!);

            Assert.Equal(1, list.Count);
            Assert.Null(list.Get(0));
        }

        // ===================================
        // 3. TESTS FOR Get() METHOD (3 Tests)
        // ===================================

        [Fact]
        public void Get_ValidIndexPosition_ReturnsCorrectElement()
        {
            var list = new CustomArrayList<string>();
            list.Add("Course A");
            list.Add("Course B");

            Assert.Equal("Course B", list.Get(1));
        }

        [Fact]
        public void Get_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            var list = new CustomArrayList<int>();
            list.Add(100);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        }

        [Fact]
        public void Get_IndexEqualToOrExceedingCount_ThrowsArgumentOutOfRangeException()
        {
            var list = new CustomArrayList<int>();
            list.Add(50);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(10));
        }

        // ========================================
        // 4. TESTS FOR RemoveAt() METHOD (3 Tests)
        // ========================================

        [Fact]
        public void RemoveAt_ValidIndex_RemovesElementAndShiftsRemainingItemsLeft()
        {
            var list = new CustomArrayList<char>();
            list.Add('A');
            list.Add('B');
            list.Add('C');

            list.RemoveAt(1); // Removes 'B'

            Assert.Equal(2, list.Count);
            Assert.Equal('A', list.Get(0));
            Assert.Equal('C', list.Get(1));
        }

        [Fact]
        public void RemoveAt_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            var list = new CustomArrayList<string>();
            list.Add("Valid");

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(2));
        }

        [Fact]
        public void RemoveAt_LastRemainingItem_ReducesCountToZero()
        {
            var list = new CustomArrayList<string>();
            list.Add("Sole Item");

            list.RemoveAt(0);

            Assert.Equal(0, list.Count);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(0));
        }

        // =========================================
        // 5. TESTS FOR QuickSort() METHOD (3 Tests)
        // =========================================

        [Fact]
        public void QuickSort_UnsortedIntegerArray_SortsInAscendingOrder()
        {
            var list = new CustomArrayList<int>();
            list.Add(42);
            list.Add(12);
            list.Add(89);
            list.Add(5);

            list.QuickSort((a, b) => a.CompareTo(b));

            Assert.Equal(5, list.Get(0));
            Assert.Equal(12, list.Get(1));
            Assert.Equal(42, list.Get(2));
            Assert.Equal(89, list.Get(3));
        }

        [Fact]
        public void QuickSort_AlreadySortedArray_MaintainsCorrectOrder()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.QuickSort((a, b) => a.CompareTo(b));

            Assert.Equal(1, list.Get(0));
            Assert.Equal(2, list.Get(1));
            Assert.Equal(3, list.Get(2));
        }

        [Fact]
        public void QuickSort_EmptyOrSingleElementArray_HandlesGracefullyWithoutError()
        {
            var list = new CustomArrayList<int>();
            list.QuickSort((a, b) => a.CompareTo(b));
            Assert.Equal(0, list.Count);

            list.Add(99);
            list.QuickSort((a, b) => a.CompareTo(b));
            Assert.Equal(99, list.Get(0));
        }

        // ============================================
        // 6. TESTS FOR BinarySearch() METHOD (3 Tests)
        // ============================================

        [Fact]
        public void BinarySearch_ExistingKeyInSortedArray_ReturnsCorrectIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);

            int resultIndex = list.BinarySearch(30, item => item, (k1, k2) => k1.CompareTo(k2));

            Assert.Equal(2, resultIndex);
        }

        [Fact]
        public void BinarySearch_NonExistingKey_ReturnsNegativeOne()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            int resultIndex = list.BinarySearch(99, item => item, (k1, k2) => k1.CompareTo(k2));

            Assert.Equal(-1, resultIndex);
        }

        [Fact]
        public void BinarySearch_EmptyArray_ReturnsNegativeOne()
        {
            var list = new CustomArrayList<int>();

            int resultIndex = list.BinarySearch(10, item => item, (k1, k2) => k1.CompareTo(k2));

            Assert.Equal(-1, resultIndex);
        }
    }

