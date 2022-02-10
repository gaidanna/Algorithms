/*
Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
 
Example 1:

Input: s = "cbaebabacd", p = "abc"
Output: [0,6]
Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".
Example 2:

Input: s = "abab", p = "ab"
Output: [0,1,2]
Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".
using System.Collections.Generic;
*/
using System.Collections.Generic;

namespace Leetcode
{
    public class AnagramsInString
    {
        //the number of small letters in alphabet
        public int NumberOfLetters = 26;
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            if (s == null || s.Length == 0 || s.Length < p.Length)
            {
                return result;
            }

            int[] anagamChars = new int[NumberOfLetters];
            int[] textChars = new int[NumberOfLetters];

            for (int i = 0; i < p.ToCharArray().Length; i++)
            {
                anagamChars[p[i] - 'a'] += 1;
                textChars[s[i] - 'a'] += 1;
            }

            bool identical = Compare(anagamChars, textChars);
            if (identical)
            {
                result.Add(0);
            }

            var left = 0;
            for (int i = p.ToCharArray().Length; i < s.ToCharArray().Length; i++)
            {
                
                textChars[s[left] - 'a'] -= 1;
                textChars[s[i] - 'a'] += 1;

                left++;
                identical = Compare(anagamChars, textChars);
                if (identical)
                {
                    result.Add(left);
                }
            }
            return result;
        }

        private bool Compare(int[] array1, int[] array2)
        {
            for (int i = 0; i < NumberOfLetters; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
