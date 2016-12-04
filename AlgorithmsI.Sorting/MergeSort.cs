using System;

namespace AlgorithmsI.Sorting
{
    public class MergeSort
    {
        public static void Sort<T>(T[] items) where T : IComparable<T>
        {
            BreakIntoTwoHalves(items);
        }

        //This method breaks the original array into smaller pieces.
        private static void BreakIntoTwoHalves<T>(T[] items) where T : IComparable<T>
        {
            //This is the base case that causes recursion to end
            if (items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;
            T[] left = new T[leftSize];
            T[] right = new T[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            BreakIntoTwoHalves(left);
            BreakIntoTwoHalves(right);

            //The reference to items array doesn't change! No where we say items = new Items
            SortAndMergeTwoArrays(items, left, right);
        }


        //The whole idea is that given two arrays can we merge two arrays into one big array that is sorted
        private static void SortAndMergeTwoArrays<T>(T[] items, T[] firstHalf, T[] secondHalf) where T : IComparable<T>
        {
            int i = 0, k = 0, j = 0;

            while (i < firstHalf.Length && j < secondHalf.Length)
            {
                if (firstHalf[i].CompareTo(secondHalf[j]) <= 0)
                {
                    items[k] = firstHalf[i];
                    i++;
                    k++;
                }
                else
                {
                    items[k] = secondHalf[j];
                    j++;
                    k++;
                }
            }

            while (i < firstHalf.Length)
            {
                items[k] = firstHalf[i];
                i++;
                k++;
            }
            while (j < secondHalf.Length)
            {
                items[k] = secondHalf[j];
                j++;
                k++;
            }
        }
    }
}
