using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinaryTree<T> : IEnumerable
    {
        public Node<T> Root { get; set; }
        public int Count { get; private set; }

        public BinaryTree()
        {
            Count = 0;
        }

        public BinaryTree(IEnumerable<T> values) : this()
        {
            foreach (var item in values)
            {
                Insert(item);
            }
        }

        public T Insert(T value)
        {
            var newNode = new Node<T>(value);
            if (Root is null)
            {
                Root = newNode;
                Count++;
                return value;
            }

            var q = new Queue<Node<T>>();
            q.Enqueue(Root);
            while (q.Count>0)
            {
                var temp = q.Dequeue();
                if (temp.Left is not null) q.Enqueue(temp.Left);
                else
                {
                    temp.Left = newNode;
                    Count++;
                    return value;
                }

                if (temp.Right is not null) q.Enqueue(temp.Right);
                else
                {
                    temp.Right = newNode;
                    Count++;
                    return value;
                }
            }
            throw new Exception("Fail");
        }

        public static List<Node<T>> LevelOrderTraverse(Node<T> root)
        {
            var list = new List<Node<T>>();
            if (root is not null)
            {
                var q = new Queue<Node<T>>();
                q.Enqueue(root);
                while (q.Count>0)
                {
                    var temp = q.Dequeue();
                    list.Add(temp);
                    if (temp.Left is not null) q.Enqueue(temp.Left);
                    if (temp.Right is not null) q.Enqueue(temp.Right);
                }
            }
            return list;
        }

        public static List<T> InOrderTraverse(Node<T> root,List<T> list)
        {
            if (root is null) return null;

            if (root is not null)
            {
                InOrderTraverse(root.Left,list);
                list.Add(root.Value);
                InOrderTraverse(root.Right,list);
            }
            return list;
        }

        public static List<T> PostOrderTraverse(Node<T> root, List<T> list)
        {
            if (root is null) return null;

            if (root is not null)
            {
                PostOrderTraverse(root.Left, list);
                PostOrderTraverse(root.Right, list);
                list.Add(root.Value);   
            }
            return list;
        }

        public static List<T> PreOrderTraverse(Node<T> root, List<T> list)
        {
            if (root is null) return null;

            if (root is not null)
            {
                list.Add(root.Value);
                PreOrderTraverse(root.Left, list);
                PreOrderTraverse(root.Right, list);  
            }
            return list;
        }

        public static List<T> InOrderIterationTraverse(Node<T> root)
        {

            if (root == null) return null;

            var list = new List<T>();
            var stack = new Stack<Node<T>>();
            bool done = false;
            Node<T> currentNode = root;

            while (!done)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (stack.Count == 0) done = true;
                    else
                    {
                        currentNode = stack.Pop();
                        list.Add(currentNode.Value);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return LevelOrderTraverse(Root).GetEnumerator();
        }
    }
}
