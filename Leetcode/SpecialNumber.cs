using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SpecialNumber
    {
        //incorrect solution, arrays are ref type and have the same values after update
        //private int countOnes;
        //private int[,] newarray;
        //public int method(int input1, int input2, int[] input3)
        //{
        //    newarray = new int[input1, input2];
        //    var days = 0;
        //    countOnes = 0;
        //    int count = 0;
        //    int previousReplaces = int.MaxValue;
        //    var array = new int[input1, input2];
        //    for (int i = 0; i < input1; i++)
        //    {
        //        for (int j = 0; j < input2; j++)
        //        {
        //            if (input3[count] == 1)
        //            {
        //                countOnes++;
        //            }
        //            array[i, j] = input3[count];
        //            count++;
        //        }
        //    }

        //    while (true)
        //    {
        //        var replaces = CalculateReplacedOnes(array);
        //        days++;
        //        if (replaces == countOnes)
        //        {
        //            break;
        //        }
        //        else if (replaces == previousReplaces)
        //        {
        //            days = -1;
        //            break;
        //        }
        //        previousReplaces = replaces;
        //        array = newarray;
        //    }
        //    return days;
        //}

        //private int CalculateReplacedOnes(int[,] array)
        //{
        //    var count = 0;
        //    for (int i = 0; i < array.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < array.GetLength(1); j++)
        //        {
        //            if (array[i, j] == 2)
        //            {
        //                if (i > 0 && array[i - 1, j] == 1)
        //                {
        //                    newarray[i - 1, j] = 2;
        //                    count++;
        //                }

        //                if (i < array.GetLength(0) - 1 && array[i + 1, j] == 1)
        //                {
        //                    newarray[i + 1, j] = 2;
        //                    count++;
        //                }

        //                if (j < array.GetLength(1) - 1 && array[i, j + 1] == 1)
        //                {
        //                    newarray[i, j + 1] = 2;
        //                    count++;
        //                }

        //                if (j > 0 && array[i, j - 1] == 1)
        //                {
        //                    newarray[i, j - 1] = 2;
        //                    count++;
        //                }
        //            }
        //            else
        //            {
        //                newarray[i, j] = array[i, j];
        //            }
        //        }
        //    }
        //    return count;
        //}

        public int method(string[] input1, int input2)
        {
            var count = 0;
            for (int i = 0; i < input1.Length; i++)
            {
                var number = int.Parse(input1[i]);
                var result = FindValue(number);
                if (result)
                    count++;
            }
            return count;
        }

        private bool FindValue(int number)
        {
            bool special = false;
            //var calcVelue = 0;
            //if (number % 2 != 0)
            //{
            //    calcVelue = number / 2 + 1;
            //}
            //else
            //{
            //    calcVelue = number / 2;
            //}


            //for (int i = 1; i <= calcVelue; i++)
            //{
            //    var remaining = number - i;
            //    if (remaining == GetReverseNumber(i))
            //    {
            //        special = true;
            //        break;
            //    }
            //}

            for (int i = 1; i < number; i++)
            {
                var remaining = number - i;
                if (remaining == GetReverseNumber(i))
                {
                    special = true;
                    break;
                }
            }
            return special;
        }
        private int GetReverseNumber(int number)
        {
            int reverseNumber = 0;
            while (number > 0)
            {
                reverseNumber = reverseNumber * 10 + number % 10;
                number = number / 10;
            }
            return reverseNumber;
        }
    }
}
