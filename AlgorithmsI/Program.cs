using System;
using AlgorithmI.MaxPriorityQueue;
using AlgorithmsI.BinarySearchTree;
using AlgorithmsI.Sorting;


namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] {1, 3, 4, 54, 2, 12, 32, 231, 534, 121, 23, 54, 12, 53};

            var mpq = new MaxPriorityQ<int>(10);

            for (int i = 0; i < 10; i++)
            {
                mpq.Add(items[i]);
            }

            while (mpq.Count > 0)
            {
                Console.WriteLine(mpq.RemoveMax());
            }
        }
    }
}
