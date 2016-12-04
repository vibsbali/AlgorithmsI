using System;
using AlgorithmsI.Sorting;


namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] {1, 3, 4, 54, 53};

            QuickSort<int>.Sort(items);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
