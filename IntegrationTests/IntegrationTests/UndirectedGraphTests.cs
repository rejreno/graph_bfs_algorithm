using basic_graph_implementation.Exceptions;
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
        public void CreateGraph_HappyPath()
        {
            // Arrange
            var graph = new UndirectedGraph<MockNode>();
            var node1 = new MockNode("Robert");
            var node2 = new MockNode("Peter");
            var node3 = new MockNode("Andrew");
            var node4 = new MockNode("Mick");

            // Act
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddEdge(node1, node2);
            graph.AddEdge(node3, node4);

            // Assert
            var output = new StringWriter();
            Console.SetOut(output);

            graph.ShowGraph();

            var expected = "Robert -- Peter\r\nAndrew -- Mick\r\n";
            Assert.Equal(expected, output.ToString());
        }

        [Fact]
        public void AddNode_WhenNodeAlreadyExists_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var graph = new UndirectedGraph<MockNode>();
            var node = new MockNode("Fred");
            var node2 = new MockNode("Fred");

            graph.AddNode(node);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => graph.AddNode(node2));

            Assert.Equal(GraphExceptions.NodeAlreadyExist, exception.Message);
        }

        [Fact]
        public void AddEdge_WhenNodesDoNotExist_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var graph = new UndirectedGraph<MockNode>();
            var node = new MockNode("Fred");
            var node2 = new MockNode("Billy");
            var node3 = new MockNode("John");

            graph.AddNode(node);
            graph.AddNode(node2);
            graph.AddEdge(node, node2);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => graph.AddEdge(node2, node3));

            Assert.Equal(GraphExceptions.NodesDoNotExist, exception.Message);
        }

        [Fact]
        public void AddEdge_WhenNodesAreTheSame_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var graph = new UndirectedGraph<MockNode>();
            var node = new MockNode("Fred");
            var node2 = new MockNode("Billy");

            graph.AddNode(node);
            graph.AddNode(node2);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => graph.AddEdge(node2, node2));

            Assert.Equal(GraphExceptions.NodesAreTheSame, exception.Message);
        }

        [Fact]
        public void AddEdge_WhenEdgesAreDuplicated_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var graph = new UndirectedGraph<MockNode>();
            var node = new MockNode("Fred");
            var node2 = new MockNode("Billy");
            var node3 = new MockNode("John");

            graph.AddNode(node);
            graph.AddNode(node2);
            graph.AddEdge(node, node2);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => graph.AddEdge(node, node2));

            Assert.Equal(GraphExceptions.EdgesAreDuplicated, exception.Message);
        }
    }
}
