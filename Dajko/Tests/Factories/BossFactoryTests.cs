using NUnit.Framework;

namespace Tests.Factories
{
    [TestFixture]
    public class BossFactoryTests
    {
        [Test]
        public void CreateBoss_ReturnsValidBossEntity()
        {
            /// Arrange
            BossFactory bossFactory = new BossFactory();
            double x = 10;
            double y = 20;
            /// Act
            Entity bossEntity = bossFactory.CreateBoss(x, y);
            /// Assert
            Assert.IsNotNull(bossEntity);
            /// Add more assertions to validate the properties or components of the bossEntity
        }
        
        [Test]
        public void CreateMinion_ReturnsValidMinionEntity()
        {
            /// Arrange
            BossFactory bossFactory = new BossFactory();
            double x = 10;
            double y = 20;
            /// Act
            Entity minionEntity = bossFactory.CreateMinion(x, y);
            /// Assert
            Assert.IsNotNull(minionEntity);
            /// Add more assertions to validate the properties or components of the minionEntity
        }
    }
}