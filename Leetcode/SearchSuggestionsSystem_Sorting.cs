/* You are given an array of strings products and a string searchWord.
Design a system that suggests at most three product names from products after each character of searchWord is typed. Suggested products should have common prefix with searchWord. If there are more than three products with a common prefix return the three lexicographically minimums products.
Return a list of lists of the suggested products after each character of searchWord is typed.

Example 1:
Input: products = ["mobile","mouse","moneypot","monitor","mousepad"], searchWord = "mouse"
Output: [
["mobile","moneypot","monitor"],
["mobile","moneypot","monitor"],
["mouse","mousepad"],
["mouse","mousepad"],
["mouse","mousepad"]
]
Explanation: products sorted lexicographically = ["mobile","moneypot","monitor","mouse","mousepad"]
After typing m and mo all products match and we show user ["mobile","moneypot","monitor"]
After typing mou, mous and mouse the system suggests ["mouse","mousepad"]
*/
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class SearchSuggestionsSystem_Sorting
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            var sortedProducts = products.OrderBy(p => p).ToList();

            var result = new List<IList<string>>();
            var current = "";
            foreach (var s in searchWord)
            {
                current += s;

                for (var i = sortedProducts.Count - 1; i >= 0; --i)
                {
                    if (!sortedProducts[i].StartsWith(current))
                    {
                        sortedProducts.RemoveAt(i);
                    }
                }

                result.Add(sortedProducts.Take(3).ToList());
            }

            return result;
        }
        
    }
}
