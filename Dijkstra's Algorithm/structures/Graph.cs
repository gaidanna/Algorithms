using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.structures
{
    public class Graph
    {
        Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        public Node GetNode(int id)
        {
            if (!nodes.ContainsKey(id))
            {
                nodes.Add(id, new Node(id));
            }
            return nodes[id];
        }

        public void AddEdge(int u, int v)
        {
            var sourceNode = GetNode(u);
            var destionationNode = GetNode(v);
            sourceNode.AdjacencyList.Add(destionationNode);
        }
    }

    public class Node
    {
        public Node(int id)
        {
            Id = id;
            AdjacencyList = new List<Node>();
        }
        public List<Node> AdjacencyList { get; set; }
        public int Id { get; set; }
    }
}
