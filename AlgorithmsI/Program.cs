using System;
using AlgorithmsI.Sorting;


namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] {1, 3, 4, 54, 2, 12, 32, 231, 534, 121, 23, 54, 12, 53};

            MergeSort.Sort(items);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
