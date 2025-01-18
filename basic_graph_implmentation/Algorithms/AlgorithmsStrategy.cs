using basic_graph_implementation.Graphs;
using basic_graph_implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_graph_implementation.Algorithms
{
    public class AlgorithmsStrategy<T> where T : IGraphNode
    {
        private IGraphAlgorithm<T> _graphAlgorithm;

        public List<string> Run(IGraphAlgorithm<T> graphAlgorithm, IGraph<T> graph, T startNode)
        {
            _graphAlgorithm = graphAlgorithm;

            return _graphAlgorithm.Execute(graph, startNode);
        }
    }
}
