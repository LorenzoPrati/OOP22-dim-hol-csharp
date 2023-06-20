using System.Numerics;

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
        /// <param name="x">The x-coordinate of the Boss.</param>
        /// <param name="y">The y-coordinate of the Boss.</param>
        /// <returns>The created Boss entity.</returns>
        public Entity CreateBoss(double x, double y)
        {
            return new EntityBuilder()
                .Add(new BossComponent())
                .Add(new PositionComponent(new Vector2(x, y), 0))
                .Add(new MovementComponent(new Vector2(0, 1), BossSpeed, false))
                .Add(new BodyComponent(new RectBodyShape(BossWidth, BossHeight), true))
                .Add(new HealthComponent(BossHealth))
                .Add(new AnimationComponent(GetAnimationsMap()["boss"], "walk"))
                .Add(new AIComponent(new RoutineFactory().CreateBossRoutine()))
                .Build();
        }

        /// <summary>
        /// Create a minion Entity.
        /// </summary>
        /// <param name="x">The x-coordinate of the Minions.</param>
        /// <param name="y">The y-coordinate of the Minions.</param>
        /// <returns>The created Minion entity.</returns>
        public Entity CreateMinion(double x, double y)
        {
            return new EntityBuilder()
                .Add(new PositionComponent(new Vector2(x, y), 0))
                .Add(new MovementComponent(new Vector2(0, 1), MinionsSpeed, false))
                .Add(new BodyComponent(new RectBodyShape(MinionsWidth, MinionsHeight), true))
                .Add(new HealthComponent(MinionsHealth))
                .Add(new AnimationComponent(GetAnimationsMap()["enemy"], "idle"))
                .Add(new AIComponent(new RoutineFactory().CreateMinionRoutine()))
                .Build();
        }
    }
}
