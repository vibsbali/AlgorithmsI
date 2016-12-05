using System;
using AlgorithmsI.Sorting;


namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] {'z', 'k', 'a', 'c', 'd', 'f', 'k', 'z'};

            QuickSort<char>.Sort(items);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
