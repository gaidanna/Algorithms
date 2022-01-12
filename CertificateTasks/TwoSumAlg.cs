/*
Download the following text file: algo1-programming_prob-2sum.txt
The goal of this problem is to implement a variant of the 2-SUM algorithm (covered in the Week 6 lecture
on hash table applications). 
The file contains 1 million integers, both positive and negative (there might be some repetitions!).
This is your array of integers, with the  row of the file specifying the  entry of the array.
Your task is to compute the number of target values  in the interval [-10000,10000] (inclusive) such 
that there are distinct numbers  in the input file that satisfy . (NOTE: ensuring distinctness requires
a one-line addition to the algorithm from lecture.)
Write your numeric answer (an integer between 0 and 20001) in the space provided.
OPTIONAL CHALLENGE: If this problem is too easy for you, try implementing your own hash table for it. 
For example, you could compare performance under the chaining and open addressing approaches to 
resolving collisions.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CertificateTasks
{
    public class TwoSumAlg
    {
        private const int intervalMin = -10000;
        private const int intervalMax = 10000;
        public Dictionary<long, int> ReadInput()
        {
            var inputData = new Dictionary<long, int>();
            var count = 1;
            var input = File.ReadAllLines(@"C:\Users\Ganna Gaidabas\Desktop\algo1-programming_prob-2sum.txt").ToList();

            for (int i = 0; i < input.Count; i++)
            {
                var key = Convert.ToInt64(input[i]);
                if (!inputData.ContainsKey(key))
                {
                    inputData.Add(key, count);
                }
            }
            return inputData;
        }

        public HashSet<long> TwoSumCalculate(Dictionary<long, int> inputValues)
        {
            HashSet<long> result = new HashSet<long>();
            foreach (var kvp in inputValues)
            {
                List<long> searhedValues = new List<long>();
                var bound1 = intervalMin - kvp.Key;
                var bound2 = intervalMax - kvp.Key;

                for (long i = bound1; i <= bound2; i++)
                {
                    if(inputValues.ContainsKey(i))
                    {
                        searhedValues.Add(i);
                        i++;
                    }
                }

                for (int i = 0; i < searhedValues.Count; i++)
                {
                    var sum = kvp.Key + searhedValues[i];

                    if (!result.Contains(sum))
                    {
                        result.Add(sum);
                    }
                }
                inputValues.Remove(kvp.Key);

            }
            return result;
        }
    }
}
