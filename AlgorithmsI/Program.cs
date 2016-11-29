using System;
using AlgorithmsI.StacksAndQueues;


namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new DequeWithArray<int>();

            Console.WriteLine("Inserting 0 to 3");
            for (int i = 0; i < 4; i++)
            {
                queue.EnqueueLast(i);
            }

            Console.WriteLine("Printing 0 to 1");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine("Inserting 4 to 7");
            for (int i = 4; i < 8; i++)
            {
                queue.EnqueueLast(i);
            }

            Console.WriteLine("Printing complete queue");
            var currentCount = queue.Count;
            for (int i = 0; i < currentCount; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine("Inserting 0 to 16");
            for (int i = 0; i < 16; i++)
            {
                queue.EnqueueLast(i);
            }


            Console.WriteLine($"Current count is {queue.Count}");

            
        }
    }
}
