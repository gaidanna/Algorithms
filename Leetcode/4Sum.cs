/* Given four integer arrays nums1, nums2, nums3, and nums4 all of length n, return the number of tuples (i, j, k, l) such that:
0 <= i, j, k, l < n
nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0

Example 1:
Input: nums1 = [1,2], nums2 = [-2,-1], nums3 = [-1,2], nums4 = [0,2]
Output: 2
Explanation:
The two tuples are:
1. (0, 0, 0, 1) -> nums1[0] + nums2[0] + nums3[0] + nums4[1] = 1 + (-2) + (-1) + 2 = 0
2. (1, 1, 0, 0) -> nums1[1] + nums2[1] + nums3[0] + nums4[0] = 2 + (-1) + (-1) + 0 = 0  */

using System.Collections.Generic;

namespace Leetcode
{
    public class FourSum
    {
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            var count = 0;
            var arraysSum1 = TwoArraysSum(nums1, nums2);
            var arraysSum2 = TwoArraysSum(nums3, nums4);

            foreach (var kvp in arraysSum1)
            {
                if (arraysSum2.ContainsKey(-kvp.Key))
                {
                    count += kvp.Value * arraysSum2[-kvp.Key];
                }
            }
            return count;
        }

        public Dictionary<int, int> TwoArraysSum(int[] array1, int[] array2)
        {
            var result = new Dictionary<int, int>();
            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    var sum = array1[i] + array2[j];
                    if (!result.ContainsKey(sum))
                    {
                        result.Add(sum, 0);
                    }
                    result[sum] += 1;
                }
            }
            return result;
        }
    }
}
