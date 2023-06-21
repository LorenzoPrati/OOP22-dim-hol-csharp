using System;
using System.Collections.Generic;
using Entity;
using Components;

namespace Levels
{
    
    /// <summary>
    /// The RoomStrategy interface is used to define the behavior of each different game room.
    /// Implementations of this interface provide methods to generate entities for the game room, such as enemies and the player
    /// and position them within the room.
    /// </summary>

    public interface IRoomStrategy
    {
        /// <summary>
        /// Generate entities for the game room.
        /// This method should be implemented to create the enemies, the player,
        /// and position them into the room according to the specific strategy of the room.
        /// </summary>
        List<IEntity> Generate(IEntity? entity, HashSet<Tuple<int, int>> availableTiles, List<IEntity> entities);
    }
}