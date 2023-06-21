using NUnit.Framework;
using Map;

namespace MapTest
{
    [TestFixture]
    public class TileImplTests
    {
        [Test]
        public void IsWalkableTile_WhenWalkable_ReturnsTrue()
        {
            // Arrange
            int tileSetId = 1;
            bool walkable = true;
            TileImpl tile = new TileImpl(tileSetId, walkable);

            // Act
            bool isWalkable = tile.IsWalkableTile();

            // Assert
            Assert.IsTrue(isWalkable, "The tile should be walkable.");
        }

        [Test]
        public void IsWalkableTile_WhenNotWalkable_ReturnsFalse()
        {
            // Arrange
            int tileSetId = 1;
            bool walkable = false;
            TileImpl tile = new TileImpl(tileSetId, walkable);

            // Act
            bool isWalkable = tile.IsWalkableTile();

            // Assert
            Assert.IsFalse(isWalkable, "The tile should not be walkable.");
        }

        [Test]
        public void GetTileSetId_ReturnsCorrectId()
        {
            // Arrange
            int tileSetId = 1;
            bool walkable = true;
            TileImpl tile = new TileImpl(tileSetId, walkable);

            // Act
            int returnedTileSetId = tile.GetTileSetId();

            // Assert
            Assert.AreEqual(tileSetId, returnedTileSetId, "The returned tile set ID should match the expected value.");
        }
    }
}