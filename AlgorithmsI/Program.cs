using System;
using AlgorithmsI.BinarySearchTree;


namespace AlgorithmsI
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinaryTree<int>();

           bst.Add(4);
            bst.Add(2);
            bst.Add(5);
            bst.Add(1);
            bst.Add(3);
            bst.Add(7);
            bst.Add(6);
            bst.Add(8);



            bst.PrintPreOrderTraversal();

            Console.WriteLine($"Number of nodes = {bst.Count}");

        }
    }
}
