using System;
using System.Collections.Generic;

namespace Miscellaneous
{
    public class BinarySearchTree
    {
        private BNode root;

        public int Count => BinaryTreeUtilities.Count(root);
        public int Height => BinaryTreeUtilities.Height(root);
        public bool isBinaryTree => BinaryTreeUtilities.IsBinarySearchTree(root);

        public void Add(int value)
        {
            root = Add(root, value);
        }

        private BNode Add(BNode node, int value)
        {
            if (node == null)
                node = new BNode(value);

            else if (value < node.Value)
                node.Left = Add(node.Left, value);

            else
                node.Right = Add(node.Right, value);

            return node;
        }

        public void PrintInOrder()
        {
            PrintInOrder(root);
        }

        private void PrintInOrder(BNode node)
        {
            if (node == null) return;

            PrintInOrder(node.Left);
            System.Console.WriteLine(node.Value);
            PrintInOrder(node.Right);
        }

        public void PrintLevelOrder()
        {
            BinaryTreeUtilities.PrintLevelOrder(root);
        }

        public bool Find(int value)
        {
            return Find(root, value);
        }

        private bool Find(BNode node, int value)
        {
            if (node == null) return false;

            if (node.Value == value) return true;

            if (value < node.Value)
                return Find(node.Left, value);
            else
                return Find(node.Right, value);
        }

        public void Remove(int value)
        {
            root = Remove(root, value);
        }

        private BNode Remove(BNode node, int value)
        {
            if (node == null) return null;

            if (value < node.Value)
                node.Left = Remove(node.Left, value);
            else if (value > node.Value)
                node.Right = Remove(node.Right, value);
            else
            {
                // If the element has no children
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }
                // if the element has only one child on the left
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                // if the element has only one child on the right
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                // if the element has two children
                else
                {
                    node.Value = MaxValue(node.Left);
                    node.Left = Remove(node.Left, node.Value);
                }
            }

            return node;
        }

        public int MinValue(BNode node)
        {
            if (node == null) return int.MaxValue;

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Value;
        }

        public int MaxValue(BNode node)
        {
            if (node == null) return int.MinValue;

            while (node.Right != null)
            {
                node = node.Right;
            }
            return node.Value;
        }
    }
}