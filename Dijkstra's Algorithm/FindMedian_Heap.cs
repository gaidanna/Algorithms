using HackerrankAlgorithms.structures;
using System;
using System.Collections.Generic;

namespace HackerrankAlgorithms
{
    public class FindMedian_Heap
    {
        MinHeap upperValuesHeap = new MinHeap();
        MaxHeap lowerValuesHeap = new MaxHeap();

        public List<double> runningMedian(List<int> input)
        {
            List<double> medians = new List<double>();
            for (int i = 0; i < input.Count; i++)
            {
                AddNumber(input[i], lowerValuesHeap, upperValuesHeap);
                RebalanceHeaps(lowerValuesHeap, upperValuesHeap);
                medians.Add(GetMedian(lowerValuesHeap, upperValuesHeap));
            }
            return medians;
        }

        private double GetMedian(MaxHeap minHeap, MinHeap maxHeap)
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

        public List<int> ReadData()
        {
            List<int> input = new List<int>();
            var numberOfQueries = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 0; i < numberOfQueries; i++)
            {
                var r = Convert.ToInt32(Console.ReadLine().Trim());
                input.Add(r);
            }
            return input;
        }
    }
}
