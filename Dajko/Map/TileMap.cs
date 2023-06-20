using System.Collections.Generic;

namespace Levels.Map
{
    /// Represents a two-dimensional grid of tiles in a game map.
    public sealed class TileMapImpl : ITileMap
    {
        private readonly Tile[,] tilemap;
        private readonly int width;
        private readonly int height;
        private readonly int tileWidth;
        private readonly int tileHeight;
        private readonly List<Tile[,]> layers;

        /// Creates a new TileMap with the given layers, width, height, tileWidth, and tileHeight.
        public TileMapImpl(List<Tile[,]> layers, int width, int height, int tileWidth, int tileHeight)
        {
            this.layers = new List<Tile[,]>(layers);
            this.width = width;
            this.height = height;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tilemap = layers[0];
        }

        /// Gets the Tile at the given coordinates.
        public Tile GetTile(int x, int y)
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
        /// 'AsReadOnly()' called on layers list, is used to create an immutable read-only list. 
        public IReadOnlyList<Tile[,]> Layers => layers.AsReadOnly();    

        /// Checks if the given coordinates are valid within the map.
        public bool IsValidCoordinate(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
    }
}