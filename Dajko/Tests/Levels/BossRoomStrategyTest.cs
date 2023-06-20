using NUnit.Framework;

namespace Tests.Levels
{
    [TestFixture]
    public class BossRoomStartegyTests
    {
        [Test]
        public void Generate_ReturnsListOfEntities()
        {
            // Arrange
            BossRoomStartegy strategy = new BossRoomStartegy();
            // Act
            List<Entity> result = strategy.Generate();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

        }
    }
}