namespace ArrayTests
{
    public class ArrayTests
    {
        [Fact]
        public void ArrayCountTest()
        {
            //Arrange
            var array = new Array.Array<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);

            //Act
            int count = array.Count;

            //Assertion
            Assert.Equal(3, count);
            Assert.Equal(4, array.Capacity);
        }

        [Fact]
        public void ArrayGetItemTest()
        {
            var array = new Array.Array<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);

            var item = array.GetItem(2);
            
            Assert.Equal(3, item);
        }

        [Fact]
        public void ArrayFindTest()
        {
            var array = new Array.Array<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            
            int result = array.Find(1);
            int result2 = array.Find(4);

            Assert.Equal(result, 0);
            Assert.Equal(result2, -1);
        }

        [Fact]
        public void ArrayEnumeratorTest()
        {
            var array = new Array.Array<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);

            string result = "";
            foreach (var item in array)
            {
                result = string.Concat(result, item);
            }

            Assert.Equal(result, "123");
        }

        [Fact]
        public void ArrayConstructorTest()
        {
            var array = new Array.Array<int>(1, 2, 3, 4, 5);
            array.Add(6);
            Assert.Equal(6, array.Count);
        }

        [Fact]
        public void ArraySetItemTest()
        {
            var array = new Array.Array<int>(2,3,4,5);
            array.SetItem(6,2);
            Assert.Equal(6, array.GetItem(2));
        }

        [Fact]
        public void ArrayGetItemExceptionTest()
        {
            try
            {
                var array = new Array.Array<int>();
                array.Add(1);
                array.Add(3);
                array.Add(5);

                var item = array.GetItem(-1);

                Assert.False(true);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void ArrayCopyTest()
        {
            var array = new Array.Array<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            var newArray = array.Copy(1, 3);
            var item = newArray[1];

            Assert.Equal(3, item);
        }

        [Fact]
        public void ArraySwapTest()
        {
            var array = new Array.Array<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            array.Swap(0, 2);
            var item1 = array.GetItem(0);
            var item2 = array.GetItem(2);

            Assert.Equal(item1, 3);
            Assert.Equal(item2, 1);

        }

        [Fact]
        public void ArrayRemoveTest()
        {
            var array = new Array.Array<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            var item = array.RemoveItem(2);
            var item2 = array.GetItem(2);

            Assert.Equal(3, item);
            Assert.Equal(item2, 4);
        }
    }
}