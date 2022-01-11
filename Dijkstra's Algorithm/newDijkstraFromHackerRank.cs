//using System;
//using System.Collections.Generic;
//using System.IO;
//class Solution
//{
//    //from hackerrank
//    static void Main(String[] args)
//    {
//        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
//        int T = Convert.ToInt32(Console.ReadLine());       // No. of Test Cases.
//        string[] nums;
//        int nodes, edges;
//        int[,] graph;
//        int from, to, weight;
//        for (int TCases = 1; TCases <= T; TCases++)
//        {
//            nums = Console.ReadLine().Split(' ');
//            nodes = Convert.ToInt32(nums[0]);
//            edges = Convert.ToInt32(nums[1]);
//            graph = new int[nodes, nodes];

//            // Set All elements to 0.
//            Array.Clear(graph, 0, nodes * nodes);

//            // Setup the Graph.
//            for (int i = 1; i <= edges; i++)
//            {
//                nums = Console.ReadLine().Split(' ');
//                from = Convert.ToInt32(nums[0]);
//                to = Convert.ToInt32(nums[1]);
//                weight = Convert.ToInt32(nums[2]);

//                if (graph[from - 1, to - 1] == 0 || graph[from - 1, to - 1] > weight)
//                {
//                    graph[from - 1, to - 1] = weight;
//                    graph[to - 1, from - 1] = weight;
//                }
//            }
//            int src = Convert.ToInt32(Console.ReadLine());

//            // Display the initial values.
//            // Console.WriteLine("Source Node: " + src);
//            //  PrintGraph(graph, nodes);

//            PrintShortestPaths(graph, src - 1, nodes);
//        }
//    }
//    static void PrintShortestPaths(int[,] graph, int src, int nodes)
//    {

//        int[] dist = new int[nodes];
//        bool[] sptset = new bool[nodes];

//        // Initialize the Distance and Shortest Path Set Values.
//        for (int i = 0; i < nodes; i++)
//        {
//            dist[i] = Int32.MaxValue;
//            sptset[i] = false;
//        }

//        // Set the source to source distance as 0.
//        dist[src] = 0;

//        // Find the shortest path for all vertices.
//        for (int count = 0; count < nodes - 1; count++)
//        {
//            // Find the Minimum distance node.
//            int u = 0, min = Int32.MaxValue;
//            for (int v = 0; v < nodes; v++)
//                if (!sptset[v] && dist[v] <= min)
//                {
//                    min = dist[v]; u = v;
//                }

//            sptset[u] = true;

//            // Update the distance of adjacent nodes.
//            for (int v = 0; v < nodes; v++)
//            {
//                if (!sptset[v] && graph[u, v] != 0 && dist[u] != Int32.MaxValue
//                                   && dist[u] + graph[u, v] < dist[v])
//                    dist[v] = dist[u] + graph[u, v];
//            }
//        }

//        // Display the output.
//        bool printed = false;
//        for (int i = 0; i < nodes; i++)
//        {
//            if (i != src)
//            {
//                if (printed) Console.Write(" ");
//                Console.Write(dist[i] == Int32.MaxValue ? -1 : dist[i]);
//                printed = true;
//            }
//        }
//        Console.WriteLine();
//    }
//}