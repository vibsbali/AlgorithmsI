using System;

using AlgorithmsI.ArrayList;

namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayList = new ArrayList<int>(4);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < 10; i++)
            {
                arrayList.Add(i);
            }

            Console.WriteLine(arrayList.Count);
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            arrayList.RemoveAt(5);
            Console.WriteLine(arrayList.Count);
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            arrayList.Insert(5, 5);
            Console.WriteLine(arrayList.Count);
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(arrayList[4]);
        }
    }
}
