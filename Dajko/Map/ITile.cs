namespace Map
{
    /// <summary>
    /// Represents a tile in the game map.
    /// Tiles are used to build the game world and provide information
    /// about their properties such as walkability and tile set ID.
    /// </summary>
    public interface ITile
    {
        /// <summary>
        /// Returns whether this Tile is walkable.
        /// </summary>
        bool IsWalkableTile();

        /// <summary>
        /// Returns the tile set ID.
        /// </summary>
        int GetTileSetId();
    }
}