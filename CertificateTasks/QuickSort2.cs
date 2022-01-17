/*Task
 GENERAL DIRECTIONS:
Download the following text file (right click and select "Save As..."): QuickSort.txt
The file contains all of the integers between 1 and 10,000 (inclusive, with no repeats) in unsorted order. The integer in the  row of the file gives you the  entry of an input array.
Your task is to compute the total number of comparisons used to sort the given input file by QuickSort. As you know, the number of comparisons depends on which elements are chosen as pivots, so we'll ask you to explore three different pivoting rules.
You should not count comparisons one-by-one. Rather, when there is a recursive call on a subarray of length , you should simply add  to your running total of comparisons. (This is because the pivot element is compared to each of the other  elements in the subarray in this recursive call.)
WARNING: The Partition subroutine can be implemented in several different ways, and different implementations can give you differing numbers of comparisons. For this problem, you should implement the Partition subroutine exactly as it is described in the video lectures (otherwise you might get the wrong answer).

Programming Assignment 2 - Question 1
DIRECTIONS FOR THIS PROBLEM:
For the first part of the programming assignment, you should always use the first element of the array as the pivot element.
HOW TO GIVE US YOUR ANSWER:
Type the numeric answer in the space provided.
So if your answer is 1198233847, then just type 1198233847 in the space provided without any space, commas, or other punctuation marks. You have 5 attempts to get the correct answer.
Answer - 162086

Programming Assignment 2 - Question 2
GENERAL DIRECTIONS AND HOW TO GIVE US YOUR ANSWER:
See the first question.
DIRECTIONS FOR THIS PROBLEM:
Compute the number of comparisons (as in Problem 1), always using the final element of the given array as the pivot element. Again, be sure to implement the Partition subroutine exactly as it is described in the video lectures.

Recall from the lectures that, just before the main Partition subroutine, you should exchange the pivot element (i.e., the last element) with the first element.
Answer - 164124

Programming Assignment 2 - Question 3
GENERAL DIRECTIONS AND HOW TO GIVE US YOUR ANSWER:

See the first question.

DIRECTIONS FOR THIS PROBLEM:

Compute the number of comparisons (as in Problem 1), using the "median-of-three" pivot rule. [The primary motivation behind this rule is to do a little bit of extra work to get much better performance on input arrays that are nearly sorted or reverse sorted.] 
In more detail, you should choose the pivot as follows. Consider the first, middle, and final elements of the given array. (If the array has odd length it should be clear what the "middle" element is; for an array with even length 2k (k - степень), 
use the k-th  element as the "middle" element. So for the array 4 5 6 7, the "middle" element is the second one ---- 5 and not 6!) Identify which of these three elements is the median (i.e., the one whose value is in between the other two), 
and use this as your pivot. As discussed in the first and second parts of this programming assignment, be sure to implement Partition exactly as described in the video lectures (including exchanging the pivot element with the first element 
just before the main Partition subroutine).

EXAMPLE: For the input array 8 2 4 5 7 1 you would consider the first (8), middle (4), and last (1) elements; since 4 is the median of the set {1,4,8}, you would use 4 as your pivot element.
SUBTLE POINT: A careful analysis would keep track of the comparisons made in identifying the median of the three candidate elements. You should NOT do this. That is, as in the previous two problems, you should simply add m-1 to your running total of comparisons every time you recurse on a subarray with length m.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CertificateTasks
{
    public class QuickSort2
    {
        public int NumberOfCalls;
        public QuickSort2()
        {
            NumberOfCalls = 0;
        }
        public void QuickSort(int[] elements, int pivotIndex, int startIndex, int lastIndex)
        {
            int i = startIndex + 1;
            int j = startIndex + 1;
            if (startIndex >= lastIndex)
            {
                NumberOfCalls++;
                return;
            }
            NumberOfCalls += lastIndex - startIndex - 1;
            if (lastIndex - startIndex > 1)
            {
                pivotIndex = GetPivotIndex(elements, startIndex, lastIndex);
            }
            
            var pivot = elements[pivotIndex];
            if (pivotIndex != startIndex)
            {
                var tempValue = elements[startIndex];
                elements[startIndex] = pivot;
                elements[pivotIndex] = tempValue;
            }

            for (int a = startIndex; a <= lastIndex; a++)
            {
                if (elements[a] < pivot)
                {
                    if (i != j)
                    {
                        var tempValue = elements[i];
                        elements[i] = elements[a];
                        elements[a] = tempValue;
                    }
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }

            //was used pivotindex instead of startindex
            var temp = elements[i - 1];
            elements[i - 1] = elements[startIndex];
            elements[startIndex] = temp;

            QuickSort(elements, startIndex, startIndex, i - 2);
            QuickSort(elements, i, i, lastIndex);
        }

        private int GetPivotIndex(int[] elements, int startIndex, int lastIndex)
        {
            var temp = lastIndex - startIndex + 1;
            var startElement = elements[startIndex];
            var lastElement = elements[lastIndex];

            var midIndex = lastIndex - temp / 2;
            var midElement = elements[midIndex];
            SortedDictionary<int, int> tempElements = new SortedDictionary<int, int>();
            tempElements.Add(startElement, startIndex);
            tempElements.Add(midElement, midIndex);
            tempElements.Add(lastElement, lastIndex);

            return tempElements.ElementAt(1).Value;
        }

        public int[] ReadInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\QuickSort.txt");
            var list = File.ReadAllLines(path).ToList();
            var numberOfQueries = Convert.ToInt32(list.Count);
            int[] convertedParams = new int[numberOfQueries];
            for (int i = 0; i < numberOfQueries; i++)
            {
                convertedParams[i] = Convert.ToInt32(list[i]);
            }
            return convertedParams;
        }
    }
}