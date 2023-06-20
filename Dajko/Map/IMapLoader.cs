﻿using System.Collections.Generic;
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
        List<Tile[,]> GetMapTileLayers();

        /// <summary>
        /// Loads a normal room tile map.
        /// </summary>
        TileMap LoadNormalRoom();

        /// <summary>
        /// Loads a shop room tile map.
        /// </summary>
        TileMap LoadShopRoom();

        /// <summary>
        /// Loads a boss room tile map.
        /// </summary>
        TileMap LoadBossRoom();

        /// <summary>
        /// Loads a room map from the given input stream.
        /// </summary>
        TileMap LoadRoomMap(Stream inputStream);

        /// <summary>
        /// Returns the tile map data as a <see cref="TileMapImpl"/> object.
        /// </summary>
        TileMap GetTileMap();
    }
}