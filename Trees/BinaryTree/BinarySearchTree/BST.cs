using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.BinaryTree.BinarySearchTree
{
    public class BST<T> where T : IComparable
    {
        public Node<T> Root { get; set; }
        public BST()
        {
            Root = null;
        }
        public BST(Node<T> node)
        {
            Root = node;
        }

        public BST(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            var current = Root;
            Node<T> parent;
            while (true)
            {
                parent = current;
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                    if(current is null)
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                else
                {
                    current = current.Right;
                    if (current is null)
                    {
                        parent.Right = newNode;
                        return;
                    }
                }
            }
        }

        public T FindMin(Node<T> root)
        {
            T minValue = root.Value;
            while (root.Left is not null)
            {
                minValue = root.Left.Value;
                root = root.Left;
            }
            return minValue;
        }

        public T FindMin()
        {
            if (Root == null) throw new Exception("Empty tree!");
            Node<T> current = Root;
            while (current.Left != null) current = current.Left;
            return current.Value;
        }

        public T FindMax()
        {
            if (Root == null) throw new Exception("Empty tree!");
            var current = Root;
            while (current.Right is not null) current = current.Right;
            return current.Value;
        }

        public Node<T> Find(T key)
        {
            if (Root == null) throw new Exception("Empty");
            var current = Root;
            while (current.Value.CompareTo(key) is not 0)
            {
                if (key.CompareTo(current.Value) < 0) current = current.Left;
                else current = current.Right;
                if (current is null) throw new Exception("Not Found");
            }
            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root == null) throw new Exception("Empty");
            if(key.CompareTo(root.Value)<0) root.Left = Remove(root.Left, key);
            else if (key.CompareTo(root.Value) > 0) root.Right = Remove(root.Right, key);
            else
            {
                if (root.Left is null) return root.Right;
                else if (root.Right is null) return root.Left;

                root.Value = FindMin(root.Right);
                root.Right = Remove(root.Right, root.Value);
            }
            return root;
        }
    }
}
