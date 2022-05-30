/* Given an array intervals where intervals[i] = [li, ri] represent the interval [li, ri), remove all intervals that are covered by another interval in the list.
The interval [a, b) is covered by the interval [c, d) if and only if c <= a and b <= d.
Return the number of remaining intervals.

Example 1:
Input: intervals = [[1,4],[3,6],[2,8]]
Output: 2
Explanation: Interval [3,6] is covered by [2,8], therefore it is removed.

Example 2:
Input: intervals = [[1,4],[2,3]]
Output: 1 */

//comparer - want to keep item on the same place - return 1, want to swap it - return - 1;

using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class RemoveCoveredInterval
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            var count = 0;
            var prevEnd = 0;
            var currEnd = 0;
            var comparer = new CustomComparer();

            Array.Sort(intervals, comparer);

            for (int i = 0; i < intervals.Length; i++)
            {
                currEnd = intervals[i][1];
                if (prevEnd < currEnd)
                { 
                    count++;
                    prevEnd = currEnd;
                }
            }
            return count;
        }

        public class CustomComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {

                if (x[0] == y[0])
                {
                    if (x[1] - y[1] < 0)
                    {
                        return 1;
                    }
                    else if (x[1] - y[1] > 0)
                    {
                        return -1;
                    }
                    else return 0;
                }
                else
                {
                    return x[0] - y[0];
                }
            }
        }
    }
}
