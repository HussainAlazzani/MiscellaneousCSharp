using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyDataStructures
{
    public class BinarySearchTree : IEnumerable<int>
    {
        private BNode root;

        public int[] GetValues => this.ToArray<int>();
        public int MinValue => this.GetMinValue(root);
        public int MaxValue => this.GetMaxValue(root);
        public int Count => BinaryTreeUtilities.Count(root);
        public int Height => BinaryTreeUtilities.Height(root);
        public bool isBinaryTree => BinaryTreeUtilities.IsBinarySearchTree(root);

        public IEnumerator<int> GetEnumerator()
        {
            if (root == null)
            {
                Enumerable.Empty<int>();
            }
            else
            {
                List<int> values = new List<int>();
                BinaryTreeUtilities.GetAllValues(root, values);
                foreach (var item in values)
                {
                    yield return item;

                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

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
                    node.Value = GetMaxValue(node.Left);
                    node.Left = Remove(node.Left, node.Value);
                }
            }

            return node;
        }

        /// <summary>
        /// This is an iterative implementation that is specific to a binary search tree.
        /// </summary>
        public int GetMinValue(BNode node)
        {
            if (node == null) return int.MaxValue;

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Value;
        }

        /// <summary>
        /// This is an iterative implementation that is specific to a binary search tree.
        /// </summary>
        public int GetMaxValue(BNode node)
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