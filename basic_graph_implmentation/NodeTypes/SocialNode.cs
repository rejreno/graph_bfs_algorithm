using basic_graph_implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_graph_implementation.NodeTypes
{
    public class SocialNode : IGraphNode
    {
        public string Identificator { get; set;}

        public SocialNode(string Identificator) 
        {
            this.Identificator = Identificator;
        }
    }
}
