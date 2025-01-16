// See https://aka.ms/new-console-template for more information
using basic_graph_implementation.Graphs;
using basic_graph_implementation.NodeTypes;

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
graph1.RemoveNode(node2);
Console.WriteLine("------------");
graph1.ShowGraph();
