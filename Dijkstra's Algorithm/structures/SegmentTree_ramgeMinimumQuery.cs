using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.structures
{
    public class SegmentTree
    {
        public int[] Tree { get; set; }
        public SegmentTree()
        { }

        public void CreateSegmentTree(int[] arr, int n)
        {
            //Height of segment tree
            var x = (int)(Math.Ceiling(Math.Log(n) / Math.Log(2)));
            int maxSize = 2 * (int)Math.Pow(2, x) - 1;
            Tree = new int[maxSize];

            ConstructSegmentTree(arr, 0, n - 1, 0);
        }

        //from github
        //public void ConstructSegmentTree(int[] segmentTree, int[] input, int low, int high, int pos)
        //{
        //    if (low == high)
        //    {
        //        segmentTree[pos] = input[low];
        //        return;
        //    }
        //    int mid = (low + high) / 2;
        //    //left node
        //    ConstructSegmentTree(segmentTree, input, low, mid, 2 * pos + 1);
        //    //right node
        //    ConstructSegmentTree(segmentTree, input, mid + 1, high, 2 * pos + 2);
        //    //alternatively can be number addition
        //    segmentTree[pos] = Math.Min(segmentTree[2 * pos + 1], segmentTree[2 * pos + 2]);
        //}

        private int ConstructSegmentTree(/*int[] segmentTree,*/ int[] input, int low, int high, int pos)
        {
            if (low == high)
            {
                Tree[pos] = input[low];
                return input[low];
            }
            int mid = (low + high) / 2;

            Tree[pos] = Math.Min(ConstructSegmentTree(/*segmentTree,*/ input, low, mid, 2 * pos + 1), 
                                        ConstructSegmentTree(/*segmentTree,*/ input, mid + 1, high, 2 * pos + 2));
            return Tree[pos];
        }

        public int GetRangeMinQuery(int[] segmentTree, int low, int high, int queryLow, int queryHigh, int pos)
        {
            if (queryLow <= low && queryHigh >= high)//query overlaps low-high segment, then we return value
            {
                return segmentTree[pos];
            }
            if (queryLow > high || queryHigh < low) //no overlap at all
            {
                return int.MaxValue;
            }
            int mid = (low + high) / 2;
            return Math.Min(GetRangeMinQuery(segmentTree, low, mid, queryLow, queryHigh, 2 * pos + 1),
                    GetRangeMinQuery(segmentTree, mid + 1, high, queryLow, queryHigh, 2 * pos + 2));
        }
    }
}
