using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisjointSet
{
    public class DisjointSet<T> : IEnumerable<T>
    {
        private Dictionary<T, DisjointSetNode<T>> set = new Dictionary<T, DisjointSetNode<T>>();

        public DisjointSet()
        {

        }

        public DisjointSet(IEnumerable<T> values)
        {
            foreach (var value in values) MakeSet(value);
        }

        public int Count { get; private set; }

        public void MakeSet(T value)
        {
            if(set.ContainsKey(value)) throw new Exception("The value has already been defined.");
            var newSet = new DisjointSetNode<T>(value, 0);
            newSet.Parent = newSet;
            set.Add(value, newSet);
            Count++;
        }

        public T FindSet(T value)
        {
            if (!set.ContainsKey(value)) throw new Exception("The value could not be found!");
            
            var node = set[value];
            return findSet(set[value]).Value;
        }

        private DisjointSetNode<T> findSet(DisjointSetNode<T> node)
        {
            var parent = node.Parent;
            if (node != parent)
            {
                node.Parent = findSet(node.Parent);
                return node.Parent;
            }
            return parent;
        }

        public void Union(T v1, T v2)
        {
            if (v1 is null || v2 is null) throw new ArgumentNullException();

            var root1 = FindSet(v1);
            var root2 = FindSet(v2);

            if (root1.Equals(root2)) return;

            var node1 = set[root1];
            var node2 = set[root2];

            if (node1.Rank == node2.Rank)
            {
                node2.Parent = node1;
                node1.Rank++;
            }

            else
            {
                if (node1.Rank < node2.Rank)
                {
                    node1.Parent = node2;
                }
                else
                {
                    node2.Parent = node1;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.Values.Select(x => x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
