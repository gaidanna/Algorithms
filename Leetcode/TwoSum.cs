using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
