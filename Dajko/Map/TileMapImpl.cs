using System.Collections.Generic;

namespace Map
{
    /// Represents a two-dimensional grid of tiles in a game map.
    public sealed class TileMapImpl : ITileMap
    {
        private readonly ITile[,] tilemap;
        private readonly int width;
        private readonly int height;
        private readonly int tileWidth;
        private readonly int tileHeight;
        private readonly List<ITile[,]> layers;

        /// Creates a new TileMap with the given layers, width, height, tileWidth, and tileHeight.
        public TileMapImpl(List<ITile[,]> layers, int width, int height, int tileWidth, int tileHeight)
        {
            this.layers = new List<ITile[,]>(layers);
            this.width = width;
            this.height = height;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tilemap = layers[0];
        }

        /// Gets the Tile at the given coordinates.
        public ITile GetTile(int x, int y)
        {
            return tilemap[x, y];
        }

        /// Gets the width of the map in tiles.
        public int Width => width;

        /// Gets the height of the map in tiles.
        public int Height => height;

        /// Gets the width of each tile in pixels.
        public int TileWidth => tileWidth;

        /// Gets the height of each tile in pixels.
        public int TileHeight => tileHeight;

        /// Gets the list of map layers.
        /// Uses the 'IReadOnlyList<T>' interface to expose the layers as a read-only list.
        /// 'AsReadOnly()' called on layers list is used to create an immutable read-only list.
        public List<ITile[,]> GetLayers()
        {
            return new List<ITile[,]>(layers);
        }

        /// Checks if the given coordinates are valid within the map.
        public bool IsValidCoordinate(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
        
        /// Gets the height of each tile in pixels.
        int ITileMap.GetTileWidth()
        {
            return tileWidth;
        }

        /// Gets the height of each tile in pixels.
        int ITileMap.GetTileHeight()
        {
            return tileHeight;
        }
        
        /// Gets the width.
        int ITileMap.GetWidth()
        {
            return width;
        }

        /// Gets the height.
        int ITileMap.GetHeight()
        {
            return height;
        }
    }
}
