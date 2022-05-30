/*Given string num representing a non-negative integer num, and an integer k, return the smallest possible integer after removing k digits from num.

Example 1:
Input: num = "1432219", k = 3
Output: "1219"
Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.

Example 2:
Input: num = "10200", k = 1
Output: "200"
Explanation: Remove the leading 1 and the number is 200. Note that the output must not contain leading zeroes.

Example 3:
Input: num = "10", k = 2
Output: "0"
Explanation: Remove all the digits from the number and it is left with nothing which is 0. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public class RemoveDigits
    {
        public string RemoveKdigits(string num, int k)
        {
            StringBuilder stringBuilder = new StringBuilder();

            Stack<int> keptNumbers = new Stack<int>();

            var numbersArray = new int[num.Length];

            for (int i = 0; i < num.ToCharArray().Length; i++)
            {
                //var alternative = num[i] - '0';
                numbersArray[i] = (int)Char.GetNumericValue(num[i]);
            }

            for (int i = 0; i < num.Length; i++)
            {
                while (keptNumbers.Any() && k > 0 && keptNumbers.Peek() > num[i] - '0')
                {

                    keptNumbers.Pop();
                    k--;
                }
                keptNumbers.Push(num[i] - '0');
            }

            for (int i = 0; i < k; i++)
            {
                keptNumbers.Pop();
            }

            var result = keptNumbers.ToArray();
            Array.Reverse(result);
            bool firstZero = true;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0 && firstZero)
                {
                    continue;
                }

                firstZero = false;

                stringBuilder.Append(result[i]);
            }
            return stringBuilder.Length > 0 ? stringBuilder.ToString() : "0";
        }
    }
}
