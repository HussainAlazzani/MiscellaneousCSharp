using System;

namespace MyDataStructures
{
    public class BinaryTree
    {
        private BNode root;

        public int MinValue => MinTreeValue(root);
        public int MaxValue => MaxTreeValue(root);

        public void PrintLevelOrder()
        {
            BinaryTreeUtilities.PrintLevelOrder(root);
        }

        public bool Find(int value)
        {
            return Find(root, value);
        }

        // Diferent implementation from the binary search tree Find method.
        private bool Find(BNode node, int value)
        {
            if (node == null) return false;

            if (node.Value == value) return true;

            bool foundInLeft = Find(node.Left, value);
            bool foundInRight = Find(node.Right, value);
            return foundInLeft || foundInRight;
        }

        public int MinTreeValue(BNode node)
        {
            if (node == null) return int.MaxValue;

            int left = Math.Min(node.Value, MinTreeValue(node.Left));
            int right = Math.Min(node.Value, MinTreeValue(node.Right));

            return Math.Min(left, right);
        }

        public int MaxTreeValue(BNode node)
        {
            if (node == null) return int.MinValue;

            int left = Math.Max(node.Value, MaxTreeValue(node.Left));
            int right = Math.Max(node.Value, MaxTreeValue(node.Right));

            return Math.Max(left, right);
        }

        // Hard coded...
        public void BuildHeapTree()
        {
            root = new BNode(100);
            root.Left = new BNode(80);
            root.Left.Left = new BNode(60);
            root.Left.Left.Left = new BNode(40);
            root.Left.Left.Right = new BNode(50);
            root.Left.Right = new BNode(70);
            root.Left.Right.Left = new BNode(30);
            root.Left.Right.Right = new BNode(55);
            root.Right = new BNode(90);
            root.Right.Left = new BNode(75);
            root.Right.Right = new BNode(85);
            root.Right.Right.Left = new BNode(60);
            root.Right.Right.Left.Right = new BNode(40);
            root.Right.Right.Left.Left = new BNode(50);
            root.Right.Right.Right = new BNode(65);
            root.Right.Right.Right.Left = new BNode(55);
            root.Right.Right.Right.Right = new BNode(60);
        }
    }
}