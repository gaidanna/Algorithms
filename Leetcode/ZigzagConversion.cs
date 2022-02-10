/*Given a string s, return the longest palindromic substring in s.

Example 1:
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.

Example 2:
Input: s = "cbbd"
Output: "bb"*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ZigzagConversion
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }
            Dictionary<int, List<char>> dict = new Dictionary<int, List<char>>();
            for (int i = 0; i < numRows; i++)
            {
                dict.Add(i + 1, new List<char>());
            }

            var count = 0;
            var diagonalCount = numRows - 1;
            var minDiagonalRow = numRows == 2 ? 1 : 2;
            for (int i = 0; i < s.Length; i++)
            {
                if (count < numRows)
                {
                    dict[count + 1].Add(s[i]);
                    count++;
                    if (count == numRows && minDiagonalRow == 1)
                    {
                        count = 0;
                    }
                }
                else
                {
                    if (diagonalCount >= minDiagonalRow)
                    {
                        dict[diagonalCount].Add(s[i]);
                        
                        if (diagonalCount == minDiagonalRow)
                        {
                            count = 0;
                            diagonalCount = numRows - 1;
                        }
                        else
                        {
                            diagonalCount--;
                        }
                    }
                }
            }
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in dict)
            {
                sb.Append(String.Join("", kvp.Value));
            }
            return sb.ToString(); 
        }
    }
}
