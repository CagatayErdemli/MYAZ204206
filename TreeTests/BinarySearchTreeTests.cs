using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;
using Trees.BinaryTree.BinarySearchTree;

namespace TreeTests
{
    public class BinarySearchTreeTests
    {
        private BST<int> _tree { get; set; }

        public BinarySearchTreeTests()
        {
            _tree = new BST<int>();
        }

        [Fact]
        public void Add_Root_Test()
        {
            _tree.Add(1);
            Assert.Equal(1, _tree.Root.Value);
        }

        [Fact]
        public void Adding_with_IEnumerable_Constructor()
        {
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });

            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(3, item),
                item => Assert.Equal(16, item),
                item => Assert.Equal(22, item),
                item => Assert.Equal(23, item),
                item => Assert.Equal(37, item),
                item => Assert.Equal(44, item),
                item => Assert.Equal(99, item));
        }

        [Fact]
        public void Findmin_Test()
        {
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });
            var min = bst.FindMin(bst.Root);
            Assert.Equal(3, min);
        }

        [Fact]
        public void Findmax_Test()
        {
            // Act
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });
            var max = bst.FindMax();
            Assert.Equal(99, max);
        }

        [Fact]
        public void Find()
        {
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });
            var node = bst.Find(37);
            Assert.Equal(node, bst.Root.Right.Left);
        }

        [Fact]
        public void Revemo_A_Leaf()
        {
            var bst = new BST<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });
            var node = bst.Remove(bst.Root, 20);

            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(40, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(60, item),
                item => Assert.Equal(65, item),
                item => Assert.Equal(70, item),
                item => Assert.Equal(85, item));
        }

        [Fact]
        public void Revemo_A_Node_With_One_Child()
        {
            var bst = new BST<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });
            var node = bst.Remove(bst.Root, 20);
            node = bst.Remove(bst.Root, 40);

            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(45, item),
                item => Assert.Equal(60, item),
                item => Assert.Equal(65, item),
                item => Assert.Equal(70, item),
                item => Assert.Equal(85, item));
        }

        [Fact]
        public void Revemo_A_Node_With_Two_Child()
        {
            var bst = new BST<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });

            bst.Remove(bst.Root, 20);
            bst.Remove(bst.Root, 40);
            bst.Remove(bst.Root, 60);

            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(45, item),
                item => Assert.Equal(65, item),
                item => Assert.Equal(70, item),
                item => Assert.Equal(85, item));

            Assert.Equal(65, bst.Root.Value);
        }
    }
}
