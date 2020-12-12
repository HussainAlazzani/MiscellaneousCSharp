using Xunit;
using System.Linq;

namespace MyDataStructures.Tests
{
    public class SinglyLinkListTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void CreateNodeWithIntegerValue_StoresValue(int value)
        {
            // Arrange
            SNode node;
            int expected = value;

            // Act
            node = new SNode(value);

            // Assert
            Assert.Equal(expected, node.Value);
        }

        [Fact]
        public void AddIntegersToEndOfList_AppendsToList()
        {
            // Arrange
            var linkList = new SinglyLinkList();
            int[] values = { 0, -1, 5, 10 };

            // Act
            for (int i = 0; i < values.Length; i++)
            {
                linkList.AddToTail(values[i]);
            }

            // Assert
            int[] result = linkList.GetValues;
            Assert.Equal(values, result);
        }

        [Fact]
        public void AddIntegersToStartOfList_PrependsToList()
        {
            // Arrange
            var linkList = new SinglyLinkList();
            int[] values = { 0, -1, 5, 10 };
            int[] expected = values.Reverse().ToArray();

            // Act
            for (int i = 0; i < values.Length; i++)
            {
                linkList.AddToHead(values[i]);
            }

            // Assert
            int[] result = linkList.GetValues;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetValueOfEmptyList_ReturnsEmptyArray()
        {
            // Arrange
            var linkList = new SinglyLinkList();

            // Act
            int[] result = linkList.GetValues;

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ClearLinkList_ReturnsEmptyArray()
        {
            // Arrange
            var linkList = BuildLinkListFrom0To9();
            // Act
            linkList.Clear();

            // Assert
            int[] result = linkList.GetValues;
            Assert.Empty(result);
        }

        [Theory]
        [InlineData(0)]         // First element
        [InlineData(4)]         // Middle element
        [InlineData(9)]         // Last element
        public void FindIntegerThatExistsInLinkList_ReturnTrue(int value)
        {
            // Arrange
            var linkList = BuildLinkListFrom0To9();
            
            // Act
            bool result = linkList.Find(value);
            
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(20)]            // Non-existent element
        [InlineData(int.MinValue)]  // Edge case
        [InlineData(int.MaxValue)]  // Edge case
        public void FindIntegerThatDoesNotExistInLinkList_ReturnsFalse(int value)
        {
            // Arrange
            var linkList = BuildLinkListFrom0To9();

            // Act
            bool result = linkList.Find(value);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(0)]             // First element
        [InlineData(4)]             // Middle element
        [InlineData(9)]             // Last element
        public void RemoveElementFromLinkList_ElementAreRemoved(int removedValue)
        {
            // Arrange
            var linkList = BuildLinkListFrom0To9();
            
            // Act
            linkList.Remove(removedValue);
            
            // Assert
            int[] updatedLinkList = linkList.GetValues;
            Assert.DoesNotContain<int>(removedValue, updatedLinkList);
        }

        [Fact]
        public void ReverseLinkList_LinkListReversed()
        {
            // Arrange
            var linkList = BuildLinkListFrom0To9();
            int[] expected = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            // Act
            linkList.Reverse();

            // Assert
            int[] valuesReversed = linkList.GetValues;
            Assert.Equal<int>(expected, valuesReversed);
        }

        private SinglyLinkList BuildLinkListFrom0To9()
        {
            var linkList = new SinglyLinkList();
            for (int i = 0; i < 10; i++)
                linkList.AddToTail(i);

            return linkList;
        }
    }
}