using Xunit;

namespace MyDataStructures.Tests
{
    public class BinarySearchTreeTest
    {
        [Fact]
        public void GetAllElementValuesFromBinarySearchTree_ReturnsOrderedArray()
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();
            int[] expected = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 , 12};

            // Act
            int[] result = bsTree.GetValues;

            // Assert
            Assert.Equal<int>(expected, result);
        }

        [Fact]
        public void IsItABinarySearchTree_ReturnsTrue()
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();

            // Act
            bool result = bsTree.isBinaryTree;

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(5)]     // Root node
        [InlineData(0)]     // Left-most leaf
        [InlineData(12)]    // Right-most leaf
        [InlineData(7)]     // Middle node
        public void FindIntegerValueThatExists_ReturnsTrue(int value)
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();

            // Act
            bool result = bsTree.Find(value);
            
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(17)]                // Non-existent element
        [InlineData(int.MaxValue)]      // Edge case
        [InlineData(int.MinValue)]      // Edge case
        public void FindIntegerValueThatDoesNotExist_ReturnsFalse(int value)
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();
            
            // Act
            bool result = bsTree.Find(value);
            
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(5)]     // Root node
        [InlineData(0)]     // Left-most leaf
        [InlineData(12)]    // Right-most leaf
        [InlineData(4)]     // Node with one left child
        [InlineData(10)]    // Node with one right child
        [InlineData(7)]     // Node with two children
        public void RemoveElementBasedOnIntegerValue_ElementRemoved(int value)
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();

            // Act
            bsTree.Remove(value);

            // Assert
            bool result = bsTree.Find(value);
            Assert.False(result);
        }

        [Fact]
        public void GetMinimumInteger_ReturnsMinimumInteger()
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();
            int expected = 0;

            // Act
            int result = bsTree.MinValue;
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetMaximumInteger_ReturnsMaximumInteger()
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();
            int expected = 12;

            // Act
            int result = bsTree.MaxValue;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountNumberOfNodes_ReturnsTotalNodes()
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();
            int expected = 12;

            // Act
            int result = bsTree.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindTheHeightOfTheTree_ReturnsTreeHeight()
        {
            // Arrange
            var bsTree = BuildBinarySearchTree();
            int expected = 5;

            // Act
            int result = bsTree.Height;

            // Assert
            Assert.Equal(expected, result);
        }


        // Hard coded binary search tree model to test against
        private BinarySearchTree BuildBinarySearchTree()
        {
            var bsTree = new BinarySearchTree();
            int[] values = { 5, 2, 7, 1, 4, 0, 3, 6, 9, 8, 10, 12 };
            for (int i = 0; i < values.Length; i++)
            {
                bsTree.Add(values[i]);
            }

            return bsTree;
        }
    }
}