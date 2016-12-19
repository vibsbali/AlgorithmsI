using System;
using System.Linq;

namespace AlgorithmsI.Sorting
{
    public class QuickSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] items)
        {
            //Shuffle(ref items);
            PartionAndSort(items, 0, items.Length - 1);
        }

        private static void PartionAndSort(T[] items, int pivot, int hi)
        {
            //base case
            if (pivot >= hi)
            {
                return;
            }

            var i = pivot + 1;
            var j = hi;
            while (true)
            {
                while (items[i].CompareTo(items[pivot]) <= 0 && i < j)
                {
                    i++;
                }

                while (items[j].CompareTo(items[pivot]) > 0 && j >= i - 1)
                {
                    j--;
                }

                //We only exchange if the pointers has not crossed over
                if (j > i)
                {
                    Exchange(items, i, j);
                }
                else
                {
                    break;
                }
            }

            Exchange(items, pivot, j);
            PartionAndSort(items, pivot, j - 1);
            PartionAndSort(items, j + 1, hi);
        }

        private static void Exchange(T[] items, int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        private static void Shuffle(ref T[] items)
        {
            Random rand = new Random();
            var result = items.OrderBy(i => rand.Next());
            items = result.ToArray();
        }
    }
}
