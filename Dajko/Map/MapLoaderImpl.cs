using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Map
{
    /// <summary>
    /// The class is responsible for parsing an XML file and loading a map from it.
    /// </summary>
    public sealed class MapLoaderImpl : IMapLoader
    {
        private int width;
        private int height;
        private int tileWidth;
        private int tileHeight;
        private List<ITile[,]> mapTileLayers;

        /// <summary>
        /// Constructor for the map loader implementation.
        /// </summary>
        public MapLoaderImpl()
        {
            mapTileLayers = new List<ITile[,]>();
        }
        
        /// <summary>
        /// Loads a map from an XML file.
        /// </summary>
        public void LoadMap(Stream inputStream)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(inputStream);
                doc.DocumentElement.Normalize();

                var rootElement = doc.DocumentElement;
                tileWidth = int.Parse(rootElement.GetAttribute("tilewidth"));
                tileHeight = int.Parse(rootElement.GetAttribute("tileheight"));

                var layerNodeList = doc.GetElementsByTagName("layer");
                width = int.Parse(layerNodeList.Item(0).Attributes.GetNamedItem("width").Value);
                height = int.Parse(layerNodeList.Item(0).Attributes.GetNamedItem("height").Value);

                mapTileLayers = new List<ITile[,]>();
                for (int i = 0; i < layerNodeList.Count; i++)
                {
                    mapTileLayers.Add(CreateTileMatrix(layerNodeList.Item(i)));
                }
            }
            catch (XmlException exception)
            {
                throw new MapLoadingException("Failed to load map, invalid XML file.", exception);
            }
        }

        /// <summary>
        /// Creates a tile matrix from the given layer node.
        /// </summary>
        private ITile[,] CreateTileMatrix(XmlNode layerNode)
        {
            var layerElement = (XmlElement)layerNode;
            var propertyNodes = layerElement.GetElementsByTagName("property");
            var dataElement = (XmlElement)layerElement.GetElementsByTagName("data").Item(0);

            var lines = dataElement.FirstChild.InnerText.Split(new[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var nonEmptyLines = new List<string>(lines);
            nonEmptyLines.RemoveAll(string.IsNullOrEmpty);

            var matrix = new ITile[width, height];
            var tileMapIdIndex = 0;
            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    for (int propertyIndex = 0; propertyIndex < propertyNodes.Count; propertyIndex++)
                    {
                        var property = (XmlElement)propertyNodes.Item(propertyIndex);
                        var tileMapId = int.Parse(nonEmptyLines[tileMapIdIndex]);
                        if (tileMapId == int.Parse(property.GetAttribute("tileMapIdInt"))
                            && property.HasAttribute("walkableBool") && property.HasAttribute("tileSetIdInt"))
                        {
                            var walkable = bool.Parse(property.GetAttribute("walkableBool"));
                            var tileSetId = int.Parse(property.GetAttribute("tileSetIdInt"));
                            matrix[row, col] = new TileImpl(tileSetId, walkable);
                        }
                    }
                    tileMapIdIndex++;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Gets the map tile layers.
        /// </summary>
        public List<ITile[,]> GetMapTileLayers()
        {
            return new List<ITile[,]>(mapTileLayers);
        }

        /// <summary>
        /// Loads the normal room map.
        /// </summary>
        public ITileMap LoadNormalRoom()
        {
            using (var inputStream = GetType().Assembly.GetManifestResourceStream("Dajko/Config/Classic-room.xml"))
            {
                return LoadRoomMap(inputStream);
            }
        }

        /// <summary>
        /// Loads the shop room map.
        /// </summary>
        public ITileMap LoadShopRoom()
        {
            using (var inputStream = GetType().Assembly.GetManifestResourceStream("Dajko/Config/Shop-room.xml"))
            {
                return LoadRoomMap(inputStream);
            }
        }

        /// <summary>
        /// Loads the boss room map.
        /// </summary>
        public ITileMap LoadBossRoom()
        {
            using (var inputStream = GetType().Assembly.GetManifestResourceStream("Dajko/Config/Boss-room.xml"))
            {
                return LoadRoomMap(inputStream);
            }
        }

        /// <summary>
        /// Loads a room map from the provided input stream.
        /// </summary>
        public ITileMap LoadRoomMap(Stream inputStream)
        {
            LoadMap(inputStream);
            return GetTileMap();
        }

        /// <summary>
        /// Gets the tile map.
        /// </summary>
        public ITileMap GetTileMap()
        {
            return new TileMapImpl(mapTileLayers, width, height, tileWidth, tileHeight);
        }
    }
}
