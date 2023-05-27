using Trees;

namespace TreeTests
{
    public class BinaryTreeTests
    {
        private BinaryTree<int> _tree;

        public BinaryTreeTests()
        {
            _tree = new BinaryTree<int>();
        }

        [Fact]
        public void Insert_Create_Root()
        {
            _tree.Insert(1);
            Assert.Equal(1, _tree.Root.Value);
        }

        [Fact]
        public void Insert_Check_Left_Node()
        {
            _tree.Insert(1);
            _tree.Insert(2);

            Assert.Equal(_tree.Root.Value, 1);
            Assert.Equal(_tree.Root.Left.Value, 2);
        }

        [Fact]
        public void Insert_Check_Right_Node()
        {
            _tree.Insert(1);
            _tree.Insert(2);
            _tree.Insert(3);

            Assert.Equal(_tree.Root.Value, 1);
            Assert.Equal(_tree.Root.Left.Value, 2);
            Assert.Equal(_tree.Root.Right.Value, 3);
        }

        [Fact]
        public void Multiple_Insertion_Check()
        {
            new List<int>() { 1, 2, 3, 4, 5, 6, 7 }.ForEach(item => _tree.Insert(item));

            Assert.Equal(_tree.Root.Value, 1);
            Assert.Equal(_tree.Root.Left.Value, 2);
            Assert.Equal(_tree.Root.Right.Value, 3);
            Assert.Equal(_tree.Root.Left.Left.Value, 4);
            Assert.Equal(_tree.Root.Left.Right.Value, 5);
            Assert.Equal(_tree.Root.Right.Left.Value, 6);
            Assert.Equal(_tree.Root.Right.Right.Value, 7);
        }

        [Fact]
        public void Count_Check()
        {
            new List<int>() { 1, 2, 3, 4, 5, 6, 7 }.ForEach(item => _tree.Insert(item));
            Assert.Equal(7, _tree.Count);
        }
        
        [Fact]
        public void Level_Order_Traverse_Test()
        {
            new List<int>() { 1, 2, 3, 4, 5, 6, 7 }.ForEach(item => _tree.Insert(item));
            var list = BinaryTree<int>.LevelOrderTraverse(_tree.Root);

            Assert.Collection(list,
                item => Assert.Equal(1, item.Value),
                item => Assert.Equal(2, item.Value),
                item => Assert.Equal(3, item.Value),
                item => Assert.Equal(4, item.Value),
                item => Assert.Equal(5, item.Value),
                item => Assert.Equal(6, item.Value),
                item => Assert.Equal(7, item.Value));
        }

        [Fact]
        public void IsLeaf_Test()
        {
            _tree.Insert(1);
            Assert.True(_tree.Root.IsLeaf);
        }

        [Fact]
        public void In_Order_Traverse_Test()
        {
            new List<int>() { 1, 2, 3, 4, 5, 6, 7 }.ForEach(item => _tree.Insert(item));
            var list = BinaryTree<int>.InOrderTraverse(_tree.Root, new List<int>());

            Assert.Collection(list,
                item => Assert.Equal(4, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(5, item),
                item => Assert.Equal(1, item),
                item => Assert.Equal(6, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(7, item));
        }

        [Fact]
        public void In_Order_Iteration_Traverse_Test()
        {
            new List<int>() { 1, 2, 3, 4, 5, 6, 7 }.ForEach(item => _tree.Insert(item));
            var list = BinaryTree<int>.InOrderIterationTraverse(_tree.Root);

            Assert.Collection(list,
                item => Assert.Equal(4, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(5, item),
                item => Assert.Equal(1, item),
                item => Assert.Equal(6, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(7, item));
        }
    }
}