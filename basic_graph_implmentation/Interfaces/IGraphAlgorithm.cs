using basic_graph_implementation.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_graph_implementation.Interfaces
{
    public interface IGraphAlgorithm<T> where T : IGraphNode
    {
        public List<string> Execute(IGraph<T> graph, T startNode);
    }
}
