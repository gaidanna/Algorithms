namespace CertificateTasks
{
    public class BinarySearch_recursive
    {
        public int Search(int[] sortedArray, int startIndex, int lastIndex, int searchedValue)
        {
            if (lastIndex >= startIndex)
            {
                var midIndex = startIndex + (lastIndex - startIndex) / 2;

                if (searchedValue == sortedArray[midIndex])
                {
                    return midIndex;
                }
                if (searchedValue < sortedArray[midIndex])
                {
                    return Search(sortedArray, startIndex, midIndex - 1, searchedValue);
                }
                else
                {
                    return Search(sortedArray, midIndex + 1, lastIndex, searchedValue);
                }
            }
            return -1;
        }
    }
}
