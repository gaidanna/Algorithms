/*3. Longest Substring Without Repeating Characters
Given a string s, find the length of the longest substring without repeating characters.

Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            var left = 0;
            var right = 0;
            var maxDifference = 0;

            Dictionary<char, int> charsCountDict = new Dictionary<char, int>();
            var chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!charsCountDict.ContainsKey(chars[i]))
                {
                    charsCountDict.Add(chars[i], right);
                }
                else
                {
                    left = Math.Max(charsCountDict[chars[i]] + 1, left);
                    charsCountDict[chars[i]] = i; 
                }
                right++;

                var difference = right - left;
                if (difference > maxDifference)
                {
                    maxDifference = difference;
                }
            }

            return maxDifference;
        }
    }
}
