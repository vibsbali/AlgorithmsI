using System;
using AlgorithmsI.BinarySearchTree;


namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinaryTree<int>();

            bst.Add(8);
            bst.Add(5);
            bst.Add(10);
            bst.Add(2);
            bst.Add(6);
            bst.Add(7);

            bst.Remove(5);

            bst.PrintInOrderTraversal();

            Console.WriteLine($"Number of nodes = {bst.Count}");

        }
    }
}
