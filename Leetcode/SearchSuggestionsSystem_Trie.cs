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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SearchSuggestionsSystem_Trie
    {
        public class Node
        {
            private static int numberOfLetters = 26;
            public Node[] Children;
            public bool IsEndOfWord = false;
            public char Value;

            public Node()
            {
                Children = new Node[numberOfLetters];
            }
            public Node(char value)
            {
                Value = value;
                Children = new Node[numberOfLetters];
            }
            public void Insert(string s)
            {
                Insert(s, 0);
            }

            private void Insert(string s, int index)
            {
                if (index == s.Length)
                {
                    return;
                }

                var charIndex = s[index] - 'a';
                if (Children[charIndex] == null)
                {
                    Children[charIndex] = new Node(s[index]);
                }

                if (index == s.Length - 1)
                {
                    Children[charIndex].IsEndOfWord = true;
                }
                Children[charIndex].Insert(s, index + 1);
            }

            public List<string> SearchSuggestions(string searchCombination)
            {
                StringBuilder sb = new StringBuilder();
                var currentNode = this;
                for (int i = 0; i < searchCombination.Length; i++)
                {
                    if (currentNode.Children[searchCombination[i] - 'a'] == null)
                    {
                        return new List<string>();
                    }
                    else
                    {
                        currentNode = currentNode.Children[searchCombination[i] - 'a'];
                    }
                }
                sb.Append(searchCombination);

                return DFS(currentNode, sb, new List<string>());
            }

            private List<string> DFS(Node node, StringBuilder sb, List<string> words)
            {
                if (words.Count == 3)
                {
                    return words;
                }
                if (node.IsEndOfWord)
                {
                    words.Add(sb.ToString());
                }
                for (int i = 0; i < node.Children.Length; i++)
                {
                    if (node.Children[i] != null)
                    {
                        sb.Append(node.Children[i].Value);

                        words = DFS(node.Children[i], sb, words);
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
                return words;
            }
        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            Node root = new Node();
            IList<IList<string>> result = new List<IList<string>>();

            foreach (var word in products)
            {
                root.Insert(word);
            }

            for (int i = 0; i < searchWord.Length; i++)
            {
                var substring = searchWord.Substring(0, i + 1);
                var r = root.SearchSuggestions(substring);
                result.Add(r);
            }

            return result;
        }
    }
}
