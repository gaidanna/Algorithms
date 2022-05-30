/* Give a binary string s, return the number of non-empty substrings that have the same number of 0's and 1's, and all the 0's and all the 1's in these substrings are grouped consecutively.
Substrings that occur multiple times are counted the number of times they occur.

Example 1:
Input: s = "00110011"
Output: 6
Explanation: There are 6 substrings that have equal number of consecutive 1's and 0's: "0011", "01", "1100", "10", "0011", and "01".
Notice that some of these substrings repeat and are counted the number of times they occur.
Also, "00110011" is not a valid substring because all the 0's (and 1's) are not grouped together.

Example 2:
Input: s = "10101"
Output: 4
Explanation: There are 4 substrings: "10", "01", "10", "01" that have equal number of consecutive 1's and 0's.*/
using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class CountBinarySubstring
    {
        //much faster approach
        public int CountBinarySubstrings(string s)
        {
            var result = 0;
            Dictionary<int, int> groups = new Dictionary<int, int>();
            var groupCount = 1;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (i == 0)
                {
                    groups.Add(groupCount, 1);
                }
                if (s[i] == s[i + 1])
                {
                    groups[groupCount] = groups[groupCount] + 1;
                }
                else
                {
                    groupCount++;
                    groups.Add(groupCount, 1);
                }
            }

            for (int i = 1; i < groupCount; i++)
            {
                result += Math.Min(groups[i], groups[i + 1]);
            }
            return result;
        }
        public int CountBinarySubstrings2(string s)
        {
            var result = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                var duplicatesCount = 1;
                var j = i + 1;
                while (j <= s.Length - 1 && s[i] == s[j] && duplicatesCount < s.Length / 2)
                {
                    duplicatesCount++;
                    j++;
                }
                while (duplicatesCount > 0 && j <= s.Length - 1)
                {
                    if (s[i] != s[j])
                    {
                        duplicatesCount--;
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (duplicatesCount == 0)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
