using Queue.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Search
{
    public class BreadthFirst<T>
    {
        public bool Find(IGraph<T> graph, T vertexKey)
        {
            return bfs(graph.ReferenceVertex,
                new HashSet<T>(),
                vertexKey);
        }

        private bool bfs(IGraphVertex<T> referenceVertex,
            HashSet<T> visited,
            T searchVertexKey)
        {
            var Q = new LinkedListQueue<IGraphVertex<T>>();
            Q.Enqueue(referenceVertex);
            visited.Add(referenceVertex.Key);
            while (Q.Count > 0)
            {
                var current = Q.Dequeue();
                Console.WriteLine(current.Key);
                if (current.Key.Equals(searchVertexKey))
                    return true;

                foreach (var edge in current.Edges)
                {
                    if (visited.Contains(edge.TargetVertexKey))
                        continue;
                    visited.Add(edge.TargetVertexKey);
                    Q.Enqueue(edge.TargetVertex);
                }
            }

            return false;
        }
    }
}
