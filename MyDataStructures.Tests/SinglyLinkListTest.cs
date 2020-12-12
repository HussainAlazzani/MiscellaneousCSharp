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
        public void CreateNodeWithIntegerValue_StoreValue(int value)
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
        public void AddIntegersToEndOfList_AppendToList()
        {
            // Arrange
            var linkList = new SinglyLinkList();
            int[] values = { 0, -1, 5, 10 };

            // Act
            for (int i = 0; i < values.Length; i++)
            {
                linkList.AddToTail(values[i]);
            }

            int[] result = linkList.GetValues;

            // Assert
            Assert.Equal(values, result);
        }

        [Fact]
        public void AddIntegersToStartOfList_PrependToList()
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

            int[] result = linkList.GetValues;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetValueOfEmptyList_EmptyArray()
        {
            // Arrange
            var linkList = new SinglyLinkList();

            // Act
            int[] result = linkList.GetValues;

            // Assert
            Assert.Empty(result);
        }
    }
}