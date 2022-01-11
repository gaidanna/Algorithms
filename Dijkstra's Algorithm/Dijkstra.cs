using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms
{
    public class Dijkstra
    {
        public int numberOfQueries;
        public int startVertixNumber;
        public int numberOfNodes;
        public int numberOfEdges;

        public List<List<List<int>>> cases = new List<List<List<int>>>();

        public void ReadData()
        {
            var list = File.ReadLines(@"C:\Users\Ganna Gaidabas\Desktop\DK.txt").ToList();

            numberOfQueries = Convert.ToInt32(list[0].Trim());
            for (int i = 0; i < numberOfQueries; i++)
            {
                List<List<int>> nodesInfo = new List<List<int>>();
                var inputParams = ReadParams(list[1]);

                numberOfNodes = inputParams[0];
                numberOfEdges = inputParams[1];

                for (int a = 2; a < numberOfEdges + 2; a++)
                {
                    var r = ReadParams(list[a]);


                    nodesInfo.Add(new List<int>(r));
                    r.Reverse(0, 2);
                    nodesInfo.Add(r);

                    //nodesInfo.Add(list[a].TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
                }

                startVertixNumber = Convert.ToInt32(list[list.Count - 1]);
                cases.Add(nodesInfo);
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

        public List<int> ShortestReach(int numberOfNodes, List<List<int>> edges, int s)
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

                var neigbours = edges.Where(k => k[0] == (vertix)).ToList();

                for (int b = 0; b < neigbours.Count; b++)
                {
                    var verticForCalc = neigbours[b][1];
                   // var verticForCalcIndex = verticForCalc - 1;

                    if (!visited.Contains(verticForCalc))
                    {
                        var distanceToVertix = neigbours[b][2];
                        //if (distances[index] != int.MaxValue)
                        //{
                        //    var distance = distances[index] + distanceToVertix;

                        //    if (distances[verticForCalc] > distance)
                        //    {
                        //        distances[verticForCalc] = distance;
                        //    }
                        //}
                        if (vertices[vertix] == int.MaxValue)
                        {
                            break;
                        }
                        var distance = vertices[vertix] + distanceToVertix;
                        if (vertices[verticForCalc] > distance)
                        {
                            vertices[verticForCalc] = distance;
                        }
                    }
                }
                edges.RemoveAll(a => a[0] == vertix);
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
                    sb.Append(item + " " );
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
    }
}
