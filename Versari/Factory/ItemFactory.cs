using Entity;
using MyComponents;
using Components;

namespace Factory
{
    public class ItemFactory
    {
        private static int IncreaseCurrentHealth = 1;
        private static int IncreaseCurrentCoins = 1;
        private readonly Func<IEntity, List<Type>, Boolean> increaseCurrentHealth = (e, c) => 
        {
            var hasComponentNeeded = c.Any(comp => e.HasComponent(comp));
            if(hasComponentNeeded)
            {
                var healthComp = (HealthComponent)e.GetComponent(typeof(HealthComponent));
                if(healthComp.CurrentHealth < healthComp.MaxHealth)
                {
                    healthComp.CurrentHealth += IncreaseCurrentHealth;
                    return true;
                }
                return false;
            }
            return false;
        };

        private readonly Func<IEntity, List<Type>, Boolean> increaseCurrentCoinsAmount = (e, c) => 
        {
            var hasComponentNeeded = c.Any(comp => e.HasComponent(comp));
            if(hasComponentNeeded)
            {
                var coinComp = (CoinPocketComponent)e.GetComponent(typeof(CoinPocketComponent));
                coinComp.Coins = coinComp.Coins + IncreaseCurrentCoins;
                return true;
            }
            return false;
        };

        public IEntity CreateHeart(double x, double y)
        {
            return new EntityBuilder()
                .Add(new PositionComponent(new Vector2D(x, y), 0)) 
                .Add(new ItemComponent(increaseCurrentHealth))
                .Build(); 

        }

        public IEntity CreateCoin(double x, double y)
        {
            return new EntityBuilder()
                .Add(new PositionComponent(new Vector2D(x, y), 0))
                .Add(new ItemComponent(increaseCurrentCoinsAmount))
                .Build();
        }
    }
}