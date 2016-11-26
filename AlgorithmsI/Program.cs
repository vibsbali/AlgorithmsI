using System;
using AlgorithmsI.LinkedLists;

namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList<int>();

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(linkedList.Remove(1));
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            foreach (var node in linkedList)
            {
                Console.WriteLine(node);
            }
           // Console.WriteLine(linkedList.Remove(1));
            foreach (var node in linkedList)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine(linkedList.Remove(2));
            Console.WriteLine(linkedList.Remove(3));
            Console.WriteLine(linkedList.Count);
            foreach (var node in linkedList)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine(linkedList.Remove(1));
            foreach (var node in linkedList)
            {
                Console.WriteLine(node);
            }

            linkedList.AddFirst(2);
            linkedList.AddFirst(1);
            foreach (var node in linkedList)
            {
                Console.WriteLine(node);
            }
        }
    }
}
