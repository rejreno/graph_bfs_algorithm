using basic_graph_implementation.Graphs;
using basic_graph_implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_graph_implementation.Algorithms
{
    public static class BreadthFirstSearch
    {
        public static List<string> BreadthFirstSearchStart<T>(UndirectedGraph<T> graph, T startNode) where T : IGraphNode
        {
            if (!graph.ContainsNode(startNode))
            {
                throw new Exception("The start node does not exist in the graph.");
            }

            var visited = new HashSet<string>();
            var queue = new Queue<T>();
            var result = new List<string>();

            queue.Enqueue(startNode);
            visited.Add(startNode.Identificator);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                result.Add(currentNode.Identificator);

                foreach (var neighbor in graph.GetNeighbors(currentNode))
                {
                    if (!visited.Contains(neighbor.Identificator))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor.Identificator);
                    }
                }
            }

            return result;
        }
    }
}
