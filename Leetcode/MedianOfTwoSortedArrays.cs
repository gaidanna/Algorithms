/* Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
The overall run time complexity should be O(log (m+n)).

Example 1:
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MedianTwoArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double result = 0;
            var mergedArray = MergeTwoArrays(nums1, nums2);
            if (mergedArray.Length % 2 == 0)
            {
                result = (double) (mergedArray[mergedArray.Length / 2 - 1] + mergedArray[mergedArray.Length / 2]) / 2;
            }
            else
            {
                result = mergedArray[mergedArray.Length / 2];
            }
            return result;
        }

        private int[] MergeTwoArrays(int[] nums1, int[] nums2)
        {
            var count = nums1.Length + nums2.Length;
            int[] mergedArray = new int[count];
            Queue<int> q1 = new Queue<int>(nums1);
            Queue<int> q2 = new Queue<int>(nums2);
            var index = 0;

            while (index < count)
            {
                if (q1.Count > 0 && q2.Count > 0)
                {
                    if (q1.Peek() < q2.Peek())
                    {
                        mergedArray[index] = q1.Dequeue();
                    }
                    else
                    {
                        mergedArray[index] = q2.Dequeue(); ;
                    }
                    index++;
                }
                else
                {
                    break;
                }
            }

            var tempQueue = q1.Count > 0 ? q1 : q2;
            for (int j = index; j < mergedArray.Length; j++)
            {
                mergedArray[j] = tempQueue.Dequeue(); ;
            }
            return mergedArray;
        }
    }
}
