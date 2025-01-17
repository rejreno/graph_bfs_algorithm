using basic_graph_implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_graph_implementation.Graphs
{
    public class UndirectedGraph<T> : IGraph<T> where T : IGraphNode
    {
        private Dictionary<string, List<T>> graph;

        public UndirectedGraph()
        {
            graph = new Dictionary<string, List<T>>();
        }

        public void AddNode(T node)
        {
            if (this.IsNodeAlreadyExist(node))
            {
                throw new Exception("This node is already exists!");
            }

            graph[node.Identificator] = new List<T>();
        }

        public void AddEdge(T node1, T node2)
        {
            if (!this.IsNodeExist(node1, node2))
            {
                throw new Exception("Nodes dont exist!");
            }

            if (this.AreNodesTheSame(node1, node2))
            {
                throw new Exception("Nodes are the same!");
            }

            if (this.IsEdgeDuplicated(node1, node2))
            {
                throw new Exception("Edges are duplicated!");
            }

            graph[node1.Identificator].Add(node2);
            graph[node2.Identificator].Add(node1);
        }

        public void RemoveNode(T node)
        {
            foreach (var edges in graph)
            {
                edges.Value.RemoveAll(edge => edge.Identificator == node.Identificator);
            }
            graph.Remove(node.Identificator);
        }

        public void ShowGraph()
        {
            var visitedEdges = new HashSet<(string, string)>();

            foreach (var node in graph)
            {
                foreach (var edge in node.Value)
                {
                    if (!visitedEdges.Contains((edge.Identificator, node.Key)))
                    {
                        Console.WriteLine($"{node.Key} -- {edge.Identificator}");
                        visitedEdges.Add((node.Key, edge.Identificator));
                    }
                }
            }
        }

        public bool ContainsNode(T node)
        {
            return graph.ContainsKey(node.Identificator);
        }

        public List<T> GetNeighbors(T node)
        {
            if (graph.ContainsKey(node.Identificator))
            {
                return graph[node.Identificator];
            }
            return new List<T>();
        }

        private bool IsNodeExist(T node1, T node2)
        {
            return graph.ContainsKey(node1.Identificator) && graph.ContainsKey(node2.Identificator);
        }

        private bool IsNodeAlreadyExist(T node)
        {
            return graph.ContainsKey(node.Identificator);
        }

        private bool IsEdgeDuplicated(T node1, T node2)
        {
            return graph[node1.Identificator].Contains(node2) || graph[node2.Identificator].Contains(node1);
        }

        private bool AreNodesTheSame(T node1, T node2)
        {
            return node1.Identificator == node2.Identificator;
        }
    }
}
