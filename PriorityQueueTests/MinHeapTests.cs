using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueTests
{
    public class MinHeapTests
    {
        private BHeap<int> minHeap { get; set; }

        public MinHeapTests()
        {
            minHeap = new MinHeap<int>(new int[] { 1, 2, 3, 4, 5, 6 });
        }
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 3)]
        [InlineData(2, 5)]
        [InlineData(3, 7)]
        [InlineData(10, 21)]
        [InlineData(20, 41)]
        public void GetLeftChildIndex_Test(int index, int leftChildIndex)
        {
            var result = minHeap.GetLeftChildIndex(index);

            Assert.Equal(result, leftChildIndex);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(10, 4)]
        [InlineData(20, 9)]
        [InlineData(30, 14)]
        public void GetParentIndex_Test(int index, int parentIndex)
        {
            var result = minHeap.GetParentIndex(index);

            Assert.Equal(result, parentIndex);
        }

        [Fact]
        public void Count_Test()
        {
            var count = minHeap.Count;
            Assert.Equal(6, count);
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            Assert.Collection(minHeap,
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(4, item),
                item => Assert.Equal(5, item),
                item => Assert.Equal(6, item));
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(15)]
        public void Add_Test(int value)
        {
            minHeap = new MinHeap<int>(new int[] { 1, 2, 3, 4, 5, 6, value });
            Assert.Collection(minHeap,
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(4, item),
                item => Assert.Equal(5, item),
                item => Assert.Equal(6, item),
                item => Assert.Equal(value, item));

            Assert.Equal(value, minHeap.Array.GetItem(minHeap.Count - 1));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void HeapifyUp_Test(int value)
        {
            minHeap = new MinHeap<int>(new int[] { 10, 20, 30, 40, 50, 60, value });

            Assert.Collection(minHeap,
                item => Assert.Equal(value, item),
                item => Assert.Equal(20, item),
                item => Assert.Equal(10, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(60, item),
                item => Assert.Equal(30, item));

            Assert.Equal(value, minHeap.Array.GetItem(0));
        }

        [Theory]
        [InlineData(70)]
        [InlineData(80)]
        [InlineData(90)]
        [InlineData(95)]
        [InlineData(99)]
        public void Remove_Test(int value)
        {
            minHeap = new MinHeap<int>(new int[] { 10, 20, 30, 40, 50, 60, value });
            var removedItem = minHeap.DeleteMinMax();

            Assert.Collection(minHeap,
                item => Assert.Equal(20, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(30, item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(60, item));

            Assert.Equal(10, removedItem);
        }
    }
}
