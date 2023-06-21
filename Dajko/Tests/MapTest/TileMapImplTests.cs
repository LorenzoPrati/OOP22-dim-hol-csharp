using NUnit.Framework;
using System.Collections.Generic;
using Map;

namespace MapTest
{
    [TestFixture]
    public class TileMapTests
    {
        private TileMapImpl tileMap;

        [SetUp]
        public void Setup()
        {
            // Create a sample tile map for testing
            List<ITile[,]> layers = new List<ITile[,]>();
            ITile[,] tiles = new ITile[3, 3]; // Create a 3x3 tile map
            // Populate the tiles with some sample values
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    tiles[x, y] = new TileImpl(2, true);
                }
            }
            layers.Add(tiles); // Add the tile map to the layers list

            // Create the TileMapImpl instance for testing
            tileMap = new TileMapImpl(layers, 3, 3, 32, 32);
        }

        [Test]
        public void GetTile_ValidCoordinates_ReturnsTile()
        {
            // Arrange
            int x = 1;
            int y = 2;

            // Act
            ITile tile = tileMap.GetTile(x, y);

            // Assert
            Assert.IsNotNull(tile);
        }

        [Test]
        public void IsValidCoordinate_ValidCoordinates_ReturnsTrue()
        {
            // Arrange
            int x = 2;
            int y = 1;

            // Act
            bool isValid = tileMap.IsValidCoordinate(x, y);

            // Assert
            Assert.IsTrue(isValid);
        }

        // Add more tests to cover other methods and scenarios

        // Example of using TestCase attribute to test multiple inputs
        [TestCase(4, 2)]
        [TestCase(2, 4)]
        [TestCase(-1, 2)]
        [TestCase(2, -1)]
        public void IsValidCoordinate_InvalidCoordinates_ReturnsFalse(int x, int y)
        {
            // Act
            bool isValid = tileMap.IsValidCoordinate(x, y);

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}
