using System;
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

        public int Count { get; private set; }
    }
}
