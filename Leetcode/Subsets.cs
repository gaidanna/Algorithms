using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Subset
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                IList<int> keepTrackingList = new List<int>();
               
                for (int j = i; j < nums.Length; j++)
                {
                    IList<int> list = new List<int>();
                    list.Add(nums[i]);
                    if (j == i)
                    {
                        keepTrackingList.Add(nums[j]);
                        result.Add(list);
                    }
                    else
                    {
                        keepTrackingList.Add(nums[j]);
                        list.Add(nums[j]);
                        result.Add(list);
                    }

                    if (keepTrackingList.Count > 2)
                    { 
                    result.Add(keepTrackingList.ToList());
                    }
                }
            }
            return result;
        }
    }
}
