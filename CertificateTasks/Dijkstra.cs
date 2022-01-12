/*
 Programming Assignment 5
In this programming problem you'll code up Dijkstra's shortest-path algorithm.
Download the following text file (Right click and select "Save As..."): dijkstraData.txt
The file contains an adjacency list representation of an undirected weighted graph with 200 vertices
labeled 1 to 200. Each row consists of the node tuples that are adjacent to that particular vertex 
along with the length of that edge. For example, the 6th row has 6 as the first entry indicating that 
this row corresponds to the vertex labeled 6. The next entry of this row "141,8200" indicates that 
there is an edge between vertex 6 and vertex 141 that has length 8200. The rest of the pairs of this 
row indicate the other vertices adjacent to vertex 6 and the lengths of the corresponding edges.
Your task is to run Dijkstra's shortest-path algorithm on this graph, using 1 (the first vertex) as 
the source vertex, and to compute the shortest-path distances between 1 and every other vertex of the 
graph. If there is no path between a vertex  and vertex 1, we'll define the shortest-path distance 
between 1 and  to be 1000000.
You should report the shortest-path distances to the following ten vertices, in order: 7,37,59,82,99,115,133,165,188,197. Enter the shortest-path distances using the fields below for each of the vertices.
IMPLEMENTATION NOTES: This graph is small enough that the straightforward  time implementation 
of Dijkstra's algorithm should work fine. OPTIONAL: For those of you seeking an additional 
challenge, try implementing the heap-based version. Note this requires a heap that supports 
deletions, and you'll probably need to maintain some kind of mapping between vertices and their 
positions in the heap.
Vertex 7:
2599
Vertex 37:
2610
Vertex 59:
2947
Vertex 82:
2052
Vertex 99:
2367
Vertex 115:
2399
Vertex 133:
2029
Vertex 165:
2442
Vertex 188:
2505
Vertex 197:
3068
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CertificateTasks
{
    public class MyGraph
    {
        public int[] CalculateShortestPath(int[,] nodes, int startNode)
        {
            var visited = new bool[nodes.GetLength(0)];
            var distances = new int[nodes.GetLength(0)];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[startNode - 1] = 0;
            

            for (int i = 0; i < nodes.GetLength(0); i++)
            {
                var indexMinValue = GetMinIndex(distances, visited);

                visited[indexMinValue] = true;

                for (int j = 0; j < nodes.GetLength(0); j++)
                {
                    if (nodes[indexMinValue, j] != 0 && 
                        (distances[indexMinValue] + nodes[indexMinValue, j]) < distances[j] && 
                        !visited[j] && distances[indexMinValue] != int.MaxValue)
                        {
                            distances[j] = distances[indexMinValue] + nodes[indexMinValue, j];
                        }
                }
            }
            return distances;
        }

        private int GetMinIndex(int[] distances,bool[] visited)
        {
            var minValue = int.MaxValue;
            var minIndex = -1;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] < minValue && !visited[i])
                {
                    minValue = distances[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public int[,] FillInGraph(Dictionary<int, List<Tuple<int, int>>> inputData)
        {
            var nodes = new int[inputData.Count, inputData.Count];
            foreach (var item in inputData)
            {
                var key = item.Key;
                for (int i = 0; i < item.Value.Count; i++)
                {
                    nodes[key - 1, item.Value[i].Item1 - 1] = item.Value[i].Item2;
                }
            }
            return nodes;
        }
        public Dictionary<int, List<Tuple<int, int>>> ReadInput()
        {
            Dictionary<int, List<Tuple<int, int>>> inputValues = new Dictionary<int, List<Tuple<int, int>>>();
            var inputData = File.ReadAllLines(@"C:\Users\Ganna Gaidabas\Desktop\dijkstraData.txt").ToList();
            for (int i = 0; i < inputData.Count; i++)
            {
                var splittedValues = inputData[i].Split('\t', StringSplitOptions.RemoveEmptyEntries);
                
                var key = Convert.ToInt32(splittedValues[0]);
                inputValues.Add(key, new List<Tuple<int, int>>());
                
                for (int j = 1; j < splittedValues.Length; j++)
                {
                    var adjVertex = splittedValues[j].Split(',', StringSplitOptions.RemoveEmptyEntries);
                    inputValues[key].Add(new Tuple<int, int>(Convert.ToInt32(adjVertex[0]), Convert.ToInt32(adjVertex[1])));
                }
            }

            return inputValues;
        }
    }
}
