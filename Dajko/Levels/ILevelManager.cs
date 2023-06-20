using System.Collections.Generic;

namespace Dimhol.Levels
{
    /// Generates a new level for the game, including the placement of the player and enemies.
    public interface ILevelManager
    {
        /// Changes the current level in the game and returns the updated list of entities.
        List<Entity> ChangeLevel(List<Entity> entities);

        /// Retrieves the tile map for the current level.
        TileMap GetTileMap();
    }
}