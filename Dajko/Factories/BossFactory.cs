using System.Numerics;

using Entity;
using Components;

namespace Factories
{
    /// <summary>
    /// The BossFactory class is responsible for creating Boss entities in the game.
    /// </summary>
    public class BossFactory
    {
        private const double BossWidth = 4;
        private const double BossHeight = 3;
        private const double BossSpeed = 1.5;
        private const int BossHealth = 20;
        private const double MinionsSpeed = 1;
        private const double MinionsWidth = 0.5;
        private const double MinionsHeight = 0.5;
        private const int MinionsHealth = 1;

        /// <summary>
        /// Create a Boss Entity.
        /// </summary>
        public IEntity CreateBoss(double x, double y)
        {
            return new EntityBuilder()
                .Add(new BossComponent())
                .Add(new PositionComponent(new Vector2D(x, y), 0))
                .Add(new MovementComponent(new Vector2D(0, 1), BossSpeed, false))
                .Build();
        }

        /// <summary>
        /// Create a minion Entity.
        /// </summary>
        public IEntity CreateMinion(double x, double y)
        {
            return new EntityBuilder()
                .Add(new PositionComponent(new Vector2D(x, y), 0))
                .Add(new MovementComponent(new Vector2D(0, 1), MinionsSpeed, false))
                .Build();
        }
    }
}
