using Entity;
using Components;
using Factories;
using Map;
using System.Collections.Generic;


namespace Levels
{
    /// Generates a new level for the game, including the placement of the player and enemies.
    public interface ILevelManager
    {
        /// Changes the current level in the game and returns the updated list of entities.
        List<IEntity> ChangeLevel(List<IEntity> entities);

        /// Retrieves the tile map for the current level.
        ITileMap GetTileMap();
    }
}