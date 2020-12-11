using System;

namespace Miscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree();
            binaryTree.BuildHeapTree();
            binaryTree.PrintLevelOrder();
            System.Console.WriteLine("Min: " + binaryTree.MinValue);
            System.Console.WriteLine("Max: " + binaryTree.MaxValue);
        }
    }
}
