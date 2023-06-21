using Factories;
using Map;
using Entity;
using Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Levels
{
    /// <summary>
    /// The strategy to generate a normal room in the game.
    /// </summary>
    public class NormalRoomStrategy : IRoomStrategy
    {
         private const int EntityWidth = 1;
         private const int EntityHeight = 1;
         private const int NumInteractive = 1;

         /// <summary>
         /// Constructs a NormalRoomStrategy.
         /// </summary>
         public NormalRoomStrategy(GenericFactory genericFactory, EnemyFactory enemyFactory, ItemFactory itemFactory,
                                   InteractableObjectFactory interactableObjectFactory, Random randomGenerator)
             // : base(genericFactory, enemyFactory, itemFactory, interactableObjectFactory, randomGenerator)
         {
         }

         /// <summary>
         /// Generates entities for the normal room.
         /// </summary>
         public List<IEntity> Generate(IEntity? entity, HashSet<Tuple<int, int>> availableTiles,
                                                    List<IEntity> entities)
         {
             List<IEntity> newListOfEntities = new List<IEntity>();
//
//             // Place the player:
//             GeneratePlayer(availableTiles, entities, newListOfEntities, EntityWidth, EntityHeight);
//
//             // Place the enemies:
//             GenerateEnemies(availableTiles, newListOfEntities);
//
//             // Place the items:
//             GenerateItems(availableTiles, newListOfEntities);
//
//             // Place gate:
//             GenerateGate(NumInteractive, availableTiles, newListOfEntities);
//
             return newListOfEntities;
         }
     }
}
