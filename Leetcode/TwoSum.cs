/* Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

Example 1:
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:
Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1] */

using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class TwoSumsCalc
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int,int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], 0);
                }
                dict[nums[i]] += 1;
            }

            foreach (var kvp in dict)
            {
                if (kvp.Value > 0)
                {
                    var temp = target - kvp.Key;
                    if (temp == kvp.Key && kvp.Value > 1 || temp != kvp.Key && dict.ContainsKey(temp))
                    {
                        result.Add(kvp.Key);
                        result.Add(temp);
                        break;
                    }
                }
            }

            var ind1 = Array.IndexOf(nums, result[0]);
            var ind2 = Array.LastIndexOf(nums, result[1]);
            return new int[] { ind1, ind2 };
        }
    }
}
