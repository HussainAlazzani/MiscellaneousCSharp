using System;
using System.Collections.Generic;

namespace MyDataStructures
{
    /// <summary>
    /// This class contains utility methods that can be called by all types of binary trees.
    /// </summary>
    static class BinaryTreeUtilities
    {
        public static void PrintLevelOrder(BNode node)
        {
            if (node == null) return;

            var q = new Queue<BNode>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                node = q.Dequeue();
                System.Console.WriteLine(node.Value);
                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }

        public static int Count(BNode node)
        {
            if (node == null) return 0;

            int leftCount = Count(node.Left);
            int rightCount = Count(node.Right);

            return leftCount + rightCount + 1;
        }

        public static int Height(BNode node)
        {
            if (node == null) return 0;

            int leftHeight = Height(node.Left);
            int rightHeight = Height(node.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static bool IsBinarySearchTree(BNode root)
        {
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }

        private static bool IsBinarySearchTree(BNode node, int min, int max)
        {
            if (node == null) return true;

            else if (node.Value < max && node.Value >= min &&
             IsBinarySearchTree(node.Left, min, node.Value) &&
             IsBinarySearchTree(node.Right, node.Value, max))
            {
                return true;
            }

            else
                return false;
        }

        
    }
}
