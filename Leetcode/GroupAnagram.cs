/* iven an array of strings strs, group the anagrams together. You can return the answer in any order.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Example 1:
Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
*/

using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class GroupAnagram
    {
        public int NumberOfLetters = 26;
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                var charArray = strs[i].ToCharArray().ToList();
                charArray.Sort();
                var sortedString = new string(charArray.ToArray());
                if (!anagrams.ContainsKey(sortedString))
                {
                    anagrams.Add(sortedString, new List<string>());
                }
                anagrams[sortedString].Add(strs[i]);
            }

            foreach (var value in anagrams.Values)
            {
                result.Add(value);
            }
            IList<IList<string>> p = result;
            return p;
        }
    }
}
