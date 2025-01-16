﻿// See https://aka.ms/new-console-template for more information
using basic_graph_implementation.Algorithms;
using basic_graph_implementation.Graphs;
using basic_graph_implementation.NodeTypes;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Feature flags
        var featureFlags = new Dictionary<string, bool>
        {
            { "EnableBFS", true } // Set to false to disable BFS execution
        };

        var node1 = new SocialNode("Alice");
        var node2 = new SocialNode("Peter");
        var node3 = new SocialNode("John");
        var node4 = new SocialNode("Bart");

        var graph1 = new UndirectedGraph<SocialNode>();
        graph1.AddNode(node1);
        graph1.AddNode(node2);
        graph1.AddNode(node3);
        graph1.AddNode(node4);
        graph1.AddEdge(node1, node2);
        graph1.AddEdge(node2, node3);
        graph1.AddEdge(node3, node4);
        graph1.ShowGraph();
        //graph1.RemoveNode(node2);
        //Console.WriteLine("------------");
        //graph1.ShowGraph();

        // Execute BFS only if the feature flag is enabled
        if (featureFlags["EnableBFS"])
        {
            var bfsResult = BreadthFirstSearch.BreadthFirstSearchStart(graph1, node1);

            Console.WriteLine("BFS Result:");
            foreach (var nodeId in bfsResult)
            {
                Console.WriteLine(nodeId);
            }
        }
        else
        {
            Console.WriteLine("BFS is disabled by feature flag.");
        }
    }
}