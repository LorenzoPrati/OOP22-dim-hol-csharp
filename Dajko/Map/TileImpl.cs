using System;

namespace Map
{
    /// <summary>
    /// A Tile represents a single tile in a game map, with information about whether it is collidable.
    /// </summary>
    public class TileImpl : ITile
    {
        private readonly bool walkable;
        private readonly int tileSetId;

        /// <summary>
        /// Constructs a new Tile with the specified collidability.
        /// </summary>
        public TileImpl(int tileSetId, bool walkable)
        {
            this.tileSetId = tileSetId;
            this.walkable = walkable;
        }

        /// <summary>
        /// Returns whether this Tile is collidable.
        /// </summary>
        public bool IsWalkableTile()
        {
            return walkable;
        }

        /// <summary>
        /// Returns the tile set ID.
        /// </summary>
        public int GetTileSetId()
        {
            return tileSetId;
        }
    }
}