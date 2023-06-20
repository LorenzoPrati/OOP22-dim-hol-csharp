using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class LevelManagerImplTests
    {
        private LevelManagerImpl levelManager;

        [SetUp]
        public void SetUp()
        {
            /// Set up the LevelManagerImpl instance for each test
            levelManager = new LevelManagerImpl(debug: false);
        }

        [Test]
        public void ChangeLevel_ShouldIncrementCurrentLevel()
        {
            /// Arrange
            var entities = new List<Entity>();

            // Act
            levelManager.ChangeLevel(entities);

            /// Assert
            Assert.AreEqual(1, levelManager.CurrentLevel);
        }

        [Test]
        public void GetTileMap_ShouldReturnDefensiveCopyOfTileMap()
        {
            /// Act
            var tileMap = levelManager.GetTileMap();

            /// Modify the tileMap (to check if it's a defensive copy)
            tileMap.Width = 10;

            /// Assert
            Assert.AreNotEqual(tileMap.Width, levelManager.GetTileMap().Width);
        }
    }
}