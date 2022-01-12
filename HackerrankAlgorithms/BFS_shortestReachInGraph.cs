using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms
{
    public class BFS_shortestReachInGraph
    {
        public int numberOfQueries;
        public int startVertixNumber;
        public int numberOfNodes;
        public int numberOfEdges;

        public Dictionary<int, Dictionary<int, List<int>>> nodesList = new Dictionary<int, Dictionary<int, List<int>>>();
        public void ReadData()
        {
            numberOfQueries = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfQueries; i++)
            {
                Dictionary<int, List<int>> nodes = new Dictionary<int, List<int>>();
                var inputParams = ReadTwoParams(Console.ReadLine());

                numberOfNodes = inputParams[0];
                numberOfEdges = inputParams[1];

                for (int a = 0; a < numberOfNodes; a++)
                {
                    nodes.Add(a + 1, new List<int>());
                }

                for (int a = 0; a < numberOfEdges; a++)
                {
                    var edgeVertices = ReadTwoParams(Console.ReadLine());
                    nodes[edgeVertices[0]].Add(edgeVertices[1]);
                    nodes[edgeVertices[1]].Add(edgeVertices[0]);
                }

                startVertixNumber = Convert.ToInt32(Console.ReadLine());
                nodesList.Add(startVertixNumber, nodes);
            }
        }

        public int[] CalculateDistances(Dictionary<int, List<int>> nodes, int startVertixNumber)
        {
            var distances = new int[nodes.Count];
            var visited = new HashSet<int>();
            Queue<KeyValuePair<int, List<int>>> queue = new Queue<KeyValuePair<int, List<int>>>();
            queue.Enqueue(nodes.SingleOrDefault(k => k.Key == startVertixNumber));
            //check for default value, it means we have our startvertixnumber in dict

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = -1;
            }
            distances[startVertixNumber - 1] = 0;

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex.Key))
                    continue;

                visited.Add(vertex.Key);

                for (int i = 0; i < vertex.Value.Count; i++)
                {
                    if (distances[vertex.Value[i] - 1] == -1 && !visited.Contains(vertex.Value[i]))
                    {
                        distances[vertex.Value[i] - 1] = distances[vertex.Key - 1] + 6;
                        queue.Enqueue(nodes.SingleOrDefault(k => k.Key == vertex.Value[i]));
                    }
                }
            }

            return distances;
        }
        public void PrintResult(int[] result)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
            {
                if (item != 0)
                {
                    sb.Append(item + " ");
                }
            }

            Console.WriteLine(sb.ToString());
        }
        private List<int> ReadTwoParams(string input)
        {
            var inputParams = input.Trim().Split(' ');

            var firstParam = Convert.ToInt32(inputParams[0]);
            var secondParam = Convert.ToInt32(inputParams[1]);

            return new List<int> { firstParam, secondParam };
        }
    }
}
