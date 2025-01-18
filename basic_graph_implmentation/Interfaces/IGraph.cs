using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_graph_implementation.Interfaces
{
    public interface IGraph<T>
    {
        public void AddNode(T node);
        public void AddEdge(T node1, T node2);
        public void RemoveNode(T node);
        public bool ContainsNode(T node);
        public List<T> GetNeighbors(T node);
    }
}
