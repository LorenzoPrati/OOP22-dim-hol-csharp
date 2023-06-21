using System.Collections.Generic;

namespace Map
{
    /// The ITileMap interface represents a map made up of tiles.
    public interface ITileMap
    {
        /// Returns the tile at the specified coordinates.
        ITile GetTile(int x, int y);

        /// Returns the width of the tile map.
        int GetWidth();

        /// Returns the height of the tile map.
        int GetHeight();

        /// Returns the width of a single tile in the tile map.
        int GetTileWidth();

        /// Returns the height of a single tile in the tile map.
        int GetTileHeight();

        /// Returns the layers of the tile map.
        List<ITile[,]> GetLayers();

        /// Checks if the given coordinates are valid within the map.
        bool IsValidCoordinate(int x, int y);
    }
}