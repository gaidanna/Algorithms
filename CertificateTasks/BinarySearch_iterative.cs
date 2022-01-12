namespace CertificateTasks
{
    public class BinarySearch_iterative
    {
        public int Search(int[] sortedArray, int searchedValue)
        {
            int startIndex = 0;
            int lastIndex = sortedArray.Length - 1;
            while (lastIndex >= startIndex)
            {
                int midIndex = startIndex + (lastIndex - startIndex) / 2;
                if (searchedValue == sortedArray[midIndex])
                {
                    return midIndex;
                }
                else if (searchedValue > sortedArray[midIndex])
                {
                    startIndex = midIndex + 1;
                }
                else
                {
                    lastIndex = midIndex - 1;
                }
            }
            return -1;
        }
    }
}
