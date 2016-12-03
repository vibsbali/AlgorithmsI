using System;

namespace AlgorithmsI.Sorting
{
    public class InsertionSort
    {
        public static void Sort<T>(T[] items) where T : IComparable<T>
        {
            for (int i = 1; i < items.Length; i++)
            {
                var elementToCompareAgainst = i-1;
                for (int j = i; j > 0; j--, elementToCompareAgainst--)
                {
                    if (items[elementToCompareAgainst].CompareTo(items[j]) > 0)
                    {
                        Swap(items, elementToCompareAgainst, j);
                        //elementToCompareAgainst--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void Swap<T>(T[] items, int leftIndex, int rightIndex)
        {
            var temp = items[leftIndex];
            items[leftIndex] = items[rightIndex];
            items[rightIndex] = temp;
        }
    }
}
