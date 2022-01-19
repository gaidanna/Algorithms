/* In this programming problem you'll code up the dynamic programming algorithm for computing a maximum-weight independent set of a path graph. 
Download the text file below mwis.txt
This file describes the weights of the vertices in a path graph (with the weights listed in the order in which vertices appear in the path). It has the following format:
[number_of_vertices]
[weight of first vertex]
[weight of second vertex]
...
For example, the third line of the file is "6395702," indicating that the weight of the second vertex of the graph is 6395702. 
Your task in this problem is to run the dynamic programming algorithm (and the reconstruction procedure) from lecture on this data set.  
The question is: of the vertices 1, 2, 3, 4, 17, 117, 517, and 997, which ones belong to the maximum-weight independent set?  
(By "vertex 1" we mean the first vertex of the graph---there is no vertex 0.)   In the box below, enter a 8-bit string, where the ith bit should be 1 if the ith of 
these 8 vertices is in the maximum-weight independent set, and 0 otherwise. For example, if you think that the vertices 1, 4, 17, and 517 are in the maximum-weight independent
set and the other four vertices are not, then you should enter the string 10011010 in the box below.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CertificateTasks2
{
    public class MaxWeightIndependentSet
    {
        public int NumberOfvertices;
        public Dictionary<int, int> ReadInput()
        {
            
            Dictionary<int, int> vertices = new Dictionary<int, int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\mwis.txt");
            var input = File.ReadAllLines(path);
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    NumberOfvertices = Convert.ToInt32(input[i]);
                }
                else
                {
                    var weight = Convert.ToInt32(input[i]);
                    vertices.Add(i, weight);
                }
            }
            return vertices;
        }

        public long[] CalculateWIS(Dictionary<int, int> vertices)
        {
            long[] result = new long[NumberOfvertices + 1];
            result[0] = 0;
            result[1] = vertices[1];

            for (int i = 2; i < result.Length; i++)
            {
                result[i] = Math.Max(result[i - 1], result[i - 2] + vertices[i]);
            }
            return result;
        }

        public List<int> Reconstruction(long[] result, Dictionary<int, int> vertices)
        {
            List<int> selectedValues = new List<int>();
            var count = NumberOfvertices;
            while (count >= 1)
            {
                if (count == 1)
                {
                    selectedValues.Add(count);
                    count--;
                }
                else if (result[count - 1] >= result[count - 2] + vertices[count])
                {
                    count--;
                }
                else
                {
                    selectedValues.Add(count);
                    count -= 2;
                }
            }
            return selectedValues;
        }

        public bool[] CheckVertices(List<int> selectedValues)
        {
            bool[] presentedvalues = new bool[8];
            int[] valuesToCheck = new int[] { 1, 2, 3, 4, 17, 117, 517, 997 };

            for (int i = 0; i < valuesToCheck.Length; i++)
            {
                if (selectedValues.Contains(valuesToCheck[i]))
                {
                    presentedvalues[i] = true;
                }
                else
                {
                    presentedvalues[i] = false;
                }
            }
            return presentedvalues;
        }
    }
}
