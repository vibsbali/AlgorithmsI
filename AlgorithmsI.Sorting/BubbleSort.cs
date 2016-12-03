using System;

namespace AlgorithmsI.Sorting
{
    public class BubbleSort
    {
        public static void Sort<T>(T[] items) where T : IComparable<T>
        {
            var hasSwappedPerformed = true;
            while (hasSwappedPerformed)
            {
                hasSwappedPerformed = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i-1].CompareTo(items[i]) > 0)
                    {
                        Swap(items, i - 1, i);
                        hasSwappedPerformed = true;
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
