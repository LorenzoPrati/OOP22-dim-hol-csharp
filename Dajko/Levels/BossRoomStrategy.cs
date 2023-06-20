namespace Dajko
{
    /// BossRoomStartegy is responsable for generating entities for a boss room in the game.
    /// It generates the player, boss and enemy waves for the room.

    public class BossRoomStartegy : AbstractRoomStartegy
    {
        private const int PLAYER_ENTITY_WIDTH = 1;
        private const int PLAYER_ENTITY_HEIGHT = 1;
        private const int MINIONS_ENTITY_WIDTH = 1;
        private const int MINIONS_ENTITY_HEIGHT = 1;
        private const int BOSS_ENTITY_WIDTH = 4;
        private const int BOSS_ENTITY_HEIGHT = 3;
        private readonly BossFactory bossFactory;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public BossRoomStartegy(GenericFactory genericFactory, ItemFactory itemFactory,
            EnemyFactory enemyFactory, InteractableObjectFactory interactableObjectFactory,
            Random randomGenerator, BossFactory bossFactory)
            : base(genericFactory, enemyFactory, itemFactory, interactableObjectFactory, randomGenerator)
        {
            this.bossFactory = bossFactory;
        }

        /// Generate entities for a boss room:
        public List<Entity> Generate(Optional<Entity> entities, HashSet<Tuple<int, int>> availableTiles,
            List<Entity> entities)
        {
            var newListOfEntities = new List<Entity>;
            GeneratePlayer(availableTiles, entities, newListOfEntities, PLAYER_ENTITY_WIDTH, PLAYER_ENTITY_HEIGHT);
            GenerateAndPlaceBoss(availableTiles, newListOfEntities, BOSS_ENTITY_WIDTH, BOSS_ENTITY_HEIGHT);
            GenerateEnemies(availableTiles, newListOfEntities);
            GenerateAndPlaceMinions(availableTiles, newListOfEntities, MINIONS_ENTITY_WIDTH, MINIONS_ENTITY_HEIGHT);
            return newListOfEntities;
        }

        /// Generates and places minions entities in the room.
        private void GenerateAndPlaceMinions(HashSet<Tuple<int, int>> availableTiles, List<Entity> entities,
            int minionsEntityWidth, int minionsEntityHeight)
        {
            Entity minions = CreateMinions(availableTiles);
            PlaceEntityAtRandomPosition(minions, availableTiles, minionsEntityWidth, minionsEntityHeight);
            entities.Add(minions);
        }

        /// Creates a minion entity and assigns it a random position from the set of available tiles.
        private Entity CreateMinions(HashSet<Tuple<int, int>> availableTiles)
        {
            var randomCoordinates = GetRandomTile(availableTiles);
            double x = randomCoordinates.Item1;
            double y = randomCoordinates.Item2;
            return bossFactory.CreateMinion(x, y);
        }

        // Generates and places the boss entity in a random position.
        private void GenerateAndPlaceBoss(HashSet<Tuple<int, int>> availableTiles, List<Entity> entities,
            int bossEntityWidth, int bossEntityHeight)
        {
            int numBosses = CalculateNumEntities(availableTiles, bossEntityWidth, bossEntityHeight);
            Enumerable.Range(0, numBosses).Select(_ => CreateBoss(availableTiles)).ToList().ForEach(boss =>
            {
                PlaceEntityWithDimension(boss, availableTiles, bossEntityWidth, bossEntityHeight, new Random());
                entities.Add(boss);
            });
        }

        // Places the entity at a random position with specified dimensions within the set of available tiles.
        private void PlaceEntityWithDimension(Entity entity, HashSet<Tuple<int, int>> availableTiles,
            int entityWidth, int entityHeight, Random randomGenerator)
        {
            var validTiles = FindValidTilesWithDimension(availableTiles, entityWidth, entityHeight);
            if (validTiles.Any())
            {
                var randomTile = validTiles[randomGenerator.Next(validTiles.Count)];
                var positionComponent = (PositionComponent)entity.GetComponent(typeof(PositionComponent));
                var position = new Vector2(randomTile.Item1, randomTile.Item2);
                positionComponent.SetPos(position);
            }
        }

        // Finds valid tiles with the specified dimensions within the set of available tiles.
        private List<Tuple<int, int>> FindValidTilesWithDimension(HashSet<Tuple<int, int>> availableTiles,
            int width, int height)
        {
            var validTiles = new List<Tuple<int, int>>();
            foreach (var tile in availableTiles)
            {
                int tileX = tile.Item1;
                int tileY = tile.Item2;
                bool isValid = true;
                // Check if the dimensions of the entity fit within the current tile and its neighboring tiles
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        var currentTile = new Tuple<int, int>(tileX + i, tileY + j);
                        if (!availableTiles.Contains(currentTile))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (!isValid)
                        break;
                }

                if (isValid)
                    validTiles.Add(tile);
            }

            return validTiles;
        }

        // Retrieves a random tile that can accommodate the boss entity's dimensions.
        private Tuple<int, int> GetRandomTileForBoss(HashSet<Tuple<int, int>> freeTiles)
        {
            var shuffledTiles = new List<Tuple<int, int>>(freeTiles);
            shuffledTiles.Shuffle();
            return shuffledTiles.FirstOrDefault(tile => CanAccommodateTileForBoss(tile, freeTiles)) ??
                   throw new InvalidOperationException("No free available tiles that can accommodate the boss entity.");
        }
        
        // Checks if a given tile can accommodate a Boss entity.
        private bool CanAccommodateTileForBoss(Tuple<int, int> tile, HashSet<Tuple<int, int>> availableTiles) 
        {
            return CanAccommodate(tile, availableTiles, BOSS_ENTITY_WIDTH, BOSS_ENTITY_HEIGHT, "Boss");
        }
        
        // Retrieves the list of tiles occupied by the boss entity, based on its starting position.
        private List<Tuple<int, int>> GetBossTiles(Tuple<int, int> startPos) 
        {
            var bossTiles = new List<Tuple<int, int>>();
            int startX = startPos.Item1;
            int startY = startPos.Item2;

            for (int x = startX; x < startX + BOSS_ENTITY_WIDTH; x++)
            {
                for (int y = startY; y < startY + BOSS_ENTITY_HEIGHT; y++)
                {
                    bossTiles.Add(new Tuple<int, int>(x, y));
                }
            }
            return bossTiles;
        }
        
        // Calculates the center position of a group of tiles.
        private Vector2 GetTileCenterPosition(List<Tuple<int, int>> tiles) 
        {
            double totalX = 0;
            double totalY = 0;

            foreach (var tile in tiles)
            {
                totalX += tile.Item1;
                totalY += tile.Item2;
            }

            double centerX = totalX / tiles.Count + 0.5;
            double centerY = totalY / tiles.Count + 0.5;

            return new Vector2(centerX, centerY);
        }
        
        // Creates a boss entity with a random position, considering its tile dimensions.
        private Entity CreateBoss(HashSet<Tuple<int, int>> freeTiles)
        {
            var randomTile = GetRandomTileForBoss(freeTiles);
            var bossTiles = GetBossTiles(randomTile);
            var bossPosition = GetTileCenterPosition(bossTiles);

            return bossFactory.CreateBoss(bossPosition.X, bossPosition.Y);
        }
    }
}