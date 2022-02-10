/*
In this programming problem and the next you'll code up the clustering algorithm from lecture for computing a max-spacing kk-clustering.
Download the text file below clustering1.txt

This file describes a distance function (equivalently, a complete graph with edge costs).  It has the following format:
[number_of_nodes]
[edge 1 node 1] [edge 1 node 2] [edge 1 cost]
[edge 2 node 1] [edge 2 node 2] [edge 2 cost]
...
There is one edge (i,j)(i,j) for each choice of 1 \leq i \lt j \leq n1≤i<j≤n, where nn is the number of nodes.
For example, the third line of the file is "1 3 5250", indicating that the distance between nodes 1 and 3 (equivalently, the cost of the edge (1,3)) is 5250. 
You can assume that distances are positive, but you should NOT assume that they are distinct.
Your task in this problem is to run the clustering algorithm from lecture on this data set, where the target number kk of clusters is set to 4. 
What is the maximum spacing of a 4-clustering?
ADVICE: If you're not getting the correct answer, try debugging your algorithm using some small test cases.  And then post them to the discussion forum!

Hint 
Another helpful definition for max-spacing: "the edge that decreases the number of clusters from k to k-1 clusters." 
In other words, finish the clustering algorithm, and then compute once more for the closest pair of separate 
(i.e., from different clusters) points. This edge will be your maximum spacing.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CertificateTasks2
{
    public class ClusteringAlgorithm
    {
        public const int NumberOfClusters = 3;
        public static int NumberOfVertices { get; set; }
        public Graph ReadInut()
        {
            Graph graph = new Graph();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\clustering1.txt");
            var input = File.ReadAllLines(path);

            for (int i = 0; i < input.Length; i++)
            {
                var temp = input[i].Trim().Split(" ");
                if (i != 0)
                {
                    int u = Convert.ToInt32(temp[0]);
                    int v = Convert.ToInt32(temp[1]);
                    int edge = Convert.ToInt32(temp[2]);

                    Node n1 = graph.GetNode(u);
                    Node n2 = graph.GetNode(v);

                    graph.edges.Add(new Tuple<int, Node, Node>(edge, n1, n2));
                }
                else
                {
                    NumberOfVertices = Convert.ToInt32(temp[0]);
                }
            }
            return graph;
        }

        public List<Tuple<int, Node, Node>> CalcClusters(Graph graph)
        {
            var count = NumberOfVertices;
            var sortedEdges = graph.edges.OrderByDescending(i => i.Item1).ToList();

            while (NumberOfVertices > NumberOfClusters)
            {
                sortedEdges = FuseVertices(sortedEdges);
                NumberOfVertices--;
            }
            return sortedEdges;
        }

        private List<Tuple<int, Node, Node>> FuseVertices(List<Tuple<int, Node, Node>> edges)
        {
            for (int i = edges.Count - 1; i >= 0; i--)
            {
                if (edges[i].Item2.Parent != edges[i].Item3.Parent)
                {
                    edges[i].Item3.Parent = edges[i].Item2.Parent;
                    break;
                }
                
            }

            for (int i = edges.Count - 1; i >= 0; i--)
            {
                if (edges[i].Item2.Parent == edges[i].Item3.Parent)
                {
                    edges.RemoveAt(i);
                }
            }

            return edges;
        }
        public class Graph
        {
            public Dictionary<int, Node> nodes { get; set; } = new Dictionary<int, Node>();
            public List<Tuple<int, Node, Node>> edges = new List<Tuple<int, Node, Node>>();
            public Node GetNode(int key)
            {
                if (!nodes.ContainsKey(key))
                {
                    nodes.Add(key, new Node(key));
                }
                return nodes[key];
            }


        }

        public class Node
        {
            public Node Parent { get; set; }
            public int Key { get; set; }

            public Node(int key)
            {
                Parent = this;
                Key = key;
            }
        }
    }

    
}
