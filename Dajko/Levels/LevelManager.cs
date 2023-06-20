using System;
using System.Collections.Generic;
using System.Linq;

namespace Levels
{
    /// The LevelGenerator class generates a new level for the game, including the placement of the player and enemies.
    public class LevelManagerImpl : ILevelManager
    {
        private const int DEFAULT_LENGTH_TO_BOSS_ROOM = 15;
        private const int DEBUG_LENGTH_TO_BOSS_ROOM = 4;
        private const int DEFAULT_SHOPS_PER_CYCLE = 3;
        private readonly IMapLoader mapLoader;
        private readonly INormalRoomStrategy normalRoomStrategy;
        private readonly IShopRoomStrategy shopRoomStrategy;
        private readonly IBossRoomStrategy bossRoomStrategy;
        private readonly int maxRoomNumber;
        private TileMap tileMap;
        private int currentLevel;

        /// Constructs a LevelManagerImpl object.
        public LevelManagerImpl(bool debug)
        {
            this.maxRoomNumber = debug ? DEBUG_LENGTH_TO_BOSS_ROOM : DEFAULT_LENGTH_TO_BOSS_ROOM;
            this.mapLoader = new MapLoaderImpl();
            var genericFactory = new GenericFactory();
            var enemyFactory = new EnemyFactory();
            var itemFactory = new ItemFactory();
            var bossFactory = new BossFactory();
            var interactableObjectFactory = new InteractableObjectFactory();
            var randomGenerator = new Random();
            this.tileMap = mapLoader.LoadNormalRoom();
            normalRoomStrategy = new NormalRoomStrategy(genericFactory, enemyFactory, itemFactory,
                interactableObjectFactory, randomGenerator);
            shopRoomStrategy = new ShopRoomStrategy(genericFactory, enemyFactory, itemFactory,
                interactableObjectFactory, randomGenerator);
            bossRoomStrategy = new BossRoomStrategy(genericFactory, itemFactory, enemyFactory,
                interactableObjectFactory, randomGenerator, bossFactory);
            this.currentLevel = 0;
        }

        /// Changes the current level by generating a new level with the placement of the player and enemies.
        public List<Entity> ChangeLevel(List<Entity> entities)
        {
            currentLevel++;
            var player = SavePlayer(entities);
            return GenerateLevel(player, entities);
        }

        /// Determines the type of room to generate based on the current level.
        private IRoomStrategy DetermineRoomType()
        {
            if (currentLevel == maxRoomNumber)
            {
                tileMap = mapLoader.LoadBossRoom();
                return bossRoomStrategy;
            }
            if (currentLevel % DEFAULT_SHOPS_PER_CYCLE == 0)
            {
                tileMap = mapLoader.LoadShopRoom();
                return shopRoomStrategy;
            }
            tileMap = mapLoader.LoadNormalRoom();
            return normalRoomStrategy;
        }

        /// Retrieves the tile map for the current level.
        public TileMap GetTileMap()
        {
            // Create a defensive copy of the tileMap
            return new TileMapImpl(
                tileMap.Layers,
                tileMap.Width,
                tileMap.Height,
                tileMap.TileWidth,
                tileMap.TileHeight);
        }

        /// Retrieves the set of available tiles in the map.
        private HashSet<(int, int)> GetAvailableTiles()
        {
            return Enumerable.Range(0, tileMap.Height)
                .SelectMany(row =>
                    Enumerable.Range(0, tileMap.Width)
                        .Where(column => tileMap.GetTile(column, row).IsWalkableTile())
                        .Select(column => (row, column))
                )
                .ToHashSet();
        }

        /// Retrieves the player entity from the game world.
        private Entity? SavePlayer(List<Entity> entities)
        {
            return entities.FirstOrDefault(entity => entity.HasComponent<PlayerComponent>());
        }

        /// Generates the level by adding entities (player, enemies) to the world.
        private List<Entity> GenerateLevel(Entity? player, List<Entity> entities)
        {
            return DetermineRoomType().Generate(player, GetFreeTiles(), entities);
        }
    }
}