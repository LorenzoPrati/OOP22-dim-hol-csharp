// using NUnit.Framework;
// using System.Collections.Generic;
// using Levels;
// using Map;
// using Entity;
//
// namespace LevelsTest
// {
//     [TestFixture]
//     public class LevelManagerImplTests
//     {
//         private LevelManagerImpl levelManager;
//
//         [SetUp]
//         public void SetUp()
//         {
//             /// Set up the LevelManagerImpl instance for each test
//             levelManager = new LevelManagerImpl(debug: false);
//         }
//
//         [Test]
//         public void ChangeLevel_ShouldIncrementCurrentLevel()
//         {
//             /// Arrange
//             var entities = new List<IEntity>();
//
//             // Act
//             levelManager.ChangeLevel(entities);
//
//             /// Assert
//             Assert.AreEqual(1, levelManager);
//         }
//     }
// }