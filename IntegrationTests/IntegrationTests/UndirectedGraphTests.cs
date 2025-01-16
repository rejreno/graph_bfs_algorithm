using basic_graph_implementation.Graphs;
using basic_graph_implementation.Interfaces;
namespace GraphImplementationTests.IntegrationTests
{
    public class UndirectedGraphTests
    {
        private class MockNode : IGraphNode
        {
            public string Identificator { get; set; }

            public MockNode(string identificator)
            {
                Identificator = identificator;
            }
        }

        [Fact]
        public void ShowGraph_HappyPath()
        {
            // Arrange
            var graph = new UndirectedGraph<MockNode>();
            var node1 = new MockNode("1");
            var node2 = new MockNode("2");

            // Act
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddEdge(node1, node2);

            // Assert
            var output = new StringWriter();
            Console.SetOut(output);

            graph.ShowGraph();

            var expected = "1 -- 2\r\n";
            Assert.Equal(expected, output.ToString());
        }
    }
}
