/* TASK
Download the following text file (right click and select "Save As..."): SCC.txt
The file contains the edges of a directed graph. Vertices are labeled as positive integers from 1 to 875714. 
Every row indicates an edge, the vertex label in first column is the tail and the vertex label in second 
column is the head (recall the graph is directed, and the edges are directed from the first column vertex 
to the second column vertex). So for example, the 11-th  row looks liks : "2 47646". This just means that the 
vertex with label 2 has an outgoing edge to the vertex with label 47646
Your task is to code up the algorithm from the video lectures for computing strongly connected components 
(SCCs), and to run this algorithm on the given graph.
Enter the sizes of the 5 largest SCCs in the given graph using the fields below, in decreasing order of sizes.
So if your algorithm computes the sizes of the five largest SCCs to be 500, 400, 300, 200 and 100, enter 500
in the first field, 400 in the second, 300 in the third, and so on. If your algorithm finds less than 5 SCCs,
then enter 0 for the remaining fields. Thus, if your algorithm computes only 3 SCCs whose sizes are 400, 300,
and 100, then you enter 400, 300, and 100 in the first, second, and third fields, respectively, and 0 in the 
remaining 2 fields.
WARNING: This is the most challenging programming assignment of the course. Because of the size of the graph 
you may have to manage memory carefully. The best way to do this depends on your programming language and 
environment, and we strongly suggest that you exchange tips for doing this on the discussion forums.
Largest SCC:
Second largest SCC:
Third largest SCC:
Fourth largest SCC:
Fifth largest SCC:
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CertificateTasks
{
    public class Node
    {
        public int Id { get; set; }
        public List<Node> AdjList { get; set; }
        public Node(int id)
        {
            Id = id;
            AdjList = new List<Node>();
        }
    }
    public class StronglyConnectedGraph
    {
        public int[] FinishingTimes;
        public int[] Leaders;
        public Dictionary<int, Node> ReverseNodes { get; set; }
        public Dictionary<int, Node> OriginalNodes { get; set; }
        public int FinishingTime;
        public StronglyConnectedGraph()
        {
            OriginalNodes = new Dictionary<int, Node>();
            ReverseNodes = new Dictionary<int, Node>();
            FinishingTime = 0;
        }

        public void AddEdge(Dictionary<int, Node> nodes, int startPoint, int endPoint)
        {
            var startNode = GetNode(nodes, startPoint);
            var endNode = GetNode(nodes, endPoint);
            startNode.AdjList.Add(endNode);
        }

        public Node GetNode(Dictionary<int, Node> nodes, int id)
        {
            if (!nodes.ContainsKey(id))
            {
                nodes.Add(id, new Node(id));
            }
            return nodes[id];
        }

        public Node CopyNodeWithNewKey(Node node, int key)
        {
            return new Node(key) { AdjList = node.AdjList };
        }

        public Dictionary<int, Node> UpdateNodesToFinishingTimes(Dictionary<int, Node> nodes)
        {
            var newNodes = new Dictionary<int, Node>();
            var ascNodes = nodes.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            var count = 0;
            foreach (var kvp in ascNodes)
            {
                var node = GetNode(nodes, kvp.Key);
                node.Id = FinishingTimes[count];
                newNodes.Add(FinishingTimes[count], node);
                count++;
            }
            return newNodes;
        }
        public void DFS(Dictionary<int, Node> nodes)
        {
            var visited = new HashSet<int>();
            var descNodes = nodes.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            FinishingTimes = new int[nodes.Count];
            Leaders = new int[nodes.Count];
            foreach (var kvp in descNodes)
            {
                if (!visited.Contains(kvp.Key))
                {
                    DFS(kvp.Value, kvp.Value, visited);
                }
            }
        }

        private void DFS(Node node, Node leader, HashSet<int> visited)
        {
            visited.Add(node.Id);
            Leaders[node.Id - 1] = leader.Id;
            for (int i = 0; i < node.AdjList.Count; i++)
            {
                if (!visited.Contains(node.AdjList[i].Id))
                {
                    DFS(node.AdjList[i], leader, visited);
                }
            }
            FinishingTime++;
            FinishingTimes[node.Id - 1] = FinishingTime;
        }
        public void FillInReverseGraph(Dictionary<int, Node> nodes, List<string[]> edgeValues)
        {
            for (int i = 0; i < edgeValues.Count; i++)
            {
                var startValue = Convert.ToInt32(edgeValues[i][1]);
                var endValue = Convert.ToInt32(edgeValues[i][0]);
                if (startValue != endValue)
                {
                    AddEdge(nodes, startValue, endValue);
                }
            }
        }

        public void FillInGraph(Dictionary<int, Node> nodes, List<string[]> edgeValues)
        {
            for (int i = 0; i < edgeValues.Count; i++)
            {
                var startValue = Convert.ToInt32(edgeValues[i][0]);
                var endValue = Convert.ToInt32(edgeValues[i][1]);
                if (startValue != endValue)
                {
                    AddEdge(nodes, startValue, endValue);
                }
            }
        }

        public List<string[]> ReadInput()
        {
            var edgeValues = new List<string[]>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\SCC.txt");
            var lineCollection = File.ReadAllLines(path).ToList();
            foreach (var line in lineCollection)
            {
                var edges = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                edgeValues.Add(edges);
            }
            return edgeValues;
        }
    }
}
