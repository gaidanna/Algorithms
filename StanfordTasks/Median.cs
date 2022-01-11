/* 
Download the following text file: Median.txt
The goal of this problem is to implement the "Median Maintenance" algorithm (covered in the Week 5 lecture on heap applications). 
The text file contains a list of the integers from 1 to 10000 in unsorted order; you should treat this as a stream of numbers,
arriving one by one. Letting Xi denote the i-th number of the file, the k-th median  is defined as the median Mk of the numbers X1, ..., Xk. 
(So, if K is odd, then Mk is ((k+1)/2)th smallest number among X11,.., Xk; if K is even, then Mk is the (K/2)th smallest number among X1, ..., Xk.)
In the box below you should type the sum of these 10000 medians, modulo 10000 (i.e., only the last 4 digits). That is, you should compute (M1+M2+M3+...+M10000) mod 10000.
OPTIONAL EXERCISE: Compare the performance achieved by heap-based and search-tree-based
Answer 1213
*/

using CertificateTasks.Heap;
using System;
using System.Collections.Generic;
using System.IO;

namespace CertificateTasks
{
    public class Median
    {
        MinHeap upperValuesHeap = new MinHeap();
        MaxHeap lowerValuesHeap = new MaxHeap();

        public List<double> runningMedian(List<int> input)
        {
            double midSum = 0; 
            List<double> medians = new List<double>();
            for (int i = 0; i < input.Count; i++)
            {
                AddNumber(input[i], lowerValuesHeap, upperValuesHeap);
                RebalanceHeaps(lowerValuesHeap, upperValuesHeap);
                var midValue = GetMedian(lowerValuesHeap, upperValuesHeap, i + 1);
                medians.Add(midValue);
                midSum = (midSum + midValue) % 10000;
            }
            return medians;
        }

        private double GetMedian(MaxHeap minHeap, MinHeap maxHeap, int index)
        {
            IHeap smallerHeap = minHeap.Size < maxHeap.Size ? minHeap : maxHeap;
            IHeap biggerHeap = minHeap.Size < maxHeap.Size ? maxHeap : minHeap;

            if (smallerHeap.Size == biggerHeap.Size)
            {
                return (double)(smallerHeap.Peek() + biggerHeap.Peek()) / 2;
            }
            else
            {
                return biggerHeap.Peek();
            }
        }

        private void RebalanceHeaps(MaxHeap minHeap, MinHeap maxHeap)
        {
            IHeap smallerHeap = minHeap.Size < maxHeap.Size ? minHeap : maxHeap;
            IHeap biggerHeap = minHeap.Size < maxHeap.Size ? maxHeap : minHeap;

            if (biggerHeap.Size - smallerHeap.Size >= 2)
            {
                var valueToMove = biggerHeap.Poll();
                smallerHeap.Add(valueToMove);
            }
        }

        private void AddNumber(int v, MaxHeap minHeap, MinHeap maxHeap)
        {
            if (minHeap.Size == 0 || v < minHeap.Peek())
            {
                minHeap.Add(v);
            }
            else
            {
                maxHeap.Add(v);
            }
        }

        public List<int> ReadDataStanford()
        {
            var numberOfQueries = File.ReadAllLines(@"C:\Users\Ganna Gaidabas\Desktop\Median.txt");
            List<int> input = new List<int>();

            for (int i = 0; i < numberOfQueries.Length; i++)
            {
                var r = Convert.ToInt32(numberOfQueries[i]);
                input.Add(r);
            }
            return input;
        }
    }
}
