using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Node<T>
    {
        public Node()
        {

        }

        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public override string ToString()
        {
            return $"{Value}";
        }

        public bool IsLeaf => (Left == null && Right == null);  
    }
}
