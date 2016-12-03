using System;

namespace AlgorithmsI.Sorting
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] items) where T : IComparable<T>
        {
            for (int i = 0; i < items.Length; i++)
            {
                var indexOfSmallestItem = i;
                int j;

                for (j = i+1; j < items.Length; j++)
                {
                    if (items[indexOfSmallestItem].CompareTo(items[j]) > 0)
                    {
                        indexOfSmallestItem = j;    
                    }
                }

                if (i != indexOfSmallestItem)
                {
                    Swap(items, i, indexOfSmallestItem);
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
