/*In this programming problem you'll code up Prim's minimum spanning tree algorithm.

Download the text file below edges.txt
This file describes an undirected graph with integer edge costs.It has the format
[number_of_nodes] [number_of_edges]
[one_node_of_edge_1] [other_node_of_edge_1] [edge_1_cost]
[one_node_of_edge_2] [other_node_of_edge_2] [edge_2_cost]
...
For example, the third line of the file is "2 3 -8874", indicating that there is an edge connecting vertex #2 and vertex #3 that has cost -8874. 
You should NOT assume that edge costs are positive, nor should you assume that they are distinct.
Your task is to run Prim's minimum spanning tree algorithm on this graph.  You should report the overall cost of a minimum spanning tree --- an integer, which may or may not be negative --- in the box below. 
IMPLEMENTATION NOTES: This graph is small enough that the straightforward O(mn) time implementation of Prim's algorithm should work fine. OPTIONAL: For those of you seeking an additional challenge, 
try implementing a heap-based version. The simpler approach, which should already give you a healthy speed-up, is to maintain relevant edges in a heap (with keys = edge costs).  The superior approach stores 
the unprocessed vertices in the heap, as described in lecture.  Note this requires a heap that supports deletions, and you'll probably need to maintain some kind of mapping between
vertices and their positions in the heap.
*/

using System;
using System.IO;
using System.Reflection;

//MST, minimum Spanning Tree
namespace CertificateTasks2
{
    public class PrimsMSTalgorithm
    {
        public int NumberOfVertices;
        public int NumberOfEdges;

        public Graph ReadInut()
        {
            Graph graph = null;
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\edges.txt");
            var input = File.ReadAllLines(path);            

            for (int i = 0; i < input.Length; i++)
            {
                var temp = input[i].Trim().Split(" ");
                if (i != 0)
                {
                    int u = Convert.ToInt32(temp[0]);
                    int v = Convert.ToInt32(temp[1]);
                    int edge = Convert.ToInt32(temp[2]);
                    graph.Nodes[u -1, v - 1] = edge;
                    graph.Nodes[v -1, u - 1] = edge;
                }
                else
                {
                    NumberOfVertices = Convert.ToInt32(temp[0]);
                    NumberOfEdges = Convert.ToInt32(temp[1]);
                    graph = new Graph(NumberOfVertices);
                }
            }
            return graph;
        }

        public int[] CalcPrimsAlgorithm(Graph graph)
        {
            var visitedNodes = new int[NumberOfVertices];

            for (int i = 0; i < visitedNodes.Length; i++)
            {
                visitedNodes[i] = int.MaxValue;
            }
            visitedNodes[0] = 0;

            for (int i = 0; i < NumberOfVertices - 1; i++)
            {
                var vertices = FindMin(visitedNodes, graph.Nodes);
                visitedNodes[vertices.Item2] = graph.Nodes[vertices.Item1, vertices.Item2];
            }
            return visitedNodes;
        }

        public Tuple<int, int> FindMin(int[] visitedNodes, int[,] allnodes)
        {
            var minEdge = Int32.MaxValue;
            var startVertex = -1;
            var endVertex = -1;

            for (int i = 0; i < visitedNodes.Length; i++)
            {
                if (visitedNodes[i] < int.MaxValue)
                {
                    for (int j = 0; j < allnodes.GetLength(1); j++)
                    {
                        if (allnodes[i, j] < minEdge && visitedNodes[j] == int.MaxValue)
                        {
                            minEdge = allnodes[i, j];
                            startVertex = i;
                            endVertex = j;
                        }
                    }
                }
            }
            return new Tuple<int, int>(startVertex, endVertex);
        }
    }

    public class Graph
    {
        public int[,] Nodes;

        public Graph(int numberOfVertices)
        {
            Nodes = new int[numberOfVertices, numberOfVertices];
            for (int i = 0; i < Nodes.GetLength(0); i++)
            {
                for (int j = 0; j < Nodes.GetLength(1); j++)
                {
                    Nodes[i, j] = int.MaxValue;
                }
            }
        }
    }
}
