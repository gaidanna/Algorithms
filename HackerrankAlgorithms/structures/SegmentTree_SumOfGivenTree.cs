using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.structures
{
    class SegmentTree_SumOfGivenTree
    {
        public int[] Tree { get; set; }
        public SegmentTree_SumOfGivenTree()
        { }

        public void CreateSegmentTree(int[] arr, int arrayLength)
        {
            //Height of segment tree
            var x = (int)(Math.Ceiling(Math.Log(arrayLength) / Math.Log(2)));
            int maxSize = 2 * (int)Math.Pow(2, x) - 1;
            Tree = new int[maxSize];

            ConstructSegmentTree(arr, 0, arrayLength - 1, 0);
        }

        private int ConstructSegmentTree(int[] input, int low, int high, int pos)
        {
            if (low == high)
            {
                Tree[pos] = input[low];
                return input[low];
            }
            int mid = (low + high) / 2;

            //sum
            Tree[pos] = ConstructSegmentTree(input, low, mid, 2 * pos + 1) +
                                        ConstructSegmentTree(input, mid + 1, high, 2 * pos + 2);
            return Tree[pos];
        }

        public int GetSumRangeQuery(int[] segmentTree, int low, int high, int queryLow, int queryHigh, int pos)
        {
            if (queryLow <= low && queryHigh >= high)//query overlaps low-high segment, then we return value
            {
                return segmentTree[pos];
            }
            if (queryLow > high || queryHigh < low) //no overlap at all
            {
                return 0;
            }
            int mid = (low + high) / 2;
            return GetSumRangeQuery(segmentTree, low, mid, queryLow, queryHigh, 2 * pos + 1) +
                    GetSumRangeQuery(segmentTree, mid + 1, high, queryLow, queryHigh, 2 * pos + 2);
        }

        public void UpdateValue(int[] inputArr, int index, int newVal)
        {
            if (index < 0 || index > inputArr.Length - 1)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            int diff = newVal - inputArr[index];

            inputArr[index] = newVal;

            UpdateValueUtil(0, inputArr.Length - 1, index, diff, 0);
        }

        private void UpdateValueUtil(int low, int high, int index, int diff, int currentNodeIndex)
        {
            if (index < low || index > high)
                return;

            Tree[currentNodeIndex] += diff;
            //if (low >= high)
            //{
            //    return;
            //}
            if (low != high)
            {
                int mid = (low + high) / 2;
                UpdateValueUtil(low, mid, index, diff, 2 * currentNodeIndex + 1);
                UpdateValueUtil(mid + 1, high, index, diff, 2 * currentNodeIndex + 2);
            }
        }
    }
}
