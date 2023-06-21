using System.Collections.Generic;
using System.IO;

namespace Map
{
    /// <summary>
    /// Represents a contract for classes that can load and provide information about a tile map.
    /// </summary>
    public interface IMapLoader
    {
        /// <summary>
        /// Retrieves the tile layers of the map.
        /// </summary>
        List<ITile[,]> GetMapTileLayers();

        /// <summary>
        /// Loads a normal room tile map.
        /// </summary>
        ITileMap LoadNormalRoom();

        /// <summary>
        /// Loads a shop room tile map.
        /// </summary>
        ITileMap LoadShopRoom();

        /// <summary>
        /// Loads a boss room tile map.
        /// </summary>
        ITileMap LoadBossRoom();

        /// <summary>
        /// Loads a room map from the given input stream.
        /// </summary>
        ITileMap LoadRoomMap(Stream inputStream);

        /// <summary>
        /// Returns the tile map data as a <see cref="TileMapImpl"/> object.
        /// </summary>
        ITileMap GetTileMap();
    }
}