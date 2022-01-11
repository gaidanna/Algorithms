using System;

namespace CertificateTasks
{
    public class MergeSort
    {
        public int[] Sort(int[] unorderedValues)
        {
            int[] leftValues = new int[unorderedValues.Length / 2];
            int[] rightValues = new int[unorderedValues.Length - unorderedValues.Length / 2];

            for (int i = 0; i < unorderedValues.Length / 2; i++)
            {
                leftValues[i] = unorderedValues[i];
            }
            for (int j = 0; j < unorderedValues.Length - unorderedValues.Length / 2; j++)
            {
                rightValues[j] = unorderedValues[unorderedValues.Length / 2 + j];
            }

            if (unorderedValues.Length <= 1)
            {
                return unorderedValues;
            }
            var orderedLeftVal = Sort(leftValues);
            var orderedRightVal = Sort(rightValues);
            var sortedVal = Merge(unorderedValues, orderedLeftVal, orderedRightVal);
            return sortedVal;
        }

        private int[] Merge(int[] unorderedValues, int[] leftValues, int[] rightValues)
        {
            var orderedValues = new int[unorderedValues.Length];
            var i = 0;
            var j = 0;
            var k = 0;

            while (i < leftValues.Length && j < rightValues.Length)
            {
                if (leftValues[i] < rightValues[j])
                {
                    orderedValues[k] = leftValues[i];
                    i++;
                }
                else
                {
                    orderedValues[k] = rightValues[j];
                    j++;
                }
                k++;
            }

            while (i < leftValues.Length)
            {
                orderedValues[k] = leftValues[i];
                i++;
                k++;
            }

            while (j < rightValues.Length)
            {
                orderedValues[k] = rightValues[j];
                j++;
                k++;
            }
            return orderedValues;
        }

        public int[] ReadInput()
        {
            var arrayCount = Convert.ToInt32(Console.ReadLine());
            int[] inputValues = new int[arrayCount];
            for (int i = 0; i < arrayCount; i++)
            {
                inputValues[i] = Convert.ToInt32(Console.ReadLine());
            }
            return inputValues;
        }
    }
}
