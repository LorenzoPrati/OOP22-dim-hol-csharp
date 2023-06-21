using Factories;
using Map;
using Entity;
using Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Levels
{
    public class ShopRoomStrategy : IRoomStrategy
    {
         private const int NUM_ITEMS = 10;
         private const int NUM_POWER_UP = 2;
         private const int NUM_SHOP_KEEPER = 1;
         private const int ENTITY_WIDTH = 1;
         private const int ENTITY_HEIGHT = 1;
         private const int NUM_INTERACTIVE = 1;
         private GenericFactory genericFactory;
         private InteractableObjectFactory interactableObjectFactory;

         public ShopRoomStrategy(GenericFactory genericFactory, EnemyFactory enemyFactory, ItemFactory itemFactory,
             InteractableObjectFactory interactableObjectFactory, Random random)
             // : base(genericFactory, enemyFactory, itemFactory, interactableObjectFactory, random)
         {
             this.interactableObjectFactory = new InteractableObjectFactory();
             this.genericFactory = new GenericFactory();
         }

         public List<IEntity> Generate(IEntity? entity, HashSet<Tuple<int, int>> availableTiles, List<IEntity> entities)
         {
             List<IEntity> newListOfEntities = new List<IEntity>();
//
//             GeneratePlayer(availableTiles, entities, newListOfEntities, ENTITY_WIDTH, ENTITY_HEIGHT);
//
//             GenerateShopKeeper(NUM_SHOP_KEEPER, availableTiles, newListOfEntities);
//
//             GenerateCoins(NUM_ITEMS, availableTiles, newListOfEntities);
//
//             GenerateHearts(NUM_ITEMS, availableTiles, newListOfEntities);
//
//             GenerateHeartPowerUp(NUM_POWER_UP, availableTiles, newListOfEntities);
//
//             GenerateVelocityPowerUp(NUM_POWER_UP, availableTiles, newListOfEntities);
//
//             GenerateGate(NUM_INTERACTIVE, availableTiles, newListOfEntities);
//
//             return newListOfEntities;
//         }
//
//         private void GenerateHeartPowerUp(int numPowerUp, HashSet<Tuple<int, int>> availableTiles, List<IEntity> entities)
//         {
//             List<IEntity> heartPowerUp = Enumerable.Range(1, numPowerUp)
//                 .Select(i => CreateHeartPowerUp(availableTiles))
//                 .Select(heartPower =>
//                 {
//                     PlaceEntityAtRandomPosition(heartPower, availableTiles, ENTITY_WIDTH, ENTITY_HEIGHT);
//                     return heartPower;
//                 })
//                 .ToList();
//
//             entities.AddRange(heartPowerUp);
//         }
//
//         private IEntity CreateHeartPowerUp(HashSet<Tuple<int, int>> availableTiles)
//         {
//             Tuple<int, int> randomCoordinates = GetRandomTile(availableTiles);
//             double x = randomCoordinates.Item1;
//             double y = randomCoordinates.Item2;
//             return interactableObjectFactory.CreateShopHeart(x, y);
//         }
//
//         private void GenerateVelocityPowerUp(int numPowerUp, HashSet<Tuple<int, int>> availableTiles, List<IEntity> entities)
//         {
//             List<IEntity> velocityPowerUp = Enumerable.Range(1, numPowerUp)
//                 .Select(i => CreateVelocityPowerUp(availableTiles))
//                 .Select(velocityPower =>
//                 {
//                     PlaceEntityAtRandomPosition(velocityPower, availableTiles, ENTITY_WIDTH, ENTITY_HEIGHT);
//                     return velocityPower;
//                 })
//                 .ToList();
//
//             entities.AddRange(velocityPowerUp);
//         }
//
//         private IEntity CreateVelocityPowerUp(HashSet<Tuple<int, int>> availableTiles)
//         {
//             Tuple<int, int> randomCoordinates = GetRandomTile(availableTiles);
//             double x = randomCoordinates.Item1;
//             double y = randomCoordinates.Item2;
//             return interactableObjectFactory.CreateShopVelocity(x, y);
//         }
//
//         private IEntity CreateShopKeeper(HashSet<Tuple<int, int>> availableTiles)
//         {
//             Tuple<int, int> randomCoordinates = GetRandomTile(availableTiles);
//             double x = randomCoordinates.Item1;
//             double y = randomCoordinates.Item2;
//             return genericFactory.CreateShopkeeper(x, y);
//         }
//
//         private void GenerateShopKeeper(int numShopKeeper, HashSet<Tuple<int, int>> availableTiles, List<IEntity> entities)
//         {
//             List<IEntity> shopKeepers = Enumerable.Range(0, numShopKeeper)
//                 .Select(i => CreateShopKeeper(availableTiles))
//                 .Select(shopkeeper =>
//                 {
//                     PlaceEntityAtRandomPosition(shopkeeper, availableTiles, ENTITY_WIDTH, ENTITY_HEIGHT);
//                     return shopkeeper;
//                 })
//                 .ToList();
//
//             entities.AddRange(shopKeepers);
             return newListOfEntities;
         }
    }
}
