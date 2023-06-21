using NUnit.Framework;
using System.IO;
using System.Reflection;
using Map;

namespace MapTest
{
    [TestFixture]
    public class MapLoaderImplTests
    {
        private MapLoaderImpl mapLoader = new MapLoaderImpl();

        [SetUp]
        public void SetUp()
        {
            mapLoader = new MapLoaderImpl();
        }

        [Test]
        public void LoadMap_ValidXml_ShouldLoadMap()
        {
            // Arrange
            var xml = @"<?xml version='1.0' encoding='UTF-8'?>
                        <map tilewidth='32' tileheight='32'>
                            <layer width='3' height='3'>
                                <data>
                                    1, 2, 3,
                                    4, 5, 6,
                                    7, 8, 9
                                </data>
                            </layer>
                        </map>";
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)))
            {
                // Act
                mapLoader.LoadMap(stream);
            }

            // Assert
            var mapTileLayers = mapLoader.GetMapTileLayers();
            Assert.AreEqual(1, mapTileLayers.Count);
            Assert.AreEqual(3, mapLoader.GetTileMap().GetWidth());
            Assert.AreEqual(3, mapLoader.GetTileMap().GetHeight());
        }
    }
}
