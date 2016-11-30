using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace AlgorithmsI.BinarySearchTree
{
    public class BinaryTree<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;

        public void Add(T value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddRecursively(root, value);
            }
            Count++;
        }

        private void AddRecursively(BinaryTreeNode<T> parent, T value)
        {
            //If current is 
            if (parent.CompareTo(value) <= 0)
            {
                if (parent.RightNode == null)
                {
                    parent.RightNode = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddRecursively(parent.RightNode, value);
                }
            }
            else
            {
                if (parent.LeftNode == null)
                {
                    parent.LeftNode = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddRecursively(parent.LeftNode, value);
                }
            }
        }

        //LRP
        public void PrintPostOrderTraversal()
        {
            PostOrderTraversal(root);
        }

        private void PostOrderTraversal(BinaryTreeNode<T> binaryTreeNode)
        {
            if (binaryTreeNode != null)
            {
                PostOrderTraversal(binaryTreeNode.LeftNode);
                PostOrderTraversal(binaryTreeNode.RightNode);
                Console.WriteLine(binaryTreeNode.Value);
            }
        }

        //LPR
        public void PrintInOrderTraversal()
        {
            InOrderTraversal(root);
        }

        private void InOrderTraversal(BinaryTreeNode<T> binaryTreeNode)
        {
            if (binaryTreeNode != null)
            {
                InOrderTraversal(binaryTreeNode.LeftNode);
                Console.WriteLine(binaryTreeNode.Value);
                InOrderTraversal(binaryTreeNode.RightNode);
            }
        }

        //PLR
        public void PrintPreOrderTraversal()
        {
            PreOrderTraversal(root);
        }

        private void PreOrderTraversal(BinaryTreeNode<T> binaryTreeNode)
        {
            if (binaryTreeNode != null)
            {
                Console.WriteLine(binaryTreeNode.Value);
                PreOrderTraversal(binaryTreeNode.LeftNode);
                PreOrderTraversal(binaryTreeNode.RightNode);
            }
        }

        public int Count { get; private set; }
    }
}
