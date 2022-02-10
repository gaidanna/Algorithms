/*
This problem also asks you to solve a knapsack instance, but a much bigger one. 
Download the text file below knapsack_big.txt
This file describes a knapsack instance, and it has the following format:
[knapsack_size][number_of_items]
[value_1] [weight_1]
[value_2] [weight_2]
...
For example, the third line of the file is "50074 834558", indicating that the second item has value 50074 and size 834558, respectively.  As before, you should assume that item weights and the knapsack capacity are integers.
This instance is so big that the straightforward iterative implemetation uses an infeasible amount of time and space.  So you will have to be creative to compute an optimal solution.  One idea is to go back to a recursive implementation, solving subproblems --- and, of course, caching the results to avoid redundant work --- only on an "as needed" basis.  Also, be sure to think about appropriate data structures for storing and looking up solutions to subproblems.
In the box below, type in the value of the optimal solution.
ADVICE: If you're not getting the correct answer, try debugging your algorithm using some small test cases. And then post them to the discussion forum!
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CertificateTasks2
{
    //needs optimization, straightforward approach
    public class KnapsackBig
    {

        public int KnapsackSize;
        public int NumberOfItems;

        public List<Item> ReadInut()
        {
            List<Item> items = new List<Item>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\knapsack_big.txt");
            var input = File.ReadAllLines(path);

            for (int i = 0; i < input.Length; i++)
            {
                var temp = input[i].Trim().Split(" ");
                if (i != 0)
                {
                    long value = Convert.ToInt64(temp[0]);
                    long size = Convert.ToInt64(temp[1]);
                    items.Add(new Item(value, size));
                }
                else
                {
                    KnapsackSize = Convert.ToInt32(temp[0]);
                    NumberOfItems = Convert.ToInt32(temp[1]);
                }
            }
            return items;
        }

        public long[,] KnapsakCalculation(List<Item> items)
        {
            long[,] knapsackCalculations = new long[NumberOfItems + 1, KnapsackSize + 1];

            //[i, 0] and [0, j] should be 0, we skip them
            for (int i = 1; i < knapsackCalculations.GetLength(0); i++)
            {
                for (int j = 1; j < knapsackCalculations.GetLength(1); j++)
                {
                    if (j - items[i - 1].Size >= 0)
                    {
                        knapsackCalculations[i, j] = Math.Max(
                            knapsackCalculations[i - 1, j],
                            knapsackCalculations[i - 1, j - items[i - 1].Size] + items[i - 1].Value);
                    }
                    else
                    {
                        knapsackCalculations[i, j] = knapsackCalculations[i - 1, j];
                    }
                }
            }
            return knapsackCalculations;
        }

        public List<long> Reconstruct(long[,] knapsackCalculations, List<Item> items)
        {
            List<long> result = new List<long>();
            var j = knapsackCalculations.GetLength(1) - 1;
            for (int i = knapsackCalculations.GetLength(0) - 1; i >= 0; i--)
            {
                if (knapsackCalculations[i - 1, j] == 0)
                {
                    break;
                }
                else if (knapsackCalculations[i, j] != knapsackCalculations[i - 1, j])
                {
                    result.Add(i);
                    j = (int)(j - items[i - 1].Size);
                }
                else
                {
                    j--;
                }
            }
            return result;
        }

        public class Item
        {
            public long Value { get; set; }
            public long Size { get; set; }
            public Item(long value, long size)
            {
                Value = value;
                Size = size;
            }
        }
    }
}
