using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms
{
    public class MorseCode
    {
        private static Node currentNode;
        private static Node tree = new Node(null);
        private static Dictionary<string, string> morse = new Dictionary<string, string>()
        { {"E", "."}, { "T", "-"}, {"I", ".."}, { "A", ".-"}, {"N", "-."}, { "M", "--"},
            {"S", "..."}, { "U", "..-"}, {"R", ".-."}, { "W", ".--"},
            {"D", "-.."}, { "K", "-.-"}, {"G", "--."}, { "O", "---"} };
        
        public static string[] Possibilities(string signals)
        {
            InitializeTree();
            var searchResult = tree.Search(signals);

            var values = new string[searchResult.Count];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = searchResult.Dequeue().Data;
            }
            return values;
        }

        private static void InitializeTree()
        {
            
            foreach (var kvp in morse)
            {
                currentNode = tree;
                tree.Insert(kvp.Value, kvp.Key);
            }
        }

        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public string Data { get; set; }

            public Node(string data)
            {
                this.Data = data;
            }

            public void Insert(string signal, string data)
            {
                var charArray = signal.ToCharArray();
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i] == '.')
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = new Node(data);
                        }
                        else
                        {
                            currentNode = currentNode.Left;
                        }
                    }
                    else if (charArray[i] == '-')
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = new Node(data);
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                        }
                    }
                }
            }

            public Queue<Node> Search(string signals)
            {
                var morseValues = new Queue<Node>();
                morseValues.Enqueue(this);

                var charArray = signals.ToCharArray();
                for (int i = 0; i < charArray.Length; i++)
                {
                    var tempValues = new List<Node>();

                    while (morseValues.Any())
                    {
                        var currentValue = morseValues.Dequeue();
                        if (charArray[i] == '.')
                        {
                            tempValues.Add(currentValue.Left);
                        }
                        else if (charArray[i] == '-')
                        {
                            tempValues.Add(currentValue.Right);
                        }
                        else if (charArray[i] == '?')
                        {
                            tempValues.Add(currentValue.Left);
                            tempValues.Add(currentValue.Right);
                        }
                    }

                    foreach (var v in tempValues)
                    {
                        morseValues.Enqueue(v);
                    }
                }

                return morseValues;
            }
        }
    }
}
