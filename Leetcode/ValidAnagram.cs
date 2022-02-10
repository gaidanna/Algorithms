/* Given two strings s and t, return true if t is an anagram of s, and false otherwise.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Example 1:
Input: s = "anagram", t = "nagaram"
Output: true

Example 2:
Input: s = "rat", t = "car"
Output: false
*/

using System.Linq;

namespace Leetcode
{
    public class ValidAnagram
    {
        public int NumberOfLetters = 26;

        //this one is fast
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            var r1 = s.ToCharArray().ToList();
            r1.Sort();

            var r2 = t.ToCharArray().ToList();
            r2.Sort();

            var sortedS = new string(r1.ToArray());
            var sortedT = new string(r2.ToArray());
            return sortedS == sortedT;
        }

        //failed with timeout on leetcode, but still correct
        public bool IsAnagram2(string s, string t)
        {
            if (s == null || t == null || s.Length != t.Length || s.Length == 0)
            {
                return false;
            }
            var arrayS = new int[26];
            var arrayT = new int[26];

            for (int i = 0; i < s.ToCharArray().Length; i++)
            {
                arrayS[s[i] - 'a'] += 1;
                arrayT[t[i] - 'a'] += 1;
            }
            return Compare(arrayS, arrayT);
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
