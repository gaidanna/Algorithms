using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms
{
    //Trie
    public class Node
    {
        int numberOfQuesries = 0;
        public int Amount { get; set; }
        public Node[] Children { get; set; } = new Node[26];

        public Node()
        {
            Amount = 1;
        }

        public const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static int GetCharIndex(char c)
        {
            return Alphabet.IndexOf(c);
        }

        public void SetNode(char c)
        {
            Children[GetCharIndex(c)] = new Node();
        }
        public void Add(string word)
        {
            Add(word, 0);
        }

        public int Find(string word)
        {
            return Find(word, 0);
        }
        private void Add(string word, int index)
        {
            Node childNode;
            if (index == word.Length)
            {
                return;
            }

            var alpabetIndex = GetCharIndex(word[index]);
            childNode = Children[alpabetIndex];
            if (childNode == null)
            {
                SetNode(word[index]);
            }
            else
            {
                childNode.Amount += 1;
            }
            Children[alpabetIndex].Add(word, index + 1);
        }

        private int Find(string word, int index)
        {
            int result = 0;
            var index2 = GetCharIndex(word[index]);
            var searchedNode = Children[index2];
            if (searchedNode == null)
            {
                return 0;
            }
            else
            {
                result = searchedNode.Amount;
                index++;
                if (index < word.Length)
                {
                    result = searchedNode.Find(word, index);
                }
                
                return result;
            }
        }

        //}

        
        public List<int> Contacts(List<List<string>> queries)
        {

            var result = new List<int>();
            for (int i = 0; i < queries.Count; i++)
            {
                if (queries[i][0] == "add")
                {
                    Add(queries[i][1]);
                }
                else if (queries[i][0] == "find")
                {
                    var r = Find(queries[i][1]);
                    result.Add(r);
                }
            }
            return result;
        }

        public List<List<string>> ReadData()
        {
            numberOfQuesries = Convert.ToInt32(Console.ReadLine());
            List<List<string>> queries = new List<List<string>>();

            for (int i = 0; i < numberOfQuesries; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
            }

            return queries;
            //List<int> result = Contacts(queries);
        }
    }
}
