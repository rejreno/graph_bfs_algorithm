// See https://aka.ms/new-console-template for more information

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

        // Create the nodes
        var alice = new SocialNode("Alice");
        var bob = new SocialNode("Bob");
        var charlie = new SocialNode("Charlie");
        var david = new SocialNode("David");
        var eve = new SocialNode("Eve");
        var frank = new SocialNode("Frank");
        var grace = new SocialNode("Grace");
        var hannah = new SocialNode("Hannah");
        var isaac = new SocialNode("Isaac");
        var jack = new SocialNode("Jack");
        var kate = new SocialNode("Kate");

        // Create the graph
        var graph = new UndirectedGraph<SocialNode>();
        graph.AddNode(alice);
        graph.AddNode(bob);
        graph.AddNode(charlie);
        graph.AddNode(david);
        graph.AddNode(eve);
        graph.AddNode(frank);
        graph.AddNode(grace);
        graph.AddNode(hannah);
        graph.AddNode(isaac);
        graph.AddNode(jack);
        graph.AddNode(kate);

        // Add edges (relationships)
        graph.AddEdge(alice, bob);
        graph.AddEdge(alice, charlie);
        graph.AddEdge(bob, david);
        graph.AddEdge(bob, eve);
        graph.AddEdge(charlie, frank);
        graph.AddEdge(charlie, grace);
        graph.AddEdge(david, hannah);
        graph.AddEdge(eve, isaac);
        graph.AddEdge(frank, jack);
        graph.AddEdge(grace, kate);

        // Show the graph structure
        Console.WriteLine("Graph Structure:");
        graph.ShowGraph();

        // Execute BFS only if the feature flag is enabled
        if (featureFlags["EnableBFS"])
        {
            var bfsResult = BreadthFirstSearch.BreadthFirstSearchStart(graph, alice);

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