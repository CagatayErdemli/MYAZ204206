using PriorityQueue;

namespace PriorityQueueTests
{
    public class MaxHeapTests
    {
        private MaxHeap<int> _maxHeap { get; set; }
        public MaxHeapTests()
        {
            _maxHeap = new MaxHeap<int>(new int[] { 54, 45, 36, 27, 21, 18, 21, 11 });
        }

        [Fact]
        public void Count_Test()
        {
            Assert.Equal(8, _maxHeap.Count);
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            var list = _maxHeap;
            Assert.Equal(8, list.Count);
            Assert.Collection(_maxHeap,
                item => Assert.Equal(54, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(36, item),
                item => Assert.Equal(27, item),
                item => Assert.Equal(21, item),
                item => Assert.Equal(18, item),
                item => Assert.Equal(21, item),
                item => Assert.Equal(11, item));
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(15)]
        public void Add_Test(int value)
        {
            _maxHeap = new MaxHeap<int>(new int[] { 54, 45, 36, 27, 21, 18, 21, 11, value });
            Assert.Collection(_maxHeap,
                item => Assert.Equal(54, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(36, item),
                item => Assert.Equal(27, item),
                item => Assert.Equal(21, item),
                item => Assert.Equal(18, item),
                item => Assert.Equal(21, item),
                item => Assert.Equal(11, item),
                item => Assert.Equal(value, item));

            Assert.Equal(value, _maxHeap.Array.GetItem(_maxHeap.Count - 1));
        }

        [Theory]
        [InlineData(90)]
        [InlineData(91)]
        [InlineData(92)]
        [InlineData(93)]
        [InlineData(94)]
        [InlineData(95)]
        public void HeapifyUp_Test(int value)
        {
            _maxHeap = new MaxHeap<int>(new int[] { 54, 45, 36, 27, 21, 18, 21, 11, value });

            Assert.Collection(_maxHeap,
                item => Assert.Equal(value, item),
                item => Assert.Equal(54, item),
                item => Assert.Equal(36, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(21, item),
                item => Assert.Equal(18, item),
                item => Assert.Equal(21, item),
                item => Assert.Equal(11, item),
                item => Assert.Equal(27, item));

            Assert.Equal(value, _maxHeap.Array.GetItem(0));
        }

        [Fact]
        public void Remove_Test()
        {
            _maxHeap = new MaxHeap<int>(new int[] { 54, 45, 36, 27, 21, 18, 21, 11 });
            var removedItem = _maxHeap.DeleteMinMax();

            Assert.Collection(_maxHeap,
                item => Assert.Equal(45, item),
                item => Assert.Equal(27, item),
                item => Assert.Equal(36, item),
                item => Assert.Equal(11, item),
                item => Assert.Equal(21, item),
                item => Assert.Equal(18, item),
                item => Assert.Equal(21, item));

            Assert.Equal(54, removedItem);
        }

        [Fact]
        public void ItemAdd_Test()
        {
            var maxHeap = new MaxHeap<int>(new int[] { 30, 50, 42, 66, 10, 16, 5 });
            var list = new List<int>();
            foreach (var item in maxHeap) list.Add(maxHeap.DeleteMinMax());

            Assert.Collection(list,
                item => Assert.Equal(item, 66),
                item => Assert.Equal(item, 50),
                item => Assert.Equal(item, 42),
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 16),
                item => Assert.Equal(item, 10),
                item => Assert.Equal(item, 5));

        }
    }
}