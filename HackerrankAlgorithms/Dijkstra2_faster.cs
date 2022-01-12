using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms
{
    //working faster
    public class Dijkstra2
    {
        public int numberOfQueries;
        public int startVertixNumber;
        public int numberOfNodes;
        public int numberOfEdges;

        public List<Dictionary<int, Dictionary<int, int>>> cases = new List<Dictionary<int, Dictionary<int, int>>>();

        public void ReadData()
        {
            var list = File.ReadLines(@"C:\Users\Ganna Gaidabas\Desktop\DK1.txt").ToList();
            Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();
            numberOfQueries = Convert.ToInt32(list[0].Trim());
            for (int i = 0; i < numberOfQueries; i++)
            {
                var inputParams = ReadParams(list[1]);

                numberOfNodes = inputParams[0];
                numberOfEdges = inputParams[1];
                
                for (int a = 2; a < numberOfEdges + 2; a++)
                {
                    var r = ReadParams(list[a]);
                    HelpMethod(dict, r);
                    r.Reverse(0, 2);
                    HelpMethod(dict, r);
                }

                startVertixNumber = Convert.ToInt32(list[list.Count - 1]);
                cases.Add(dict);
            }
        }

        //public void ReadData()
        //{
        //    numberOfQueries = Convert.ToInt32(Console.ReadLine().Trim());
        //    for (int i = 0; i < numberOfQueries; i++)
        //    {
        //        List<List<int>> nodesInfo = new List<List<int>>();
        //        var inputParams = ReadParams(Console.ReadLine());

        //        numberOfNodes = inputParams[0];
        //        numberOfEdges = inputParams[1];

        //        for (int a = 0; a < numberOfEdges; a++)
        //        {
        //            nodesInfo.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
        //        }

        //        startVertixNumber = Convert.ToInt32(Console.ReadLine());
        //        cases.Add(nodesInfo);
        //    }        
        //}

        public List<int> ShortestReach(int numberOfNodes, Dictionary<int, Dictionary<int, int>> edges, int s)
        {
            //var distances = new List<int>(new int[n]);
            //var visited = new bool[n];
            var visited = new HashSet<int>();
            var vertices = new SortedDictionary<int, int>();

            for (int i = 0; i < numberOfNodes; i++)
            {
                vertices.Add(i + 1, int.MaxValue);
            }

            vertices[s] = 0;

            for (int i = 0; i < numberOfNodes; i++)
            {
                var vertix = FindMinVertix(vertices, visited);

                visited.Add(vertix);

                if (!edges.ContainsKey(vertix))
                {
                    continue;
                }
                //var neigbours = edges.Where(k => k.Key == (vertix)).ToList();
                var neigbours = edges[vertix];
                foreach (var verticForCalc in neigbours)
                {
                    if (!visited.Contains(verticForCalc.Key))
                    {
                        var distanceToVertix = verticForCalc.Value;

                        if (vertices[vertix] == int.MaxValue)
                        {
                            break;
                        }
                        var distance = vertices[vertix] + distanceToVertix;
                        if (vertices[verticForCalc.Key] > distance)
                        {
                            vertices[verticForCalc.Key] = distance;
                        }
                    }
                }
                edges.Remove(vertix);
                //edges.RemoveAll(a => a[1] == index);
            }

            var r = vertices.Values.ToList();

            for (int i = r.Count - 1; i >= 0; i--)
            {
                if (r[i] == int.MaxValue)
                {
                    r[i] = -1;
                }
                else if (r[i] == 0)
                {
                    r.RemoveAt(i);
                }
            }
            return r;
        }

        private int FindMinVertix(SortedDictionary<int, int> vertices, HashSet<int> visited)
        {
            var minValue = int.MaxValue;
            int vertix = -1;
            foreach (var vertex in vertices)
            {
                if (vertex.Value <= minValue && !visited.Contains(vertex.Key))
                {
                    minValue = vertex.Value;
                    vertix = vertex.Key;

                }
            }
            return vertix;
        }

        public void PrintResult(List<int> result)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
            {
                if (item != 0)
                {
                    sb.Append(item + " ");
                }
            }

            Console.WriteLine(sb.ToString() + Environment.NewLine);
        }

        private List<int> ReadParams(string input)
        {
            var convertedParams = new List<int>();
            var inputParams = input.TrimEnd().Split(' ');

            foreach (var param in inputParams)
            {
                convertedParams.Add(Convert.ToInt32(param));
            }

            return convertedParams;
        }

        private Dictionary<int, Dictionary<int, int>> HelpMethod(Dictionary<int, Dictionary<int, int>> dict, List<int> r)
        {
            if (dict.TryGetValue(r[0], out var value))
            {
                if (value.ContainsKey(r[1]))
                {
                    if (r[2] < value[r[1]])
                    {
                        value[r[1]] = r[2];
                    }
                }
                else
                {
                    value.Add(r[1], r[2]);
                }
            }
            else
            {
                dict.Add(r[0], new Dictionary<int, int>() { { r[1], r[2] } });
                // dict.Add(r[1], new Dictionary<int, int>() { { r[0], r[2] } });
            }
            return dict;
        }
    }
}
