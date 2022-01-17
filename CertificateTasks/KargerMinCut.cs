/* 
Download the following text file (right click and select "Save As..."): kargerMinCut.txt
The file contains the adjacency list representation of a simple undirected graph. There are 200 vertices 
labeled 1 to 200. The first column in the file represents the vertex label, and the particular row (other 
entries except the first column) tells all the vertices that the vertex is adjacent to. So for example, 
the  row looks like : "6 155 56 52 120 ......". This just means that the vertex with label 6 is adjacent to 
(i.e., shares an edge with) the vertices with labels 155,56,52,120,......,etc
Your task is to code up and run the randomized contraction algorithm for the min cut problem and use it on 
the above graph to compute the min cut. (HINT: Note that you'll have to figure out an implementation of edge
contractions. Initially, you might want to do this naively, creating a new graph from the old every time 
there's an edge contraction. But you should also think about more efficient implementations.) 
(WARNING: As per the video lectures, please make sure to run the algorithm many times with different random 
seeds, and remember the smallest cut that you ever find.) Write your numeric answer in the space provided. 
So e.g., if your answer is 5, just type 5 in the space provided.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CertificateTasks
{
    //randomized contraction algorithm for the min cut problem
    public class Vertex
    {
        public List<Edge> IncidentEdges { get; set; } = new List<Edge>();
        public int Value;
        public Vertex(List<int> adjList)
        {
            for (int i = 1; i < adjList.Count; i++)
            {
                Value = adjList[0];
                IncidentEdges.Add(new Edge(this.Value, adjList[i]));
            }
        }
    }

    public class Edge
    { 
        public int Tail { get; set; }
        public int Head { get; set; }

        public Edge(int tail, int head)
        {
            Tail = tail;
            Head = head;
        }
    }
    public class Graph
    {
        public Graph(List<List<int>> inputData)
        {
            FillInEdges(inputData);
            FillInVertices(inputData);
        }
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();
        public List<Edge> Edges { get; set; } = new List<Edge>();
        private void FillInEdges(List<List<int>> inputData)
        {
            HashSet<int> visitedVertices = new HashSet<int>();
            for (int i = 0; i < inputData.Count; i++)
            {
                var startPoint = inputData[i][0];
                visitedVertices.Add(startPoint);
                for (int j = 1; j < inputData[i].Count; j++)
                {
                    if (startPoint < inputData[i][j])
                    {
                        Edges.Add(new Edge(startPoint, inputData[i][j]));
                    }
                    else
                    {
                        if (!visitedVertices.Contains(inputData[i][j]))
                        {
                            Edges.Add(new Edge(inputData[i][j], startPoint));
                        }
                    }
                }
            }
        }
        private void FillInVertices(List<List<int>> inputData)
        {
            for (int i = 0; i < inputData.Count; i++)
            {
                Vertices.Add(new Vertex(inputData[i]));
            }
        }
    }
    public class KargerMinCut
    {
        public List<List<int>> ReadInput()
        {
            List<List<int>> output = new List<List<int>>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\kargerMinCut.txt");
            var inputData = File.ReadAllLines(path).ToList();
            for (int i = 0; i < inputData.Count; i++)
            {
                var elements = inputData[i].Split('\t', StringSplitOptions.RemoveEmptyEntries);
                var vertexElements = new List<int>();
                foreach (var el in elements)
                {
                    vertexElements.Add(Convert.ToInt32(el));
                }
                output.Add(vertexElements);
            }
            return output;
        }

        public int CalculateMinCut(Graph graph)
        {
            while (graph.Vertices.Count > 2)
            {
                var randomIndex = GetRandomIndex(graph.Edges.Count);
                var randomEdge = graph.Edges[randomIndex];
                
                var tail = graph.Vertices.First(x => x.Value == randomEdge.Tail);
                var head = graph.Vertices.First(x => x.Value == randomEdge.Head);

                graph.Vertices = ContractVertices(graph.Vertices, randomEdge, tail, head);
                graph.Edges = ContractEdges(graph.Edges, randomEdge);
            }
            return graph.Vertices[0].IncidentEdges.Count;
        }

        private List<Vertex> ContractVertices(List<Vertex> vertices, Edge edge, Vertex tail, Vertex head)
        {
            var unitedVertex = UniteVertices(edge, tail, head);
            vertices.RemoveAll( x => x.Value == tail.Value);
            vertices.RemoveAll(x => x.Value == head.Value);
            vertices.Add(unitedVertex);

            for (int a = 0; a < vertices.Count; a++)
            {
                for (int i = vertices[a].IncidentEdges.Count - 1; i >= 0; i--)
                {
                    if (vertices[a].IncidentEdges[i].Head == head.Value)
                    {
                        vertices[a].IncidentEdges[i].Head = tail.Value;
                    }
                    else if (vertices[a].IncidentEdges[i].Tail == head.Value)
                    {
                        vertices[a].IncidentEdges[i].Tail = tail.Value;
                    }
                }
            }
            return vertices;
        }

        private List<Edge> ContractEdges(List<Edge> edges, Edge randomEdge)
        {
            edges.RemoveAll(x => x.Head == randomEdge.Head && x.Tail == randomEdge.Tail);
            edges.RemoveAll(x => x.Head == randomEdge.Tail && x.Tail == randomEdge.Head);

            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Tail == randomEdge.Head)
                {
                    edges[i].Tail = randomEdge.Tail;
                }
                else if (edges[i].Head == randomEdge.Head)
                {
                    edges[i].Head = randomEdge.Tail;
                }
            }
            return edges;
        }
        private Vertex UniteVertices(Edge edge, Vertex vertex1, Vertex vertex2)
        {
            vertex1.IncidentEdges.RemoveAll(x => x.Head == edge.Head && x.Tail == edge.Tail);
            vertex2.IncidentEdges.RemoveAll(x => x.Head == edge.Tail && x.Tail == edge.Head);
            vertex1.IncidentEdges.AddRange(vertex2.IncidentEdges);
            return vertex1;
        }

        private int GetRandomIndex(int maxIndex)
        {
            var random = new Random();
            var r = random.Next(maxIndex);
            return r;
        }
    }
}