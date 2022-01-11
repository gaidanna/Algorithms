/* Download the text file here. (Right click and select "Save As...")
This file contains all of the 100,000 integers between 1 and 100,000 (inclusive) in some order, with no integer repeated.
Your task is to compute the number of inversions in the file given, where the i-th row of the file indicates the i-th entry of an array.
Because of the large size of this array, you should implement the fast divide-and-conquer algorithm covered in the video lectures.
The numeric answer for the given input file should be typed in the space below.
So if your answer is 1198233847, then just type 1198233847 in the space provided without any spaces or commas or any other punctuation marks. You can make up to 5 attempts.
(We do not require you to submit your code, so feel free to use any programming language you want --- just type the final numeric answer in the following space.)
[TIP: before submitting, first test the correctness of your program on some small test files or your own devising. Then post your best test cases to the discussion forums to help your fellow students!] */

using System;
using System.IO;
using System.Linq;

namespace CertificateTasks
{
    public class Inversion
    {
        public long InversionCount;
        public Inversion()
        {
            InversionCount = 0;
        }

        public int[] ReadInput()
        {
            
            var list = File.ReadAllLines(@"C:\Users\Ganna Gaidabas\Desktop\inv.txt").ToList();
            var numberOfQueries = Convert.ToInt32(list.Count);
            int[] convertedParams = new int[numberOfQueries];
            for (int i = 0; i < numberOfQueries; i++)
            {
                convertedParams[i] = Convert.ToInt32(list[i]);
            }
            return convertedParams;
            //var arrayCount = Convert.ToInt32(Console.ReadLine());
            //int[] inputValues = new int[arrayCount];
            //var r = Console.ReadLine().Split(' ');
            //for (int i = 0; i < r.Length; i++)
            //{
            //    inputValues[i] = Convert.ToInt32(r[i]);
            //}
            //return inputValues;
        }

        public int[] SortAndCount(int[] unorderedValues)
        {
            if (unorderedValues.Length <= 1)
            {
                return unorderedValues;
            }

            int[] leftValues = new int[unorderedValues.Length / 2];
            int[] rightValues = new int[unorderedValues.Length - leftValues.Length];

            for (int i = 0; i < leftValues.Length; i++)
            {
                leftValues[i] = unorderedValues[i];
            }
            for (int j = 0; j < rightValues.Length; j++)
            {
                rightValues[j] = unorderedValues[unorderedValues.Length / 2 + j];
            }
            
            var leftSortedValues = SortAndCount(leftValues);
            var rightSortedInversion = SortAndCount(rightValues);
            var splitInversion = MergeAndCount(unorderedValues, leftSortedValues, rightSortedInversion);

            return splitInversion;
        }

        // for calc split inversion
        private int[] MergeAndCount(int[] unorderedValues, int[] leftSortedValues, int[] rightSortedValues)
        {
            int[] orderedValues = new int[unorderedValues.Length]; 
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < leftSortedValues.Length && j < rightSortedValues.Length)
            {
                if (rightSortedValues[j] < leftSortedValues[i])
                {
                    orderedValues[k] = rightSortedValues[j];
                    InversionCount += leftSortedValues.Length - i;
                    j++;
                }
                else
                {
                    orderedValues[k] = leftSortedValues[i];
                    i++;
                }
                k++;
            }

            while (i < leftSortedValues.Length)
            {
                orderedValues[k] = leftSortedValues[i];
                i++;
                k++;
            }

            while (j < rightSortedValues.Length)
            {
                orderedValues[k] = rightSortedValues[j];
                j++;
                k++;
            }
            return orderedValues;
        }
    }
}
