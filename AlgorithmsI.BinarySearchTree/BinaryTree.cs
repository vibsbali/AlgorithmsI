using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace AlgorithmsI.BinarySearchTree
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;
        public int Count { get; private set; }

        public void Add(T value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddUsingLoop(root, value);
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

        private void AddUsingLoop(BinaryTreeNode<T> parent, T value)
        {
            while (true)
            {
                if (parent.CompareTo(value) <= 0)
                {
                    if (parent.RightNode == null)
                    {
                        parent.RightNode = new BinaryTreeNode<T>(value);
                        break;
                    }
                    //else
                    parent = parent.RightNode;
                }
                else
                {
                    if (parent.LeftNode == null)
                    {
                        parent.LeftNode = new BinaryTreeNode<T>(value);
                        break;
                    }
                    
                    //else
                    parent = parent.LeftNode;
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
        public void PrintPreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, root);
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> binaryTreeNode)
        {
            if (binaryTreeNode != null)
            {
                action(binaryTreeNode.Value);
                PreOrderTraversal(action, binaryTreeNode.LeftNode);
                PreOrderTraversal(action, binaryTreeNode.RightNode);
            }
        }

        public void Remove(T value)
        {
            BinaryTreeNode<T> parentNode;
            var nodeFound = FindWithParent(out parentNode, value);
            if (nodeFound != null)
            {
                //We have four options
                //1. The node is a tail node
                if (nodeFound.LeftNode == null && nodeFound.RightNode == null)
                {
                    if (CheckIfLeft(nodeFound, parentNode))
                    {
                        parentNode.LeftNode = null;
                    }
                    else
                    {
                        parentNode.RightNode = null;
                    }
                }

                //2. Node to remove doesn't have any right child
                else if (nodeFound.RightNode == null)
                {
                    if (CheckIfLeft(nodeFound, parentNode))
                    {
                        parentNode.LeftNode = nodeFound.LeftNode;
                    }
                    else
                    {
                        parentNode.RightNode = nodeFound.LeftNode;
                    }
                }

                //3. Node to remove does have a right child which inturn doesn't have any left child
                else if (nodeFound.RightNode != null)
                {
                    if (nodeFound.RightNode.LeftNode == null)
                    {
                        if (CheckIfLeft(nodeFound, parentNode))
                        {
                            parentNode.LeftNode = nodeFound.RightNode;
                        }
                        else
                        {
                            parentNode.RightNode = nodeFound.RightNode;
                        }
                    }
                    //4. Node found has a right child which in turn has a left child -- find the left most child and replace
                    else
                    {
                        var parent = nodeFound.RightNode;
                        var leftMostNode = nodeFound.RightNode.LeftNode;
                        while (leftMostNode.LeftNode != null)
                        {
                            parent = leftMostNode;
                            leftMostNode = leftMostNode.LeftNode;
                        }

                        if (CheckIfLeft(nodeFound, parentNode))
                        {
                            parentNode.LeftNode = leftMostNode;
                        }
                        else
                        {
                            parent.RightNode = leftMostNode;
                        }
                        leftMostNode.LeftNode = nodeFound.LeftNode;
                        leftMostNode.RightNode = nodeFound.RightNode;
                        parent.LeftNode = null;
                    }
                }

                Count--;
            }
        }

        private bool CheckIfLeft(BinaryTreeNode<T> nodeFound, BinaryTreeNode<T> parentNode)
        {
            return nodeFound.CompareTo(parentNode.Value) < 0;
        }


        public bool Find(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(out parent, value) != null;
        }

        private BinaryTreeNode<T> FindWithParent(out BinaryTreeNode<T> parent, T value)
        {
            BinaryTreeNode<T> current = root;
            parent = null;

            while (current != null)
            {
                if (current.CompareTo(value) == 0)
                {
                    return current;
                }

                if (current.CompareTo(value) > 0)
                {
                    parent = current;
                    current = current.LeftNode;
                }

                if (current.CompareTo(value) < 0)
                {
                    parent = current;
                    current = current.RightNode;
                }
            }

            return null;
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
            //The way to do this is with a stack look at the book
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
