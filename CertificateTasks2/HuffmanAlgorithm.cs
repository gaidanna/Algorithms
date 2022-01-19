/*In this programming problem and the next you'll code up the greedy algorithm from the lectures on Huffman coding.
Download the text file below huffman.txt
This file describes an instance of the problem.It has the following format:
[number_of_symbols]
[weight of symbol #1]
[weight of symbol #2]
...
For example, the third line of the file is "6852892," indicating that the weight of the second symbol of the alphabet is 6852892.  
(We're using weights instead of frequencies, like in the "A More Complex Example" video.)
Continuing the previous problem, what is the minimum length of a codeword in your Huffman code?
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CertificateTasks2
{
    public class HuffmanAlgorithm
    {
        public int MaxLength = 0;
        public int MinLength = 0;
        public SortedDictionary<long, Node> ReadInput()
        {
            var numberOfSymbols = 0;
            SortedDictionary<long, Node> codes = new SortedDictionary<long, Node>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\huffman.txt");
            var input = File.ReadAllLines(path);
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    numberOfSymbols = Convert.ToInt32(input[i]);
                }
                else
                {
                    var key = Convert.ToInt64(input[i]);
                    codes.Add(key, new Node(key));
                }
            }
            return codes;
        }

        public Node CalcHuffmanCodes(SortedDictionary<long, Node> codes)
        {
            var node1 = codes[codes.Keys.First()];
            codes.Remove(codes.Keys.First());
            var node2 = codes[codes.Keys.First()];
            codes.Remove(codes.Keys.First());

            var maxLength = node1.MaxLength >= node2.MaxLength ? node1.MaxLength + 1 : node2.MaxLength + 1;
            var minLength = node1.MinLength >= node2.MinLength ? node2.MinLength + 1 : node1.MinLength + 1;
            var fusedNode = new Node(node1.Data + node2.Data) { Left = node1, Right = node2, MaxLength = maxLength, MinLength = minLength  };
            codes.Add(node1.Data + node2.Data, fusedNode);
            if (codes.Count >= 2)
            {
                return CalcHuffmanCodes(codes);
            }
            else
            {
                //see min and max properties for answer
                return fusedNode;
            }
        }
    }

    public class Node
    {
        public int MaxLength;
        public int MinLength;
        public long Data;
        public Node Left;
        public Node Right;
        public Node(long data)
        {
            MinLength = 0;
            MaxLength = 0;
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
