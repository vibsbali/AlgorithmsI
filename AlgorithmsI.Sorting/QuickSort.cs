using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Sorting
{
    public class QuickSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] items) 
        {
            Shuffle(ref items);
            Partion(items, 0, 1, items.Length - 1);
        }

        private static void Partion(T[] items, int lo, int i, int j)
        {
            if (i >= j)
            {
                return;
            }

            while (i < j)
            {
                while (items[lo].CompareTo(items[i]) >= 0 && i <= j)
                {
                    i++;
                }

                while (items[lo].CompareTo(items[j]) < 0 && j >= i)
                {
                    j--;
                }

                Exchange(items, i, j);
            }

            Exchange(items, lo, j);

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
